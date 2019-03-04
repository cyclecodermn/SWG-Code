using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class ConditionalsTests
    {
        private Conditionals _conditionals = new Conditionals();

        [TestCase(true, true, true)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        public void AreWeInTroubleTest(bool a, bool b, bool expected)
        {
            var actual = _conditionals.AreWeInTrouble(a, b);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        public void CanSleepInTest(bool a, bool b, bool expected)
        {
            var actual = _conditionals.CanSleepIn(a, b);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 5)]
        [TestCase(2, 2, 8)]
        public void SumDoubleTest(int a, int b, int expected)
        {
            var actual = _conditionals.SumDouble(a, b);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]
        public void Diff21Test(int n, int expected)
        {
            var actual = _conditionals.Diff21(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]
        public void ParrotTroubleTest(bool b, int n, bool expected)
        {
            var actual = _conditionals.ParrotTrouble(b, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]
        public void Makes10Test(int x, int y, bool expected)
        {
            var actual = _conditionals.Makes10(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(103, true)]
        [TestCase(90, true)]
        [TestCase(89, false)]
        public void NearHundredTest(int n, bool expected)
        {
            var actual = _conditionals.NearHundred(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1, false, true)]
        [TestCase(-1, 1, false, true)]
        [TestCase(-4, -5, true, true)]
        public void PosNegTest(int x, int y, bool b, bool expected)
        {
            var actual = _conditionals.PosNeg(x, y, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("candy", "not candy")]
        [TestCase("x", "not x")]
        [TestCase("bad", "not bad")]
        public void NotStringTest(string s, string expected)
        {
            var actual = _conditionals.NotString(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("kitten", 1, "ktten")]
        [TestCase("kitten", 0, "itten")]
        [TestCase("kitten", 4, "kittn")]
        public void MissingCharTest(string s, int n, string expected)
        {
            var actual = _conditionals.MissingChar(s, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("code", "eodc")]
        [TestCase("a", "a")]
        [TestCase("ab", "ba")]
        public void FrontBackTest(string s, string expected)
        {
            var actual = _conditionals.FrontBack(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Microsoft", "MicMicMic")]
        [TestCase("Chocolate", "ChoChoCho")]
        [TestCase("at", "atatat")]
        public void Front3Test(string s, string expected)
        {
            var actual = _conditionals.Front3(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("cat", "tcatt")]
        [TestCase("Hello", "oHelloo")]
        [TestCase("a", "aaa")]
        public void BackAroundTest(string s, string expected)
        {
            var actual = _conditionals.BackAround(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(8, false)]
        public void Multiple3or5Test(int n, bool expected)
        {
            var actual = _conditionals.Multiple3or5(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("hi there", true)]
        [TestCase("hi", true)]
        [TestCase("high up", false)]
        [TestCase("g", false)]
        [TestCase("hip", false)]
        [TestCase("hi, how are you?", true)]
        public void StartHiTest(string str, bool expected)
        {
            var actual = _conditionals.StartHi(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(120, -1, true)]
        [TestCase(-1, 120, true)]
        [TestCase(2, 120, false)]
        public void StartHiTest(int x, int y, bool expected)
        {
            var actual = _conditionals.IcyHot(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(12, 99, true)]
        [TestCase(21, 12, true)]
        [TestCase(8, 99, false)]
        public void Between10and20Test(int x, int y, bool expected)
        {
            var actual = _conditionals.Between10and20(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(13, 20, 10, true)]
        [TestCase(20, 19, 10, true)]
        [TestCase(20, 10, 12, false)]
        public void HasTeenTest(int x, int y, int z, bool expected)
        {
            var actual = _conditionals.HasTeen(x, y, z);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(13, 99, true)]
        [TestCase(21, 19, true)]
        [TestCase(13, 13, false)]
        [TestCase(44, 5, false)]
        public void SoAloneTest(int x, int y, bool expected)
        {
            var actual = _conditionals.SoAlone(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("adelbc", "abc")]
        [TestCase("adelHello", "aHello")]
        [TestCase("adedbc", "adedbc")]
        public void RemoveDelTest(string s, string expected)
        {
            var actual = _conditionals.RemoveDel(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("mix snacks", true)]
        [TestCase("pix snacks", true)]
        [TestCase("piz snacks", false)]
        public void IxStartTest(string str, bool expected)
        {
            var actual = _conditionals.IxStart(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("ozymandias", "oz")]
        [TestCase("bzoo", "z")]
        [TestCase("oxx", "o")]
        [TestCase("w", "")]
        public void StartOzTest(string s, string expected)
        {
            var actual = _conditionals.StartOz(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 3)]
        [TestCase(1, 3, 2, 3)]
        [TestCase(3, 2, 1, 3)]
        public void MaxTest(int a, int b, int c, int expected)
        {
            var actual = _conditionals.Max(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(8, 13, 8)]
        [TestCase(13, 8, 8)]
        [TestCase(13, 7, 0)]
        public void CloserTest(int a, int b, int expected)
        {
            var actual = _conditionals.Closer(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", true)]
        [TestCase("Heelle", true)]
        [TestCase("Heelele", false)]
        [TestCase("344", false)]
        public void GotETest(string str, bool expected)
        {
            var actual = _conditionals.GotE(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "HeLLO")]
        [TestCase("hi there", "hi thERE")]
        [TestCase("hi", "HI")]
        public void EndUpTest(string s, string expected)
        {
            var actual = _conditionals.EndUp(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Miracle", 2, "Mrce")]
        [TestCase("abcdefg", 2, "aceg")]
        [TestCase("abcdefg", 3, "adg")]
        public void EveryNthTest(string s, int n, string expected)
        {
            var actual = _conditionals.EveryNth(s, n);
            Assert.AreEqual(expected, actual);
        }

    }
}
