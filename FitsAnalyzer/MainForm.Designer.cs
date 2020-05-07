namespace FitsAnalyzer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripOpenFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPreviousButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripNumberComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripNextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripFitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSettingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripHelpButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataPictureBox = new System.Windows.Forms.PictureBox();
            this.hduDataGridView = new System.Windows.Forms.DataGridView();
            this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hduDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openToolStripMenuItem.Text = "Открыть ...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.saveToolStripMenuItem.Text = "Сохранить снимок";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.toolStripSeparator4,
            this.fitToolStripMenuItem,
            this.toolStripSeparator5,
            this.previousToolStripMenuItem,
            this.nextToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Enabled = false;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+<+>";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.zoomInToolStripMenuItem.Text = "Приблизить";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Enabled = false;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+<->";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.zoomOutToolStripMenuItem.Text = "Отдалить";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(246, 6);
            // 
            // fitToolStripMenuItem
            // 
            this.fitToolStripMenuItem.Enabled = false;
            this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            this.fitToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.fitToolStripMenuItem.Text = "Вписать в окно";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Enabled = false;
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.previousToolStripMenuItem.Text = "Предыдущий снимок";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Enabled = false;
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.nextToolStripMenuItem.Text = "Следующий снимок";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referenceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.referenceToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenFileButton,
            this.toolStripSaveButton,
            this.toolStripSeparator1,
            this.toolStripPreviousButton,
            this.toolStripNumberComboBox,
            this.toolStripNextButton,
            this.toolStripSeparator2,
            this.toolStripZoomInButton,
            this.toolStripFitButton,
            this.toolStripZoomOutButton,
            this.toolStripSeparator3,
            this.toolStripSettingsButton,
            this.toolStripHelpButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripOpenFileButton
            // 
            this.toolStripOpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenFileButton.Image")));
            this.toolStripOpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenFileButton.Name = "toolStripOpenFileButton";
            this.toolStripOpenFileButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripOpenFileButton.Text = "toolStripButton1";
            this.toolStripOpenFileButton.ToolTipText = "Открыть новый FITS-файл";
            this.toolStripOpenFileButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSaveButton
            // 
            this.toolStripSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSaveButton.Enabled = false;
            this.toolStripSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveButton.Image")));
            this.toolStripSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveButton.Name = "toolStripSaveButton";
            this.toolStripSaveButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripSaveButton.Text = "Сохранить снимок";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripPreviousButton
            // 
            this.toolStripPreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPreviousButton.Enabled = false;
            this.toolStripPreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPreviousButton.Image")));
            this.toolStripPreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPreviousButton.Name = "toolStripPreviousButton";
            this.toolStripPreviousButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripPreviousButton.Text = "Предыдущий снимок";
            this.toolStripPreviousButton.ToolTipText = "Предыдущий снимок";
            this.toolStripPreviousButton.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // toolStripNumberComboBox
            // 
            this.toolStripNumberComboBox.Enabled = false;
            this.toolStripNumberComboBox.Name = "toolStripNumberComboBox";
            this.toolStripNumberComboBox.Size = new System.Drawing.Size(80, 25);
            this.toolStripNumberComboBox.ToolTipText = "Текущий снимок";
            this.toolStripNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripNumberComboBox_SelectedIndexChanged);
            // 
            // toolStripNextButton
            // 
            this.toolStripNextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNextButton.Enabled = false;
            this.toolStripNextButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNextButton.Image")));
            this.toolStripNextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNextButton.Name = "toolStripNextButton";
            this.toolStripNextButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripNextButton.Text = "Следующий снимок";
            this.toolStripNextButton.ToolTipText = "Следующий снимок";
            this.toolStripNextButton.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripZoomInButton
            // 
            this.toolStripZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomInButton.Enabled = false;
            this.toolStripZoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomInButton.Image")));
            this.toolStripZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomInButton.Name = "toolStripZoomInButton";
            this.toolStripZoomInButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripZoomInButton.Text = "Приблизить";
            // 
            // toolStripFitButton
            // 
            this.toolStripFitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFitButton.Enabled = false;
            this.toolStripFitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFitButton.Name = "toolStripFitButton";
            this.toolStripFitButton.Size = new System.Drawing.Size(39, 22);
            this.toolStripFitButton.Text = "100%";
            this.toolStripFitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripZoomOutButton
            // 
            this.toolStripZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomOutButton.Enabled = false;
            this.toolStripZoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomOutButton.Image")));
            this.toolStripZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomOutButton.Name = "toolStripZoomOutButton";
            this.toolStripZoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripZoomOutButton.Text = "Отдалить";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSettingsButton
            // 
            this.toolStripSettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettingsButton.Image")));
            this.toolStripSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettingsButton.Name = "toolStripSettingsButton";
            this.toolStripSettingsButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripSettingsButton.Text = "Настройки";
            // 
            // toolStripHelpButton
            // 
            this.toolStripHelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripHelpButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripHelpButton.Image")));
            this.toolStripHelpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripHelpButton.Name = "toolStripHelpButton";
            this.toolStripHelpButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripHelpButton.Text = "Справка";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar,
            this.toolStripProgressStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.AutoToolTip = true;
            this.toolStripStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusLabel.Text = "Выберите файл для анализа";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripProgressStatusLabel
            // 
            this.toolStripProgressStatusLabel.Name = "toolStripProgressStatusLabel";
            this.toolStripProgressStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.toolStripProgressStatusLabel.Text = "0 %";
            this.toolStripProgressStatusLabel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.hduDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(800, 490);
            this.splitContainer1.SplitterDistance = 590;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataPictureBox
            // 
            this.dataPictureBox.BackColor = System.Drawing.Color.Black;
            this.dataPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPictureBox.Location = new System.Drawing.Point(0, 0);
            this.dataPictureBox.Name = "dataPictureBox";
            this.dataPictureBox.Size = new System.Drawing.Size(590, 490);
            this.dataPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dataPictureBox.TabIndex = 1;
            this.dataPictureBox.TabStop = false;
            // 
            // hduDataGridView
            // 
            this.hduDataGridView.AllowUserToAddRows = false;
            this.hduDataGridView.AllowUserToDeleteRows = false;
            this.hduDataGridView.AllowUserToOrderColumns = true;
            this.hduDataGridView.AllowUserToResizeRows = false;
            this.hduDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hduDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.ValueColumn,
            this.CommentColumn});
            this.hduDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hduDataGridView.Location = new System.Drawing.Point(0, 0);
            this.hduDataGridView.Name = "hduDataGridView";
            this.hduDataGridView.ReadOnly = true;
            this.hduDataGridView.RowHeadersVisible = false;
            this.hduDataGridView.Size = new System.Drawing.Size(206, 490);
            this.hduDataGridView.TabIndex = 0;
            // 
            // KeyColumn
            // 
            this.KeyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KeyColumn.HeaderText = "Ключ";
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.ReadOnly = true;
            this.KeyColumn.Width = 58;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValueColumn.HeaderText = "Значение";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.Width = 80;
            // 
            // CommentColumn
            // 
            this.CommentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CommentColumn.HeaderText = "Комментарий";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            this.CommentColumn.Width = 102;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FitsAnalyzer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hduDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.DataGridView hduDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripOpenFileButton;
        private System.Windows.Forms.ToolStripButton toolStripSaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripPreviousButton;
        private System.Windows.Forms.ToolStripComboBox toolStripNumberComboBox;
        private System.Windows.Forms.ToolStripButton toolStripNextButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripSettingsButton;
        private System.Windows.Forms.ToolStripButton toolStripHelpButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripZoomInButton;
        private System.Windows.Forms.ToolStripButton toolStripFitButton;
        private System.Windows.Forms.ToolStripButton toolStripZoomOutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressStatusLabel;
        private System.Windows.Forms.PictureBox dataPictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
    }
}

