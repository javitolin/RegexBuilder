using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class LiteralTests
    {
        [TestMethod()]
        public void LiteralTest_OneWord_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddLiteral("Hello");

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("Hello"));
        }
        
        [TestMethod()]
        public void LiteralTest_OneLetter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddLiteral("H");

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("H"));
        }        

        [TestMethod()]
        public void LiteralTest_OneWordTwiceOnceGiven_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddLiteral("Hello", Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("Hello"));
        }

        [TestMethod()]
        public void LiteralTest_OneWordTwiceTwiceGiven_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddLiteral("Hello", Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("HelloHello"));
        }
    }
}