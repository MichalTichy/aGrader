namespace CAC
{
    partial class InputNumber
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
            this.butDel = new System.Windows.Forms.Button();
            this.butAddOrChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(96, 55);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(60, 23);
            this.butDel.TabIndex = 13;
            this.butDel.Text = "Zavřít";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAddOrChange
            // 
            this.butAddOrChange.Location = new System.Drawing.Point(12, 55);
            this.butAddOrChange.Name = "butAddOrChange";
            this.butAddOrChange.Size = new System.Drawing.Size(60, 23);
            this.butAddOrChange.TabIndex = 12;
            this.butAddOrChange.Text = "Přidat";
            this.butAddOrChange.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Číslo";
            // 
            // numeric
            // 
            this.numeric.Location = new System.Drawing.Point(12, 25);
            this.numeric.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numeric.Minimum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            -2147483648});
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(144, 20);
            this.numeric.TabIndex = 16;
            this.numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeric.ThousandsSeparator = true;
            // 
            // InputNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 90);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric;

    }
}