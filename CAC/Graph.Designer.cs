namespace aGrader
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbCorrect = new System.Windows.Forms.CheckBox();
            this.cbWrong = new System.Windows.Forms.CheckBox();
            this.cbProcessorTime = new System.Windows.Forms.CheckBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.chartBIG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBIG)).BeginInit();
            this.SuspendLayout();
            // 
            // chartResults
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartResults.Legends.Add(legend1);
            resources.ApplyResources(this.chartResults, "chartResults");
            this.chartResults.Name = "chartResults";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Lime;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Správně";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Chybně";
            series3.ChartArea = "ChartArea1";
            series3.Enabled = false;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Processor\\ntime";
            this.chartResults.Series.Add(series1);
            this.chartResults.Series.Add(series2);
            this.chartResults.Series.Add(series3);
            // 
            // cbCorrect
            // 
            resources.ApplyResources(this.cbCorrect, "cbCorrect");
            this.cbCorrect.Checked = true;
            this.cbCorrect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCorrect.Name = "cbCorrect";
            this.cbCorrect.UseVisualStyleBackColor = true;
            this.cbCorrect.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbWrong
            // 
            resources.ApplyResources(this.cbWrong, "cbWrong");
            this.cbWrong.Checked = true;
            this.cbWrong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWrong.Name = "cbWrong";
            this.cbWrong.UseVisualStyleBackColor = true;
            this.cbWrong.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbProcessorTime
            // 
            resources.ApplyResources(this.cbProcessorTime, "cbProcessorTime");
            this.cbProcessorTime.Name = "cbProcessorTime";
            this.cbProcessorTime.UseVisualStyleBackColor = true;
            this.cbProcessorTime.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            resources.GetString("cbSort.Items"),
            resources.GetString("cbSort.Items1"),
            resources.GetString("cbSort.Items2"),
            resources.GetString("cbSort.Items3")});
            resources.ApplyResources(this.cbSort, "cbSort");
            this.cbSort.Name = "cbSort";
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Name = "label1";
            // 
            // butSave
            // 
            resources.ApplyResources(this.butSave, "butSave");
            this.butSave.Name = "butSave";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // saveImage
            // 
            this.saveImage.DefaultExt = "bmp";
            resources.ApplyResources(this.saveImage, "saveImage");
            // 
            // chartBIG
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.MaximumAutoSize = 90F;
            chartArea2.Name = "ChartArea1";
            this.chartBIG.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBIG.Legends.Add(legend2);
            resources.ApplyResources(this.chartBIG, "chartBIG");
            this.chartBIG.Name = "chartBIG";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Lime;
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Správně";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Red;
            series5.IsValueShownAsLabel = true;
            series5.Legend = "Legend1";
            series5.Name = "Chybně";
            series6.ChartArea = "ChartArea1";
            series6.Enabled = false;
            series6.IsValueShownAsLabel = true;
            series6.Legend = "Legend1";
            series6.Name = "Processor\\ntime";
            this.chartBIG.Series.Add(series4);
            this.chartBIG.Series.Add(series5);
            this.chartBIG.Series.Add(series6);
            // 
            // Graph
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartBIG);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.cbProcessorTime);
            this.Controls.Add(this.cbWrong);
            this.Controls.Add(this.cbCorrect);
            this.Controls.Add(this.chartResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Graph";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBIG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.CheckBox cbCorrect;
        private System.Windows.Forms.CheckBox cbWrong;
        private System.Windows.Forms.CheckBox cbProcessorTime;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBIG;
    }
}