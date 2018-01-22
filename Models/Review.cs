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
    }
}
