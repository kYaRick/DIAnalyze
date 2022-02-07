namespace DIAnalyze_lab_7
{
    partial class MainForm
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
            this.formsPlot = new ScottPlot.FormsPlot();
            this.update = new System.Windows.Forms.Button();
            this.alphaTBox = new System.Windows.Forms.TextBox();
            this.alphaLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // formsPlot
            // 
            this.formsPlot.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot.Location = new System.Drawing.Point(12, 12);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(917, 426);
            this.formsPlot.TabIndex = 0;
            // 
            // update
            // 
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Location = new System.Drawing.Point(459, 438);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(62, 31);
            this.update.TabIndex = 1;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // alphaTBox
            // 
            this.alphaTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaTBox.Location = new System.Drawing.Point(429, 447);
            this.alphaTBox.Name = "alphaTBox";
            this.alphaTBox.Size = new System.Drawing.Size(24, 13);
            this.alphaTBox.TabIndex = 2;
            this.alphaTBox.Text = "0,5";
            // 
            // alphaLable
            // 
            this.alphaLable.AutoSize = true;
            this.alphaLable.BackColor = System.Drawing.Color.Transparent;
            this.alphaLable.Location = new System.Drawing.Point(387, 447);
            this.alphaLable.Name = "alphaLable";
            this.alphaLable.Size = new System.Drawing.Size(36, 13);
            this.alphaLable.TabIndex = 3;
            this.alphaLable.Text = "alpha:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 487);
            this.Controls.Add(this.alphaLable);
            this.Controls.Add(this.alphaTBox);
            this.Controls.Add(this.update);
            this.Controls.Add(this.formsPlot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox alphaTBox;
        private System.Windows.Forms.Label alphaLable;
    }
}

