using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Constant;
using PianoForte.Model;
using System.Windows.Forms;

namespace PianoForte.Manager
{
    public class ValidateManager
    {
        public const string NO_ERROR_TEXT = "";
        public const string NOT_FILL_FIRSTNAME_TEXT = "กรุณากรอกชื่อจริง";
        public const string NOT_FILL_LASTNAME_TEXT = "กรุณากรอกนามสกุล";
        public const string NOT_FILL_NICKNAME_TEXT = "กรุณากรอกชื่อเล่น";
        public const string INVALID_BIRTHDAY_TEXT = "กรุณากรอกวันเกิดให้ถูกต้อง";
        public const string NOT_FILL_ADDRESS_TEXT = "กรุณากรอกที่อยู่ให้ครบถ้วน";
        public const string INVALID_ADDRESS_TEXT = "กรุณากรอกที่อยู่ให้ถูกต้อง";
        public const string NOT_FILL_PHONE_NUMBER_TEXT = "กรุณากรอกเบอร์ติดต่ออย่างน้อย 1 เบอร์";
        public const string INVALID_PHONE_NUMBER_TEXT = "กรุณากรอกเบอร์ติดต่อให้ถูกต้อง";
        public const string NOT_FILL_EMAIL_TEXT = "กรุณากรอกอีเมล์";
        public const string INVALID_EMAIL_TEXT = "กรุณากรอกอีเมล์ให้ถูกต้อง";
        public const string NOT_FILL_IDENTITY_NUMBER_TEXT = "กรุณากรอกหมายเลขบัตรประชาชน";
        public const string INVALID_IDENTITY_NUMBER_TEXT = "กรุณากรอกเลขบัตรประชาชนให้ถูกต้อง";

        public enum ErrorMeaning
        {
            NO_ERROR,
            NOT_FILL_FIRSTNAME,
            NOT_FILL_LASTNAME,
            NOT_FILL_NICKNAME,
            INVALID_BIRTHDAY,
            NOT_FILL_ADDRESS,
            INVALID_ADDRESS,
            NOT_FILL_PHONE_NUMBER,
            INVALID_PHONE_NUMBER,
            NOT_FILL_EMAIL,
            INVALID_EMAIL,
            NOT_FILL_IDENTITY_NUMBER,
            INVALID_IDENTITY_NUMBER,
        }

        public static string validate(Student student)
        {
            string errorText = "";

            ErrorMeaning error = validateFirstname(student.Firstname);
            if (error == ErrorMeaning.NO_ERROR)
            {
                error = validateLastname(student.Lastname);
                if (error == ErrorMeaning.NO_ERROR)
                {
                    error = validateNickname(student.Nickname);
                    if (error == ErrorMeaning.NO_ERROR)
                    {
                        error = validateBirthday(student.Birthday);
                        if (error == ErrorMeaning.NO_ERROR)
                        {
                            error = validateAddress(student.Address);
                            if (error == ErrorMeaning.NO_ERROR)
                            {
                                error = validatePhoneNumber(student.Phone1, student.Phone2, student.Phone3);
                                if (error == ErrorMeaning.NO_ERROR)
                                {
                                    error = validateEmail(student.Email);
                                    if (error == ErrorMeaning.NO_ERROR)
                                    {
                                        //Do Nothing
                                    }
                                }
                            }
                        }
                    }
                }
            }

            errorText = getErrorText(error);

            return errorText;
        }

        public static string validate(Teacher teacher)
        {
            string errorText = "";

            ErrorMeaning error = validateFirstname(teacher.Firstname);
            if (error == ErrorMeaning.NO_ERROR)
            {
                error = validateLastname(teacher.Lastname);
                if (error == ErrorMeaning.NO_ERROR)
                {
                    error = validateNickname(teacher.Nickname);
                    if (error == ErrorMeaning.NO_ERROR)
                    {
                        error = validatePhoneNumber(teacher.Phone1, teacher.Phone2, teacher.Phone3);
                        if (error == ErrorMeaning.NO_ERROR)
                        {
                            error = validateEmail(teacher.Email);
                            if (error == ErrorMeaning.NO_ERROR)
                            {
                                //Do Nothing
                            }
                        }
                    }
                }
            }

            errorText = getErrorText(error);

            return errorText;
        }

        public static bool isNumber(string input)
        {
            bool returnFlag = true;

            if (input == "")
            {
                returnFlag = false;
            }
            else
            {
                List<string> numberList = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });

                List<string> stringInputList = new List<string>();
                for (int i = 0; i < input.Length; i++)
                {
                    stringInputList.Add(input.Substring(i, 1));
                }

                for (int i = 0; i < stringInputList.Count; i++)
                {
                    bool isExist = false;
                    for (int j = 0; j < numberList.Count; j++)
                    {
                        if (stringInputList[i] == numberList[j])
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        returnFlag = false;
                        break;
                    }
                }
            }            

            return returnFlag;
        }

        public static bool isUsableDiscountRate(string stringDiscountRate, double productPrice, bool isPercent)
        {
            bool returnFlag = false;

            if (ValidateManager.isNumber(stringDiscountRate))
            {
                double discountRate = Convert.ToDouble(stringDiscountRate);

                if (isPercent)
                {
                    if ((discountRate >= 0) && (discountRate <= 100))
                    {
                        returnFlag = true;
                    }
                }
                else
                {
                    if ((discountRate >= 0) && (discountRate <= productPrice))
                    {
                        returnFlag = true;
                    }
                }
            }

            return returnFlag;
        }

        public static bool isMonday(string day)
        {
            bool returnFlag = false;

            if ((day == DateTimeConstant.MONDAY_EN) || (day == DateTimeConstant.MONDAY_TH))
            {
                returnFlag = true;
            }

            return returnFlag;
        }

        public static bool validateCreditCardNumber(string creditCardNumber)
        {
            bool returnFlag = false;

            if (creditCardNumber.Length == 16)
            {
                if (isNumber(creditCardNumber))
                {
                    returnFlag = true;
                }
            }

            return returnFlag;
        }

        private static ErrorMeaning validateFirstname(string firstname)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if (firstname == "")
            {
                error = ErrorMeaning.NOT_FILL_FIRSTNAME;
            }

            return error;
        }

        private static ErrorMeaning validateLastname(string lastname)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if (lastname == "")
            {
                error = ErrorMeaning.NOT_FILL_LASTNAME;
            }

            return error;
        }

        private static ErrorMeaning validateNickname(string nickname)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if (nickname == "")
            {
                error = ErrorMeaning.NOT_FILL_NICKNAME;
            }

            return error;
        }

        private static ErrorMeaning validateBirthday(DateTime birthday)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            DateTime today = new DateTime(DateTime.Now.Ticks);
            if (birthday > today)
            {
                error = ErrorMeaning.INVALID_BIRTHDAY;
            }

            return error;
        }

        private static ErrorMeaning validateAddress(Address address)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if ((address.Address1 == "") && (address.Address2 == ""))
            {
                error = ErrorMeaning.NOT_FILL_ADDRESS;
            }
            else if (address.PostCode < 10000)
            {
                error = ErrorMeaning.INVALID_ADDRESS;
            }

            return error;
        }

        private static ErrorMeaning validatePhoneNumber(string phone1, string phone2, string phone3)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if ((phone1 == "") && (phone2 == "") && (phone3 == ""))
            {
                error = ErrorMeaning.NOT_FILL_PHONE_NUMBER;
            }
            else
            {
                if ((isNumber(phone1) || phone1 == "") && 
                    (isNumber(phone2) || phone2 == "") && 
                    (isNumber(phone3) || phone3 == ""))
                {
                    if (((phone1 != "") && (ConvertManager.toDisplayPhoneNumber(phone1) == "")) ||
                        ((phone2 != "") && (ConvertManager.toDisplayPhoneNumber(phone2) == "")) ||
                        ((phone3 != "") && (ConvertManager.toDisplayPhoneNumber(phone3) == "")))
                    {
                        error = ErrorMeaning.INVALID_PHONE_NUMBER;
                    }
                }   
                else
                {
                    error = ErrorMeaning.INVALID_PHONE_NUMBER;
                }
            }

            return error;
        }

        private static ErrorMeaning validateEmail(string email)
        {
            ErrorMeaning error = ErrorMeaning.NO_ERROR;

            if (email != "")
            {
                for (int i = 0; i == 0; i++)
                {
                    string[] tempStr1 = new string[2];
                    tempStr1 = email.Split('@');
                    try
                    {
                        if ((tempStr1[0] == "") || (tempStr1[1] == ""))
                        {
                            error = ErrorMeaning.INVALID_EMAIL;
                            break;
                        }
                        else
                        {
                            string[] tempStr2 = new string[2];
                            tempStr2 = tempStr1[1].Split('.');
                            if ((tempStr2[0] == "") || (tempStr2[1] == ""))
                            {
                                error = ErrorMeaning.INVALID_EMAIL;
                                break;
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        LogManager.writeLog(e.Message);
                        error = ErrorMeaning.INVALID_EMAIL;
                        break;
                    }
                }
            }

            return error;
        }

        private static string getErrorText(ErrorMeaning errorMeaning)
        {
            string errorText = "";

            switch (errorMeaning)
            {
                case ErrorMeaning.NO_ERROR:
                    break;
                case ErrorMeaning.NOT_FILL_FIRSTNAME:
                    errorText = NOT_FILL_FIRSTNAME_TEXT;
                    break;
                case ErrorMeaning.NOT_FILL_LASTNAME:
                    errorText = NOT_FILL_LASTNAME_TEXT;
                    break;
                case ErrorMeaning.NOT_FILL_NICKNAME:
                    errorText = NOT_FILL_NICKNAME_TEXT;
                    break;
                case ErrorMeaning.INVALID_BIRTHDAY:
                    errorText = INVALID_BIRTHDAY_TEXT;
                    break;
                case ErrorMeaning.NOT_FILL_ADDRESS:
                    errorText = NOT_FILL_ADDRESS_TEXT;
                    break;
                case  ErrorMeaning.INVALID_ADDRESS:
                    errorText = INVALID_ADDRESS_TEXT;
                    break; ;
                case ErrorMeaning.NOT_FILL_PHONE_NUMBER:
                    errorText = NOT_FILL_PHONE_NUMBER_TEXT;
                    break;
                case ErrorMeaning.INVALID_PHONE_NUMBER:
                    errorText = INVALID_PHONE_NUMBER_TEXT;
                    break;
                case ErrorMeaning.NOT_FILL_EMAIL:
                    errorText = NOT_FILL_EMAIL_TEXT;
                    break;
                case ErrorMeaning.INVALID_EMAIL:
                    errorText = INVALID_EMAIL_TEXT;
                    break;
                case ErrorMeaning.NOT_FILL_IDENTITY_NUMBER:
                    errorText = NOT_FILL_IDENTITY_NUMBER_TEXT;
                    break;
                case ErrorMeaning.INVALID_IDENTITY_NUMBER:
                    errorText = INVALID_IDENTITY_NUMBER_TEXT;
                    break;
            }

            return errorText;
        }

        public static bool isPressNumber(KeyEventArgs e)
        {
            bool returnFlag = false;

            switch (e.KeyData)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Back:
                case Keys.Delete:
                case Keys.Home:
                case Keys.End:
                    returnFlag = true;
                    break;
                default:
                    returnFlag = false;
                    break;
            }

            return returnFlag;
        }
    }
}
