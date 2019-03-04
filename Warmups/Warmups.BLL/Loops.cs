using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string largerString = "";

            for (int i = 0; i < n; i++)
            {
                largerString = largerString + str;
            }
            return largerString;
        }

        public string FrontTimes(string str, int n)
        {
            string returnStr = "", repeatStr = "";
            int frontStrLen = str.Length;

            if (frontStrLen > 3) { frontStrLen = 3; }
            repeatStr = str.Substring(0, frontStrLen);

            for (int i = 0; i < n; i++)
            {
                returnStr = returnStr + repeatStr;
            }
            return returnStr;
        }

        public int CountXX(string str)
        {
            string xxCk = "";
            int xxCount = 0;

            for (int i = 0; i <= str.Length - 2; i++)
            {
                xxCk = str.Substring(i, 2);
                if (xxCk == "xx") { xxCount++; }
            }
            return xxCount;
        }

        public bool DoubleX(string str)
        {
            int xxCount = 0;
            bool xxFound = false;

            for (int i = 0; i <= str.Length - 2; i++)
            {
                if (str.Substring(i, 1) == "x")
                {
                    if (str.Substring(i + 1, 1) == "x") { xxFound = true; }
                    else { break; }
                }
            }
            return xxFound;
        }

        public string EveryOther(string str)
        {
            string returnStr = "";

            for (int i = 0; i < str.Length; i += 2)
            {
                returnStr += str[i];
            }
            return returnStr;
        }

        public string StringSplosion(string str)
        {
            throw new NotImplementedException();
        }

        public int CountLast2(string str)
        {
            int last2count = 0;
            string current2 = "", last2 = str.Substring(str.Length - 2, 2);
            for (int i = 0; i < str.Length - 2; i++)
            {
                current2 = str.Substring(i, 2);
                if (current2 == last2) { last2count++; }
            }
            return(last2count);
        }

        public int Count9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            //throw new NotImplementedException();

            int currentNum, next1, sixCount = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                currentNum = numbers[i];
                next1 = numbers[i + 1];

                if ((currentNum == 6) && ((next1 == 6) || next1 == 7))
                {
                    // foundOne6 = true;
                    sixCount++;
                }
           
            }
            return sixCount;
        }

        public bool NoTriples(int[] numbers)
        {
            bool noTrips = true;
            int currentNum, next1, next2;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                currentNum = numbers[i];
                next1 = numbers[i + 1];
                next2 = numbers[i + 2];

                //Console.WriteLine($"CurrentNum is {currentNum}. Next1 is {next1}. Next2 is {next2}. Notrips is {noTrips}.");
                //Console.ReadLine();
                if ((next1 == currentNum) && (next2 == currentNum))
                {
                    noTrips = false;
                    break;
                }
            }
            return noTrips;
        }

        public bool Pattern51(int[] numbers)
        {
            int theVal = numbers[0];
            bool returnVal = false;
            {

                for (int i = 0; i < numbers.Length - 2; i++)
                {
                    if ((numbers[i + 1] == numbers[i] + 5) && (numbers[i + 2] == numbers[i] - 1))
                    { returnVal = true; }
                }

            }
            return returnVal;
        }

    }
}
