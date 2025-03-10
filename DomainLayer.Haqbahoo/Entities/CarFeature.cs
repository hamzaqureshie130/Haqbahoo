using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    // Many-to-Many Relationship Table
    public class CarFeature
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
