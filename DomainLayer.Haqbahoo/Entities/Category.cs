using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        // Navigation Property
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
