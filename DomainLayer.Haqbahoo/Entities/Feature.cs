using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    // Features Table (Dynamic Features added by Admin)
    public class Feature
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }  // e.g., "4 Doors", "Airbags", "Seats 5 Passengers"
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    }

}
