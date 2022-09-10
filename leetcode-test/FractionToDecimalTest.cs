using NUnit.Framework;

namespace leetcode_test
{
    public class FractionToDecimalTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(1, 2);
            Assert.AreEqual("0.5", result);
        }

        [Test]
        public void Test2()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(-50, 8);
            Assert.AreEqual("-6.25", result);
        }

        [Test]
        public void Test3()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(50, -8);
            Assert.AreEqual("-6.25", result);
        }

        [Test]
        public void Test4()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(-1, -2147483648);
            Assert.AreEqual("0.000000000465661", result);
        }

        [Test]
        public void Test5()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(-1000000000, -2147483648);
            Assert.AreEqual("0.465661287307739", result);
        }

        [Test]
        public void Test6()
        {
            var solution = new Solution();
            var result = solution.FractionToDecimal(-2147483648, -1);
            Assert.AreEqual("2147483648", result);
        }
    }
}