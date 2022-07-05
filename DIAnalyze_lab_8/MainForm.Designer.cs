namespace DIAnalyze_lab_8
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
            this.alphaTB = new System.Windows.Forms.TextBox();
            this.betaTB = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formsPlot
            // 
            this.formsPlot.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot.Location = new System.Drawing.Point(13, 13);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(604, 425);
            this.formsPlot.TabIndex = 0;
            // 
            // alphaTB
            // 
            this.alphaTB.Location = new System.Drawing.Point(614, 13);
            this.alphaTB.Name = "alphaTB";
            this.alphaTB.Size = new System.Drawing.Size(243, 20);
            this.alphaTB.TabIndex = 1;
            this.alphaTB.Text = "0,2";
            // 
            // betaTB
            // 
            this.betaTB.Location = new System.Drawing.Point(614, 40);
            this.betaTB.Name = "betaTB";
            this.betaTB.Size = new System.Drawing.Size(243, 20);
            this.betaTB.TabIndex = 2;
            this.betaTB.Text = "0,2";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(614, 67);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(243, 28);
            this.update.TabIndex = 3;
            this.update.Text = "Оновити";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 450);
            this.Controls.Add(this.update);
            this.Controls.Add(this.betaTB);
            this.Controls.Add(this.alphaTB);
            this.Controls.Add(this.formsPlot);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private System.Windows.Forms.TextBox alphaTB;
        private System.Windows.Forms.TextBox betaTB;
        private System.Windows.Forms.Button update;
    }
}

