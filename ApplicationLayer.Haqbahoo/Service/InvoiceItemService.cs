using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class InvoiceItemService:IInvoiceItemService
    {
        private IInvoiceItemRepository _invoiceItemRepository;
        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceItemRepository = invoiceItemRepository;

        }

        public Task<bool> AddInvoiceItem(InvoiceItem invoiceItem)
        {
            return _invoiceItemRepository.AddInvoiceItem(invoiceItem);
        }
    }
}
