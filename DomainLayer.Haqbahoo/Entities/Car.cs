using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal RentPerDay { get; set; }
        public string CoverImageUrl { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public IFormFile CoverImageFile { get; set; }
        [NotMapped]
        public List<IFormFile> GalleryImageFiles { get; set; }

        // Image Gallery (One-to-Many)
        public ICollection<Gallery> GalleryImages { get; set; } = new List<Gallery>();

        // Car Features (Many-to-Many)
        public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    }
}
