using System;
using System.Collections.Generic;
using System.Text;

namespace PlantsBook.Push
{
    public static class Calculation
    {
        public static double pushPeriod;
        public static double CalculationPeriodicity(string selectValue, IList<string> Value)
        {
            if (selectValue == Value[0])
            {
                pushPeriod = 1;
            }
            else if (selectValue == Value[1])
            {
                pushPeriod = 2;
            }
            else if (selectValue == Value[2])
            {
                pushPeriod = 3;
            }
            else if (selectValue == Value[3])
            {
                pushPeriod = 4;
            }
            else if (selectValue == Value[4])
            {
                pushPeriod = 5;
            }
            else if (selectValue == Value[5])
            {
                pushPeriod = 6;
            }
            else if (selectValue == Value[6])
            {
                pushPeriod = 7;
            }
            else if (selectValue == Value[7])
            {
                pushPeriod = 14;
            }
            else if (selectValue == Value[8])
            {
                pushPeriod = 21;
            }
            else
            {
                pushPeriod = 28;
            }
            return pushPeriod;
        }

    }
}
