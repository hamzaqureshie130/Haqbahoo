using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.ViewModel
{
    public class InvoiceViewModel
    {
        
            public string InvoiceNumber { get; set; }
            public string CustomerType { get; set; }
            public DateTime InvoiceDate { get; set; }
            public DateTime DueDate { get; set; }
        public decimal Discount { get; set; }
        public List<Product> Products { get; set; }
        public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();
    }
    public class InvoiceItemViewModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
    }

}
