using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCADataAnalyzer
{
    class CalendarControl
    {
        private MonthCalendar _calendar;
        private List<int[]> inData;
        private ChartSelect chartEnum;
        private ReportView parentView;
        private int selectDayLimit = 0;

        public CalendarControl(ReportView form, ChartSelect val, List<int[]> data)
        {
            inData = data;
            chartEnum = val;
            parentView = form;
            _calendar = parentView.chartCalendar;
        }

        public void init()
        {
            int[] firstData = new int[4];
            int[] lastData = new int[4];
            DateTime selectedDate;

            

            firstData = inData.First();
            lastData = inData.Last();

            DateTime fD = DateTime.ParseExact(firstData[0].ToString(),
                                                "yyyyMMdd",
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None);
            DateTime lD = DateTime.ParseExact(lastData[0].ToString(),
                                                "yyyyMMdd",
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None);

            _calendar.MinDate = fD;
            _calendar.MaxDate = lD;

            /* set Calendar option depand Chart options */
            switch (chartEnum)
            {
                case ChartSelect.E_CHART_HOURLY:
                    selectDayLimit = 1;
                    break;
                case ChartSelect.E_CHART_WEEKLY:
                    selectDayLimit = 7;
                    break;
                default:
                    try
                    {

                    }
                    catch (InvalidCastException e)
                    {

                    }
                    break;
            }
            /* set Calendar */
            _calendar.MaxSelectionCount = selectDayLimit;
            /* Range에 범위가 지정될 경우 DateChagned callback이 불린다. Start==End일때는 안불린다. */
            _calendar.SetSelectionRange(_calendar.SelectionStart, (_calendar.SelectionStart).AddDays(selectDayLimit - 1));
        }

        public void ChangeRange()
        {
            DateTime lastDate = _calendar.MaxDate;
            switch(chartEnum)
            {
                case ChartSelect.E_CHART_HOURLY:
                    /* Do Nothing */
                    break;
                case ChartSelect.E_CHART_WEEKLY:
                    if (lastDate >= (_calendar.SelectionStart.AddDays(selectDayLimit - 1)))
                    { 
                        lastDate = (_calendar.SelectionStart).AddDays(selectDayLimit - 1);
                    }
                    _calendar.SetSelectionRange(_calendar.SelectionStart, lastDate);
                    break;

                default:
                    try
                    {

                    }
                    catch (InvalidCastException e)
                    {

                    }
                    break;
            }
            
        }
    }
}
