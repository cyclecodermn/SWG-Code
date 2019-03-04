using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        private Arrays _arrays = new Arrays();

        [TestCase(new[] { 1, 2, 6 }, true)]
        [TestCase(new[] { 6, 1, 2, 3 }, true)]
        [TestCase(new[] { 13, 6, 1, 2, 3 }, false)]

        public void FirstLast6Test(int[] nums, bool expected)
        {
            var actual = _arrays.FirstLast6(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, false)]
        [TestCase(new[] { 1, 2, 3, 1 }, true)]
        [TestCase(new[] { 1, 2, 1 }, true)]
        public void SameFirstLastTest(int[] nums, bool expected)
        {
            var actual = _arrays.SameFirstLast(nums);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(3, new[] { 3, 1, 4 })]
        [TestCase(1, new[] { 3 })]
        [TestCase(5, new[] { 3, 1, 4, 1, 5 })]
        public void MakePiTest(int n, int[] expected)
        {
            var actual = _arrays.MakePi(n);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new[] { 1, 2, 3 }, new[] { 7, 3 }, true)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 7, 3, 2 }, false)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3 }, true)]
        public void CommonEndTest(int[] a, int[] b, bool expected)
        {
            var actual = _arrays.CommonEnd(a, b);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new[] { 1, 2, 3 }, 6)]
        [TestCase(new[] { 5, 11, 2 }, 18)]
        [TestCase(new[] { 7, 0, 0 }, 7)]
        public void SumTest(int[] nums, int expected)
        {
            var actual = _arrays.Sum(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 2, 3, 1 })]
        [TestCase(new[] { 5, 11, 9 }, new[] { 11, 9, 5 })]
        [TestCase(new[] { 7, 0, 0 }, new[] { 0, 0, 7 })]
        public void RotateLeftTest(int[] nums, int[] expected)
        {
            var actual = _arrays.RotateLeft(nums);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
        [TestCase(new[] { 5, 9, 11, 1 }, new[] { 1, 11, 9, 5 })]
        [TestCase(new[] { 7, 0, 0 }, new[] { 0, 0, 7 })]
        [TestCase(new[] { 7 }, new[] { 7 })]
        public void ReverseTest(int[] nums, int[] expected)
        {
            var actual = _arrays.Reverse(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 3, 3 })]
        [TestCase(new[] { 11, 5, 9 }, new[] { 11, 11, 11 })]
        [TestCase(new[] { 2, 11, 3 }, new[] { 3, 3, 3 })]
        public void HigherWinsTest(int[] nums, int[] expected)
        {
            var actual = _arrays.HigherWins(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 2, 5 })]
        [TestCase(new[] { 7, 7, 7 }, new[] { 3, 8, 0 }, new[] { 7, 8 })]
        [TestCase(new[] { 5, 2, 9 }, new[] { 1, 4, 5 }, new[] { 2, 4 })]
        public void GetMiddleTest(int[] a, int[] b, int[] expected)
        {
            var actual = _arrays.GetMiddle(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 2, 5 }, true)]
        [TestCase(new[] { 4, 3 }, true)]
        [TestCase(new[] { 7, 5 }, false)]
        public void HasEvenTest(int[] nums, bool expected)
        {
            var actual = _arrays.HasEven(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 4, 5, 6 }, new[] { 0, 0, 0, 0, 0, 6 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 0, 0, 2 })]
        [TestCase(new[] { 3 }, new[] { 0, 3 })]
        public void KeepLastTest(int[] nums, int[] expected)
        {
            var actual = _arrays.KeepLast(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 2, 2, 3 }, true)]
        [TestCase(new[] { 3, 4, 5, 3 }, true)]
        [TestCase(new[] { 2, 3, 2, 2 }, false)]
        public void Double23Test(int[] nums, bool expected)
        {
            var actual = _arrays.Double23(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 0 })]
        [TestCase(new[] { 2, 3, 5 }, new[] { 2, 0, 5 })]
        [TestCase(new[] { 1, 2, 1 }, new[] { 1, 2, 1 })]
        public void Fix23Test(int[] nums, int[] expected)
        {
            var actual = _arrays.Fix23(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1, 3, 4, 5 }, true)]
        [TestCase(new[] { 2, 1, 3, 4, 5 }, true)]
        [TestCase(new[] { 1, 1, 1 }, false)]
        public void Unlucky1Test(int[] nums, bool expected)
        {
            var actual = _arrays.Unlucky1(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 4, 5 })]
        [TestCase(new[] { 4 }, new[] { 1, 2, 3 }, new[] { 4, 1 })]
        [TestCase(new int[] { }, new[] { 1, 2 }, new[] { 1, 2 })]
        public void Make2Test(int[] a, int[] b, int[] expected)
        {
            var actual = _arrays.Make2(a, b);
            Assert.AreEqual(expected, actual);
        }

    }
}
