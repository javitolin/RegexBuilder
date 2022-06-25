using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class RegexBuilderConstTests
    {
        [TestMethod()]
        public void AllLettersLowerCaseTest_OneCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersLowerCase, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("a"));
        }        
        
        [TestMethod()]
        public void AllLettersLowerCaseTest_OneNumber_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersLowerCase, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("1"));
        }

        [TestMethod()]
        public void AllLettersUpperCaseTest_OneCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersUpperCase, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("A"));
        }

        [TestMethod()]
        public void AllLettersUpperCaseTest_OneNumber_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersUpperCase, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("1"));
        }

        [TestMethod()]
        public void AllLettersAllCaseTest_OneCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersAllCases, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("A"));
            Assert.IsTrue(regex.IsMatch("a"));
        }

        [TestMethod()]
        public void AllLettersAllCaseTest_OneNumber_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersAllCases, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("1"));
        }

        [TestMethod()]
        public void AllNumbersTest_OneNumber_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllNumbers, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("1"));
        }

        [TestMethod()]
        public void AllNumbersTest_OneCharacter_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllNumbers, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("a"));
        }

        [TestMethod()]
        public void AllLettersAndNumbersTest_OneCharacter_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersAndNumbers, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("a"));
        }

        [TestMethod()]
        public void AllLettersAndNumbersTest_OneNumber_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllLettersAndNumbers, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("1"));
        }

        [TestMethod()]
        public void AllLettersAndNumbersTest_OneSpecialCharacter_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyOf(RegexBuilder.AllNumbers, Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("!"));
        }
    }
}