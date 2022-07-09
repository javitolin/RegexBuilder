using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRegexBuilder.Tests
{
    [TestClass()]
    public class LiteralTests
    {
        [TestMethod()]
        public void LiteralTest_OneWord_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddVerb("Hello");

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("Hello"));
        }
        
        [TestMethod()]
        public void LiteralTest_OneLetter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddVerb("H");

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("H"));
        }        

        [TestMethod()]
        public void LiteralTest_OneWordTwiceOnceGiven_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddVerb("Hello", Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("Hello"));
        }

        [TestMethod()]
        public void LiteralTest_OneWordTwiceTwiceGiven_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddVerb("Hello", Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("HelloHello"));
        }
    }
}