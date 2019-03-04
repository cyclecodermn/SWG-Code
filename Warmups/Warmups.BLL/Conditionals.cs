using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            throw new NotImplementedException();
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool sleepIn;

            sleepIn = ((!isWeekday) || (isVacation));
            return sleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int sumAB = a + b;

            if (a == b) { sumAB = sumAB * 2; }
            return sumAB;
        }
        
        public int Diff21(int n)
        {
            int diff21n = 21 - n;
            diff21n = Math.Abs(diff21n);
            if (n > 21) { diff21n = 2 * diff21n; }
            return diff21n;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool trouble = false;
            if (isTalking) { trouble = hour < 7 || hour > 20; }
            return trouble;
        }

        public bool Makes10(int a, int b)
        {
            return(a == 10 || b == 10 || a + b == 10);
        }
        
        public bool NearHundred(int n)
        {
            return (n >= 90 && n <= 110) || (n >= 190 && n <= 210);
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool returnVal = false;

            if (negative) { returnVal = (a < 0 && b < 0); }
            else { returnVal = (a < 0 && b > 0) || (a > 0 && b < 0); }
            return returnVal;
        }

        public string NotString(string s)
        {
            string returnString = "", first3 = "";

            if (s.Length > 3) { first3 = s.Substring(0, 3); }

            if (first3 != "not") { returnString = "not " + s; }
            else { returnString = s; }
            return returnString;
        }
        
        public string MissingChar(string str, int n)
        {
            string returnStr = str.Substring(0, n);

            for (int i = n + 1; i < str.Length; i++)
            {
                returnStr += str[i];
            }
            return returnStr;
        }

        public string FrontBack(string str)
        {
            string startStr = "", endStr = "", returnStr = "";

            if (str.Length < 2) { returnStr = str; }
            else
            {
                startStr = str.Substring(0, 1);
                endStr = str.Substring(str.Length - 1, 1);

                returnStr = endStr + str.Substring(1, str.Length - 2) + startStr;
            }

            return(returnStr);
        }
        
        public string Front3(string str)
        {
            string front, returnStr = "";

            if (str.Length < 3) { front = str; }
            else
            {
                front = str.Substring(0, 3);
            }

            for (int i = 0; i < 3; i++) { returnStr += front; }

            return(returnStr);
        }
        
        public string BackAround(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool Multiple3or5(int number)
        {
            throw new NotImplementedException();
        }
        
        public bool StartHi(string str)
        {
            bool startsHi = false;

            string first3 = "";

            if (str == "hi") { startsHi = true; }

            if (str.Length > 2)
            {
                first3 = str.Substring(0, 3);
                if (first3 == "hi " || first3 == "hi,") { startsHi = true; }
            }
            return (startsHi);
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            throw new NotImplementedException();
        }
        
        public bool Between10and20(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool SoAlone(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public string RemoveDel(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IxStart(string str)
        {
            return str.Substring(1, 2) == "ix";
        }
        
        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }
        
        public int Max(int a, int b, int c)
        {
            int max = a;
            if (b>max) { max = b; }
            if (c>max) { max = c; }
            return max;
        }
        
        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool GotE(string str)
        {
            bool hasE = false;
            int eCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == "e") { eCount++; }
            }

            hasE = ((eCount >= 1) && (eCount <= 3));

            return (hasE);
        }
        
        public string EndUp(string str)
        {
            string newString = "", last3 = "";
            if (str.Length < 3) { newString = str.ToUpper(); }
            else
            {
                last3 = str.Substring(str.Length - 3, 3);
                newString = str.Substring(0, str.Length - 3) + last3.ToUpper();
            }

            return(newString);
        }
        
        public string EveryNth(string str, int n)
        {
            string newString = "";
            int nextChar = 0;

            newString = str.Substring(0, 1);
            for (int i = n; i < str.Length; i += n)
            {
                newString += str.Substring(i, 1);
            }

            return(newString);
        }
    }
}
