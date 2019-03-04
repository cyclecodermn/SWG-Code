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
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            throw new NotImplementedException();
        }
        
        public bool SpecialEleven(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod35(int n)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
