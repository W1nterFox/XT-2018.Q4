using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.Task1.Simple;

namespace UnitTestProjectSimple
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void Num7IsSimple()
        {
            int x = 7;
            bool expected = true;

            bool actual = Epam.Task1.Simple.IsSimpleNum(x);
            Assert.AreEqual(expected, actual);
        }
    }
}
