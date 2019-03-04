using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class LoopsTests
    {
        private Loops _loops = new Loops();

        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        public void StringTimesTest(string str, int n, string expected)
        {
            var actual = _loops.StringTimes(str, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]
        public void FrontTimesTest(string str, int n, string expected)
        {
            var actual = _loops.FrontTimes(str, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("xxxx", 3)]
        public void CountXXTest(string str, int expected)
        {
            var actual = _loops.CountXX(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        [TestCase("dffa", false)]
        [TestCase("tx", false)]
        [TestCase("txx", true)]
        public void DoubleXTest(string str, bool expected)
        {
            var actual = _loops.DoubleX(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void EveryOtherTest(string str, string expected)
        {
            var actual = _loops.EveryOther(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void StringSplosionTest(string str, string expected)
        {
            var actual = _loops.StringSplosion(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx", 1)]
        [TestCase("axxxaaxx", 2)]
        public void CountLast2Test(string str, int expected)
        {
            var actual = _loops.CountLast2(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 9 }, 1)]
        [TestCase(new[] { 1, 9, 9 }, 2)]
        [TestCase(new[] { 1, 9, 9, 3, 9 }, 3)]
        public void Count9Test(int[] nums, int expected)
        {
            var actual = _loops.Count9(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 9, 3, 4 }, true)]
        [TestCase(new[] { 1, 2, 3, 4, 9 }, false)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, false)]
        public void ArrayFront9Test(int[] nums, bool expected)
        {
            var actual = _loops.ArrayFront9(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 1, 2, 3, 1 }, true)]
        [TestCase(new[] { 1, 1, 2, 4, 1 }, false)]
        [TestCase(new[] { 1, 1, 2, 1, 2, 3 }, true)]
        [TestCase(new[] { 1, 2, 3 }, true)]
        [TestCase(new[] { 3 }, false)]
        [TestCase(new[] { 3, 2 }, false)]
        public void Array123Test(int[] nums, bool expected)
        {
            var actual = _loops.Array123(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxcaazz", "xxbaaz", 3)]
        [TestCase("abc", "abc", 2)]
        [TestCase("abc", "axc", 0)]
        public void SubStringMatchTest(string s1, string s2, int expected)
        {
            var actual = _loops.SubStringMatch(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxHxix", "xHix")]
        [TestCase("abxxxcd", "abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void StringXTest(string str, string expected)
        {
            var actual = _loops.StringX(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("kitten", "kien")]
        [TestCase("Chocolate", "Chole")]
        [TestCase("CodingHorror", "Congrr")]
        public void AltPairsTest(string str, string expected)
        {
            var actual = _loops.AltPairs(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("yakpak", "pak")]
        [TestCase("pakyak", "pak")]
        [TestCase("yak123ya", "123ya")]
        public void DoNotYakTest(string str, string expected)
        {
            var actual = _loops.DoNotYak(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 6, 6, 2 }, 1)]
        [TestCase(new[] { 6, 6, 2, 6 }, 1)]
        [TestCase(new[] { 6, 7, 2, 6 }, 1)]
        [TestCase(new[] { 6, 7, 6, 6 }, 2)]
        [TestCase(new[] { 1, 2, 6 }, 0)]
        public void Array667Test(int[] nums, int expected)
        {
            var actual = _loops.Array667(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 1, 2, 2, 1 }, true)]
        [TestCase(new[] { 1, 1, 2, 2, 2, 1 }, false)]
        [TestCase(new[] { 1, 1, 1, 2, 2, 2, 1 }, false)]
        [TestCase(new[] { 3, 1, 1 }, true)]
        [TestCase(new[] { 2, 1 }, true)]
        public void NoTriplesTest(int[] nums, bool expected)
        {
            var actual = _loops.NoTriples(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 7, 1 }, true)]
        [TestCase(new[] { 1, 2, 8, 1 }, false)]
        [TestCase(new[] { 2, 7, 1 }, true)]
        [TestCase(new[] { 6, 4, 9, 3, 2 }, true)]
        [TestCase(new[] { 2, 7 }, false)]
        public void Pattern51Test(int[] nums, bool expected)
        {
            var actual = _loops.Pattern51(nums);
            Assert.AreEqual(expected, actual);
        }

    }
}
