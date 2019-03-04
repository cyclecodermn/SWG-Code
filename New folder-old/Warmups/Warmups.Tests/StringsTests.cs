using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class StringsTests
    {
        private Strings _strings = new Strings();

        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expected)
        {
            var actual = _strings.SayHi(name);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("What", "Up", "WhatUpUpWhat")]
        public void AbbaTest(string a, string b, string expected)
        {
            var actual = _strings.Abba(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTagsTest(string tag, string content, string expected)
        {
            var actual = _strings.MakeTags(tag, content);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]
        public void InsertWordTest(string container, string word, string expected)
        {
            var actual = _strings.InsertWord(container, word);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]
        public void MultipleEndingsTest(string s, string expected)
        {
            var actual = _strings.MultipleEndings(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]
        public void FirstHalfTest(string s, string expected)
        {
            var actual = _strings.FirstHalf(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOneTest(string s, string expected)
        {
            var actual = _strings.TrimOne(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        public void LongInMiddleTest(string s1, string s2, string expected)
        {
            var actual = _strings.LongInMiddle(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2Test(string s, string expected)
        {
            var actual = _strings.RotateLeft2(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateRight2Test(string s, string expected)
        {
            var actual = _strings.RotateRight2(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOneTest(string s, bool b, string expected)
        {
            var actual = _strings.TakeOne(s, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void MiddleTwoTest(string s, string expected)
        {
            var actual = _strings.MiddleTwo(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsWithLyTest(string s, bool expected)
        {
            var actual = _strings.EndsWithLy(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontAndBackTest(string s, int n, string expected)
        {
            var actual = _strings.FrontAndBack(s, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPositionTest(string s, int n, string expected)
        {
            var actual = _strings.TakeTwoFromPosition(s, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        [TestCase("", false)]
        [TestCase("cantaloupe", false)]
        public void HasBadTest(string s, bool expected)
        {
            var actual = _strings.HasBad(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        [TestCase("", "@@")]
        public void AtFirstTest(string s, string expected)
        {
            var actual = _strings.AtFirst(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        [TestCase("", "", "@@")]
        [TestCase("", "f", "@f")]
        public void LastCharsTest(string s1, string s2, string expected)
        {
            var actual = _strings.LastChars(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        [TestCase("", "abc", "abc")]
        [TestCase("b", "boat", "boat")]
        [TestCase("boat", "t", "boat")]
        public void ConCatTest(string s1, string s2, string expected)
        {
            var actual = _strings.ConCat(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        [TestCase("a", "a")]
        public void SwapLastTest(string s, string expected)
        {
            var actual = _strings.SwapLast(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        public void FrontAgainTest(string s, bool expected)
        {
            var actual = _strings.FrontAgain(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "Hi", "loHi")]
        [TestCase("Hello", "java", "ellojava")]
        [TestCase("java", "Hello", "javaello")]
        [TestCase("", "beep", "")]
        [TestCase("x", "yyyyy", "xy")]
        public void MinCatTest(string s1, string s2, string expected)
        {
            var actual = _strings.MinCat(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        [TestCase("oboe", "boe")]
        [TestCase("", "")]
        public void TweakFrontTest(string s, string expected)
        {
            var actual = _strings.TweakFront(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        [TestCase("x", "")]
        [TestCase("", "")]
        public void StripXTest(string s, string expected)
        {
            var actual = _strings.StripX(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
