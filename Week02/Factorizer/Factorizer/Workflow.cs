using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizer.BLL;

namespace Factorizer
{

    public class Workflow
    {
        
        public int numToFactor = 0;
        public bool isPrime = false, isPerfect = false;
        

        public void RunFactoring()
        {
            int numToFactor = 0;
            numToFactor = GetNumberFromUser();

            ProcessFactors(numToFactor);
            ProcessGetPerfect(numToFactor);
            ProcessGetPrime(numToFactor);

        }

        private void ProcessGetPrime(int numToFactor)
        {
            Console.Write(numToFactor + " is ");
            bool primeCk = PrimeChecker.CkForPrime(numToFactor);
            if (PrimeChecker.CkForPrime(numToFactor))
            {
                Console.WriteLine("a prime number.");
            }
            else
            {
                Console.WriteLine("NOT a prime number.");

            }
            isPrime = primeCk;
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
        }

        private void ProcessGetPerfect(int numToFactor)
        {
            Console.Write(numToFactor + " is ");
            bool perfectCk = PerfectChecker.GetPerfectNum(numToFactor);
            if (PerfectChecker.GetPerfectNum(numToFactor))
            {
                Console.WriteLine("a perfect number.");
            }
            else
            {
                Console.WriteLine("NOT a perfect number.");
            }
            isPerfect = perfectCk;
        }

        private void ProcessFactors(int numToFactor)
        {

            int[] numsFound = new int[10];
            numsFound = FactorFinder.GetFactors(numToFactor);

            Console.WriteLine();
            Console.Write("The factors of the number are: ");

            for (int i = 0; i < numsFound.Length; i++)
            {

                if (numsFound[i] != 0)
                {
                    Console.Write(numsFound[i] + ",");
                }
            }
            Console.WriteLine();

        }

        public int[] zeroOutArr(int[] theArr)
        {
            for (int i = 0; i < theArr.Length; i++)
            {
                theArr[i] = 0;
            }
            return theArr;
        }

        public int GetNumberFromUser()
        {

            int output = 0;
            bool validInput = false;
            do
            {

                Console.Write("Enter a number between 1 and 10: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    // it was an int, now is it between 1 and 10 ?
                    if (output >= 1 && output <= 10)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("That number was not between 1 and 10, try again.");
                    }
                }

                else
                {
                    Console.WriteLine("That was not a number!");
                }

            } while (!validInput);
            numToFactor = output;
            return (output);
        }

    }

}