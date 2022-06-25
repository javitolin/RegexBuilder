using RegexGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class AnyCharacterTests
    {
        [TestMethod]
        public void AnyCharacter_OneCharacter_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter();

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("1"));
        }

        [TestMethod]
        public void AnyCharacter_TwoCharactersAnyTimes_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("12"));
        }

        [TestMethod]
        public void AnyCharacter_TwoCharactersTwoTimes_MatchesTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("12"));
        }

        [TestMethod]
        public void AnyCharacter_ThreeCharactersTwoTimes_MatchesFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyWordCharacter(Times.Exactly(2));

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("123"));
        }
    }
}