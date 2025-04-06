using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Repository
{
    public class InvoiceItemRepository:IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddInvoiceItem(InvoiceItem invoiceItem)
        {
             _context.InvoiceItems.AddAsync(invoiceItem);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
