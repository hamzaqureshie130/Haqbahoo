using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.Entities
{
    
        public class Purchase
        {
            public Guid Id { get; set; }
            public DateTime PurchaseDate { get; set; }
            public decimal TotalAmount { get; set; }
            public string InvoiceNumber { get; set; }


        // Navigation property
        public List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        }
    }

