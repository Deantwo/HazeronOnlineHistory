namespace HazeronOnlineHistory
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.axisY = new System.Windows.Forms.Label();
            this.axisX = new System.Windows.Forms.Label();
            this.axisLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1FileButton1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1Help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxRecord = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 56);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelFormat = "yyyy-MM-dd HH:mm";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(732, 374);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.Resize += new System.EventHandler(this.chart1_Resize);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(199, 28);
            this.dateTimePicker2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2015, 10, 28, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker2.TabIndex = 2;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(93, 28);
            this.dateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2015, 10, 28, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // axisY
            // 
            this.axisY.BackColor = System.Drawing.Color.White;
            this.axisY.ForeColor = System.Drawing.Color.White;
            this.axisY.Location = new System.Drawing.Point(117, 215);
            this.axisY.Name = "axisY";
            this.axisY.Size = new System.Drawing.Size(200, 1);
            this.axisY.TabIndex = 3;
            this.axisY.Visible = false;
            // 
            // axisX
            // 
            this.axisX.BackColor = System.Drawing.Color.White;
            this.axisX.ForeColor = System.Drawing.Color.White;
            this.axisX.Location = new System.Drawing.Point(221, 107);
            this.axisX.Name = "axisX";
            this.axisX.Size = new System.Drawing.Size(1, 200);
            this.axisX.TabIndex = 3;
            this.axisX.Visible = false;
            // 
            // axisLabel
            // 
            this.axisLabel.AutoSize = true;
            this.axisLabel.BackColor = System.Drawing.Color.White;
            this.axisLabel.ForeColor = System.Drawing.Color.Black;
            this.axisLabel.Location = new System.Drawing.Point(228, 220);
            this.axisLabel.Name = "axisLabel";
            this.axisLabel.Size = new System.Drawing.Size(35, 13);
            this.axisLabel.TabIndex = 4;
            this.axisLabel.Text = "label1";
            this.axisLabel.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1File,
            this.menuStrip1Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip1File
            // 
            this.menuStrip1File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1FileButton1,
            this.toolStripSeparator1,
            this.menuStrip1FileExit});
            this.menuStrip1File.Name = "menuStrip1File";
            this.menuStrip1File.Size = new System.Drawing.Size(37, 20);
            this.menuStrip1File.Text = "File";
            // 
            // menuStrip1FileButton1
            // 
            this.menuStrip1FileButton1.Name = "menuStrip1FileButton1";
            this.menuStrip1FileButton1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuStrip1FileButton1.Size = new System.Drawing.Size(134, 22);
            this.menuStrip1FileButton1.Text = "Start";
            this.menuStrip1FileButton1.Click += new System.EventHandler(this.menuStrip1FileButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // menuStrip1FileExit
            // 
            this.menuStrip1FileExit.Name = "menuStrip1FileExit";
            this.menuStrip1FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuStrip1FileExit.Size = new System.Drawing.Size(134, 22);
            this.menuStrip1FileExit.Text = "Exit";
            this.menuStrip1FileExit.Click += new System.EventHandler(this.menuStrip1FileExit_Click);
            // 
            // menuStrip1Help
            // 
            this.menuStrip1Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip1HelpAbout});
            this.menuStrip1Help.Name = "menuStrip1Help";
            this.menuStrip1Help.Size = new System.Drawing.Size(44, 20);
            this.menuStrip1Help.Text = "Help";
            // 
            // menuStrip1HelpAbout
            // 
            this.menuStrip1HelpAbout.Name = "menuStrip1HelpAbout";
            this.menuStrip1HelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuStrip1HelpAbout.Size = new System.Drawing.Size(126, 22);
            this.menuStrip1HelpAbout.Text = "About";
            this.menuStrip1HelpAbout.Click += new System.EventHandler(this.menuStrip1HelpAbout_Click);
            // 
            // tbxRecord
            // 
            this.tbxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxRecord.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxRecord.Location = new System.Drawing.Point(10, 436);
            this.tbxRecord.Name = "tbxRecord";
            this.tbxRecord.ReadOnly = true;
            this.tbxRecord.Size = new System.Drawing.Size(732, 13);
            this.tbxRecord.TabIndex = 6;
            this.tbxRecord.WordWrap = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10 minute intervals",
            "1 hour intervals",
            "2 hour intervals",
            "6 hour intervals",
            "12 hour intervals",
            "1 day intervals",
            "2 day intervals",
            "1 week intervals",
            "1 month intervals",
            "3 month intervals",
            "6 month intervals",
            "1 year intervals"});
            this.comboBox1.Location = new System.Drawing.Point(304, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 461);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tbxRecord);
            this.Controls.Add(this.axisLabel);
            this.Controls.Add(this.axisX);
            this.Controls.Add(this.axisY);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "HazeronOnlineHistory";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label axisY;
        private System.Windows.Forms.Label axisX;
        private System.Windows.Forms.Label axisLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1File;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1FileButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1FileExit;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1Help;
        private System.Windows.Forms.ToolStripMenuItem menuStrip1HelpAbout;
        private System.Windows.Forms.TextBox tbxRecord;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

