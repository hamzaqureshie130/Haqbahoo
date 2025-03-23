using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Product
    {
        public Guid Id { get; set; } 

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        public string Code { get; set; } // Unique product code (auto-generated)

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Purchase price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Purchase price must be greater than zero")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Sale price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than zero")]
        public decimal SalePrice { get; set; }
    }
}
