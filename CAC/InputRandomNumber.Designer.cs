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
            this.tbNumberMin = new System.Windows.Forms.TextBox();
            this.butDel = new System.Windows.Forms.Button();
            this.butAddOrChange = new System.Windows.Forms.Button();
            this.tbNumberMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            // tbNumberMin
            // 
            this.tbNumberMin.Location = new System.Drawing.Point(16, 50);
            this.tbNumberMin.Name = "tbNumberMin";
            this.tbNumberMin.Size = new System.Drawing.Size(58, 20);
            this.tbNumberMin.TabIndex = 18;
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(100, 76);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(60, 23);
            this.butDel.TabIndex = 17;
            this.butDel.Text = "Odebrat";
            this.butDel.UseVisualStyleBackColor = true;
            // 
            // butAddOrChange
            // 
            this.butAddOrChange.Location = new System.Drawing.Point(14, 76);
            this.butAddOrChange.Name = "butAddOrChange";
            this.butAddOrChange.Size = new System.Drawing.Size(60, 23);
            this.butAddOrChange.TabIndex = 16;
            this.butAddOrChange.Text = "Přidat";
            this.butAddOrChange.UseVisualStyleBackColor = true;
            // 
            // tbNumberMax
            // 
            this.tbNumberMax.Location = new System.Drawing.Point(100, 50);
            this.tbNumberMax.Name = "tbNumberMax";
            this.tbNumberMax.Size = new System.Drawing.Size(58, 20);
            this.tbNumberMax.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(80, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "-";
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
            this.label4.Location = new System.Drawing.Point(132, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "max";
            // 
            // InputRandomNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 109);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumberMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumberMin);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputRandomNumber";
            this.Text = "InputRandomNumber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumberMin;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrChange;
        private System.Windows.Forms.TextBox tbNumberMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}