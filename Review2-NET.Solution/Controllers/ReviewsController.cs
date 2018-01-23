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
            var model = new Review();
            model.ProductId=productId;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Review newReview)
        {
            if (string.IsNullOrWhiteSpace(newReview.Author )) { newReview.Author = "Anonymous"; }
            if (string.IsNullOrWhiteSpace(newReview.Comment)) { newReview.Comment = "N/a"; }
            if (newReview.Comment.Length>255) { newReview.Comment.Substring(0,255); }
            if (newReview.Rating>5) { newReview.Rating = 5; }
            if (newReview.Rating<1) { newReview.Rating = 1; }

            reviewRepo.Save(newReview);
            return RedirectToAction("Index","Products");
        }

        public IActionResult ProductReviews(int productId)
        {
            var model = reviewRepo.Reviews.Where(review => review.ProductId == productId).ToList();
            Product dummy = new Product();
            ViewBag.avg = dummy.GetAvgRating(model);
            return View(model);
        }

        public IActionResult Delete(int reviewId)
        {
            Review model = reviewRepo.Reviews.FirstOrDefault(review => review.ReviewId == reviewId);
            return View(model);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteAllConfirmed(int reviewId)
        {
            Review unwantedReview = reviewRepo.Reviews.FirstOrDefault(review => review.ReviewId == reviewId);
            reviewRepo.Remove(unwantedReview);
            return RedirectToAction("Index","Products");
        }
    }
}
