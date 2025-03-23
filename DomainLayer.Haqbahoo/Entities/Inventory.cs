using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int? QuantityIn { get; set; }
        public int? QuantityOut { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
