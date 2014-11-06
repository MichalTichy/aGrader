namespace CAC
{
    partial class Input
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
            this.SuspendLayout();
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(78, 165);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(54, 23);
            this.butDel.TabIndex = 8;
            this.butDel.Text = "Odebrat";
            this.butDel.UseVisualStyleBackColor = true;
            // 
            // butAddOrChange
            // 
            this.butAddOrChange.Location = new System.Drawing.Point(12, 165);
            this.butAddOrChange.Name = "butAddOrChange";
            this.butAddOrChange.Size = new System.Drawing.Size(60, 23);
            this.butAddOrChange.TabIndex = 7;
            this.butAddOrChange.Text = "Přidat";
            this.butAddOrChange.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "butAddOrChange bude mít text \"Pridat\" nebo \"Změnit\".\r\n A butDel bude zapnut/vypnu" +
    "t.";
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butAddOrChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Input";
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAddOrChange;
        private System.Windows.Forms.Label label1;
    }
}