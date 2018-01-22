using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review2_NET.Models;
using Review2_NET.Controllers;
using Review2_NET.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Review2_NET.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        Mock<IProductRepo> mock = new Mock<IProductRepo>();

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
        public void IndexTest_returnActionResult()
        {
            DbSetUp();
            ProductsController testController = new ProductsController(mock.Object);

            IActionResult result = testController.Index();
           
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void IndexTest_testViewModel()
        {
            DbSetUp();
            ProductsController testController = new ProductsController(mock.Object);

            ViewResult indexView = testController.Index() as ViewResult;
            var products = indexView.ViewData.Model as List<Product>;

            Assert.IsInstanceOfType(products, typeof(List<Product>));
        }

        [TestMethod]
        public void DetailsTest_returnActionResult()
        {
            DbSetUp();
            ProductsController testController = new ProductsController(mock.Object);

            IActionResult details1 = testController.Details(0);
            IActionResult details2 = testController.Details(1);
            IActionResult details3 = testController.Details(2);

            Assert.IsInstanceOfType(details1, typeof(ActionResult));
            Assert.IsInstanceOfType(details2, typeof(ActionResult));
            Assert.IsInstanceOfType(details3, typeof(ActionResult));
        }

        [TestMethod]
        public void DetailsTest_correctInfo()
        {
            DbSetUp();
            ProductsController testController = new ProductsController(mock.Object);

            ViewResult infoView1 = testController.Details(0) as ViewResult;
            Product details1 = infoView1.ViewData.Model as Product;
            ViewResult infoView2 = testController.Details(1) as ViewResult;
            Product details2 = infoView1.ViewData.Model as Product;
            ViewResult infoView3 = testController.Details(2) as ViewResult;
            Product details3 = infoView1.ViewData.Model as Product;

            Assert.AreEqual(details1.Name, "testName1");
            Assert.AreEqual(details1.Cost, 999);
            Assert.AreEqual(details2.Name, "testName2");
            Assert.AreEqual(details2.Cost, 1);
            Assert.AreEqual(details3.Name, "testName3");
            Assert.AreEqual(details3.Cost, 25);
        }


    }
}
