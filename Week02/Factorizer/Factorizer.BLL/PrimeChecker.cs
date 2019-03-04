using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PrimeChecker
    {

        public static bool CkForPrime(int number)
        {
            bool primeCk = true;
            for (int i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    primeCk = false;
                }
            }
            return primeCk;
        }
    }
}
