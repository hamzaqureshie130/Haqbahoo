using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Haqbahoo.ViewModel
{
    public class InventoryViewModel
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
