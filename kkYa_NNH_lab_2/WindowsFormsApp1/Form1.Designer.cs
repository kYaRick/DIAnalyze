namespace WindowsFormsApp1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDispersia = new System.Windows.Forms.TextBox();
            this.tbNumOfPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLearningSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxItter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chBoxRedPoints = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.gBoxAddPoints = new System.Windows.Forms.GroupBox();
            this.btRandomArr = new System.Windows.Forms.Button();
            this.btAddPoint = new System.Windows.Forms.Button();
            this.btTeachNeuron = new System.Windows.Forms.Button();
            this.tBoxDelay = new System.Windows.Forms.TextBox();
            this.lablDelay = new System.Windows.Forms.Label();
            this.tAResult = new System.Windows.Forms.Label();
            this.tBResult = new System.Windows.Forms.Label();
            this.gBoxInputData = new System.Windows.Forms.GroupBox();
            this.gBoxFunctions = new System.Windows.Forms.GroupBox();
            this.btGenKlasters = new System.Windows.Forms.Button();
            this.gBoxInfo = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lablLog = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gBoxAddPoints.SuspendLayout();
            this.gBoxInputData.SuspendLayout();
            this.gBoxFunctions.SuspendLayout();
            this.gBoxInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(-23, -12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.IsVisibleInLegend = false;
            series1.MarkerColor = System.Drawing.Color.Blue;
            series1.MarkerSize = 14;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.MarkerSize = 14;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.MarkerBorderColor = System.Drawing.Color.Red;
            series3.MarkerBorderWidth = 0;
            series3.MarkerColor = System.Drawing.Color.Blue;
            series3.MarkerSize = 12;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.MarkerBorderColor = System.Drawing.Color.Blue;
            series4.MarkerBorderWidth = 0;
            series4.MarkerColor = System.Drawing.Color.Red;
            series4.MarkerSize = 12;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "Series4";
            series5.BorderColor = System.Drawing.Color.Black;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Black;
            series5.MarkerSize = 6;
            series5.Name = "Series5";
            series5.ShadowColor = System.Drawing.Color.Black;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.LabelForeColor = System.Drawing.Color.LightSalmon;
            series6.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series6.MarkerSize = 12;
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series6.Name = "Series6";
            series6.YValuesPerPoint = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.LabelForeColor = System.Drawing.Color.DodgerBlue;
            series7.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series7.MarkerSize = 12;
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series7.Name = "Series7";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(767, 438);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "sigma = ";
            // 
            // tbDispersia
            // 
            this.tbDispersia.BackColor = System.Drawing.SystemColors.Control;
            this.tbDispersia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDispersia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDispersia.Location = new System.Drawing.Point(73, 19);
            this.tbDispersia.Name = "tbDispersia";
            this.tbDispersia.Size = new System.Drawing.Size(50, 13);
            this.tbDispersia.TabIndex = 2;
            this.tbDispersia.Text = "0.2";
            // 
            // tbNumOfPoints
            // 
            this.tbNumOfPoints.BackColor = System.Drawing.SystemColors.Control;
            this.tbNumOfPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumOfPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNumOfPoints.Location = new System.Drawing.Point(73, 38);
            this.tbNumOfPoints.Name = "tbNumOfPoints";
            this.tbNumOfPoints.Size = new System.Drawing.Size(50, 13);
            this.tbNumOfPoints.TabIndex = 4;
            this.tbNumOfPoints.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "N = ";
            // 
            // tbLearningSpeed
            // 
            this.tbLearningSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.tbLearningSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLearningSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLearningSpeed.Location = new System.Drawing.Point(73, 57);
            this.tbLearningSpeed.Name = "tbLearningSpeed";
            this.tbLearningSpeed.Size = new System.Drawing.Size(50, 13);
            this.tbLearningSpeed.TabIndex = 6;
            this.tbLearningSpeed.Text = "0.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = " J = ";
            // 
            // tbMaxItter
            // 
            this.tbMaxItter.BackColor = System.Drawing.SystemColors.Control;
            this.tbMaxItter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMaxItter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMaxItter.Location = new System.Drawing.Point(73, 76);
            this.tbMaxItter.Name = "tbMaxItter";
            this.tbMaxItter.Size = new System.Drawing.Size(50, 13);
            this.tbMaxItter.TabIndex = 8;
            this.tbMaxItter.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "maxIter = ";
            // 
            // chBoxRedPoints
            // 
            this.chBoxRedPoints.AutoSize = true;
            this.chBoxRedPoints.Location = new System.Drawing.Point(13, 64);
            this.chBoxRedPoints.Name = "chBoxRedPoints";
            this.chBoxRedPoints.Size = new System.Drawing.Size(113, 17);
            this.chBoxRedPoints.TabIndex = 10;
            this.chBoxRedPoints.Text = "Redistribute points";
            this.chBoxRedPoints.UseVisualStyleBackColor = true;
            this.chBoxRedPoints.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "X = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y =";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(43, 21);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 13);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "0";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(43, 35);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(80, 13);
            this.textBox6.TabIndex = 14;
            this.textBox6.Text = "0";
            // 
            // gBoxAddPoints
            // 
            this.gBoxAddPoints.Controls.Add(this.btRandomArr);
            this.gBoxAddPoints.Controls.Add(this.btAddPoint);
            this.gBoxAddPoints.Controls.Add(this.textBox5);
            this.gBoxAddPoints.Controls.Add(this.textBox6);
            this.gBoxAddPoints.Controls.Add(this.label5);
            this.gBoxAddPoints.Controls.Add(this.label6);
            this.gBoxAddPoints.Enabled = false;
            this.gBoxAddPoints.Location = new System.Drawing.Point(726, 344);
            this.gBoxAddPoints.Name = "gBoxAddPoints";
            this.gBoxAddPoints.Size = new System.Drawing.Size(135, 112);
            this.gBoxAddPoints.TabIndex = 15;
            this.gBoxAddPoints.TabStop = false;
            this.gBoxAddPoints.Text = "Add a point";
            this.gBoxAddPoints.Visible = false;
            // 
            // btRandomArr
            // 
            this.btRandomArr.BackColor = System.Drawing.Color.Transparent;
            this.btRandomArr.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btRandomArr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRandomArr.Location = new System.Drawing.Point(9, 82);
            this.btRandomArr.Name = "btRandomArr";
            this.btRandomArr.Size = new System.Drawing.Size(120, 25);
            this.btRandomArr.TabIndex = 16;
            this.btRandomArr.Text = "Add random array";
            this.btRandomArr.UseVisualStyleBackColor = false;
            this.btRandomArr.Click += new System.EventHandler(this.btRandomArr_Click);
            // 
            // btAddPoint
            // 
            this.btAddPoint.BackColor = System.Drawing.Color.Transparent;
            this.btAddPoint.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btAddPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddPoint.Location = new System.Drawing.Point(9, 51);
            this.btAddPoint.Name = "btAddPoint";
            this.btAddPoint.Size = new System.Drawing.Size(120, 25);
            this.btAddPoint.TabIndex = 15;
            this.btAddPoint.Text = "Add";
            this.btAddPoint.UseVisualStyleBackColor = false;
            this.btAddPoint.Click += new System.EventHandler(this.btAddPoint_Click);
            // 
            // btTeachNeuron
            // 
            this.btTeachNeuron.BackColor = System.Drawing.Color.Transparent;
            this.btTeachNeuron.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btTeachNeuron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTeachNeuron.Location = new System.Drawing.Point(7, 87);
            this.btTeachNeuron.Name = "btTeachNeuron";
            this.btTeachNeuron.Size = new System.Drawing.Size(120, 25);
            this.btTeachNeuron.TabIndex = 16;
            this.btTeachNeuron.Text = "Teach a neuron";
            this.btTeachNeuron.UseVisualStyleBackColor = false;
            this.btTeachNeuron.Click += new System.EventHandler(this.btTeachNeuron_Click);
            // 
            // tBoxDelay
            // 
            this.tBoxDelay.BackColor = System.Drawing.SystemColors.Control;
            this.tBoxDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxDelay.Location = new System.Drawing.Point(81, 45);
            this.tBoxDelay.Name = "tBoxDelay";
            this.tBoxDelay.Size = new System.Drawing.Size(45, 13);
            this.tBoxDelay.TabIndex = 16;
            this.tBoxDelay.Text = "100";
            // 
            // lablDelay
            // 
            this.lablDelay.AutoSize = true;
            this.lablDelay.Location = new System.Drawing.Point(11, 45);
            this.lablDelay.Name = "lablDelay";
            this.lablDelay.Size = new System.Drawing.Size(65, 13);
            this.lablDelay.TabIndex = 17;
            this.lablDelay.Text = "Pause(ms) =";
            // 
            // tAResult
            // 
            this.tAResult.AutoSize = true;
            this.tAResult.Location = new System.Drawing.Point(11, 16);
            this.tAResult.Name = "tAResult";
            this.tAResult.Size = new System.Drawing.Size(39, 13);
            this.tAResult.TabIndex = 18;
            this.tAResult.Text = "T(A) = ";
            // 
            // tBResult
            // 
            this.tBResult.AutoSize = true;
            this.tBResult.Location = new System.Drawing.Point(11, 32);
            this.tBResult.Name = "tBResult";
            this.tBResult.Size = new System.Drawing.Size(39, 13);
            this.tBResult.TabIndex = 19;
            this.tBResult.Text = "T(B) = ";
            // 
            // gBoxInputData
            // 
            this.gBoxInputData.Controls.Add(this.tbDispersia);
            this.gBoxInputData.Controls.Add(this.label1);
            this.gBoxInputData.Controls.Add(this.label2);
            this.gBoxInputData.Controls.Add(this.tbNumOfPoints);
            this.gBoxInputData.Controls.Add(this.label3);
            this.gBoxInputData.Controls.Add(this.tbLearningSpeed);
            this.gBoxInputData.Controls.Add(this.label4);
            this.gBoxInputData.Controls.Add(this.tbMaxItter);
            this.gBoxInputData.Location = new System.Drawing.Point(726, 116);
            this.gBoxInputData.Name = "gBoxInputData";
            this.gBoxInputData.Size = new System.Drawing.Size(135, 98);
            this.gBoxInputData.TabIndex = 20;
            this.gBoxInputData.TabStop = false;
            this.gBoxInputData.Text = "Input data";
            // 
            // gBoxFunctions
            // 
            this.gBoxFunctions.Controls.Add(this.btGenKlasters);
            this.gBoxFunctions.Controls.Add(this.btTeachNeuron);
            this.gBoxFunctions.Controls.Add(this.tBoxDelay);
            this.gBoxFunctions.Controls.Add(this.lablDelay);
            this.gBoxFunctions.Controls.Add(this.chBoxRedPoints);
            this.gBoxFunctions.Location = new System.Drawing.Point(726, 220);
            this.gBoxFunctions.Name = "gBoxFunctions";
            this.gBoxFunctions.Size = new System.Drawing.Size(135, 118);
            this.gBoxFunctions.TabIndex = 21;
            this.gBoxFunctions.TabStop = false;
            this.gBoxFunctions.Text = "Functions";
            // 
            // btGenKlasters
            // 
            this.btGenKlasters.BackColor = System.Drawing.Color.Transparent;
            this.btGenKlasters.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btGenKlasters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGenKlasters.Location = new System.Drawing.Point(7, 14);
            this.btGenKlasters.Name = "btGenKlasters";
            this.btGenKlasters.Size = new System.Drawing.Size(120, 25);
            this.btGenKlasters.TabIndex = 18;
            this.btGenKlasters.Text = "Generate clusters";
            this.btGenKlasters.UseVisualStyleBackColor = false;
            this.btGenKlasters.Click += new System.EventHandler(this.btGenKlasters_Click);
            // 
            // gBoxInfo
            // 
            this.gBoxInfo.Controls.Add(this.tAResult);
            this.gBoxInfo.Controls.Add(this.tBResult);
            this.gBoxInfo.Enabled = false;
            this.gBoxInfo.Location = new System.Drawing.Point(726, 457);
            this.gBoxInfo.Name = "gBoxInfo";
            this.gBoxInfo.Size = new System.Drawing.Size(135, 52);
            this.gBoxInfo.TabIndex = 22;
            this.gBoxInfo.TabStop = false;
            this.gBoxInfo.Text = "Info";
            this.gBoxInfo.Visible = false;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Location = new System.Drawing.Point(12, 432);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(703, 119);
            this.rtbLog.TabIndex = 23;
            this.rtbLog.Text = "";
            // 
            // lablLog
            // 
            this.lablLog.AutoSize = true;
            this.lablLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lablLog.Location = new System.Drawing.Point(9, 413);
            this.lablLog.Name = "lablLog";
            this.lablLog.Size = new System.Drawing.Size(37, 16);
            this.lablLog.TabIndex = 20;
            this.lablLog.Text = "Logs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(726, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 98);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input data";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(73, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(19, 13);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "-1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "x1 = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "y1 = ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(73, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(19, 13);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "-3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = " x2 = ";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(73, 54);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(19, 13);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "y2 =";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(73, 73);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(19, 13);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "3";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(735, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "Clear log";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(867, 12);
            this.chart2.Name = "chart2";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series8.MarkerBorderColor = System.Drawing.Color.Blue;
            series8.MarkerColor = System.Drawing.Color.RoyalBlue;
            series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series8.Name = "Series1";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(355, 380);
            this.chart2.TabIndex = 25;
            this.chart2.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 563);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lablLog);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.gBoxInfo);
            this.Controls.Add(this.gBoxFunctions);
            this.Controls.Add(this.gBoxInputData);
            this.Controls.Add(this.gBoxAddPoints);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gBoxAddPoints.ResumeLayout(false);
            this.gBoxAddPoints.PerformLayout();
            this.gBoxInputData.ResumeLayout(false);
            this.gBoxInputData.PerformLayout();
            this.gBoxFunctions.ResumeLayout(false);
            this.gBoxFunctions.PerformLayout();
            this.gBoxInfo.ResumeLayout(false);
            this.gBoxInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDispersia;
        private System.Windows.Forms.TextBox tbNumOfPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLearningSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxItter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chBoxRedPoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox gBoxAddPoints;
        private System.Windows.Forms.Button btAddPoint;
        private System.Windows.Forms.TextBox tBoxDelay;
        private System.Windows.Forms.Label lablDelay;
        private System.Windows.Forms.Label tAResult;
        private System.Windows.Forms.Label tBResult;
        private System.Windows.Forms.Button btTeachNeuron;
        private System.Windows.Forms.GroupBox gBoxInputData;
        private System.Windows.Forms.GroupBox gBoxFunctions;
        private System.Windows.Forms.Button btGenKlasters;
        private System.Windows.Forms.GroupBox gBoxInfo;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btRandomArr;
        private System.Windows.Forms.Label lablLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

