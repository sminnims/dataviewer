using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace VCADataAnalyzer
{
    class DataParser
    {
        /* 생성 파일에 따라 cell 넘버 변경 */
        private int inDataCellNum = 2;
        private int outDataCellNum = 4;
        private int frameTimeCellNum = 1;

        private int prevInCnt, InCnt, prevOutCnt, OutCnt;
        private int baseDate, inputDate, addDays;
        private Int32 baseTime, inputTime;
        private int[] inputData;
        public List<int[]> parsedDataList = new List<int[]>();
        //int a = E_CHART_NONE;

        public List<int> hourlyInData = new List<int>();
        public List<int> dailyInData = new List<int>();
        public List<int> weeklyInData = new List<int>();

        FileInfo objFile;

        private int updateDateAddDays(DateTime bDate, int days)
        {
            DateTime date;
            int dateInt;

            date = bDate.AddDays(addDays);
            dateInt = Int32.Parse(date.ToString("yyyyMMdd"));

            return dateInt;

        }

        public void Parse_CSV(String Filename)
        {
            objFile = new FileInfo(Filename);

            baseDate = Int32.Parse(objFile.CreationTime.ToString("yyyyMMdd"));//objFile.CreationTime.Year * 10000 + objFile.CreationTime.Month * 100 + objFile.CreationTime.Day;
            baseTime = Int32.Parse(objFile.CreationTime.ToString("HHmmss"));//objFile.CreationTime.Hour * 10000000 + objFile.CreationTime.Minute * 100000 + objFile.CreationTime.Second* 1000;

            MyParserDataInit();

            using (TextFieldParser parser = new TextFieldParser(Filename))
            {
                string[] tmp_result;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        tmp_result = field.Split(',');
                        if(tmp_result[inDataCellNum].Length != 0)
                        {
                            InCnt = Convert.ToInt32(tmp_result[inDataCellNum]);
                            OutCnt = Convert.ToInt32(tmp_result[outDataCellNum]);
                            if (parsedDataList.Count() == 0 || parser.EndOfData 
                                || prevInCnt != InCnt || prevOutCnt != OutCnt)
                            {
                                AddEelementToList(tmp_result);
                                //TODO: Process field
                            }
                        }
                    } // foreach ~
                } // while ~
            } // using ~
            
        } // public void Parse_CSV(String Filename)

        private void AddEelementToList(string[] data)
        {
            inputData = new int[4];

#if (false)
            inputTime = baseTime + Convert.ToInt32(data[frameTimeCellNum].Remove(data[frameTimeCellNum].Length - 3, 3));//(Convert.ToInt64(data[frameTimeCellNum])/1000);

            /* 시간값 보정 HHmmss -> baseTime+data식에서 mm/ss가 60이상일 수 있다. */
            tempData = inputTime % 100;
            if(tempData > 60)
            {
                inputTime -= 60;  /* min 60sec */
                inputTime += 100; /* add 1min */
            }

            tempData = (inputTime / 100) % 100;
            if(tempData > 60)
            {
                inputTime -= 6000; /* min 60min */
                inputTime += 10000; /* add 1hour */
            }

            addDays = inputTime / (24 * 10000);

            inputDate = updateDateAddDays(objFile.CreationTime, addDays);
            inputTime = inputTime - (addDays * 24 * 10000);
#endif
            inputDate = Convert.ToInt32(data[frameTimeCellNum].Substring(0, 8)); /* get date: yyyyMMdd */
            inputTime = Convert.ToInt32(data[frameTimeCellNum].Substring(8, 6)); /* get Time : hhMMss */
            inputData[0] = inputDate;
            inputData[1] = inputTime;
            inputData[2] = InCnt;
            inputData[3] = OutCnt;
            parsedDataList.Add(inputData);
            prevInCnt = InCnt;
            prevOutCnt = OutCnt;
        }

        private void ClearAllList()
        {
            parsedDataList.Clear();
        }

        private void ClearAllVar()
        {
            prevInCnt = 0;
            InCnt = 0;
            prevOutCnt = 0;
            OutCnt = 0;
        }

        public List<int[]> getStatisticalData(List<int[]> data, ChartSelect chart, DateTime fD, DateTime eD)
        {
            List<int[]> rtnData = new List<int[]>();
            List<int[]> parsedData = new List<int[]>();
            int[] inData;
            int[] outData;

            int[] getData = new int[4];
            int[] tempData = new int[4];
            int baseInCnt = 0, baseOutCnt = 0, baseTime = 0;
            int firstIdx = 0, lastIdx = 0, getIdx = 0;

            switch (chart)
            {
                case ChartSelect.E_CHART_HOURLY:                    
                    #region HOURT_STAT          
                    int HourRange = 0;
                    /* find first element on selected date */
                    getData = data.Find(
                            delegate (int[] dt)
                            {
                                firstIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );
                    HourRange = 24; /* temporary 24 */

                    baseTime = getData[1] / 10000; /* get Hour from time(HHmmss) */
                    baseInCnt = getData[2]; /* get IN cnt */

                    /* 선택한 날짜가 시작날짜가 아닐 경우 baseCnt는 이전날의 마지막 Cnt로 잡혀야 한다. */
                    if(baseInCnt != 0)
                    {
                        tempData = getData;
                        DateTime prevDate = fD.AddDays(-1);                        
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(prevDate.ToString("yyyyMMdd"));
                            }
                        );

                        if (getData == null)
                            getData = tempData;
                        baseInCnt = getData[2];
                    }

                    baseOutCnt = getData[3]; /* get OUT cnt */                   

                    getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                lastIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );

                    inData = new int[HourRange];
                    outData = new int[HourRange];

                    /* find data hourly */
                    for (int i = baseTime; i < HourRange; i++)
                    {
                        getIdx = data.FindIndex(firstIdx, lastIdx - firstIdx + 1,
                                delegate (int[] dt)
                                {
                                    int hour = dt[1] / 10000; /* get HH from HHmmss */
                                    return hour > baseTime;
                                }
                            );
                        if (getIdx >= 0)
                        {
                            getData = data[getIdx];

                            baseTime++;
                            inData[i] = getData[2] - baseInCnt;
                            outData[i] = getData[3] - baseOutCnt;

                            baseInCnt = getData[2];
                            baseOutCnt = getData[3];

                            firstIdx = getIdx;
                        }
                        else
                        {
                            getData = data[lastIdx];
                            inData[i] = getData[2] - baseInCnt;
                            outData[i] = getData[3] - baseOutCnt;
                            break;
                        }
                    }

                    rtnData.Add(inData);
                    rtnData.Add(outData);
                    #endregion
                    break;

                case ChartSelect.E_CHART_WEEKLY:
                    #region WEEK_STAT         
                    int WeekRange = 7;           
                    /* find first element on selected date */
                    getData = data.Find(
                            delegate (int[] dt)
                            {
                                firstIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );
                                        
                    baseInCnt = getData[2]; /* get IN cnt */
                    /* 선택한 날짜가 시작날짜가 아닐 경우 baseCnt는 이전날의 마지막 Cnt로 잡혀야 한다. */
                    if (baseInCnt != 0)
                    {
                        DateTime prevDate = fD.AddDays(-1);
                        tempData = getData;
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(prevDate.ToString("yyyyMMdd"));
                            }
                        );

                        if (getData == null)
                            getData = tempData;
                        baseInCnt = getData[2];
                    }
                    baseOutCnt = getData[3]; /* get OUT cnt */

                    getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                lastIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(eD.ToString("yyyyMMdd"));
                            }
                        );

                    inData = new int[WeekRange];
                    outData = new int[WeekRange];

                    DateTime currentDate;
                    currentDate = fD; /* get search date */
                    /* find data hourly */
                    for (int i = 0; i < WeekRange; i++)
                    {                        
                        /* 각 날짜의 firstIdx - lastIdx의 데이터값을 저장하고 하루씩 이동, 1주일 치 기재 */
                        /* 해당 날짜의 마지막 data를 구한다 */
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(currentDate.ToString("yyyyMMdd"));
                            }
                        );
                        if (getData != null) /* find data */
                        {
                            inData[i] = getData[2] - baseInCnt;
                            outData[i] = getData[3] - baseOutCnt;

                            baseInCnt = getData[2];
                            baseOutCnt = getData[3];
                            currentDate = currentDate.AddDays(1);
                            firstIdx = getIdx;
                        }
                    }

                    rtnData.Add(inData);
                    rtnData.Add(outData);

                    #endregion
                    break;
                default:
                    break;
            }

            return rtnData;
        }

        public List<int[]> getCumulativeData(List<int[]> data, ChartSelect chart, DateTime fD, DateTime eD)
        {
            List<int[]> rtnData = new List<int[]>();
            List<int[]> parsedData = new List<int[]>();
            int[] inData;
            int[] outData;

            int[] getData = new int[4];
            int[] tempData = new int[4];
            int baseInCnt = 0, baseOutCnt = 0, baseTime = 0;
            int firstIdx = 0, lastIdx = 0, getIdx = 0;

            switch (chart)
            {
                case ChartSelect.E_CHART_HOURLY:
                    #region HOUR_CUMUL
                    int HourRange = 0;
                    /* find first element on selected date */
                    getData = data.Find(
                            delegate (int[] dt)
                            {
                                firstIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );
                    HourRange = 24; /* temporary 24 */

                    baseTime = getData[1] / 10000; /* get Hour from time(HHmmss) */
                    baseInCnt = getData[2]; /* get IN cnt */

                    /* 선택한 날짜가 시작날짜가 아닐 경우 baseCnt는 이전날의 마지막 Cnt로 잡혀야 한다. */
                    if (baseInCnt != 0)
                    {
                        DateTime prevDate = fD.AddDays(-1);
                        tempData = getData;
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(prevDate.ToString("yyyyMMdd"));
                            }
                        );
                        if (getData == null)
                            getData = tempData;
                        baseInCnt = getData[2];
                    }

                    baseOutCnt = getData[3]; /* get OUT cnt */

                    getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                lastIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );

                    inData = new int[HourRange];
                    outData = new int[HourRange];

                    /* find data hourly */
                    for (int i = baseTime; i < HourRange; i++)
                    {
                        getIdx = data.FindIndex(firstIdx, lastIdx - firstIdx + 1,
                                delegate (int[] dt)
                                {
                                    int hour = dt[1] / 10000; /* get HH from HHmmss */
                                    return hour > baseTime;
                                }
                            );
                        if (getIdx >= 0)
                        {
                            getData = data[getIdx];

                            baseTime++;

                            inData[i] = getData[2] - baseInCnt;
                            outData[i] = getData[3] - baseOutCnt;

                            firstIdx = getIdx;
                        }
                        else
                        {
                            getData = data[lastIdx];
                            inData[i] = getData[2] - baseInCnt;
                            outData[i] = getData[3] - baseOutCnt;
                            break;
                        }
                    }

                    rtnData.Add(inData);
                    rtnData.Add(outData);
#endregion
                    break;
                case ChartSelect.E_CHART_WEEKLY:
                    #region WEEK_COMUL
                    int WeekRange = 7;
                    /* find first element on selected date */
                    getData = data.Find(
                            delegate (int[] dt)
                            {
                                firstIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(fD.ToString("yyyyMMdd"));
                            }
                        );

                    baseInCnt = getData[2]; /* get IN cnt */
                    /* 선택한 날짜가 시작날짜가 아닐 경우 baseCnt는 이전날의 마지막 Cnt로 잡혀야 한다. */
                    if (baseInCnt != 0)
                    {
                        DateTime prevDate = fD.AddDays(-1);
                        tempData = getData;
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(prevDate.ToString("yyyyMMdd"));
                            }
                        );
                        if (getData == null)
                            getData = tempData;
                        baseInCnt = getData[2];
                    }
                    baseOutCnt = getData[3]; /* get OUT cnt */

                    getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                lastIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(eD.ToString("yyyyMMdd"));
                            }
                        );

                    inData = new int[WeekRange];
                    outData = new int[WeekRange];

                    DateTime currentDate;
                    currentDate = fD; /* get search date */
                    /* find data hourly */
                    for (int i = 0; i < WeekRange; i++)
                    {
                        /* 각 날짜의 firstIdx - lastIdx의 데이터값을 저장하고 하루씩 이동, 1주일 치 기재 */
                        /* 해당 날짜의 마지막 data를 구한다 */
                        getData = data.FindLast(
                            delegate (int[] dt)
                            {
                                getIdx = data.IndexOf(dt);
                                return dt[0] == Int32.Parse(currentDate.ToString("yyyyMMdd"));
                            }
                        );
                        if (getData != null) /* find data */
                        {
                            inData[i] = getData[2];
                            outData[i] = getData[3];
                            currentDate = currentDate.AddDays(1);
                            firstIdx = getIdx;
                        }
                    }
                    rtnData.Add(inData);
                    rtnData.Add(outData);
                    #endregion
                    break;
                default:
                    break;
            }

            return rtnData;
        }


        public void MyParserDataInit()
        {
            ClearAllList();
            ClearAllVar();
        }
    }
}

