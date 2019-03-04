using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PerfectChecker
    {
        public static bool GetPerfectNum(int number)
        {
            int perfectCk = 0;
            bool returnPerfectCk = false;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0 && i != number)
                {
                    perfectCk = perfectCk + i;
                }
            }
            if (perfectCk == number)
            {
                returnPerfectCk = true;
            }
            else
            {
                returnPerfectCk = false;
            }
            return returnPerfectCk;
        }
    }
}
