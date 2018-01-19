using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Review2_NET.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
//        public int ProductId { get; set; }
//        public string Name { get; set; }
    }
}
