using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review2_NET.Models;

namespace Review2_NET.Models.Repositories
{
    public class EFReviewRepo : IReviewRepo
    {
        private MyContext db = new MyContext();

        public IQueryable<Review> Reviews { get { return db.Reviews; } }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();   
        }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }
    }
}
