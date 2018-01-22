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

        public IActionResult Create(int productId)
        {
            var model = productId;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Review newReview)
        {
            if (string.IsNullOrWhiteSpace(newReview.Author )) { newReview.Author = "Anonymous"; }
            if (string.IsNullOrWhiteSpace(newReview.Comment)) { newReview.Comment = "N/a"; }
            reviewRepo.Save(newReview);
            return RedirectToAction("Index","Products");
        }

        public IActionResult GetReviews(int productId)
        {
            var model = reviewRepo.Reviews.Where(review => review.ProductId == productId).ToList();
            return View(model);
        }

        public IActionResult DeleteAll()
        {
            return View();
        }
        [HttpPost,ActionName("DeleteAll")]
        public IActionResult DeleteAllConfirmed()
        {
            foreach (Review review in reviewRepo.Reviews)
            {
                reviewRepo.Remove(review);
            }
            return RedirectToAction("Index","Products");
        }
    }
}
