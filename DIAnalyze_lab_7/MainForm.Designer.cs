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
            this.SuspendLayout();
            // 
            // formsPlot
            // 
            this.formsPlot.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot.Location = new System.Drawing.Point(12, 12);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(629, 426);
            this.formsPlot.TabIndex = 0;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(648, 38);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(294, 31);
            this.update.TabIndex = 1;
            this.update.Text = "Оновити";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // alphaTBox
            // 
            this.alphaTBox.Location = new System.Drawing.Point(648, 12);
            this.alphaTBox.Name = "alphaTBox";
            this.alphaTBox.Size = new System.Drawing.Size(294, 20);
            this.alphaTBox.TabIndex = 2;
            this.alphaTBox.Text = "0,5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 452);
            this.Controls.Add(this.alphaTBox);
            this.Controls.Add(this.update);
            this.Controls.Add(this.formsPlot);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox alphaTBox;
    }
}

