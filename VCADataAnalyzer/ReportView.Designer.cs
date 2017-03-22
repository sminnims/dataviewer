namespace VCADataAnalyzer
{
    partial class ReportView
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCalendar = new System.Windows.Forms.MonthCalendar();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelRangeDate = new System.Windows.Forms.Label();
            this.comboStartTime = new System.Windows.Forms.ComboBox();
            this.comboEndTime = new System.Windows.Forms.ComboBox();
            this.labelTimeRangeDash = new System.Windows.Forms.Label();
            this.labelRangeTimeTitle = new System.Windows.Forms.Label();
            this.btnReloadChart = new System.Windows.Forms.Button();
            this.SubChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.Black;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.MainChart.Legends.Add(legend1);
            this.MainChart.Location = new System.Drawing.Point(12, 12);
            this.MainChart.Name = "MainChart";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawSideBySide=True, DrawingStyle=Emboss, EmptyPointValue=Zero, PointWidth=0.85, " +
    "MinPixelPointWidth=50";
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VALY";
            series1.LabelFormat = "x => x>0";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.MainChart.Series.Add(series1);
            this.MainChart.Series.Add(series2);
            this.MainChart.Size = new System.Drawing.Size(699, 460);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // chartCalendar
            // 
            this.chartCalendar.Location = new System.Drawing.Point(741, 12);
            this.chartCalendar.Name = "chartCalendar";
            this.chartCalendar.TabIndex = 1;
            this.chartCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.chartCalendar_DateChanged);
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Enabled = false;
            this.textBoxStartDate.Location = new System.Drawing.Point(812, 207);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.Size = new System.Drawing.Size(100, 21);
            this.textBoxStartDate.TabIndex = 2;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Enabled = false;
            this.textBoxEndDate.Location = new System.Drawing.Point(812, 234);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(100, 21);
            this.textBoxEndDate.TabIndex = 3;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(739, 210);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(67, 12);
            this.labelStartDate.TabIndex = 4;
            this.labelStartDate.Text = "Start Date :";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(742, 237);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(64, 12);
            this.labelEndDate.TabIndex = 5;
            this.labelEndDate.Text = "End Date :";
            // 
            // labelRangeDate
            // 
            this.labelRangeDate.AutoSize = true;
            this.labelRangeDate.Location = new System.Drawing.Point(739, 183);
            this.labelRangeDate.Name = "labelRangeDate";
            this.labelRangeDate.Size = new System.Drawing.Size(94, 12);
            this.labelRangeDate.TabIndex = 6;
            this.labelRangeDate.Text = "Selected Range";
            // 
            // comboStartTime
            // 
            this.comboStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStartTime.FormattingEnabled = true;
            this.comboStartTime.Location = new System.Drawing.Point(741, 292);
            this.comboStartTime.Name = "comboStartTime";
            this.comboStartTime.Size = new System.Drawing.Size(50, 20);
            this.comboStartTime.TabIndex = 7;
            this.comboStartTime.SelectedIndexChanged += new System.EventHandler(this.comboStartTime_SelectedIndexChanged);
            // 
            // comboEndTime
            // 
            this.comboEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEndTime.FormattingEnabled = true;
            this.comboEndTime.Location = new System.Drawing.Point(812, 292);
            this.comboEndTime.Name = "comboEndTime";
            this.comboEndTime.Size = new System.Drawing.Size(50, 20);
            this.comboEndTime.TabIndex = 8;
            this.comboEndTime.SelectedIndexChanged += new System.EventHandler(this.comboEndTime_SelectedIndexChanged);
            // 
            // labelTimeRangeDash
            // 
            this.labelTimeRangeDash.AutoSize = true;
            this.labelTimeRangeDash.Location = new System.Drawing.Point(795, 295);
            this.labelTimeRangeDash.Name = "labelTimeRangeDash";
            this.labelTimeRangeDash.Size = new System.Drawing.Size(11, 12);
            this.labelTimeRangeDash.TabIndex = 9;
            this.labelTimeRangeDash.Text = "-";
            // 
            // labelRangeTimeTitle
            // 
            this.labelRangeTimeTitle.AutoSize = true;
            this.labelRangeTimeTitle.Location = new System.Drawing.Point(742, 277);
            this.labelRangeTimeTitle.Name = "labelRangeTimeTitle";
            this.labelRangeTimeTitle.Size = new System.Drawing.Size(69, 12);
            this.labelRangeTimeTitle.TabIndex = 10;
            this.labelRangeTimeTitle.Text = "시간대 선택";
            // 
            // btnReloadChart
            // 
            this.btnReloadChart.Location = new System.Drawing.Point(874, 292);
            this.btnReloadChart.Name = "btnReloadChart";
            this.btnReloadChart.Size = new System.Drawing.Size(93, 20);
            this.btnReloadChart.TabIndex = 11;
            this.btnReloadChart.Text = "Reload";
            this.btnReloadChart.UseVisualStyleBackColor = true;
            this.btnReloadChart.Click += new System.EventHandler(this.btnReloadChart_Click);
            // 
            // SubChart
            // 
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.PointGapDepth = 50;
            chartArea2.Area3DStyle.Rotation = 20;
            chartArea2.Area3DStyle.WallWidth = 1;
            chartArea2.Name = "ChartArea1";
            this.SubChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.SubChart.Legends.Add(legend2);
            this.SubChart.Location = new System.Drawing.Point(12, 478);
            this.SubChart.Name = "SubChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            series4.YValuesPerPoint = 2;
            this.SubChart.Series.Add(series3);
            this.SubChart.Series.Add(series4);
            this.SubChart.Size = new System.Drawing.Size(699, 340);
            this.SubChart.TabIndex = 12;
            this.SubChart.Text = "SubChart";
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 830);
            this.Controls.Add(this.SubChart);
            this.Controls.Add(this.btnReloadChart);
            this.Controls.Add(this.labelRangeTimeTitle);
            this.Controls.Add(this.labelTimeRangeDash);
            this.Controls.Add(this.comboEndTime);
            this.Controls.Add(this.comboStartTime);
            this.Controls.Add(this.labelRangeDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxStartDate);
            this.Controls.Add(this.chartCalendar);
            this.Controls.Add(this.MainChart);
            this.Name = "ReportView";
            this.Text = "ReportView";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        public System.Windows.Forms.MonthCalendar chartCalendar;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelRangeDate;
        private System.Windows.Forms.ComboBox comboStartTime;
        private System.Windows.Forms.ComboBox comboEndTime;
        private System.Windows.Forms.Label labelTimeRangeDash;
        private System.Windows.Forms.Label labelRangeTimeTitle;
        private System.Windows.Forms.Button btnReloadChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart SubChart;
    }
}