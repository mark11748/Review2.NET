using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review2_NET.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review2NET.Controllers
{
    public class ReviewsController : Controller
    {
        private MyContext db = new MyContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateReview(int productId)
        {
            var model = db.Products.FirstOrDefaultAsync(product=>product.ProductId==productId);
            return View(model);
        }

        public IActionResult GetReviews(int productId)
        {
            var model = db.Reviews.Include(review => review.ProductId == productId).ToList();
            return View(model);
        }

        public IActionResult DeleteAllReviews()
        {
            return View();
        }
        [HttpPost,ActionName("DeleteAllReviews")]
        public IActionResult DeleteAllConfirmed()
        {
            
            return RedirectToRoute("Products/");
        }
    }
}
