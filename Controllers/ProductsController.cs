using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review2_NET.Models;
using Review2_NET.Models.Repositories;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review2_NET.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepo productRepo;

        public ProductsController(IProductRepo repo = null)
        {
            if (repo == null)
            { this.productRepo = new EFProductRepo(); }
            else
            { this.productRepo = repo; }
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(productRepo.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View( productRepo.Products.FirstOrDefault(product => product.ProductId == id) );
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Product model = productRepo.Products.FirstOrDefault(product=>product.ProductId==id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            return View(productRepo.Products.FirstOrDefault(product=>product.ProductId==id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product unwantedProduct = productRepo.Products.FirstOrDefault(product=>product.ProductId==id);
            productRepo.Remove(unwantedProduct);
            return RedirectToAction("Index");
        }
    }
}
