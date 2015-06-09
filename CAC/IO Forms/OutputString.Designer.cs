using System.ComponentModel;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    partial class OutputString
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbString = new System.Windows.Forms.TextBox();
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Text";
            // 
            // tbString
            // 
            this.tbString.Location = new System.Drawing.Point(13, 30);
            this.tbString.Name = "tbString";
            this.tbString.Size = new System.Drawing.Size(144, 20);
            this.tbString.TabIndex = 26;
            this.tbString.TextChanged += new System.EventHandler(this.tbString_TextChanged);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(97, 56);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 25;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(13, 56);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 24;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // OutputString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 90);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbString);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutputString";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.OutputString_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private TextBox tbString;
        private Button butClose;
        private Button butAddOrDelete;
    }
}