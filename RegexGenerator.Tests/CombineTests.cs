using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]

    public class CombineTests
    {
        [TestMethod]
        public void CombinedTest_EmailAddress_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Any).AddLiteral("@", Times.Once).AddAnyWordCharacter(Times.Any).AddLiteral(".").AddAnyWordCharacter(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("john@doe.com"));
        }

        [TestMethod]
        public void CombinedTest_WrongEmailAddress_MatchesFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Any).AddLiteral("@", Times.Once).AddAnyWordCharacter(Times.Any).AddLiteral(".").AddAnyWordCharacter(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("john@doe.com.ar"));
        }

        [TestMethod]
        public void CombinedTest_SecondEmailAddress_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Any, new[] { "." }).AddLiteral("@", Times.Once).AddAnyWordCharacter(Times.Any).AddLiteral(".").AddAnyWordCharacter(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("john.doe@doe.com"));
        }

        [TestMethod]
        public void CombinedTest_ThirdEmailAddress_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Any).AddLiteral("@", Times.Once).AddAnyWordCharacter(Times.Any).AddLiteral(".").AddAnyWordCharacter(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("john_doe@doe.com"));
        }
    }
}
