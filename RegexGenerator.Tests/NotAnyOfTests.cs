using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRegexBuilder.Tests
{
    [TestClass()]
    public class NotAnyOfTests
    {
        [TestMethod()]
        public void NotAnyOfTest_CharacterAWhenCharacterB_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddNotAnyOf(new[] { 'a' });

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("b"));
        }    
        
        [TestMethod()]
        public void NotAnyOfTest_CharacterAWhenCharacterA_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddNotAnyOf(new[] { 'a' });

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("a"));
        }        

        [TestMethod()]
        public void NotAnyOfTest_CharacterAWhenCharacterAB_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddNotAnyOf(new[] { 'a' }, Times.Any);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("ab"));
        }
    }
}