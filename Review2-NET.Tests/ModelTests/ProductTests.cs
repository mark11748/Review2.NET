using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Review2_NET.Models;
using Review2_NET.Models.Repositories;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Review2_NET.Tests
{
    [TestClass]
    public class ProductTests
    {
        Mock<IProductRepo> mock = new Mock<IProductRepo>();

        [TestInitialize]
        public void DbSetUp()
        {
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product{ProductId = 0, Name = "testName1",Description = "testDescription1",Cost = 999},
                new Product{ProductId = 1, Name = "testName2",Description = "testDescription2",Cost = 1},
                new Product{ProductId = 2, Name = "testName3",Description = "testDescription3",Cost = 25}

            }.AsQueryable());
        }

      [TestMethod]
        public void GetName()
        {
            var testProduct = new Product("testName1","testDescript1",1);
            Assert.AreEqual("testName1",testProduct.Name);
        }
        [TestMethod]
        public void GetDescription()
        {
            var testProduct = new Product("testName2", "testDescript2", 2);
            Assert.AreEqual("testDescript2", testProduct.Description);
        }
        [TestMethod]
        public void GetCost()
        {
            var testProduct = new Product("testName3", "testDescript3", 3);
            Assert.AreEqual(3, testProduct.Cost);
        }
    }
}
