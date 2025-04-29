namespace Login_Day2
{
    partial class Staticresult
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StaticsByCourse_groupBox = new System.Windows.Forms.GroupBox();
            this.StaticsByResult_groupBox = new System.Windows.Forms.GroupBox();
            this.StaticsByCourse_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Pass_lb = new System.Windows.Forms.Label();
            this.Fail_lb = new System.Windows.Forms.Label();
            this.courseListBox = new System.Windows.Forms.ListBox();
            this.StaticsByCourse_groupBox.SuspendLayout();
            this.StaticsByResult_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaticsByCourse_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).BeginInit();
            this.SuspendLayout();
            // 
            // StaticsByCourse_groupBox
            // 
            this.StaticsByCourse_groupBox.Controls.Add(this.courseListBox);
            this.StaticsByCourse_groupBox.Controls.Add(this.StaticsByCourse_chart);
            this.StaticsByCourse_groupBox.Location = new System.Drawing.Point(12, 12);
            this.StaticsByCourse_groupBox.Name = "StaticsByCourse_groupBox";
            this.StaticsByCourse_groupBox.Size = new System.Drawing.Size(458, 421);
            this.StaticsByCourse_groupBox.TabIndex = 1;
            this.StaticsByCourse_groupBox.TabStop = false;
            this.StaticsByCourse_groupBox.Text = "Statics By Course";
            // 
            // StaticsByResult_groupBox
            // 
            this.StaticsByResult_groupBox.Controls.Add(this.Fail_lb);
            this.StaticsByResult_groupBox.Controls.Add(this.Pass_lb);
            this.StaticsByResult_groupBox.Controls.Add(this.resultChart);
            this.StaticsByResult_groupBox.Location = new System.Drawing.Point(485, 21);
            this.StaticsByResult_groupBox.Name = "StaticsByResult_groupBox";
            this.StaticsByResult_groupBox.Size = new System.Drawing.Size(446, 407);
            this.StaticsByResult_groupBox.TabIndex = 2;
            this.StaticsByResult_groupBox.TabStop = false;
            this.StaticsByResult_groupBox.Text = "Statics By Result";
            this.StaticsByResult_groupBox.Enter += new System.EventHandler(this.StaticsByResult_groupBox_Enter);
            // 
            // StaticsByCourse_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.StaticsByCourse_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.StaticsByCourse_chart.Legends.Add(legend1);
            this.StaticsByCourse_chart.Location = new System.Drawing.Point(144, 19);
            this.StaticsByCourse_chart.Name = "StaticsByCourse_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.StaticsByCourse_chart.Series.Add(series1);
            this.StaticsByCourse_chart.Size = new System.Drawing.Size(300, 300);
            this.StaticsByCourse_chart.TabIndex = 0;
            this.StaticsByCourse_chart.Text = "chart1";
            // 
            // resultChart
            // 
            chartArea2.Name = "ChartArea1";
            this.resultChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.resultChart.Legends.Add(legend2);
            this.resultChart.Location = new System.Drawing.Point(140, 28);
            this.resultChart.Name = "resultChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.resultChart.Series.Add(series2);
            this.resultChart.Size = new System.Drawing.Size(300, 300);
            this.resultChart.TabIndex = 0;
            this.resultChart.Text = "chart2";
            // 
            // Pass_lb
            // 
            this.Pass_lb.AutoSize = true;
            this.Pass_lb.Location = new System.Drawing.Point(27, 41);
            this.Pass_lb.Name = "Pass_lb";
            this.Pass_lb.Size = new System.Drawing.Size(33, 13);
            this.Pass_lb.TabIndex = 5;
            this.Pass_lb.Text = "Pass:";
            // 
            // Fail_lb
            // 
            this.Fail_lb.AutoSize = true;
            this.Fail_lb.Location = new System.Drawing.Point(27, 78);
            this.Fail_lb.Name = "Fail_lb";
            this.Fail_lb.Size = new System.Drawing.Size(26, 13);
            this.Fail_lb.TabIndex = 6;
            this.Fail_lb.Text = "Fail:";
            // 
            // courseListBox
            // 
            this.courseListBox.FormattingEnabled = true;
            this.courseListBox.Location = new System.Drawing.Point(20, 37);
            this.courseListBox.Name = "courseListBox";
            this.courseListBox.Size = new System.Drawing.Size(120, 95);
            this.courseListBox.TabIndex = 1;
            // 
            // Staticresult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 440);
            this.Controls.Add(this.StaticsByResult_groupBox);
            this.Controls.Add(this.StaticsByCourse_groupBox);
            this.Name = "Staticresult";
            this.Text = "Staticresult";
            this.Load += new System.EventHandler(this.Staticresult_Load);
            this.StaticsByCourse_groupBox.ResumeLayout(false);
            this.StaticsByResult_groupBox.ResumeLayout(false);
            this.StaticsByResult_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaticsByCourse_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox StaticsByCourse_groupBox;
        private System.Windows.Forms.GroupBox StaticsByResult_groupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart StaticsByCourse_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart resultChart;
        private System.Windows.Forms.Label Fail_lb;
        private System.Windows.Forms.Label Pass_lb;
        private System.Windows.Forms.ListBox courseListBox;
    }
}