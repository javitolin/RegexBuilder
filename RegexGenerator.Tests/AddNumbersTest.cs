﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRegexBuilder.Tests
{
    [TestClass()]
    public class AddNumbersTest
    {
        [TestMethod()]
        public void AddNumbersTest_OneNumber_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyNumber(Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("2"));
        }        
        
        [TestMethod()]
        public void AddNumbersTest_OneNumberGiveLetter_AssertsFalse()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyNumber(Times.Once);

            var regex = regexBuilder.ToRegex();

            Assert.IsFalse(regex.IsMatch("a"));
        }        

        [TestMethod()]
        public void AddNumbersTest_ExtactlyThreeNumber_AssertsTrue()
        {
            RegexBuilder regexBuilder = new RegexBuilder();
            regexBuilder = regexBuilder.AddAnyNumber(Times.Exactly(3));

            var regex = regexBuilder.ToRegex();

            Assert.IsTrue(regex.IsMatch("123"));
        }
    }
}