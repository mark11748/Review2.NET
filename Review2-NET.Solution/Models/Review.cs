using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Review2_NET.Models;

namespace Review2_NET.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId   { get; set; }
        public int ProductId  { get; set; }
        public string Author  { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        public Review() { }

        public override bool Equals(System.Object obj)
        {
            if (!(obj is Review))
            { return false; }
            else
            { return (Review)obj == this; }
        }
        public override int GetHashCode()
        { return this.ReviewId.GetHashCode(); }

        public int ValidateRating(int rating)
        {
            if (rating < 1) { rating = 1; }
            if (rating > 5) { rating = 5; }

            return rating;
        }
    }
}
