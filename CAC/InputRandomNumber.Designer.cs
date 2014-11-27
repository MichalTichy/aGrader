namespace CAC
{
    partial class InputRandomNumber
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
            this.label1 = new System.Windows.Forms.Label();
            this.butDel = new System.Windows.Forms.Button();
            this.butAddOrChange = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.labErr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Číslo";
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(100, 128);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(58, 23);
            this.butDel.TabIndex = 17;
            this.butDel.Text = "Zavřít";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAddOrChange
            // 
            this.butAddOrChange.Location = new System.Drawing.Point(12, 128);
            this.butAddOrChange.Name = "butAddOrChange";
            this.butAddOrChange.Size = new System.Drawing.Size(60, 23);
            this.butAddOrChange.TabIndex = 16;
            this.butAddOrChange.Text = "Přidat";
            this.butAddOrChange.UseVisualStyleBackColor = true;
            this.butAddOrChange.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "max";
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(12, 50);
            this.numMin.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            -2147483648});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(148, 20);
            this.numMin.TabIndex = 24;
            this.numMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMin.ThousandsSeparator = true;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(12, 102);
            this.numMax.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            -2147483648});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(146, 20);
            this.numMax.TabIndex = 25;
            this.numMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMax.ThousandsSeparator = true;
            this.numMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // labErr
            // 
            this.labErr.AutoSize = true;
            this.labErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(3, 73);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(0, 13);
            this.labErr.TabIndex = 26;
            // 
            // InputRandomNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 160);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputRandomNumber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InputRandomNumber";
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label labErr;
    }
}