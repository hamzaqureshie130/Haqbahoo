using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.ViewModel
{
    public class InvoiceViewModel
    {
        public string InvoiceNumber { get; set; }  // Invoice Number
        public DateTime SaleDate { get; set; }  // Sale Date
        public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();
        public decimal TotalAmount => Items.Sum(i => i.TotalPrice);  // Total Amount
    }

    public class InvoiceItemViewModel
    {
        public string ProductCode { get; set; }  // Product Code
        public string Description { get; set; }  // Product Description
        public int Quantity { get; set; }  // Sold Quantity
        public decimal SellingPrice { get; set; }  // Selling Price (Per Unit)
        public decimal TotalPrice => Quantity * SellingPrice;  // Total Price for Item
    }
}
