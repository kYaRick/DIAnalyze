namespace Lab1 {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.epochsTextBox = new System.Windows.Forms.TextBox();
            this.learnRateTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.testInputTextBox = new System.Windows.Forms.TextBox();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lossChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.xList = new System.Windows.Forms.TextBox();
            this.tList = new System.Windows.Forms.TextBox();
            this.wList = new System.Windows.Forms.TextBox();
            this.tb_Alpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lossChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Навчаючі пари";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кількість епох";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(154, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Швидкість навчання";
            // 
            // epochsTextBox
            // 
            this.epochsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.epochsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.epochsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.epochsTextBox.Location = new System.Drawing.Point(14, 175);
            this.epochsTextBox.Name = "epochsTextBox";
            this.epochsTextBox.Size = new System.Drawing.Size(100, 22);
            this.epochsTextBox.TabIndex = 5;
            this.epochsTextBox.Text = "100";
            this.epochsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // learnRateTextBox
            // 
            this.learnRateTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.learnRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.learnRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.learnRateTextBox.Location = new System.Drawing.Point(192, 175);
            this.learnRateTextBox.Name = "learnRateTextBox";
            this.learnRateTextBox.Size = new System.Drawing.Size(100, 22);
            this.learnRateTextBox.TabIndex = 6;
            this.learnRateTextBox.Text = "0.7";
            this.learnRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(11, 785);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(417, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Навчати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(297, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Вхідні дані";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(188, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ваги";
            // 
            // testInputTextBox
            // 
            this.testInputTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.testInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testInputTextBox.Location = new System.Drawing.Point(301, 40);
            this.testInputTextBox.Name = "testInputTextBox";
            this.testInputTextBox.Size = new System.Drawing.Size(100, 22);
            this.testInputTextBox.TabIndex = 12;
            this.testInputTextBox.Text = "0; 0";
            this.testInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataChart
            // 
            this.dataChart.BackColor = System.Drawing.SystemColors.Control;
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
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Location = new System.Drawing.Point(11, 215);
            this.dataChart.Name = "dataChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerSize = 8;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DodgerBlue;
            series2.Name = "Series2";
            series2.YValuesPerPoint = 2;
            this.dataChart.Series.Add(series1);
            this.dataChart.Series.Add(series2);
            this.dataChart.Size = new System.Drawing.Size(417, 270);
            this.dataChart.TabIndex = 14;
            this.dataChart.Text = "chart1";
            // 
            // lossChart
            // 
            this.lossChart.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisX.Title = "Епоха";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisY.MajorGrid.Interval = 0D;
            chartArea2.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.Title = "Похибка";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.Name = "ChartArea1";
            this.lossChart.ChartAreas.Add(chartArea2);
            this.lossChart.Location = new System.Drawing.Point(11, 491);
            this.lossChart.Name = "lossChart";
            series3.BorderColor = System.Drawing.Color.White;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Series1";
            this.lossChart.Series.Add(series3);
            this.lossChart.Size = new System.Drawing.Size(417, 272);
            this.lossChart.TabIndex = 15;
            this.lossChart.Text = "chart2";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(11, 833);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(417, 40);
            this.button2.TabIndex = 16;
            this.button2.Text = "Перевірити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xList
            // 
            this.xList.BackColor = System.Drawing.SystemColors.Control;
            this.xList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xList.Location = new System.Drawing.Point(45, 40);
            this.xList.Multiline = true;
            this.xList.Name = "xList";
            this.xList.Size = new System.Drawing.Size(44, 105);
            this.xList.TabIndex = 17;
            this.xList.Text = "0; 0\r\n0; 1\r\n1; 0\r\n1; 1";
            this.xList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tList
            // 
            this.tList.BackColor = System.Drawing.SystemColors.Control;
            this.tList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tList.Location = new System.Drawing.Point(95, 40);
            this.tList.Multiline = true;
            this.tList.Name = "tList";
            this.tList.Size = new System.Drawing.Size(20, 105);
            this.tList.TabIndex = 18;
            this.tList.Text = "1\r\n0\r\n0\r\n0";
            // 
            // wList
            // 
            this.wList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wList.Location = new System.Drawing.Point(192, 40);
            this.wList.Multiline = true;
            this.wList.Name = "wList";
            this.wList.ReadOnly = true;
            this.wList.Size = new System.Drawing.Size(84, 105);
            this.wList.TabIndex = 19;
            // 
            // tb_Alpha
            // 
            this.tb_Alpha.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Alpha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Alpha.Location = new System.Drawing.Point(393, 175);
            this.tb_Alpha.Name = "tb_Alpha";
            this.tb_Alpha.Size = new System.Drawing.Size(35, 22);
            this.tb_Alpha.TabIndex = 21;
            this.tb_Alpha.Text = "0.7";
            this.tb_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(368, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "α:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 882);
            this.Controls.Add(this.tb_Alpha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wList);
            this.Controls.Add(this.tList);
            this.Controls.Add(this.xList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lossChart);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.testInputTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.learnRateTextBox);
            this.Controls.Add(this.epochsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lossChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox epochsTextBox;
		private System.Windows.Forms.TextBox learnRateTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox testInputTextBox;
		private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
		private System.Windows.Forms.DataVisualization.Charting.Chart lossChart;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox xList;
		private System.Windows.Forms.TextBox tList;
		private System.Windows.Forms.TextBox wList;
        private System.Windows.Forms.TextBox tb_Alpha;
        private System.Windows.Forms.Label label4;
    }
}

