using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class RegexCommonPatternsTests
    {
        [TestMethod()]
        public void EmailPatternTest_CorrectEmail_AssertsTrue()
        {
            var emailpattern = RegexCommonPatterns.EmailPattern();

            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder.AddPattern(emailpattern);

            Assert.IsTrue(regexBuilder.ToRegex().IsMatch("John@doe.com"));
        }       
        
        [TestMethod()]
        public void EmailPatternTest_WrongEmail_AssertsFalse()
        {
            var emailpattern = RegexCommonPatterns.EmailPattern();

            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder.AddPattern(emailpattern);

            Assert.IsFalse(regexBuilder.ToRegex().IsMatch("John@doe.c"));
        }
    }
}