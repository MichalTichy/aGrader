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
            this.cbRanNumInputs = new System.Windows.Forms.ComboBox();
            this.tbProperities = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butRemove = new System.Windows.Forms.Button();
            this.butAddToList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(247, 269);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 15;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(14, 269);
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
            this.lbNumbers.Location = new System.Drawing.Point(14, 155);
            this.lbNumbers.Name = "lbNumbers";
            this.lbNumbers.Size = new System.Drawing.Size(293, 108);
            this.lbNumbers.TabIndex = 16;
            // 
            // cbRanNumInputs
            // 
            this.cbRanNumInputs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRanNumInputs.FormattingEnabled = true;
            this.cbRanNumInputs.Location = new System.Drawing.Point(14, 42);
            this.cbRanNumInputs.Name = "cbRanNumInputs";
            this.cbRanNumInputs.Size = new System.Drawing.Size(293, 21);
            this.cbRanNumInputs.TabIndex = 17;
            this.cbRanNumInputs.DropDown += new System.EventHandler(this.cbRanNumInputs_DropDown);
            this.cbRanNumInputs.SelectedIndexChanged += new System.EventHandler(this.cbRanNumInputs_SelectedIndexChanged);
            // 
            // tbProperities
            // 
            this.tbProperities.Enabled = false;
            this.tbProperities.Location = new System.Drawing.Point(14, 69);
            this.tbProperities.Name = "tbProperities";
            this.tbProperities.Size = new System.Drawing.Size(293, 20);
            this.tbProperities.TabIndex = 18;
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
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(15, 126);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(293, 23);
            this.butRemove.TabIndex = 20;
            this.butRemove.Text = "Smazat vybraný";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // butAddToList
            // 
            this.butAddToList.Location = new System.Drawing.Point(15, 95);
            this.butAddToList.Name = "butAddToList";
            this.butAddToList.Size = new System.Drawing.Size(293, 23);
            this.butAddToList.TabIndex = 21;
            this.butAddToList.Text = "Přidat";
            this.butAddToList.UseVisualStyleBackColor = true;
            this.butAddToList.Click += new System.EventHandler(this.butAddToList_Click);
            // 
            // OutputNumberBasedOnRandomInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 299);
            this.Controls.Add(this.butAddToList);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProperities);
            this.Controls.Add(this.cbRanNumInputs);
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
        private ComboBox cbRanNumInputs;
        private TextBox tbProperities;
        private Label label1;
        private Button butRemove;
        private Button butAddToList;
    }
}