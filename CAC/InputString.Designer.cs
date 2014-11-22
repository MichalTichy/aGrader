namespace CAC
{
    partial class InputString
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
            this.tbString = new System.Windows.Forms.TextBox();
            this.butDel = new System.Windows.Forms.Button();
            this.butAddOrChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Text";
            // 
            // tbString
            // 
            this.tbString.Location = new System.Drawing.Point(14, 30);
            this.tbString.Name = "tbString";
            this.tbString.Size = new System.Drawing.Size(144, 20);
            this.tbString.TabIndex = 18;
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(98, 56);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(60, 23);
            this.butDel.TabIndex = 17;
            this.butDel.Text = "Zavřít";
            this.butDel.UseVisualStyleBackColor = true;
            // 
            // butAddOrChange
            // 
            this.butAddOrChange.Location = new System.Drawing.Point(14, 56);
            this.butAddOrChange.Name = "butAddOrChange";
            this.butAddOrChange.Size = new System.Drawing.Size(60, 23);
            this.butAddOrChange.TabIndex = 16;
            this.butAddOrChange.Text = "Přidat";
            this.butAddOrChange.UseVisualStyleBackColor = true;
            // 
            // InputString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 90);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbString);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InputString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbString;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrChange;
    }
}