using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool theResult = false;
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6) { theResult = true; }
            return theResult;
            // throw new NotImplementedException();
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool argsCk1, argsCk2, ckBoth;

            argsCk1 = numbers.Length > 0;
            argsCk2 = (numbers[0] == numbers[numbers.Length - 1]);

            ckBoth = argsCk1 && argsCk2;
            return ckBoth;
        }
        public int[] MakePi(int n)
        {
            double myPi = Math.PI;
            string stringPi = myPi.ToString(), ckChar = "";
            int[] returnArr = new int[n];
            int charVal = 0, returnIndex = 0;

            //
            //Less efficient technique, without TryParse
            //
            //for (int i = 0; i <= n; i++)
            //{
            //    ckChar = stringPi.Substring(i, 1);
            //    if (ckChar != ".")
            //    {
            //        charVal = Int32.Parse(ckChar);
            //        returnArr[returnIndex] = charVal;
            //        returnIndex++;
            //    }

            //}

            //More efficient techgnique, with TryParse

            for (int i = 0; i <= n; i++)
            {
                ckChar = stringPi.Substring(i, 1);
                if (Int32.TryParse(ckChar, out charVal))
                {
                    returnArr[returnIndex] = charVal;
                    returnIndex++;
                }
            }

            return returnArr;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            int aFirst, aLast, bFirst, bLast;
            bool returnBool;

            aFirst = a[0];
            aLast = a[a.Length - 1];
            bFirst = b[0];
            bLast = b[b.Length - 1];

            returnBool = (aFirst == bFirst) || (aLast == bLast);
            return returnBool;
            // throw new NotImplementedException();
        }
        
        public int Sum(int[] numbers)
        {
            int returnSum = 0;
            
            for (int i=0; i<=numbers.Length-1; i++)
            {
                returnSum += numbers[i];
            }
            return returnSum;
}
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] rotatedArr = new int[3];
            int tempNum;

            tempNum = numbers[0];

            for (int i = 0; i <= numbers.Length - 2; i++)
            {
                rotatedArr[i] = numbers[i + 1];
            }
            rotatedArr[numbers.Length - 1] = tempNum;
            return (rotatedArr);
        }

        public int[] Reverse(int[] numbers)
        {
            int[] reversedArr = new int[(numbers.Length)];
            int tempNum, reverseInc = (numbers.Length - 1);

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                tempNum = numbers[reverseInc];
                reversedArr[i] = tempNum;
                reverseInc -= 1;
            }
            return reversedArr;
        }

        public int[] HigherWins(int[] numbers)
        {
            int[] highArr = new int[3];
            int highNum = numbers[0], lastNum = numbers[numbers.Length - 1];

            if (highNum < lastNum) { highNum = lastNum; }

            for (int i = 0; i <= highArr.Length - 1; i++)
            {
                highArr[i] = highNum;
            }
            return highArr;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            bool evenFounnd = false;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers[i] % 2 == 0) { evenFounnd = true; }
                
            }
            return evenFounnd;
        }

        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            bool found23;

            for (int i = 0; i <= numbers.Length - 2; i++)
            {
                found23 = ((numbers[i] == 2) && (numbers[i + 1] == 3));
                if (found23) { numbers[i + 1] = 0; }
            }
            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            bool unlucky = false, ck13 = false, positionCk;

            for (int i = 0; i <= numbers.Length - 2; i++)
            {
                ck13 = (numbers[i] == 1 && numbers[i + 1] == 3);
                positionCk = (i == 0 || i == 1 || i == numbers.Length - 3);

                if (ck13 && positionCk)
                {
                    unlucky = true;
                }

                Console.Write(numbers[i] + ", ");
            }
            return unlucky;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int bothArrIndex = 0, bothArrLen = a.Length + b.Length;

            int[] returnArr = new int[2], aAndBarr = new int[bothArrLen];

            for (int i = 0; i < a.Length; i++)
            {
                aAndBarr[bothArrIndex] = a[i];
                bothArrIndex++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                aAndBarr[bothArrIndex] = b[i];
                bothArrIndex++;
            }

            returnArr[0] = aAndBarr[0];
            returnArr[1] = aAndBarr[1];

            return returnArr;
        }

    }
}
