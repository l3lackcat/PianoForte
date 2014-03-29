using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Manager
{
    public class UtilityManager
    {
        public static double getDiscountRate(string stringDiscountRate, double productPrice, bool isPercent)
        {
            double discountRate = 0;
            if (ValidateManager.isNumber(stringDiscountRate))
            {
                double tempDiscountRate = Convert.ToDouble(stringDiscountRate);
                if (isPercent)
                {
                    if ((tempDiscountRate >= 0) || (tempDiscountRate <= 100))
                    {
                        discountRate = (tempDiscountRate * productPrice) / 100;
                    }
                }
                else
                {
                    if ((tempDiscountRate >= 0) || (tempDiscountRate <= productPrice))
                    {
                        discountRate = tempDiscountRate;
                    }
                }
            }

            return discountRate;
        }

        public static int getCommissionRate(Course course, int teacherId)
        {
            int commissionRate = 0;

            if (course.StudentPerClassroom == 1)
            {
                commissionRate = 40;
            }
            else if (course.StudentPerClassroom == 2)
            {
                commissionRate = 35;
            }

            //Need to check how many days of teacher absent.

            return commissionRate;
        }
    }
}
