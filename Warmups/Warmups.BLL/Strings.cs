using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {

            return ("<" + tag + ">" + content + "</" + tag + ">");

        }

        public string InsertWord(string container, string word) {

            int wordLen = container.Length;
            return container.Substring(0, 2) + word + container.Substring(wordLen - 2, 2);

        }

        public string MultipleEndings(string str)
        {
            int strLen = str.Length;
            string lastTwoChars = str.Substring(strLen - 2, 2);
            return (lastTwoChars + lastTwoChars + lastTwoChars);
        }

        public string FirstHalf(string str)
        {
            int halfLen = str.Length / 2;
            string firstHalf = str.Substring(0, halfLen);
            return (firstHalf);
        }

        public string TrimOne(string str)
        {
            throw new NotImplementedException();
        }

        public string LongInMiddle(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string RotateLeft2(string str)
        {
            throw new NotImplementedException();
        }

        public string RotateRight2(string str)
        {
            throw new NotImplementedException();
        }

        public string TakeOne(string str, bool fromFront)
        {
            throw new NotImplementedException();
        }

        public string MiddleTwo(string str)
        {
            throw new NotImplementedException();
        }

        public bool EndsWithLy(string str)
        {
            throw new NotImplementedException();
        }

        public string FrontAndBack(string str, int n)
        {
            throw new NotImplementedException();
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            string returnStr = "";
            int strLen = str.Length;

            if (strLen == 0) { returnStr = "@@"; }
            else if (strLen == 1) { returnStr = str + "@"; }
            else if (strLen > 1) { returnStr = str.Substring(0, 2); }

            return (returnStr);
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            string tempStr = a + b, returnStr = "", currentChar = "", nextChar = "";

            for (int i = 0; i < tempStr.Length - 1; i++)
            {
                currentChar = tempStr.Substring(i, 1);
                nextChar = tempStr.Substring(i + 1, 1);
                if (currentChar != nextChar) { returnStr += currentChar; }
            }
            returnStr += nextChar;

            return(returnStr);
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
