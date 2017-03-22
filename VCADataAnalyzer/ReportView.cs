using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCADataAnalyzer
{
    public partial class ReportView : Form
    {
        private ChartControl _editChart;
        private CalendarControl _editCalendar;
        private int default_start_time = 8;
        private int default_end_time = 20;
        private List<int[]> inData;        
        
        /* global chart seperator */
        public ChartSelect chartEnum;

        private int[] selectTimeRange;
        private bool reloadPossible = true;

        DateTime prevStartDate, prevEndDate, currentStartDate, currentEndDate;

        public ReportView(ChartSelect chart, List<int[]> data)
        {
            InitializeComponent();

            chartEnum = chart;
            inData = data;
            _editChart = new ChartControl(this, chartEnum, inData);
            _editCalendar = new CalendarControl(this, chartEnum, inData);

            initReportChart();
            drawReportChart();
        }
        
        private void initReportChart()
        {
            selectTimeRange = new int[2];

            selectTimeRange[0] = default_start_time;  /* 시작 시간, 종료 시간은 설정값으로 지정해서 처리하는 것이 나을 것 같다. */
            selectTimeRange[1] = default_end_time;
            initTimeRangeComboBox();

            _editCalendar.init();
            updateStartEndTextBox();

            /* Report Type 별 화면 구성 */
            switch (chartEnum)
            {
                case ChartSelect.E_CHART_HOURLY:
                    /* Do Nothing, Hourly Chart is base chart view */
                    break;
                case ChartSelect.E_CHART_WEEKLY:
                    labelRangeTimeTitle.Visible = false;
                    labelTimeRangeDash.Visible = false;
                    comboStartTime.Visible = false;
                    comboEndTime.Visible = false;
                    break;

                default:
                    break;
            }

            _editChart.init(chartCalendar.SelectionStart, chartCalendar.SelectionEnd, selectTimeRange);
        }

        private void initTimeRangeComboBox()
        {
            int timeRange = 24;
            for(int i = 0; i < timeRange; i++)
            {
                comboStartTime.Items.Add(i.ToString());
                comboEndTime.Items.Add(i.ToString());
            }

            comboEndTime.Items.RemoveAt(0);
            comboEndTime.Items.Add("24");

            comboStartTime.SelectedItem = selectTimeRange[0].ToString();
            comboEndTime.SelectedItem = selectTimeRange[1].ToString();
        }

        private void drawReportChart()
        {
           _editChart.update(chartCalendar.SelectionStart, chartCalendar.SelectionEnd, selectTimeRange);
        }

        private void updateStartEndTextBox()
        {
            textBoxStartDate.Text = chartCalendar.SelectionStart.ToString("yyyy/MM/dd");
            textBoxEndDate.Text = chartCalendar.SelectionEnd.ToString("yyyy/MM/dd");
        }

        private void chartCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            _editCalendar.ChangeRange();
            updateStartEndTextBox();
        }

        private void btnReloadChart_Click(object sender, EventArgs e)
        {
            /* 중복 클릭 무시 - 날짜가 변경됐을때만 새로 그리게 수정 */
            if( prevStartDate != chartCalendar.SelectionStart || prevEndDate != chartCalendar.SelectionEnd)
            {
                drawReportChart();
            }
            else
            {
                return;
            }
        }

        private void comboStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedVal = 0;
            int endTimeVal = 0;
            if(comboEndTime.SelectedItem != null)            
                endTimeVal = Convert.ToInt32(comboEndTime.SelectedItem);            
            else
                endTimeVal = default_end_time;

            if(comboStartTime.SelectedIndex >= 0)
            {
                selectedVal = Convert.ToInt32(comboStartTime.SelectedItem);

                if (endTimeVal <= selectedVal)
                {
                    endTimeVal = selectedVal + 1;
                    comboEndTime.SelectedItem = endTimeVal.ToString();                    
                    selectTimeRange[1] = endTimeVal;
                }
                selectTimeRange[0] = selectedVal;
            }
        }

        private void comboEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedVal = 0;
            int startTimeVal = 0;//Convert.ToInt32(comboStartTime.SelectedItem);
            if (comboStartTime.SelectedItem != null)
                startTimeVal = Convert.ToInt32(comboStartTime.SelectedItem);
            else
                startTimeVal = default_start_time;

            if (comboStartTime.SelectedIndex >= 0)
            {
                selectedVal = Convert.ToInt32(comboEndTime.SelectedItem);

                if (startTimeVal >= selectedVal)
                {
                    startTimeVal = selectedVal - 1;
                    comboStartTime.SelectedItem = startTimeVal.ToString();
                    selectTimeRange[0] = startTimeVal;
                }
                selectTimeRange[1] = selectedVal;
                
            }
        }
    }
}
