using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }

        // Navigation properties
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
