using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Car
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Car Name is required.")]
        [StringLength(100, ErrorMessage = "Car Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        [StringLength(50, ErrorMessage = "Make can't be longer than 50 characters.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model can't be longer than 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Variant is required.")]
        [StringLength(50, ErrorMessage = "Variant can't be longer than 50 characters.")]
        public string Variant { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Rent Per Day is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Rent Per Day must be greater than zero.")]
        public int RentPerDay { get; set; }
        [Required(ErrorMessage = "Transmission is required.")]
        public string Transmission { get; set; }

        //[Required(ErrorMessage = "Cover Image URL is required.")]
        public string CoverImageUrl { get; set; }

        public bool Status { get; set; }

        // NotMapped fields (for file uploads)
        [NotMapped]
       
        public IFormFile CoverImageFile { get; set; }

        [NotMapped]
      
        public List<IFormFile> GalleryImageFiles { get; set; } = new List<IFormFile>();

        // Relationships
        public ICollection<Gallery> GalleryImages { get; set; } = new List<Gallery>();
        public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    }
}
