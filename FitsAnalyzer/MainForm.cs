using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using nom.tam.fits;

namespace FitsAnalyzer
{
    enum ControlsState { Off = 0, SingleOn = 1, MultipleOn = 2 }

    struct UnitMap
    {
        public int FileIndex;
        public int HDUIndex;

        public UnitMap(int fileIndex, int hduIndex)
        {
            FileIndex = fileIndex;
            HDUIndex = hduIndex;
        }
    }

    public partial class MainForm : Form
    {
        private FitsWrapper fits = new FitsWrapper();
        private string[] files;
        private List<UnitMap> unitsList;
        private int crtUnitIndex = 0;
        private int hduNumber = 0;
        private List<ToolStripItem> singleSwitchableControls;
        private List<ToolStripItem> multipleSwitchableControls;

        public MainForm()
        {
            InitializeComponent();
            singleSwitchableControls = new List<ToolStripItem>
            {
                saveToolStripMenuItem,
                viewToolStripMenuItem, zoomInToolStripMenuItem, zoomOutToolStripMenuItem, fitToolStripMenuItem,
                toolStripSaveButton,
                toolStripZoomInButton, toolStripZoomOutButton, toolStripFitButton
            };
            multipleSwitchableControls = new List<ToolStripItem>
            {
                previousToolStripMenuItem, nextToolStripMenuItem,
                toolStripPreviousButton, toolStripNumberComboBox, toolStripNextButton
            };
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Создание рабочей директории

                string crtDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    if (!Directory.Exists("fits"))
                    {
                        // Try to create the directory.
                        DirectoryInfo di = Directory.CreateDirectory("fits");
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                        $"Не удалось создать рабочую директорию \".\fits\":\n" +
                        $"{excp.Message}",
                        "Ошибка создания рабочей директории",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Вызов диалогового окна открытия файла

                openFileDialog.Title = "Открыть FITS-файл";
                // Возможные варианты начальной папки в диалоговом окне
                // openFileDialog.InitialDirectory = "c:\\"; // Диск C:
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Рабочий стол
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Мои Документы
                openFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"; // Мой компьютер
                openFileDialog.Filter = "FITS-файлы (*.fits)|*.fits|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = true;

                var openResult = openFileDialog.ShowDialog();
                if (openResult != DialogResult.OK)
                {
                    if (openResult == DialogResult.Cancel) return;
                    MessageBox.Show(
                        $"Неправильно выбран(ы) файл(ы) \"{files}\"",
                        "Ошибка открытия файла(ов)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                files = new string[openFileDialog.FileNames.Length];
                unitsList = new List<UnitMap> { };
                hduNumber = 0;
                int i = 0;

                foreach (string file in openFileDialog.FileNames)
                {
                    string workFile = crtDir + "\\fits\\" + Path.GetFileName(file);
                    try
                    {
                        if (File.Exists(workFile)) File.Delete(workFile);
                        File.Copy(file, workFile, true);
                        using (Process funpackProcess = new Process())
                        {
                            funpackProcess.StartInfo.UseShellExecute = true;
                            funpackProcess.StartInfo.FileName = ".\\Funpack.exe";
                            funpackProcess.StartInfo.Arguments = $"-F .\\fits\\{Path.GetFileName(workFile)}";
                            funpackProcess.StartInfo.CreateNoWindow = true;
                            funpackProcess.Start();
                            funpackProcess.WaitForExit();
                        }
                    }
                    catch (Exception excp)
                    {
                        MessageBox.Show(
                            $"Не удалось копировать рабочий файл \"{workFile}\" :\n" +
                            $"{excp.Message}",
                            "Ошибка создания рабочей копии файла",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    // Определение количества заголовков в файле
                    int fileHDUNumber = 0;
                    try
                    {
                        fits.OpenFile(workFile, out fileHDUNumber);
                    }
                    catch (Exception excp)
                    {
                        MessageBox.Show(
                            $"Не удалось прочитать заголовки файла \"{workFile}\":\n" +
                            $"{excp.Message}",
                            "Ошибка открытия файла",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    hduNumber += fileHDUNumber;
                    for (int j = 0; j < fileHDUNumber; j++)
                        unitsList.Add(new UnitMap(i, j));
                    files[i] = workFile;
                    i++;
                } //foreach file

                // Окрытие первого заголовка

                crtUnitIndex = 0;
                toolStripNumberComboBox.Items.Clear();
                for (int j = 1; j <= hduNumber; j++)
                    toolStripNumberComboBox.Items.Add($"{j} / {hduNumber}");
                toolStripNumberComboBox.SelectedIndex = crtUnitIndex;
            }
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripNumberComboBox.SelectedIndex > 0)
                toolStripNumberComboBox.SelectedIndex--;
        }

        private void toolStripNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtUnitIndex = toolStripNumberComboBox.SelectedIndex;
            HDULoad();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripNumberComboBox.SelectedIndex < toolStripNumberComboBox.Items.Count - 1)
                toolStripNumberComboBox.SelectedIndex++;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HDULoad()
        {
            var table = new List<string[]> { };
            var hasImage = false;
            try
            {
                fits.ReadHeader(files[unitsList[crtUnitIndex].FileIndex], unitsList[crtUnitIndex].HDUIndex, out table, out hasImage);
            }
            catch (Exception excp)
            {
                MessageBox.Show(
                    $"Не удалось открыть заголовок №{unitsList[crtUnitIndex].HDUIndex}" +
                    $" файла \"{files[unitsList[crtUnitIndex].FileIndex]}\":\n" +
                    $"{excp.Message}",
                    "Ошибка открытия файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            HeaderUpdate(table);

            // Открытие снимка для первого заголовка,
            // если таковой есть (NAXIS == 2)

            if (hasImage)
            {
                var data = new Array[] { };
                BitPix bitpix;
                try
                {
                    fits.ReadData(unitsList[crtUnitIndex].HDUIndex, out data, out bitpix);
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                        $"Не удалось открыть данные для HDU №{unitsList[crtUnitIndex].HDUIndex}" +
                        $" файла \"{files[unitsList[crtUnitIndex].FileIndex]}\":\n" +
                        $"{excp.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                DataUpdate(data, bitpix);
            }
            else
                dataPictureBox.Image = new Bitmap(250, 250);

            ControlsUpdate();
        }

        private void HeaderUpdate(List<string[]> table)
        {
            hduDataGridView.Rows.Clear();
            foreach (string[] sa in table)
                hduDataGridView.Rows.Add(sa);
        }

        private void DataUpdate(Array[] data, BitPix bitpix)
        {
            if (bitpix == BitPix.Unknown) return;

            int width = data[0].GetLength(0);
            int height = data.GetLength(0);
            Bitmap bm = new Bitmap(width, height);

            var min = Int32.MaxValue;
            var max = Int32.MinValue;

            // Определение значения для прозрачного фона
            Int32 trnValue = 0;
            if (bitpix == BitPix.Bits8) trnValue = byte.MinValue;
            else if (bitpix == BitPix.Bits16) trnValue = Int16.MinValue;
            else if (bitpix == BitPix.Bits32) trnValue = Int32.MinValue;

            // Определение значений для максиммума и
            // минимума амплитуды
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Int32 value = 0;
                    if (bitpix == BitPix.Bits8) value = ((byte[])data[y])[x];
                    else if (bitpix == BitPix.Bits16) value = ((Int16[])data[y])[x];
                    else if (bitpix == BitPix.Bits32) value = ((Int32[])data[y])[x];
                    if (value > max) max = value;
                    if ((value < min) && (value != trnValue)) min = value;
                }
            
            // Отрисовка снимка
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Int32 value = 0;
                    if (bitpix == BitPix.Bits8) value = ((byte[])data[y])[x];
                    else if (bitpix == BitPix.Bits16) value = ((Int16[])data[y])[x];
                    else if (bitpix == BitPix.Bits32) value = ((Int32[])data[y])[x];
                    int amp = (int)(255 * (value - min) / (max - min));
                    
                    if (value != trnValue)
                        bm.SetPixel(x, height - y, Color.FromArgb(amp, amp, amp));
                }
            dataPictureBox.Image = bm;
        }

        private void ControlsUpdate()
        {
            foreach (ToolStripItem component in singleSwitchableControls)
                component.Enabled = (hduNumber > 0);
            foreach (ToolStripItem component in multipleSwitchableControls)
                component.Enabled = (hduNumber > 1);
        }

    }
}
