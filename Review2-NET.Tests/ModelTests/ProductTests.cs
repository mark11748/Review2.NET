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
            var testProduct = new Product();
            testProduct.Name = "test1";
            Assert.AreEqual("test1",testProduct.Name);
        }
        [TestMethod]
        public void GetDescription()
        {
            var testProduct = new Product();
            testProduct.Description = "test2";
            Assert.AreEqual("test2", testProduct.Description);
        }
        [TestMethod]
        public void GetCost()
        {
            var testProduct = new Product();
            testProduct.Cost = 3;
            Assert.AreEqual(3, testProduct.Cost);
        }
    }
}
