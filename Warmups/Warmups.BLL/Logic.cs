using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool isBetween40and60 = (cigars >= 40 && cigars <= 60);
            bool isGreat;

            if (!isWeekend)
            {
                if (isBetween40and60) { isGreat = true; }
                else { isGreat = false; }
            }
            else
            {
                if (cigars >= 40) { isGreat = true; }
                else { isGreat = false; }
            }

            return isGreat;
            //throw new NotImplementedException();
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int theResult = 0;
            
            if ((yourStyle >= 8 || dateStyle >= 8) && (yourStyle > 2 && dateStyle > 2))
            { theResult = 2; }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {theResult = 0;}
            else
            { theResult = 1; }
            return theResult;
            //throw new NotImplementedException();
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool playOut = false;

            if (temp >= 60 && temp <= 100 && isSummer) { playOut = true; }
            else if (temp >= 60 && temp <= 90 && !isSummer) { playOut = true; }
            return playOut;
            // throw new NotImplementedException();
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int theResult =5;

            if (!isBirthday)
            {
                if (speed <= 60) { theResult = 0; }
                else if (speed >= 61 && speed <= 80) { theResult = 1; }
                else if (speed >= 81) { theResult = 2; }
            }
            else
            {
                if (speed <= 65) { theResult = 0; }
                else if (speed >= 66 && speed <= 85) { theResult = 1; }
                else if (speed >= 86) { theResult = 2; }
            }
            return theResult;
            // throw new NotImplementedException();
        }

        public int SkipSum(int a, int b)
        {
            int returnVal = 20, theSum = a + b;
            if (!(theSum >= 10 && theSum <= 19)) { returnVal = theSum; }
            return returnVal;

            // throw new NotImplementedException();
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string returnStr;
            bool weekend = false;

            weekend = (day == 0 || day == 6);

            if (vacation)
            {
                if (weekend) { returnStr = "off"; }
                else { returnStr = "10:00"; }
            }
            else
            {
                if (weekend) { returnStr = "10:00"; }
                else { returnStr = "7:00"; }
            }
            return returnStr;
        }

        public bool LoveSix(int a, int b)
        {
            return (a == 6 || b == 6 || a + b == 6 || a - b == 6 || b - a == 6);
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool returnVal = false;

            if (outsideMode)
            {
                if (n < 1 || n > 10) { returnVal = true; }
            }
            else if (n > 1 && n < 10)
            { returnVal = true; }
            return returnVal;
        }
        
        public bool SpecialEleven(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            bool returnVal = false;

            if ((n % 20 == 1) || (n % 20 == 2)) { returnVal = true; }

            return returnVal;
        }

        public bool Mod35(int n)
        {
            bool returnVal = false;

            if ((n % 3 == 0 || n % 5 == 0) && n % 15 != 0) { returnVal = true; }
            return returnVal;
        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            throw new NotImplementedException();
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int returnVal = 0;

            if ((noDoubles) && (die1 == die2))
            {
                if (die1 == 6) { die1 = 1; }
                else { die1++; }
            }

            returnVal = die1 + die2;
            return returnVal;
        }

    }
}
