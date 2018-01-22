using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Review2_NET.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public Product(){}
        public Product(string name,string descript,int cost)
        {
            this.Name = name;
            this.Description = descript;
            this.Cost = cost;
        }
        public override bool Equals(System.Object obj)
        {
            if (!(obj is Product))
            {return false;}
            else
            {return (Product)obj == this;}
        }
        public override int GetHashCode()
        { return this.ProductId.GetHashCode(); }

        public int GetAvgRating(List<Review> reviews)
        {
            int avg=0;
            int counter=0;
            foreach(Review review in reviews)
            {
                counter++;
                avg += review.Rating;
            }
            return avg;
        }
    }
}
