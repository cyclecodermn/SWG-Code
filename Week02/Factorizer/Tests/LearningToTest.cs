using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizer.BLL;

namespace Tests
{

    [TestFixture]
    public class LearningToTest
    {
        [TestCase(6,true)]
        [TestCase(3,false)]
        [TestCase(2,false)]
        
        public static void PerfectCheckerTest(int intCk, bool returnBool)
        {

            bool perfectCk = PerfectChecker.GetPerfectNum(intCk);

            Assert.AreEqual(perfectCk, returnBool);
        }

        [TestCase(7, true)]
        [TestCase(4, false)]
        [TestCase(8, false)]

        public static void PrimeCheckerTest(int intCk, bool returnBool)
        {

            bool primeCk = PrimeChecker.CkForPrime(intCk);

            Assert.AreEqual(primeCk, returnBool);
        }

        //[TestCase(3, new[] { 3, 1, 4 })]
        //[TestCase(1, new[] { 3 })]
        //[TestCase(5, new[] { 3, 1, 4, 1, 5 })]

        //public static returnInts=FactorFinder.GetFactors(int n, int[] expected);

        //Assert.AreEqual(expected, actual);

        //    //[TestCase(7, true)]
        //    //[TestCase(4, false)]
        //    //[TestCase(8, false)]

        //    //public static void FactorCheckerTest(int intCk, bool returnBool)
        //    //{

        //    //    bool primeCk = PrimeChecker.CkForPrime(intCk);
        //    //}



       // }

