using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class AnyOfTests
    {

        [TestMethod()]
        public void AnyOfTest_CharacterA_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { 'a' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("a"));
        }        
        
        [TestMethod()]
        public void AnyOfTest_CharacterABC_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { 'a', 'b', 'c' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("c"));
        }        

        [TestMethod()]
        public void AnyOfTest_CharacterATestB_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { 'a' });

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("b"));
        }

        [TestMethod()]
        public void AnyOfTest_SpecialCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { '!' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("!"));
        }

        [TestMethod()]
        public void AnyOfTest_NotCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { '^' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("^"));
        }

        [TestMethod()]
        public void AnyOfTest_BracketCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(new[] { '{' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("{"));
        }
    }
}