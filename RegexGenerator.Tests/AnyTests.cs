using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRegexBuilder.Tests
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void AnyTest_SingleCharacter_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAny();

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("a"));
        }

        [TestMethod]
        public void AnyTest_TwoCharacters_MatchesFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAny();

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("aa"));
        }

        [TestMethod]
        public void AnyTestTwoTimes_TwoCharacters_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAny(Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("aa"));
        }
    }
}