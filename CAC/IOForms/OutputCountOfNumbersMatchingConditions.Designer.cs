namespace aGrader.IOForms
{
    partial class OutputCountOfNumbersMatchingConditions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputCountOfNumbersMatchingConditions));
            this.numCountOfNumbers = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butRemoveConditon = new System.Windows.Forms.Button();
            this.butAddCondition = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioOutputs = new System.Windows.Forms.RadioButton();
            this.radioInputs = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClose
            // 
            resources.ApplyResources(this.butClose, "butClose");
            // 
            // butAddOrDelete
            // 
            resources.ApplyResources(this.butAddOrDelete, "butAddOrDelete");
            // 
            // numCountOfNumbers
            // 
            resources.ApplyResources(this.numCountOfNumbers, "numCountOfNumbers");
            this.numCountOfNumbers.Name = "numCountOfNumbers";
            this.numCountOfNumbers.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // butRemoveConditon
            // 
            resources.ApplyResources(this.butRemoveConditon, "butRemoveConditon");
            this.butRemoveConditon.Name = "butRemoveConditon";
            this.butRemoveConditon.UseVisualStyleBackColor = true;
            this.butRemoveConditon.Click += new System.EventHandler(this.butRemoveConditon_Click);
            // 
            // butAddCondition
            // 
            resources.ApplyResources(this.butAddCondition, "butAddCondition");
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.UseVisualStyleBackColor = true;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // tbCondition
            // 
            resources.ApplyResources(this.tbCondition, "tbCondition");
            this.tbCondition.Name = "tbCondition";
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            resources.ApplyResources(this.lbConditions, "lbConditions");
            this.lbConditions.Name = "lbConditions";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // radioOutputs
            // 
            resources.ApplyResources(this.radioOutputs, "radioOutputs");
            this.radioOutputs.Name = "radioOutputs";
            this.radioOutputs.UseVisualStyleBackColor = true;
            // 
            // radioInputs
            // 
            resources.ApplyResources(this.radioInputs, "radioInputs");
            this.radioInputs.Checked = true;
            this.radioInputs.Name = "radioInputs";
            this.radioInputs.TabStop = true;
            this.radioInputs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioOutputs);
            this.panel1.Controls.Add(this.radioInputs);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Name = "label4";
            // 
            // OutputCountOfNumbersMatchingConditions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numCountOfNumbers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butRemoveConditon);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.tbCondition);
            this.Controls.Add(this.lbConditions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "OutputCountOfNumbersMatchingConditions";
            this.Activated += new System.EventHandler(this.OutputNumber_Activated);
            this.Controls.SetChildIndex(this.butAddOrDelete, 0);
            this.Controls.SetChildIndex(this.butClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbConditions, 0);
            this.Controls.SetChildIndex(this.tbCondition, 0);
            this.Controls.SetChildIndex(this.butAddCondition, 0);
            this.Controls.SetChildIndex(this.butRemoveConditon, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numCountOfNumbers, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numCountOfNumbers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCountOfNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRemoveConditon;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioOutputs;
        private System.Windows.Forms.RadioButton radioInputs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}
