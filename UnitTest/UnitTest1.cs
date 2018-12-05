using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListWords.Controllers;
using System.Web.Mvc;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void returnData()
        {
            WordController controller = new WordController();

            var result = controller.returnData();
            Assert.AreEqual(typeof(ListWords.Models.Words), result.GetType()); 
        }
    }
}
