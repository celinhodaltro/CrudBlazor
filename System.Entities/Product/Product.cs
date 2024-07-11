using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Entities.Base;

namespace System.Entities
{
    public class Product : DefaultDb
    {
        [Required(ErrorMessage = "The product name is mandatory!")]
        [StringLength(100, ErrorMessage = "The product description cannot be longer than 100 characters.")]
        public string Name { get; set; } = "";

        [StringLength(500, ErrorMessage = "The product description cannot be longer than 500 characters.")]
        public string Description { get; set; } = "";

        [Range(0.01, double.MaxValue, ErrorMessage = "The price of the product must be greater than zero!")]
        public double Price { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "Product must have a category!")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = new();


    }
}
