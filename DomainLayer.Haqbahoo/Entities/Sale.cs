using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string InvoiceNumber { get; set; }
        // Navigation properties
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
