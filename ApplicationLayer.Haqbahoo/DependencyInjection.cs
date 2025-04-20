using ApplicationLayer.Haqbahoo.IService;
using ApplicationLayer.Haqbahoo.Service;
using Haqbahoo.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<ICarFeatureService, CarFeatureService>();
            services.AddScoped<IWorkShopService, WorkShopService>();

            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPurchaseItemService, PurchaseItemService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleItemService, SaleItemService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceItemService, InvoiceItemService>();
            services.AddScoped<IDashBoardService, DashboardService>();


            services.AddScoped<FileUploader>();
            return services;
            //dsd
        }
    }
}
