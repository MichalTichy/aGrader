using System.ComponentModel;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    partial class OutputNumberBasedOnRandomInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.lbNumbers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(247, 199);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 15;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(14, 199);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 14;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrDelete_Click);
            // 
            // lbNumbers
            // 
            this.lbNumbers.FormattingEnabled = true;
            this.lbNumbers.Location = new System.Drawing.Point(14, 38);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNumbers.Size = new System.Drawing.Size(293, 108);
            this.lbNumbers.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 19;
            this.label1.Text = "Číslo závislé na\r\nnáhodném vstupu";
            // 
            // tbMath
            // 
            this.tbMath.Location = new System.Drawing.Point(14, 173);
            this.tbMath.Name = "tbMath";
            this.tbMath.Size = new System.Drawing.Size(292, 20);
            this.tbMath.TabIndex = 22;
            this.tbMath.Leave += new System.EventHandler(this.tbMath_Leave);
            // 
            // OutputNumberBasedOnRandomInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 228);
            this.Controls.Add(this.tbMath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNumbers);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutputNumberBasedOnRandomInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Output";
            this.Activated += new System.EventHandler(this.OutputNumberBasedOnRandomInput_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button butClose;
        private Button butAddOrDelete;
        private ListBox lbNumbers;
        private Label label1;
        private TextBox tbMath;
    }
}