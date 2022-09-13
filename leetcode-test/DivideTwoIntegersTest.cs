using NUnit.Framework;

namespace leetcode_test
{
    public class DivideTwoIntegersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(10, 3);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Test2()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(2147483647, 1);
            Assert.AreEqual(2147483647, result);
        }

        [Test]
        public void Test3()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(-2147483648, 1);
            Assert.AreEqual(-2147483648, result);
        }

        [Test]
        public void Test4()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(-102, -3);
            Assert.AreEqual(34, result);
        }

        [Test]
        public void Test5()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(-1, -2147483648);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test6()
        {
            var solution = new Solution();
            var result = solution.DivideTwoIntegers(-2147483648, -1);
            Assert.AreEqual(2147483647, result);
        }
    }
}