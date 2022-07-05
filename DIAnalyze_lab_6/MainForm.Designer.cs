namespace DIAnalyze_lab_6
{
    partial class formsPlot
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
            this.components = new System.ComponentModel.Container();
            this._fromFirst = new System.Windows.Forms.RadioButton();
            this._centresMode = new System.Windows.Forms.RadioButton();
            this._randomMode = new System.Windows.Forms.RadioButton();
            this._updateBtn = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.ckeckShowInputCenters = new System.Windows.Forms.CheckBox();
            this.ckeckShowCalculatedCenters = new System.Windows.Forms.CheckBox();
            this.nUDMaxPoints = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDisplayOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxCalculation = new System.Windows.Forms.GroupBox();
            this.lablSigma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDSigma = new System.Windows.Forms.NumericUpDown();
            this.groupBoxMethods = new System.Windows.Forms.GroupBox();
            this.checkBoxNewListOfPoints = new System.Windows.Forms.CheckBox();
            this.toolTip_fromFirst = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxPoints)).BeginInit();
            this.groupBoxDisplayOptions.SuspendLayout();
            this.groupBoxCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSigma)).BeginInit();
            this.groupBoxMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // _fromFirst
            // 
            this._fromFirst.AutoSize = true;
            this._fromFirst.Checked = true;
            this._fromFirst.Location = new System.Drawing.Point(5, 60);
            this._fromFirst.Margin = new System.Windows.Forms.Padding(2);
            this._fromFirst.MaximumSize = new System.Drawing.Size(150, 0);
            this._fromFirst.Name = "_fromFirst";
            this._fromFirst.Size = new System.Drawing.Size(150, 17);
            this._fromFirst.TabIndex = 2;
            this._fromFirst.TabStop = true;
            this._fromFirst.Text = "random points based on ...";
            this.toolTip_fromFirst.SetToolTip(this._fromFirst, "random points based on sewn centers");
            this._fromFirst.UseVisualStyleBackColor = true;
            this._fromFirst.CheckedChanged += new System.EventHandler(this._fromFirst_CheckedChanged);
            // 
            // _centresMode
            // 
            this._centresMode.AutoSize = true;
            this._centresMode.Location = new System.Drawing.Point(5, 18);
            this._centresMode.Margin = new System.Windows.Forms.Padding(2);
            this._centresMode.Name = "_centresMode";
            this._centresMode.Size = new System.Drawing.Size(171, 17);
            this._centresMode.TabIndex = 3;
            this._centresMode.Text = "sewn centers for starting points";
            this._centresMode.UseVisualStyleBackColor = true;
            this._centresMode.CheckedChanged += new System.EventHandler(this._centresMode_CheckedChanged);
            // 
            // _randomMode
            // 
            this._randomMode.AutoSize = true;
            this._randomMode.Location = new System.Drawing.Point(5, 39);
            this._randomMode.Margin = new System.Windows.Forms.Padding(2);
            this._randomMode.Name = "_randomMode";
            this._randomMode.Size = new System.Drawing.Size(164, 17);
            this._randomMode.TabIndex = 4;
            this._randomMode.Text = "random position for first points";
            this._randomMode.UseVisualStyleBackColor = true;
            this._randomMode.CheckedChanged += new System.EventHandler(this._randomMode_CheckedChanged);
            // 
            // _updateBtn
            // 
            this._updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this._updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._updateBtn.Location = new System.Drawing.Point(418, 299);
            this._updateBtn.Margin = new System.Windows.Forms.Padding(2);
            this._updateBtn.Name = "_updateBtn";
            this._updateBtn.Size = new System.Drawing.Size(201, 36);
            this._updateBtn.TabIndex = 5;
            this._updateBtn.Text = "Update";
            this._updateBtn.UseVisualStyleBackColor = true;
            this._updateBtn.Click += new System.EventHandler(this._updateBtn_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.AutoScroll = true;
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.formsPlot1.Location = new System.Drawing.Point(2, 6);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(410, 338);
            this.formsPlot1.TabIndex = 6;
            // 
            // ckeckShowInputCenters
            // 
            this.ckeckShowInputCenters.AutoSize = true;
            this.ckeckShowInputCenters.Location = new System.Drawing.Point(6, 19);
            this.ckeckShowInputCenters.Name = "ckeckShowInputCenters";
            this.ckeckShowInputCenters.Size = new System.Drawing.Size(98, 17);
            this.ckeckShowInputCenters.TabIndex = 7;
            this.ckeckShowInputCenters.Text = "starting centers";
            this.ckeckShowInputCenters.UseVisualStyleBackColor = true;
            this.ckeckShowInputCenters.CheckStateChanged += new System.EventHandler(this._ckeckShowInputCenters_CheckStateChanged);
            // 
            // ckeckShowCalculatedCenters
            // 
            this.ckeckShowCalculatedCenters.AutoSize = true;
            this.ckeckShowCalculatedCenters.Location = new System.Drawing.Point(6, 42);
            this.ckeckShowCalculatedCenters.Name = "ckeckShowCalculatedCenters";
            this.ckeckShowCalculatedCenters.Size = new System.Drawing.Size(113, 17);
            this.ckeckShowCalculatedCenters.TabIndex = 8;
            this.ckeckShowCalculatedCenters.Text = "calculated centers";
            this.ckeckShowCalculatedCenters.UseVisualStyleBackColor = true;
            this.ckeckShowCalculatedCenters.CheckStateChanged += new System.EventHandler(this._ckeckShowCalculatedCenters_CheckStateChanged);
            // 
            // nUDMaxPoints
            // 
            this.nUDMaxPoints.Location = new System.Drawing.Point(80, 66);
            this.nUDMaxPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDMaxPoints.Name = "nUDMaxPoints";
            this.nUDMaxPoints.Size = new System.Drawing.Size(55, 20);
            this.nUDMaxPoints.TabIndex = 9;
            this.nUDMaxPoints.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBoxDisplayOptions
            // 
            this.groupBoxDisplayOptions.Controls.Add(this.ckeckShowInputCenters);
            this.groupBoxDisplayOptions.Controls.Add(this.ckeckShowCalculatedCenters);
            this.groupBoxDisplayOptions.Location = new System.Drawing.Point(418, 227);
            this.groupBoxDisplayOptions.Name = "groupBoxDisplayOptions";
            this.groupBoxDisplayOptions.Size = new System.Drawing.Size(200, 67);
            this.groupBoxDisplayOptions.TabIndex = 10;
            this.groupBoxDisplayOptions.TabStop = false;
            this.groupBoxDisplayOptions.Text = "Display options";
            // 
            // groupBoxCalculation
            // 
            this.groupBoxCalculation.Controls.Add(this.checkBoxNewListOfPoints);
            this.groupBoxCalculation.Controls.Add(this.groupBoxMethods);
            this.groupBoxCalculation.Controls.Add(this.lablSigma);
            this.groupBoxCalculation.Controls.Add(this.label1);
            this.groupBoxCalculation.Controls.Add(this.nUDSigma);
            this.groupBoxCalculation.Controls.Add(this.nUDMaxPoints);
            this.groupBoxCalculation.Location = new System.Drawing.Point(419, 17);
            this.groupBoxCalculation.Name = "groupBoxCalculation";
            this.groupBoxCalculation.Size = new System.Drawing.Size(200, 204);
            this.groupBoxCalculation.TabIndex = 11;
            this.groupBoxCalculation.TabStop = false;
            this.groupBoxCalculation.Text = "Calculation options";
            // 
            // lablSigma
            // 
            this.lablSigma.AutoSize = true;
            this.lablSigma.Location = new System.Drawing.Point(58, 93);
            this.lablSigma.Name = "lablSigma";
            this.lablSigma.Size = new System.Drawing.Size(34, 13);
            this.lablSigma.TabIndex = 12;
            this.lablSigma.Text = "sigma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 37);
            this.label1.MaximumSize = new System.Drawing.Size(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "maximum number of points in the cluster";
            // 
            // nUDSigma
            // 
            this.nUDSigma.DecimalPlaces = 1;
            this.nUDSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDSigma.Location = new System.Drawing.Point(98, 91);
            this.nUDSigma.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDSigma.Name = "nUDSigma";
            this.nUDSigma.Size = new System.Drawing.Size(51, 20);
            this.nUDSigma.TabIndex = 10;
            this.nUDSigma.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // groupBoxMethods
            // 
            this.groupBoxMethods.Controls.Add(this._centresMode);
            this.groupBoxMethods.Controls.Add(this._fromFirst);
            this.groupBoxMethods.Controls.Add(this._randomMode);
            this.groupBoxMethods.Location = new System.Drawing.Point(6, 116);
            this.groupBoxMethods.Name = "groupBoxMethods";
            this.groupBoxMethods.Size = new System.Drawing.Size(188, 83);
            this.groupBoxMethods.TabIndex = 13;
            this.groupBoxMethods.TabStop = false;
            this.groupBoxMethods.Text = "points generation method";
            // 
            // checkBoxNewListOfPoints
            // 
            this.checkBoxNewListOfPoints.AutoSize = true;
            this.checkBoxNewListOfPoints.Checked = true;
            this.checkBoxNewListOfPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNewListOfPoints.Location = new System.Drawing.Point(11, 18);
            this.checkBoxNewListOfPoints.Name = "checkBoxNewListOfPoints";
            this.checkBoxNewListOfPoints.Size = new System.Drawing.Size(109, 17);
            this.checkBoxNewListOfPoints.TabIndex = 9;
            this.checkBoxNewListOfPoints.Text = "new random poits";
            this.checkBoxNewListOfPoints.UseVisualStyleBackColor = true;
            // 
            // formsPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 348);
            this.Controls.Add(this.groupBoxCalculation);
            this.Controls.Add(this.groupBoxDisplayOptions);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this._updateBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "formsPlot";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxPoints)).EndInit();
            this.groupBoxDisplayOptions.ResumeLayout(false);
            this.groupBoxDisplayOptions.PerformLayout();
            this.groupBoxCalculation.ResumeLayout(false);
            this.groupBoxCalculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSigma)).EndInit();
            this.groupBoxMethods.ResumeLayout(false);
            this.groupBoxMethods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton _fromFirst;
        private System.Windows.Forms.RadioButton _centresMode;
        private System.Windows.Forms.RadioButton _randomMode;
        private System.Windows.Forms.Button _updateBtn;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.CheckBox ckeckShowInputCenters;
        private System.Windows.Forms.CheckBox ckeckShowCalculatedCenters;
        private System.Windows.Forms.NumericUpDown nUDMaxPoints;
        private System.Windows.Forms.GroupBox groupBoxDisplayOptions;
        private System.Windows.Forms.GroupBox groupBoxCalculation;
        private System.Windows.Forms.NumericUpDown nUDSigma;
        private System.Windows.Forms.Label lablSigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxMethods;
        private System.Windows.Forms.CheckBox checkBoxNewListOfPoints;
        private System.Windows.Forms.ToolTip toolTip_fromFirst;
    }
}

