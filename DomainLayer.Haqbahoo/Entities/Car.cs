using System;
using System.Collections.Generic;
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

        // Image Gallery (One-to-Many)
        public ICollection<Gallery> GalleryImages { get; set; } = new List<Gallery>();

        // Car Features (Many-to-Many)
        public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    }
}
