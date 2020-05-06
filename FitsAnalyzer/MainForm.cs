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
    public partial class MainForm : Form
    {
        private FitsWrapper fits = new FitsWrapper();
        private string filePath = string.Empty;
        private int crtHDUIndex = 0;
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
                // Вызов диалогового окна открытия файла

                openFileDialog.Title = "Открыть FITS-файл";
                // Возможные варианты начальной папки в диалоговом окне
                // openFileDialog.InitialDirectory = "c:\\"; // Диск C:
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Рабочий стол
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Мои Документы
                openFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"; // Мой компьютер
                openFileDialog.Filter = "FITS-файлы (*.fits)|*.fits|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show(
                        $"Неправильно выбран файл \"{filePath}\"",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                filePath = openFileDialog.FileName;
                string crtDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string workFilePath = crtDir + "\\fits\\" + Path.GetFileName(filePath);

                try
                {
                    // Determine whether the directory exists.
                    
                    if (!Directory.Exists("fits"))
                    {
                        // Try to create the directory.
                        DirectoryInfo di = Directory.CreateDirectory("fits");
                    }
                    // if (File.Exists(workFilePath)) File.Delete(workFilePath);
                    File.Copy(filePath, workFilePath, true);
                    using (Process myProcess = new Process())
                    {
                        myProcess.StartInfo.UseShellExecute = true;
                        myProcess.StartInfo.FileName = ".\\Funpack.exe";
                        myProcess.StartInfo.Arguments = $"-F .\\fits\\{Path.GetFileName(workFilePath)}";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();
                        // This code assumes the process you are starting will terminate itself. 
                        // Given that is is started without a window so you cannot terminate it 
                        // on the desktop, it must terminate itself or you can do it programmatically
                        // from this application using the Kill method.
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show("The process failed: {0}", excp.ToString());
                }

                // Определение количества заголовков в файле

                try
                {
                    fits.OpenFile(workFilePath, out hduNumber);
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                        $"Не удалось прочитать заголовки файла \"{workFilePath}\":\n" +
                        $"{excp.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Окрытие первого заголовка

                crtHDUIndex = 0;
                HDULoad();
            }
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (crtHDUIndex > 0)
            {
                crtHDUIndex--;
                HDULoad();
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (crtHDUIndex < hduNumber - 1)
            {
                crtHDUIndex++;
                HDULoad();
            }
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
                fits.ReadHeader(crtHDUIndex, out table, out hasImage);
            }
            catch (Exception excp)
            {
                MessageBox.Show(
                    $"Не удалось открыть заголовок №{crtHDUIndex} файла \"{filePath}\":\n" +
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
                    fits.ReadData(crtHDUIndex, out data, out bitpix);
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                        $"Не удалось открыть данные для HDU №{crtHDUIndex} файла \"{filePath}\":\n" +
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

            toolStripNumberComboBox.Items.Clear();
            for (int i = 1; i <= hduNumber; i++)
                toolStripNumberComboBox.Items.Add($"{i} / {hduNumber}");
            toolStripNumberComboBox.SelectedIndex = crtHDUIndex;
        }
    }
}
