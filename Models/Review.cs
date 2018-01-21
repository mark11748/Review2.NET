using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Review2_NET.Models;

namespace Review2_NET.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        public int ReviewId   { get; set; }
        public int ProductId  { get; set; }
        public string Author  { get; set; }
        public string Comment { get; set; }

        private MyContext db = new MyContext();

        public IQueryable<Review> GetAll()
        {
            IQueryable<Review> reviews = db.Reviews;
            return reviews;   
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
