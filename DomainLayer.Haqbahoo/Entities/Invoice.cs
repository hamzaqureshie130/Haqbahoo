using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerType { get; set; } // "WalkIn" or "Online"
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
