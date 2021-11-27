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
            this._sigmaTB = new System.Windows.Forms.TextBox();
            this._fromFirst = new System.Windows.Forms.RadioButton();
            this._centresMode = new System.Windows.Forms.RadioButton();
            this._randomMode = new System.Windows.Forms.RadioButton();
            this._updateBtn = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // _sigmaTB
            // 
            this._sigmaTB.Location = new System.Drawing.Point(434, 58);
            this._sigmaTB.Margin = new System.Windows.Forms.Padding(2);
            this._sigmaTB.Name = "_sigmaTB";
            this._sigmaTB.Size = new System.Drawing.Size(158, 20);
            this._sigmaTB.TabIndex = 1;
            this._sigmaTB.Text = "0,1";
            // 
            // _fromFirst
            // 
            this._fromFirst.AutoSize = true;
            this._fromFirst.Checked = true;
            this._fromFirst.Location = new System.Drawing.Point(434, 82);
            this._fromFirst.Margin = new System.Windows.Forms.Padding(2);
            this._fromFirst.Name = "_fromFirst";
            this._fromFirst.Size = new System.Drawing.Size(199, 17);
            this._fromFirst.TabIndex = 2;
            this._fromFirst.TabStop = true;
            this._fromFirst.Text = "Початкові точки - декілька перших";
            this._fromFirst.UseVisualStyleBackColor = true;
            this._fromFirst.CheckedChanged += new System.EventHandler(this._fromFirst_CheckedChanged);
            // 
            // _centresMode
            // 
            this._centresMode.AutoSize = true;
            this._centresMode.Location = new System.Drawing.Point(434, 104);
            this._centresMode.Margin = new System.Windows.Forms.Padding(2);
            this._centresMode.Name = "_centresMode";
            this._centresMode.Size = new System.Drawing.Size(185, 17);
            this._centresMode.TabIndex = 3;
            this._centresMode.Text = "Початкові точки - задані центри";
            this._centresMode.UseVisualStyleBackColor = true;
            this._centresMode.CheckedChanged += new System.EventHandler(this._centresMode_CheckedChanged);
            // 
            // _randomMode
            // 
            this._randomMode.AutoSize = true;
            this._randomMode.Location = new System.Drawing.Point(434, 125);
            this._randomMode.Margin = new System.Windows.Forms.Padding(2);
            this._randomMode.Name = "_randomMode";
            this._randomMode.Size = new System.Drawing.Size(158, 17);
            this._randomMode.TabIndex = 4;
            this._randomMode.Text = "Випадкові початкові точки";
            this._randomMode.UseVisualStyleBackColor = true;
            this._randomMode.CheckedChanged += new System.EventHandler(this._randomMode_CheckedChanged);
            // 
            // _updateBtn
            // 
            this._updateBtn.Location = new System.Drawing.Point(418, 305);
            this._updateBtn.Margin = new System.Windows.Forms.Padding(2);
            this._updateBtn.Name = "_updateBtn";
            this._updateBtn.Size = new System.Drawing.Size(201, 36);
            this._updateBtn.TabIndex = 5;
            this._updateBtn.Text = "Оновити";
            this._updateBtn.UseVisualStyleBackColor = true;
            this._updateBtn.Click += new System.EventHandler(this._updateBtn_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Location = new System.Drawing.Point(2, 12);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(410, 338);
            this.formsPlot1.TabIndex = 6;
            // 
            // formsPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 362);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this._updateBtn);
            this.Controls.Add(this._randomMode);
            this.Controls.Add(this._centresMode);
            this.Controls.Add(this._fromFirst);
            this.Controls.Add(this._sigmaTB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formsPlot";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _sigmaTB;
        private System.Windows.Forms.RadioButton _fromFirst;
        private System.Windows.Forms.RadioButton _centresMode;
        private System.Windows.Forms.RadioButton _randomMode;
        private System.Windows.Forms.Button _updateBtn;
        private ScottPlot.FormsPlot formsPlot1;
    }
}

