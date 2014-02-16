using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Utilities
{
    public class FormatManager
    {
        public static string toDisplayedPhoneNumber(string input)
        {
            string displayedPhoneNumber = "";

            if (input != "")
            {
                string part1 = "";
                string part2 = "";
                string part3 = "";

                input = input.Replace("-", "");

                int inputLength = input.Length;
                if ((inputLength == 9) && (input.Substring(0, 2) == "02"))
                {
                    part1 = input.Substring(0, 2);
                    part2 = input.Substring(2, 3);
                    part3 = input.Substring(5, inputLength - 5);
                }
                else if ((inputLength == 9) || (inputLength == 10))
                {
                    part1 = input.Substring(0, 3);
                    part2 = input.Substring(3, 3);
                    part3 = input.Substring(6, inputLength - 6);
                }

                if ((part1 != "") && (part2 != "") && (part3 != ""))
                {
                    displayedPhoneNumber = part1 + "-" + part2 + "-" + part3;
                }                
            }

            return displayedPhoneNumber;
        }
    }
}