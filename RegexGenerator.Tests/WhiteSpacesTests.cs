using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRegexBuilder.Tests
{
    [TestClass]
    public class WhiteSpacesTests
    { 
        [TestMethod]
        public void AnyWhiteSpace_OneWhiteSpace_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWhiteSpace();

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch(" "));
        }

        [TestMethod]
        public void AnyWhiteSpace_TwoWhiteSpacesAnyTimes_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWhiteSpace(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("  "));
        }

        [TestMethod]
        public void AnyWhiteSpace_TwoWhiteSpacesTwoTimes_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWhiteSpace(Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("  "));
        }

        [TestMethod]
        public void AnyWhiteSpace_ThreeWhiteSpacesTwoTimes_MatchesFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWhiteSpace(Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("   "));
        }
    }
}