using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Constant;
using System.Xml;

namespace PianoForte.Manager
{
    public class DateTimeManager
    {
        public static List<string> weekEndTimeList;
        public static List<string> weekDayTimeList;

        public enum ArrangeMode
        {
            MIN_TO_MAX,
            MAX_TO_MIN
        }

        public static void initialTimeList()
        {
            weekDayTimeList = new List<string>();
            weekEndTimeList = new List<string>();

            XmlTextReader reader = new XmlTextReader("Data\\ClassroomTimeConfig.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        string startTime = "";
                        string endTime = "";

                        if (reader.Name == "WeekdayTime")
                        {
                            startTime = reader.GetAttribute("start");
                            endTime = reader.GetAttribute("end");                            
                        }
                        else if (reader.Name == "WeekendTime")
                        {
                            startTime = reader.GetAttribute("start");
                            endTime = reader.GetAttribute("end");
                        }

                        if ((startTime != "") && (endTime != ""))
                        {
                            string currentTime = startTime;
                            while (isBetweenTimeInterval(startTime, endTime, currentTime))
                            {
                                if (reader.Name == "WeekdayTime")
                                {
                                    weekDayTimeList.Add(currentTime);
                                }
                                else if (reader.Name == "WeekendTime")
                                {
                                    weekEndTimeList.Add(currentTime);
                                }                                
                                currentTime = addMinute(currentTime, 15);
                            }

                            startTime = "";
                            endTime = "";
                        }                        
                        break;
                    case XmlNodeType.Text:                        
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }


            //weekEndTimeList = new List<string>(new string[]{ "09.00", "09.15", "09.30", "09.45", 
            //                                                 "10.00", "10.15", "10.30", "10.45", 
            //                                                 "11.00", "11.15", "11.30", "11.45", 
            //                                                 "12.00", "12.15", "12.30", "12.45", 
            //                                                 "13.00", "13.15", "13.30", "13.45", 
            //                                                 "14.00", "14.15", "14.30", "14.45",
            //                                                 "15.00", "15.15", "15.30", "15.45",
            //                                                 "16.00", "16.15", "16.30", "16.45",
            //                                                 "17.00", "17.15", "17.30", "17.45",
            //                                                 "18.00", "18.15", "18.30", "18.45", 
            //                                                 "19.00" });

            //weekDayTimeList = new List<string>(new string[]{ "12.00", "12.15", "12.30", "12.45",
            //                                                 "13.00", "13.15", "13.30", "13.45", 
            //                                                 "14.00", "14.15", "14.30", "14.45",
            //                                                 "15.00", "15.15", "15.30", "15.45",
            //                                                 "16.00", "16.15", "16.30", "16.45",
            //                                                 "17.00", "17.15", "17.30", "17.45",
            //                                                 "18.00", "18.15", "18.30", "18.45",
            //                                                 "19.00", "19.15", "19.30", "19.45",
            //                                                 "20.00" });
        }

        public static string getMinTime(string time1, string time2)
        {
            string minTime = "";

            try
            {
                int time1Length = time1.Length;
                int time2Length = time2.Length;
                if (time1Length < time2Length)
                {
                    minTime = time1;
                }
                else if (time1Length == time2Length)
                {
                    int hour1 = DateTimeManager.getHour(time1);
                    int hour2 = DateTimeManager.getHour(time2);
                    if (hour1 < hour2)
                    {
                        minTime = time1;
                    }
                    else if (hour1 == hour2)
                    {
                        int minute1 = DateTimeManager.getMinute(time1);
                        int minute2 = DateTimeManager.getMinute(time2);
                        if (minute1 < minute2)
                        {
                            minTime = time1;
                        }
                        else if (minute1 > minute2)
                        {
                            minTime = time2;
                        }
                    }
                    else if (hour1 > hour2)
                    {
                        minTime = time2;
                    }
                }
                else if (time1Length > time2Length)
                {
                    minTime = time2;
                }
            }
            catch (System.Exception exception)
            {
                LogManager.writeLog(exception.Message);
            }

            return minTime;
        }

        public static string getMaxTime(string time1, string time2)
        {
            string maxTime = "";

            try
            {
                int time1Length = time1.Length;
                int time2Length = time2.Length;
                if (time1Length > time2Length)
                {
                    maxTime = time1;
                }
                else if (time1Length == time2Length)
                {
                    int hour1 = DateTimeManager.getHour(time1);
                    int hour2 = DateTimeManager.getHour(time2);
                    if (hour1 > hour2)
                    {
                        maxTime = time1;
                    }
                    else if (hour1 == hour2)
                    {
                        int minute1 = DateTimeManager.getMinute(time1);
                        int minute2 = DateTimeManager.getMinute(time2);
                        if (minute1 > minute2)
                        {
                            maxTime = time1;
                        }
                        else if (minute1 < minute2)
                        {
                            maxTime = time2;
                        }
                    }
                    else if (hour1 < hour2)
                    {
                        maxTime = time2;
                    }
                }
                else if (time1Length < time2Length)
                {
                    maxTime = time2;
                }
            }
            catch (System.Exception exception)
            {
                LogManager.writeLog(exception.Message);
            }

            return maxTime;
        }

        public static int getHour(string time)
        {
            int hour = -1;

            int timeLength = time.Length;
            if (timeLength == 4)
            {
                hour = Convert.ToInt32(time.Substring(0, 1));
            }
            else if (timeLength == 5)
            {
                hour = Convert.ToInt32(time.Substring(0, 2));
            }

            return hour;
        }

        public static int getMinute(string time)
        {
            int minute = -1;

            int timeLength = time.Length;
            if (timeLength == 4)
            {
                minute = Convert.ToInt32(time.Substring(2, 2));
            }
            else if (timeLength == 5)
            {
                minute = Convert.ToInt32(time.Substring(3, 2));
            }

            return minute;
        }

        public static DateTime getMinDate(List<DateTime> dateList)
        {
            DateTime minDate = new DateTime();

            for (int i = 0; i < dateList.Count; i++)
            {
                if (i == 0)
                {
                    minDate = dateList[i];
                }
                else if (dateList[i] < minDate)
                {
                    minDate = dateList[i];
                }
            }

            return minDate;
        }

        public static DateTime getMaxDate(List<DateTime> dateList)
        {
            DateTime maxDate = new DateTime();

            for (int i = 0; i < dateList.Count; i++)
            {
                if (i == 0)
                {
                    maxDate = dateList[i];
                }
                else if (dateList[i] > maxDate)
                {
                    maxDate = dateList[i];
                }
            }

            return maxDate;
        }

        public static bool isWeekEnd(DateTime dateTime)
        {
            bool returnFlag = false;

            string dayOfWeek = dateTime.DayOfWeek.ToString();
            if (dayOfWeek == DateTimeConstant.SUNDAY_EN)
            {
                returnFlag = true;
            }
            else if (dayOfWeek == DateTimeConstant.MONDAY_EN)
            {
                returnFlag = false;
            }
            else if (dayOfWeek == DateTimeConstant.TUESDAY_EN)
            {
                returnFlag = false;
            }
            else if (dayOfWeek == DateTimeConstant.WEDNESDAY_EN)
            {
                returnFlag = false;
            }
            else if (dayOfWeek == DateTimeConstant.THURSDAY_EN)
            {
                returnFlag = false;
            }
            else if (dayOfWeek == DateTimeConstant.FRIDAY_EN)
            {
                returnFlag = false;
            }
            else if (dayOfWeek == DateTimeConstant.SATURDAY_EN)
            {
                returnFlag = true;
            }

            return returnFlag;
        }

        public static string getCurrentTime()
        {
            return String.Format("{0:0.00}", (double)DateTime.Now.Hour + ((double)DateTime.Now.Minute / 100));
        }

        public static string addMinute(string time, int minuteToAdd)
        {
            string[] tempString1 = new string[2];
            tempString1 = time.Split('.');

            int time_hour = Convert.ToInt32(tempString1[0]);
            int time_minute = Convert.ToInt32(tempString1[1]);
            int totalMinute = time_minute + minuteToAdd;

            time_hour = time_hour + (totalMinute / 60);
            time_minute = totalMinute % 60;

            return String.Format("{0:00.00}", (double)time_hour + ((double)time_minute / 100));
        }

        public static bool isBetweenTimeInterval(string startTime, string endTime, string timeToBeCheck)
        {
            bool returnFlag = false;

            if (((startTime == timeToBeCheck) || (startTime == getMinTime(startTime, timeToBeCheck))) &&
                ((timeToBeCheck == endTime) || (timeToBeCheck == getMinTime(timeToBeCheck, endTime))))
            {
                returnFlag = true;
            }

            return returnFlag;
        }

        public static List<DateTime> sortDate(List<DateTime> dateList)
        {
            for (int i = 0; i < dateList.Count; i++)
            {
                for (int j = i + 1; j < dateList.Count; j++)
                {
                    if (dateList[j] < dateList[i])
                    {
                        DateTime tempDate = dateList[i];
                        dateList[i] = dateList[j];
                        dateList[j] = tempDate;
                    }
                }
            }

            return dateList;
        }
    }
}
