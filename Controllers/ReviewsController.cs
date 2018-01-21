using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review2_NET.Models;
using Review2_NET.Models.Repositories;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review2NET.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepo reviewRepo;

        public ReviewsController(IReviewRepo repo = null)
        {
            if (repo == null)
            { this.reviewRepo = new EFReviewRepo(); }
            else
            { this.reviewRepo = repo; }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int reviewId)
        {
            var model = db.Products.FirstOrDefaultAsync(product=>product.ProductId==productId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Review newReview)
        {
            if (string.IsNullOrWhiteSpace(newReview.Author )) { newReview.Author = "Anonymous"; }
            if (string.IsNullOrWhiteSpace(newReview.Comment)) { newReview.Comment = "N/a"; }
            db.Reviews.Add(newReview);
            db.SaveChanges();
            return View();
        }

        public IActionResult GetReviews(int reviewId)
        {
            var model = db.Reviews.Where(review => review.ProductId == productId).ToList();
            return View(model);
        }

        public IActionResult DeleteAll()
        {
            return View();
        }
        [HttpPost,ActionName("DeleteAll")]
        public IActionResult DeleteAllConfirmed()
        {
            foreach (Review review in db.Reviews)
            {
                db.Reviews.Remove(review);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Products");
        }
    }
}
