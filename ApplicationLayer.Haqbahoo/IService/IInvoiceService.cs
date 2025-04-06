using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.IService
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoiceAsync(Guid id);
        Task<List<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(Invoice invoice);
        Task DeleteInvoiceAsync(Guid id);
        Task<InvoiceViewModel> GetNewInvoiceModelAsync();
    }
}
