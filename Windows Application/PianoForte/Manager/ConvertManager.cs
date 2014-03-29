using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Constant;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class ConvertManager
    {
        public static string toDisplayPhoneNumber(string phoneNumber)
        {
            string displayPhoneNumber = "";

            try
            {
                if (phoneNumber != "")
                {
                    string part1;
                    string part2;
                    string part3;

                    int phoneNumberLength = phoneNumber.Length;
                    if (phoneNumberLength == 9)
                    {
                        if (phoneNumber.Substring(0, 2) == "02")
                        {
                            part1 = phoneNumber.Substring(0, 2);
                            part2 = phoneNumber.Substring(2, 3);
                            part3 = phoneNumber.Substring(5, phoneNumberLength - 5);
                        }
                        else
                        {
                            part1 = phoneNumber.Substring(0, 3);
                            part2 = phoneNumber.Substring(3, 3);
                            part3 = phoneNumber.Substring(6, phoneNumberLength - 6);
                        }

                        displayPhoneNumber = part1 + "-" + part2 + "-" + part3;
                    }
                    else if (phoneNumberLength == 10)
                    {
                        part1 = phoneNumber.Substring(0, 3);
                        part2 = phoneNumber.Substring(3, 3);
                        part3 = phoneNumber.Substring(6, phoneNumberLength - 6);

                        displayPhoneNumber = part1 + "-" + part2 + "-" + part3;
                    }
                } 
            }
            catch (System.Exception exception)
            {
                Console.Write(exception.Message);
            }                       

            return displayPhoneNumber;
        }

        public static List<string> toInputPhoneNumber(string phoneNumber)
        {
            List<string> inputPhoneNumberList = new List<string>();

            try
            {
                if (phoneNumber != "")
                {
                    phoneNumber = phoneNumber.Replace("-", "");
                    phoneNumber = phoneNumber.Replace(" ", "");

                    int phoneNumberLength = phoneNumber.Length;
                    if (phoneNumber.Substring(0, 2) == "02")
                    {
                        inputPhoneNumberList.Add(phoneNumber.Substring(0, 2));
                        inputPhoneNumberList.Add(phoneNumber.Substring(2, phoneNumberLength - 2));
                    }
                    else
                    {
                        inputPhoneNumberList.Add(phoneNumber.Substring(0, 3));
                        inputPhoneNumberList.Add(phoneNumber.Substring(3, phoneNumberLength - 3));
                    }
                }
                else
                {
                    inputPhoneNumberList.Add("");
                    inputPhoneNumberList.Add("");
                }
            }
            catch (System.Exception exception)
            {
                Console.Write(exception.Message);
            }            

            return inputPhoneNumberList;
        }

        public static string toBahtText(double number)
        {
            string bahtText = "";

            List<string> numberList = new List<string>(new string[] { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" });
            List<string> digitList = new List<string>(new string[] { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" });
            List<string> digit10List = new List<string>(new string[] { "", "สิบ", "ยี่สิบ", "สามสิบ", "สี่สิบ", "ห้าสิบ", "หกสิบ", "เจ็ดสิบ", "แปปสิบ", "เก้าสิบ" });

            if (number == 0)
            {
                bahtText = "ศูนย์";
            }
            else if (number > 0)
            {
                string stringNumber = number.ToString();
                List<string> stringNumberList = new List<string>();
                for (int i = 0; i < stringNumber.Length; i++)
                {
                    stringNumberList.Add(stringNumber.Substring(i, 1));
                }

                for (int i = 0; i < stringNumberList.Count; i++)
                {
                    int num = Convert.ToInt32(stringNumberList[i]);
                    int digit = stringNumberList.Count - i - 1;

                    if (digit == 0)
                    {
                        if (num == 1)
                        {
                            int previousNum = Convert.ToInt32(stringNumberList[i - 1]);
                            if (previousNum == 0)
                            {
                                bahtText += numberList[num];
                            }
                            else
                            {
                                bahtText += "เอ็ด";
                            }
                        }
                        else
                        {
                            bahtText += numberList[num];
                        }
                    }
                    else if (digit == 1)
                    {
                        bahtText += digit10List[num];
                    }
                    else
                    {
                        if (num != 0)
                        {
                            bahtText += numberList[num] + digitList[digit];
                        }
                    }
                }
            }

            bahtText += "บาทถ้วน";

            return bahtText;
        }

        public static string toDisplayCreditCardNumber(string creditCardNumber)
        {
            string convertedCreditCardNumber = "";

            if (creditCardNumber.Length == 16)
            {
                convertedCreditCardNumber += creditCardNumber.Substring(0, 4);
                convertedCreditCardNumber += "-";
                convertedCreditCardNumber += creditCardNumber.Substring(4, 4);
                convertedCreditCardNumber += "-";
                convertedCreditCardNumber += creditCardNumber.Substring(8, 4);
                convertedCreditCardNumber += "-";
                convertedCreditCardNumber += creditCardNumber.Substring(12, 4);
            }
            else
            {
                convertedCreditCardNumber = creditCardNumber;
            }

            return convertedCreditCardNumber;
        }

        public static string toThaiDayOfWeek(string dayOfWeek)
        {
            string thaiDayOfWeek = "";

            if (dayOfWeek == DateTimeConstant.SUNDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.SUNDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.MONDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.MONDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.TUESDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.TUESDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.WEDNESDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.WEDNESDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.THURSDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.THURSDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.FRIDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.FRIDAY_TH;
            }
            else if (dayOfWeek == DateTimeConstant.SATURDAY_EN)
            {
                thaiDayOfWeek = DateTimeConstant.SATURDAY_TH;
            }

            return thaiDayOfWeek;
        }

        public static string toStringRoomNumber(int roomNumber)
        {
            string stringRoomNumber = "";

            if (roomNumber < 10)
            {
                stringRoomNumber = "0" + roomNumber.ToString();
            }
            else if (roomNumber >= 10)
            {
                stringRoomNumber = roomNumber.ToString();
            }

            return stringRoomNumber;
        }

        public static Teacher.TeacherSettings toTeacherSettings(int intSettings)
        {
            Teacher.TeacherSettings settings = Teacher.TeacherSettings.NONE;

            if (intSettings == Convert.ToInt32(Teacher.TeacherSettings.TEACHES_45_MIN))
            {
                settings = Teacher.TeacherSettings.TEACHES_45_MIN;
            }

            return settings;
        }
    }
}
