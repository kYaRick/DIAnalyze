namespace DIAnalyze_lab_3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.configurationBox = new System.Windows.Forms.GroupBox();
            this.lTextBox = new System.Windows.Forms.TextBox();
            this.FunctionBox = new System.Windows.Forms.GroupBox();
            this.radioFLinear = new System.Windows.Forms.RadioButton();
            this.radioFSquare = new System.Windows.Forms.RadioButton();
            this.lLable = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.btShowInfo = new System.Windows.Forms.Button();
            this.a2Lable = new System.Windows.Forms.Label();
            this.comboboxMethods = new System.Windows.Forms.ComboBox();
            this.a1Lable = new System.Windows.Forms.Label();
            this.a0Lable = new System.Windows.Forms.Label();
            this.resTBa2 = new System.Windows.Forms.TextBox();
            this.resTBa1 = new System.Windows.Forms.TextBox();
            this.resTBa0 = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgramName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.configurationBox.SuspendLayout();
            this.FunctionBox.SuspendLayout();
            this.resultBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.mainChart.Legends.Add(legend2);
            this.mainChart.Location = new System.Drawing.Point(-2, 48);
            this.mainChart.Name = "mainChart";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series5.Legend = "Legend1";
            series5.MarkerSize = 10;
            series5.Name = "base function";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series6.Legend = "Legend1";
            series6.Name = "base+noise";
            series6.YValuesPerPoint = 2;
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "linear empirical";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.Red;
            series8.Legend = "Legend1";
            series8.Name = "quadratic empirical";
            this.mainChart.Series.Add(series5);
            this.mainChart.Series.Add(series6);
            this.mainChart.Series.Add(series7);
            this.mainChart.Series.Add(series8);
            this.mainChart.Size = new System.Drawing.Size(1855, 888);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "MainChart";
            // 
            // configurationBox
            // 
            this.configurationBox.Controls.Add(this.lTextBox);
            this.configurationBox.Controls.Add(this.FunctionBox);
            this.configurationBox.Controls.Add(this.lLable);
            this.configurationBox.Location = new System.Drawing.Point(1658, 142);
            this.configurationBox.Name = "configurationBox";
            this.configurationBox.Size = new System.Drawing.Size(133, 120);
            this.configurationBox.TabIndex = 1;
            this.configurationBox.TabStop = false;
            this.configurationBox.Text = "Configuration";
            // 
            // lTextBox
            // 
            this.lTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lTextBox.ForeColor = System.Drawing.Color.Black;
            this.lTextBox.Location = new System.Drawing.Point(65, 92);
            this.lTextBox.Name = "lTextBox";
            this.lTextBox.Size = new System.Drawing.Size(32, 13);
            this.lTextBox.TabIndex = 0;
            this.lTextBox.Text = "1";
            // 
            // FunctionBox
            // 
            this.FunctionBox.Controls.Add(this.radioFLinear);
            this.FunctionBox.Controls.Add(this.radioFSquare);
            this.FunctionBox.Location = new System.Drawing.Point(6, 19);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(121, 67);
            this.FunctionBox.TabIndex = 5;
            this.FunctionBox.TabStop = false;
            this.FunctionBox.Text = "Functions";
            // 
            // radioFLinear
            // 
            this.radioFLinear.AutoSize = true;
            this.radioFLinear.Checked = true;
            this.radioFLinear.Enabled = false;
            this.radioFLinear.Location = new System.Drawing.Point(16, 17);
            this.radioFLinear.Name = "radioFLinear";
            this.radioFLinear.Size = new System.Drawing.Size(65, 17);
            this.radioFLinear.TabIndex = 3;
            this.radioFLinear.TabStop = true;
            this.radioFLinear.Text = "y = -3x-2";
            this.radioFLinear.UseVisualStyleBackColor = true;
            // 
            // radioFSquare
            // 
            this.radioFSquare.AutoSize = true;
            this.radioFSquare.Enabled = false;
            this.radioFSquare.Location = new System.Drawing.Point(15, 41);
            this.radioFSquare.Name = "radioFSquare";
            this.radioFSquare.Size = new System.Drawing.Size(100, 17);
            this.radioFSquare.TabIndex = 4;
            this.radioFSquare.Text = "y = -0.2x^2-3x-2";
            this.radioFSquare.UseVisualStyleBackColor = true;
            // 
            // lLable
            // 
            this.lLable.AutoSize = true;
            this.lLable.Location = new System.Drawing.Point(48, 92);
            this.lLable.Name = "lLable";
            this.lLable.Size = new System.Drawing.Size(21, 13);
            this.lLable.TabIndex = 1;
            this.lLable.Text = "l = ";
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.btShowInfo);
            this.resultBox.Controls.Add(this.a2Lable);
            this.resultBox.Controls.Add(this.comboboxMethods);
            this.resultBox.Controls.Add(this.a1Lable);
            this.resultBox.Controls.Add(this.a0Lable);
            this.resultBox.Controls.Add(this.resTBa2);
            this.resultBox.Controls.Add(this.resTBa1);
            this.resultBox.Controls.Add(this.resTBa0);
            this.resultBox.Location = new System.Drawing.Point(1658, 268);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(133, 160);
            this.resultBox.TabIndex = 2;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Results";
            // 
            // btShowInfo
            // 
            this.btShowInfo.BackColor = System.Drawing.Color.Transparent;
            this.btShowInfo.FlatAppearance.BorderSize = 0;
            this.btShowInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btShowInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowInfo.Location = new System.Drawing.Point(27, 130);
            this.btShowInfo.Name = "btShowInfo";
            this.btShowInfo.Size = new System.Drawing.Size(85, 22);
            this.btShowInfo.TabIndex = 5;
            this.btShowInfo.Text = "show error";
            this.btShowInfo.UseVisualStyleBackColor = false;
            this.btShowInfo.Click += new System.EventHandler(this.btShowInfo_Click);
            // 
            // a2Lable
            // 
            this.a2Lable.AutoSize = true;
            this.a2Lable.Location = new System.Drawing.Point(22, 108);
            this.a2Lable.Name = "a2Lable";
            this.a2Lable.Size = new System.Drawing.Size(31, 13);
            this.a2Lable.TabIndex = 3;
            this.a2Lable.Text = "a2 = ";
            // 
            // comboboxMethods
            // 
            this.comboboxMethods.CausesValidation = false;
            this.comboboxMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxMethods.ForeColor = System.Drawing.Color.Black;
            this.comboboxMethods.FormattingEnabled = true;
            this.comboboxMethods.Items.AddRange(new object[] {
            "linear empirical",
            "quadratic empirical"});
            this.comboboxMethods.Location = new System.Drawing.Point(6, 19);
            this.comboboxMethods.Name = "comboboxMethods";
            this.comboboxMethods.Size = new System.Drawing.Size(121, 21);
            this.comboboxMethods.TabIndex = 2;
            this.comboboxMethods.SelectedIndexChanged += new System.EventHandler(this.comboboxMethods_SelectedIndexChanged);
            // 
            // a1Lable
            // 
            this.a1Lable.AutoSize = true;
            this.a1Lable.BackColor = System.Drawing.Color.Transparent;
            this.a1Lable.Location = new System.Drawing.Point(22, 82);
            this.a1Lable.Name = "a1Lable";
            this.a1Lable.Size = new System.Drawing.Size(31, 13);
            this.a1Lable.TabIndex = 3;
            this.a1Lable.Text = "a1 = ";
            // 
            // a0Lable
            // 
            this.a0Lable.AutoSize = true;
            this.a0Lable.Location = new System.Drawing.Point(22, 56);
            this.a0Lable.Name = "a0Lable";
            this.a0Lable.Size = new System.Drawing.Size(31, 13);
            this.a0Lable.TabIndex = 3;
            this.a0Lable.Text = "a0 = ";
            // 
            // resTBa2
            // 
            this.resTBa2.BackColor = System.Drawing.Color.Silver;
            this.resTBa2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resTBa2.ForeColor = System.Drawing.Color.White;
            this.resTBa2.Location = new System.Drawing.Point(59, 108);
            this.resTBa2.Name = "resTBa2";
            this.resTBa2.ReadOnly = true;
            this.resTBa2.Size = new System.Drawing.Size(52, 13);
            this.resTBa2.TabIndex = 3;
            this.resTBa2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resTBa1
            // 
            this.resTBa1.BackColor = System.Drawing.Color.Silver;
            this.resTBa1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resTBa1.ForeColor = System.Drawing.Color.White;
            this.resTBa1.Location = new System.Drawing.Point(59, 82);
            this.resTBa1.Name = "resTBa1";
            this.resTBa1.ReadOnly = true;
            this.resTBa1.Size = new System.Drawing.Size(52, 13);
            this.resTBa1.TabIndex = 2;
            this.resTBa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resTBa0
            // 
            this.resTBa0.BackColor = System.Drawing.Color.Silver;
            this.resTBa0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resTBa0.ForeColor = System.Drawing.Color.White;
            this.resTBa0.Location = new System.Drawing.Point(59, 56);
            this.resTBa0.Name = "resTBa0";
            this.resTBa0.ReadOnly = true;
            this.resTBa0.Size = new System.Drawing.Size(52, 13);
            this.resTBa0.TabIndex = 1;
            this.resTBa0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // updateButton
            // 
            this.updateButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.updateButton.FlatAppearance.BorderSize = 0;
            this.updateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Location = new System.Drawing.Point(1680, 434);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(84, 41);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update chart";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.Red;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(1839, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(25, 27);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "x";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.ProgramName);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1867, 33);
            this.panel1.TabIndex = 5;
            // 
            // ProgramName
            // 
            this.ProgramName.AutoSize = true;
            this.ProgramName.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.ProgramName.ForeColor = System.Drawing.Color.White;
            this.ProgramName.Location = new System.Drawing.Point(9, 6);
            this.ProgramName.Name = "ProgramName";
            this.ProgramName.Size = new System.Drawing.Size(76, 21);
            this.ProgramName.TabIndex = 6;
            this.ProgramName.Text = "Program";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1865, 948);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.configurationBox);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.configurationBox.ResumeLayout(false);
            this.configurationBox.PerformLayout();
            this.FunctionBox.ResumeLayout(false);
            this.FunctionBox.PerformLayout();
            this.resultBox.ResumeLayout(false);
            this.resultBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.GroupBox configurationBox;
        private System.Windows.Forms.ComboBox comboboxMethods;
        private System.Windows.Forms.Label lLable;
        private System.Windows.Forms.TextBox lTextBox;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.Label a2Lable;
        private System.Windows.Forms.Label a1Lable;
        private System.Windows.Forms.Label a0Lable;
        private System.Windows.Forms.TextBox resTBa2;
        private System.Windows.Forms.TextBox resTBa1;
        private System.Windows.Forms.TextBox resTBa0;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.RadioButton radioFSquare;
        private System.Windows.Forms.RadioButton radioFLinear;
        private System.Windows.Forms.GroupBox FunctionBox;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btShowInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ProgramName;
    }
}

