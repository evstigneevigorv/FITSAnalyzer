namespace FitsAnalyzer
{
    partial class CalcForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.minAmplTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxAmplTrackBar = new System.Windows.Forms.TrackBar();
            this.maxAmplLabel = new System.Windows.Forms.Label();
            this.minAmplLabel = new System.Windows.Forms.Label();
            this.maxAmplTextBox = new System.Windows.Forms.TextBox();
            this.minAmplTextBox = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // minAmplTrackBar
            // 
            this.minAmplTrackBar.Location = new System.Drawing.Point(6, 19);
            this.minAmplTrackBar.Name = "minAmplTrackBar";
            this.minAmplTrackBar.Size = new System.Drawing.Size(501, 45);
            this.minAmplTrackBar.TabIndex = 0;
            this.minAmplTrackBar.ValueChanged += new System.EventHandler(this.minAmplTrackBar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxAmplTrackBar);
            this.groupBox1.Controls.Add(this.maxAmplLabel);
            this.groupBox1.Controls.Add(this.minAmplLabel);
            this.groupBox1.Controls.Add(this.maxAmplTextBox);
            this.groupBox1.Controls.Add(this.minAmplTextBox);
            this.groupBox1.Controls.Add(this.minAmplTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Диапазон амплитуд";
            // 
            // maxAmplTrackBar
            // 
            this.maxAmplTrackBar.Location = new System.Drawing.Point(6, 70);
            this.maxAmplTrackBar.Name = "maxAmplTrackBar";
            this.maxAmplTrackBar.Size = new System.Drawing.Size(501, 45);
            this.maxAmplTrackBar.TabIndex = 3;
            this.maxAmplTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.maxAmplTrackBar.ValueChanged += new System.EventHandler(this.maxAmplTrackBar_ValueChanged);
            // 
            // maxAmplLabel
            // 
            this.maxAmplLabel.AutoSize = true;
            this.maxAmplLabel.Location = new System.Drawing.Point(629, 69);
            this.maxAmplLabel.Name = "maxAmplLabel";
            this.maxAmplLabel.Size = new System.Drawing.Size(0, 13);
            this.maxAmplLabel.TabIndex = 2;
            // 
            // minAmplLabel
            // 
            this.minAmplLabel.AutoSize = true;
            this.minAmplLabel.Location = new System.Drawing.Point(629, 22);
            this.minAmplLabel.Name = "minAmplLabel";
            this.minAmplLabel.Size = new System.Drawing.Size(0, 13);
            this.minAmplLabel.TabIndex = 2;
            // 
            // maxAmplTextBox
            // 
            this.maxAmplTextBox.Enabled = false;
            this.maxAmplTextBox.Location = new System.Drawing.Point(513, 66);
            this.maxAmplTextBox.Name = "maxAmplTextBox";
            this.maxAmplTextBox.Size = new System.Drawing.Size(110, 20);
            this.maxAmplTextBox.TabIndex = 1;
            this.maxAmplTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // minAmplTextBox
            // 
            this.minAmplTextBox.Enabled = false;
            this.minAmplTextBox.Location = new System.Drawing.Point(513, 19);
            this.minAmplTextBox.Name = "minAmplTextBox";
            this.minAmplTextBox.Size = new System.Drawing.Size(110, 20);
            this.minAmplTextBox.TabIndex = 1;
            this.minAmplTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(713, 455);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 4;
            this.calcButton.Text = "Рассчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Location = new System.Drawing.Point(12, 137);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(776, 312);
            this.dataChart.TabIndex = 5;
            this.dataChart.Text = "chart1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 455);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(695, 23);
            this.progressBar.TabIndex = 6;
            // 
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalcForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "График амплитуды";
            ((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar minAmplTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label minAmplLabel;
        private System.Windows.Forms.TextBox minAmplTextBox;
        private System.Windows.Forms.TrackBar maxAmplTrackBar;
        private System.Windows.Forms.Label maxAmplLabel;
        private System.Windows.Forms.TextBox maxAmplTextBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}