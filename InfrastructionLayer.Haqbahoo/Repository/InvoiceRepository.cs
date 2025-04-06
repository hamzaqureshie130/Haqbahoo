using DomainLayer.Haqbahoo.Entities;
using DomainLayer.Haqbahoo.ViewModel;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> GetInvoiceAsync(Guid id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .ThenInclude(ii => ii.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .ThenInclude(ii => ii.Product)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            // Generate invoice number if not provided
            if (string.IsNullOrEmpty(invoice.InvoiceNumber))
            {
                invoice.InvoiceNumber = await GenerateInvoiceNumberAsync();
            }

            invoice.CreatedDate = DateTime.UtcNow;

            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(Guid id)
        {
            var invoice = await GetInvoiceAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<InvoiceViewModel> GetNewInvoiceModelAsync()
        {
            var products = await _context.Products.ToListAsync();

            return new InvoiceViewModel
            {
                InvoiceNumber = await GenerateInvoiceNumberAsync(),
                InvoiceDate = DateTime.Today,
                DueDate = DateTime.Today.AddDays(7),
                Products = products
            };
        }

        private async Task<string> GenerateInvoiceNumberAsync()
        {
            var lastInvoice = await _context.Invoices
                .OrderByDescending(i => i.CreatedDate)
                .FirstOrDefaultAsync();

            int lastNumber = 0;
            if (lastInvoice != null && !lastInvoice.InvoiceNumber.StartsWith("DRAFT"))
            {
                var parts = lastInvoice.InvoiceNumber.Split('-');
                if (parts.Length > 1 && int.TryParse(parts[1], out lastNumber))
                {
                    lastNumber++;
                }
            }
            else
            {
                lastNumber = 1;
            }

            return $"INV-{lastNumber.ToString().PadLeft(4, '0')}";
        }

        Task<string> IInvoiceRepository.GenerateInvoiceNumberAsync()
        {
            return GenerateInvoiceNumberAsync();
        }
    }
}