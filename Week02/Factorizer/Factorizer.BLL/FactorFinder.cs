using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class FactorFinder
    {
        //public static void PrimeCheckerTest(int intCk, bool returnBool)
        //{

        //    bool primeCk = PrimeChecker.CkForPrime(intCk);

        //    Assert.AreEqual(primeCk, returnBool);
        //}

        public static int[] GetFactors(int number)
        {
            int[] returnNums = new int[10];
            int numOfFactors = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    returnNums[numOfFactors] = i;
                    numOfFactors++;
                }

            }

            return returnNums;
        }
    }
}
