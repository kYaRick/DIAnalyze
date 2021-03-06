namespace Wave_Algorithm
{
    partial class WaveAlgorithmForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetMazeSize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.gbLegend = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudWallsPerc = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRandMaze = new System.Windows.Forms.Button();
            this.chbShowWeights = new System.Windows.Forms.CheckBox();
            this.btnFullClean = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbMethodsMode = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chbIsIgnoreSpeed = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSetMazeSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(643, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sizes";
            // 
            // btnSetMazeSize
            // 
            this.btnSetMazeSize.BackColor = System.Drawing.Color.Gray;
            this.btnSetMazeSize.FlatAppearance.BorderSize = 0;
            this.btnSetMazeSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMazeSize.Location = new System.Drawing.Point(8, 67);
            this.btnSetMazeSize.Name = "btnSetMazeSize";
            this.btnSetMazeSize.Size = new System.Drawing.Size(178, 23);
            this.btnSetMazeSize.TabIndex = 9;
            this.btnSetMazeSize.Text = "Set sizes";
            this.btnSetMazeSize.UseVisualStyleBackColor = false;
            this.btnSetMazeSize.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Column count";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.Location = new System.Drawing.Point(142, 41);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(44, 16);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Row count";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Location = new System.Drawing.Point(142, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 16);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gbLegend
            // 
            this.gbLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLegend.Controls.Add(this.label10);
            this.gbLegend.Controls.Add(this.nudWallsPerc);
            this.gbLegend.Controls.Add(this.label9);
            this.gbLegend.Controls.Add(this.btnRandMaze);
            this.gbLegend.Controls.Add(this.chbShowWeights);
            this.gbLegend.Controls.Add(this.btnFullClean);
            this.gbLegend.Controls.Add(this.label6);
            this.gbLegend.Controls.Add(this.label5);
            this.gbLegend.Controls.Add(this.label4);
            this.gbLegend.Controls.Add(this.label3);
            this.gbLegend.ForeColor = System.Drawing.Color.White;
            this.gbLegend.Location = new System.Drawing.Point(643, 108);
            this.gbLegend.Name = "gbLegend";
            this.gbLegend.Size = new System.Drawing.Size(192, 168);
            this.gbLegend.TabIndex = 6;
            this.gbLegend.TabStop = false;
            this.gbLegend.Text = "Legend";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(137, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "%";
            // 
            // nudWallsPerc
            // 
            this.nudWallsPerc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudWallsPerc.Location = new System.Drawing.Point(95, 118);
            this.nudWallsPerc.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudWallsPerc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWallsPerc.Name = "nudWallsPerc";
            this.nudWallsPerc.Size = new System.Drawing.Size(38, 16);
            this.nudWallsPerc.TabIndex = 14;
            this.nudWallsPerc.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Walls percentage";
            // 
            // btnRandMaze
            // 
            this.btnRandMaze.BackColor = System.Drawing.Color.Gray;
            this.btnRandMaze.FlatAppearance.BorderSize = 0;
            this.btnRandMaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandMaze.Location = new System.Drawing.Point(157, 114);
            this.btnRandMaze.Name = "btnRandMaze";
            this.btnRandMaze.Size = new System.Drawing.Size(29, 23);
            this.btnRandMaze.TabIndex = 12;
            this.btnRandMaze.Text = "ﭏ";
            this.btnRandMaze.UseVisualStyleBackColor = false;
            this.btnRandMaze.Click += new System.EventHandler(this.btnRandMaze_Click);
            // 
            // chbShowWeights
            // 
            this.chbShowWeights.AutoSize = true;
            this.chbShowWeights.Location = new System.Drawing.Point(9, 142);
            this.chbShowWeights.Name = "chbShowWeights";
            this.chbShowWeights.Size = new System.Drawing.Size(92, 17);
            this.chbShowWeights.TabIndex = 11;
            this.chbShowWeights.Text = "Show weights";
            this.chbShowWeights.UseVisualStyleBackColor = true;
            // 
            // btnFullClean
            // 
            this.btnFullClean.BackColor = System.Drawing.Color.Gray;
            this.btnFullClean.FlatAppearance.BorderSize = 0;
            this.btnFullClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullClean.Location = new System.Drawing.Point(9, 85);
            this.btnFullClean.Name = "btnFullClean";
            this.btnFullClean.Size = new System.Drawing.Size(178, 23);
            this.btnFullClean.TabIndex = 10;
            this.btnFullClean.Text = "Full clean";
            this.btnFullClean.UseVisualStyleBackColor = false;
            this.btnFullClean.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "-5 - finish (two right clicks)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "-7 - start (right click)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "-1 - available area (two clicks)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "-9 - wall (click)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.dataGridView1.Location = new System.Drawing.Point(-7, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(642, 551);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cbMethodsMode);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(643, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 102);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Methods";
            // 
            // cbMethodsMode
            // 
            this.cbMethodsMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMethodsMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMethodsMode.FormattingEnabled = true;
            this.cbMethodsMode.ItemHeight = 13;
            this.cbMethodsMode.Items.AddRange(new object[] {
            "onewire",
            "bidirection"});
            this.cbMethodsMode.Location = new System.Drawing.Point(9, 20);
            this.cbMethodsMode.Name = "cbMethodsMode";
            this.cbMethodsMode.Size = new System.Drawing.Size(177, 21);
            this.cbMethodsMode.TabIndex = 3;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(9, 78);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "mixed";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "diagonals";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "MarkMode.HorizontalVertical";
            this.radioButton1.Text = "horizontals/verticals";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chbIsIgnoreSpeed);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.numericUpDown3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(643, 390);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 121);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "ms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Speed";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown3.Location = new System.Drawing.Point(49, 19);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(44, 16);
            this.numericUpDown3.TabIndex = 11;
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(6, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Clean results";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(6, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Solve";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chbIsIgnoreSpeed
            // 
            this.chbIsIgnoreSpeed.AutoSize = true;
            this.chbIsIgnoreSpeed.Location = new System.Drawing.Point(8, 40);
            this.chbIsIgnoreSpeed.Name = "chbIsIgnoreSpeed";
            this.chbIsIgnoreSpeed.Size = new System.Drawing.Size(88, 17);
            this.chbIsIgnoreSpeed.TabIndex = 16;
            this.chbIsIgnoreSpeed.Text = "Ignore speed";
            this.chbIsIgnoreSpeed.UseVisualStyleBackColor = true;
            // 
            // WaveAlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(845, 555);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbLegend);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaveAlgorithmForm";
            this.Text = "Wave Algorithm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbLegend.ResumeLayout(false);
            this.gbLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetMazeSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox gbLegend;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFullClean;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbMethodsMode;
        private System.Windows.Forms.CheckBox chbShowWeights;
        private System.Windows.Forms.Button btnRandMaze;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudWallsPerc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbIsIgnoreSpeed;
    }
}

