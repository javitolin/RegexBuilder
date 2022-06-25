using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexGenerator.Tests
{
    [TestClass()]
    public class TimesTests
    {
        [TestMethod()]
        public void RangeTest_ZeroToOne_AssertsTrue()
        {
            var result = Times.Range(0, 1);
            Assert.AreEqual("{0,1}", result);
        }

        [TestMethod()]
        public void RangeTest_MinusOneToOne_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.Range(-1, 1));
        }

        [TestMethod()]
        public void RangeTest_OneToOne_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.Range(1, 1));
        }
               
        [TestMethod()]
        public void RangeTest_OneToZero_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.Range(1, 0));
        }     
        
        [TestMethod()]
        public void AtLeast_One_AssertsTrue()
        {
            var result = Times.AtLeast(1);
            Assert.AreEqual("{1,}", result);
        }        

        [TestMethod()]
        public void AtLeast_MinusOne_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.AtLeast(-1));
        }
        
        [TestMethod()]
        public void NoMoreThan_One_AssertsTrue()
        {
            var result = Times.NoMoreThan(1);
            Assert.AreEqual("{0,1}", result);            
        }

        [TestMethod()]
        public void NoMoreThan_MinusOne_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.NoMoreThan(-1));
        }       

        [TestMethod()]
        public void Exactly_One_AssertsTrue()
        {
            var result = Times.Exactly(1);
            Assert.AreEqual("{1}", result);            
        }

        [TestMethod()]
        public void Exactly_MinusOne_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Times.Exactly(-1));
        }

    }
}