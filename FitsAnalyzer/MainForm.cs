using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitsAnalyzer
{
    public partial class MainForm : Form
    {
        private string filePath = string.Empty;
        private FitsWrapper fits = new FitsWrapper();

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
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

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    fits.OpenFile(filePath);
                    var table = new List<string[]> { };
                    fits.ReadHeader(0, out table);
                    HeaderShow(table);

                    Array[] data;
                    fits.ReadData(0, out data);
                    DataShow(data);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HeaderShow(List<string[]> table)
        {
            foreach (string[] sa in table)
                hduDataGridView.Rows.Add(sa);
        }

        private void DataShow(Array[] data)
        {
            int width = data[0].GetLength(0);
            int height = data.GetLength(0);
            Bitmap bm = new Bitmap(width, height);

            short min = short.MaxValue;
            short max = short.MinValue;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    short value = ((short[])data[y])[x];
                    if (value > max) max = value;
                    if ((value < min) && (value != short.MinValue)) min = value;
                }
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    short value = ((short[])data[y])[x];
                    int amp = (int)(255 * (value - min) / (max - min));
                    var clr = Color.Transparent;
                    if (value != short.MinValue)
                    bm.SetPixel(x, height - y, Color.FromArgb(amp, amp, amp));
                }
            dataPictureBox.Image = bm;
        }
    }
}
