using NUnit.Framework;

namespace leetcode_test
{
    public class MyAtoiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solution = new Solution();
            int result = solution.MyAtoi("2147483646");
            Assert.AreEqual(result, 2147483646);
        }

        [Test]
        public void Test2()
        {
            var solution = new Solution();
            int result = solution.MyAtoi("abc_2147483646");
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Test3()
        {
            var solution = new Solution();
            int result = solution.MyAtoi2("9223372036854775808");
            Assert.AreEqual(result, 2147483647);
        }
    }
}