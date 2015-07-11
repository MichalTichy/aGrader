using System.ComponentModel;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    partial class ActionRepeatLast
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
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labLastAction = new System.Windows.Forms.Label();
            this.butClose = new System.Windows.Forms.Button();
            this.butAddOrDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // numeric
            // 
            this.numeric.Location = new System.Drawing.Point(108, 46);
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(143, 20);
            this.numeric.TabIndex = 0;
            this.numeric.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Počet opakování";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Akce k zopakování:";
            // 
            // labLastAction
            // 
            this.labLastAction.AutoSize = true;
            this.labLastAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labLastAction.Location = new System.Drawing.Point(12, 22);
            this.labLastAction.Name = "labLastAction";
            this.labLastAction.Size = new System.Drawing.Size(64, 13);
            this.labLastAction.TabIndex = 3;
            this.labLastAction.Text = "Loading...";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(191, 75);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(60, 23);
            this.butClose.TabIndex = 15;
            this.butClose.Text = "Zavřít";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butAddOrDelete
            // 
            this.butAddOrDelete.Location = new System.Drawing.Point(12, 75);
            this.butAddOrDelete.Name = "butAddOrDelete";
            this.butAddOrDelete.Size = new System.Drawing.Size(60, 23);
            this.butAddOrDelete.TabIndex = 14;
            this.butAddOrDelete.Text = "Přidat";
            this.butAddOrDelete.UseVisualStyleBackColor = true;
            this.butAddOrDelete.Click += new System.EventHandler(this.butAddOrChange_Click);
            // 
            // ActionRepeatLast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 110);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butAddOrDelete);
            this.Controls.Add(this.labLastAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActionRepeatLast";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ActionRepeatLast";
            this.Activated += new System.EventHandler(this.InputNumber_Activated);
            this.Shown += new System.EventHandler(this.ActionRepeatLast_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown numeric;
        private Label label1;
        private Label label2;
        private Label labLastAction;
        private Button butClose;
        private Button butAddOrDelete;
    }
}