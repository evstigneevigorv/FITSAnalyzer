using nom.tam.fits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FitsAnalyzer
{
    public partial class CalcForm : Form
    {
        public FitsWrapper fits;
        public string[] files;

        public CalcForm(double minAmpl, double maxAmpl, DateTime minDateTime, DateTime maxDateTime)
        {
            InitializeComponent();
            minAmplTrackBar.Value = minAmplTrackBar.Minimum = maxAmplTrackBar.Minimum = 10 * (int)minAmpl;
            maxAmplTrackBar.Value = minAmplTrackBar.Maximum = maxAmplTrackBar.Maximum = 10 * (int)maxAmpl;
            
            minAmplTextBox.Text = minAmpl.ToString();
            maxAmplTextBox.Text = maxAmpl.ToString();
            minAmplLabel.Text = $"(Минимум: {minAmpl})";
            maxAmplLabel.Text = $"(Максимум: {maxAmpl})";
        }

        private void minAmplTrackBar_ValueChanged(object sender, EventArgs e)
        {
            minAmplTextBox.Text = (minAmplTrackBar.Value / 10.0).ToString();
            if (maxAmplTrackBar.Value < minAmplTrackBar.Value)
                maxAmplTrackBar.Value = minAmplTrackBar.Value;
        }

        private void maxAmplTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxAmplTextBox.Text = (maxAmplTrackBar.Value / 10.0).ToString();
            if (minAmplTrackBar.Value > maxAmplTrackBar.Value)
                minAmplTrackBar.Value = maxAmplTrackBar.Value;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            dataChart.Series.Clear();
            dataChart.Series.Add("SumSeries");
            dataChart.Series["SumSeries"].ChartType = SeriesChartType.Spline;
            dataChart.Series["SumSeries"].XValueType = ChartValueType.DateTime;
            dataChart.Series["SumSeries"].MarkerStyle = MarkerStyle.Circle;
            int i = 0;
            foreach (string file in files)
            {
                List<DateValue> points;
                try
                {
                    fits.CalcDependency(file, minAmplTrackBar.Value / 10.0,
                                        maxAmplTrackBar.Value / 10.0, out points);
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                        $"Не удалось прочитать заголовки файла \"{file}\":\n" +
                        $"{excp.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                foreach (DateValue point in points)
                    dataChart.Series["SumSeries"].Points.AddXY(point.Date, point.Value);

                i++;
                var progress = (int)(100 * i / files.Length);
                progressBar.Value = progress;
            }

            progressBar.Value = 0;
        }
    }
}
