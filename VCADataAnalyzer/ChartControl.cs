using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
namespace VCADataAnalyzer
{
    class ChartControl
    {
        private List<int[]> inData;
        private List<int[]> outData;
        private List<Series> seriesList;
        /* Title Str table, sync with ChartSelect value */
        private string[] mainTitleStr = { "", "시간별 분포", "일간 분포", "주간 분포" };
        private string[] subTitleStr = { "", "일간 누계", "누적 분포", "주간 누계" };
        private string[] dayOfWeekStr = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", " Sat" };

        private int startTime = 0, endTime = 0;

        private DateTime fD, eD;

        private ChartSelect chartEnum;
        private Chart mainChart;
        private Chart subChart;
        private DataParser _parser;
        private bool readyFlag = false;

        public ChartControl(ReportView form, ChartSelect val, List<int[]> data)
        {
            _parser = new DataParser();
            mainChart = form.MainChart;
            subChart = form.SubChart;
            chartEnum = val;
            inData = data;
            readyFlag = false;
        }

        public void init(DateTime startDate, DateTime endDate, int[] TimeRange)
        {
            seriesList = new List<Series>();
            Title mainTitle, subTitle;
            Font titleFont = new Font("Meiryo UI", 18, FontStyle.Bold);

            mainChart.Series.Clear();
            mainChart.Legends.Clear();
            subChart.Series.Clear();
            subChart.Legends.Clear();
            
            fD = startDate;
            eD = endDate;

            startTime = TimeRange[0];
            endTime = TimeRange[1];

            mainChart.Titles.Add("title");
            subChart.Titles.Add("title");
            mainTitle = mainChart.Titles[0];
            subTitle = subChart.Titles[0];
            
            mainTitle.Font = titleFont;
            subTitle.Font = titleFont;
            mainTitle.Text = mainTitleStr[(int)chartEnum];
            subTitle.Text = subTitleStr[(int)chartEnum];                       

            initGrid(mainChart);
            initGrid(subChart);
            set3DtoChartArea(subChart);
            initSeries(mainChart, subChart);
            initLegend(mainChart, subChart);

            readyFlag = true;
        }

        public bool checkReady()
        {
            return readyFlag;
        }

        private void set3DtoChartArea(Chart _chart)
        {
            _chart.ChartAreas[0]. Area3DStyle.Enable3D = true;
            _chart.ChartAreas[0].Area3DStyle.Inclination = 20;
            _chart.ChartAreas[0].Area3DStyle.PointDepth = 100;
            _chart.ChartAreas[0].Area3DStyle.PointGapDepth = 50;
            _chart.ChartAreas[0].Area3DStyle.Rotation = 20;
            _chart.ChartAreas[0].Area3DStyle.WallWidth = 1;
            _chart.ChartAreas[0].Area3DStyle.IsClustered = true;
        }

        private void initLegend(Chart _main, Chart _sub)
        {
            Legend mainLegend = _main.Legends.Add("MainLegend");
            Legend subLegend = _sub.Legends.Add("SubLegend");

            seriesList[0].Legend = "MainLegend";
            seriesList[1].Legend = "MainLegend";
            seriesList[2].Legend = "SubLegend";
            seriesList[3].Legend = "SubLegend";

            initLegendSub(mainLegend);
            initLegendSub(subLegend);
        }

        private void initLegendSub(Legend chartLegend)
        {
            chartLegend.DockedToChartArea = "ChartArea1";
            chartLegend.IsDockedInsideChartArea = false;
            chartLegend.Alignment = System.Drawing.StringAlignment.Center;
            chartLegend.Docking = Docking.Bottom;
            chartLegend.BorderColor = System.Drawing.Color.Black;
        }

        private void initGrid(Chart _chart)
        {
            _chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            _chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            _chart.ChartAreas[0].AxisX.Interval = 1;
        }

        private void initSeries(Chart _main, Chart _sub)
        {
            Series sIn = _main.Series.Add("입장객 수");
            Series sOut = _main.Series.Add("퇴장객 수");
            Series sInTotal = _sub.Series.Add("입장객 수");
            Series sOutTotal = _sub.Series.Add("퇴장객 수");

            sIn.ChartType = SeriesChartType.Column;
            sOut.ChartType = SeriesChartType.Column;

            sInTotal.ChartType = SeriesChartType.Bar;
            sOutTotal.ChartType = SeriesChartType.Bar;
            
            _main.Series["입장객 수"]["DrawingStyle"] = "Cylinder";
            _main.Series["퇴장객 수"]["DrawingStyle"] = "Cylinder";
            _main.Series["입장객 수"]["PointWidth"] = "0.8"; /* value = 0 ~ 2 */
            _main.Series["퇴장객 수"]["PointWidth"] = "0.8"; /* value = 0 ~ 2 */

            _sub.Series["입장객 수"]["DrawingStyle"] = "Default";
            _sub.Series["퇴장객 수"]["DrawingStyle"] = "Default";
            _sub.Series["입장객 수"]["PointWidth"] = "0.8"; /* value = 0 ~ 2 */
            _sub.Series["퇴장객 수"]["PointWidth"] = "0.8"; /* value = 0 ~ 2 */
            sInTotal.YAxisType = AxisType.Secondary;
            sOutTotal.YAxisType = AxisType.Secondary;

            seriesList.Add(sIn);
            seriesList.Add(sOut);
            seriesList.Add(sInTotal);
            seriesList.Add(sOutTotal);
        }

        public void update(DateTime startDate, DateTime endDate, int[] TimeRange)
        {
            fD = startDate;
            eD = endDate;

            startTime = TimeRange[0];
            endTime = TimeRange[1];

            update(seriesList);
        }

        private void update(List<Series> seriesL)
        {
            int[] _inData;
            int[] _outData;
            int _length = 0;

            outData = new List<int[]>();

            foreach(Series s in seriesL)
            {
                s.Points.Clear();
            }
            /* draw main chart */
            outData = _parser.getStatisticalData(inData, chartEnum, fD, eD);

            _inData = outData[0];
            _outData = outData[1];

            _length = _inData.Length;

            /* add series to Main chart */
            for (int i = 0; i < _inData.Length; i++)
            {
                seriesL[0].Points.AddY(_inData[i]);                
                seriesL[1].Points.AddY(_outData[i]);
                switch (chartEnum)
                {
                    case ChartSelect.E_CHART_HOURLY:
                        seriesL[0].Points[i].AxisLabel = (i + 1) + " ~ " + (i + 2);
                        break;
                    case ChartSelect.E_CHART_WEEKLY:
                        seriesL[0].Points[i].AxisLabel = dayOfWeekStr[(int)fD.AddDays(i).DayOfWeek];
                        break;
                    default:
                        break;
                }
            }

            /* draw sub chart */
            outData.Clear();
            
            outData = _parser.getCumulativeData(inData, chartEnum, fD, eD);
            _inData = outData[0];
            _outData = outData[1];
            _length = _inData.Length;
            
            for (int i = 0; i < _inData.Length; i++)
            {
                seriesL[2].Points.AddY(_inData[i]);                
                seriesL[3].Points.AddY(_outData[i]);
                switch (chartEnum)
                {
                    case ChartSelect.E_CHART_HOURLY:
                        /* Do nothing */
                        break;
                    case ChartSelect.E_CHART_WEEKLY:
                        seriesL[2].Points[i].AxisLabel = dayOfWeekStr[(int)fD.AddDays(i).DayOfWeek];
                        break;
                    default:
                        break;
                }
            }

            /* setting additional chart option */
            switch (chartEnum)
            {
                case ChartSelect.E_CHART_HOURLY:
                    mainChart.ChartAreas[0].AxisX.Minimum = startTime - 1;
                    mainChart.ChartAreas[0].AxisX.Maximum = endTime + 1;
                    subChart.ChartAreas[0].AxisX.Minimum = startTime - 1;
                    subChart.ChartAreas[0].AxisX.Maximum = endTime + 1;
                    break;
                case ChartSelect.E_CHART_WEEKLY:                    
                    break;
                default:
                    break;
            }
     
            /* show value to label */
            foreach (Series s in seriesL)
            {
                foreach(DataPoint p in s.Points)
                {
                    if (p.YValues.Length > 0 && (double)p.YValues.GetValue(0) != 0)
                    {
                        p.IsValueShownAsLabel = true;
                    }
                }
            }

        }

    }
}
