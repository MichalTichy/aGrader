namespace CAC.IO_Forms
{
    partial class OutputNumberBasedOnRandomInput
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
            this.tbMath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNumbers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(239, 198);
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 198);
            // 
            // tbMath
            // 
            this.tbMath.Location = new System.Drawing.Point(12, 172);
            this.tbMath.Name = "tbMath";
            this.tbMath.Size = new System.Drawing.Size(287, 20);
            this.tbMath.TabIndex = 25;
            this.tbMath.Leave += new System.EventHandler(this.tbMath_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "Číslo závislé na\r\nnáhodném vstupu";
            // 
            // lbNumbers
            // 
            this.lbNumbers.FormattingEnabled = true;
            this.lbNumbers.Location = new System.Drawing.Point(12, 37);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNumbers.Size = new System.Drawing.Size(287, 108);
            this.lbNumbers.TabIndex = 23;
            // 
            // OutputNumberBasedOnRandomInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(311, 230);
            this.Controls.Add(this.tbMath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNumbers);
            this.Name = "OutputNumberBasedOnRandomInput";
            this.Activated += new System.EventHandler(this.OutputNumberBasedOnRandomInput_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.lbNumbers, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbMath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbNumbers;
    }
}
