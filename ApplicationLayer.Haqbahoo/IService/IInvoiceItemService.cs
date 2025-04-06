using DomainLayer.Haqbahoo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
    public interface IInvoiceItemService
    {
        Task<bool> AddInvoiceItem(InvoiceItem invoiceItem);
    }
}
