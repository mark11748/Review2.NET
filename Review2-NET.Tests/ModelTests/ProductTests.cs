using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Review2_NET.Models;

namespace Review2_NET.Tests
{
    [TestClass]
    public class ProductTests
    {
      [TestMethod]
        public void GetName()
        {
            var testProduct = new Product("testName1","testDescript1",1);
            Assert.AreEqual("test1",testProduct.Name);
        }
        [TestMethod]
        public void GetDescription()
        {
            var testProduct = new Product("testName2", "testDescript2", 2);
            Assert.AreEqual("test2", testProduct.Description);
        }
        [TestMethod]
        public void GetCost()
        {
            var testProduct = new Product("testName3", "testDescript3", 3);
            Assert.AreEqual(3, testProduct.Cost);
        }
    }
}
