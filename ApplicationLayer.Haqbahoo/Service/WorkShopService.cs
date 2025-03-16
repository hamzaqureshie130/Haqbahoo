using ApplicationLayer.Haqbahoo.IService;
using DomainLayer.Haqbahoo.Entities;
using Haqbahoo.Helper;
using InfrastructionLayer.Haqbahoo.IRepository;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Haqbahoo.Service
{
    public class WorkShopService : IWorkShopService
    {
        private IWorkShopRepository _workShopRepository;
        private FileUploader _fileUploader;
        public WorkShopService(IWorkShopRepository workShopRepository, FileUploader fileUploader)
        {

            _workShopRepository = workShopRepository;
            _fileUploader = fileUploader;

        }

        public async Task<bool> AddWorkShop(WorkShop workShop)
        {
            return await _workShopRepository.AddWorkShop(workShop);
        }

        public async Task<bool> DeleteWorkShop(Guid workShopId)
        {
            return await _workShopRepository.DeleteWorkShop(workShopId);
        }

        public async Task<bool> EditWorkShop(WorkShop workShop)
        {
            if (workShop.CoverImageFile != null)
            {
                var newImageResult = await _fileUploader.UploadFile(workShop.CoverImageFile);
                if (newImageResult.status)
                {
                    workShop.CoverImageUrl = newImageResult.url;
                }
            }
            return await _workShopRepository.EditWorkShop(workShop);
        }

        public async Task<IEnumerable<WorkShop>> GetAllWorkShop()
        {
          return await _workShopRepository.GetAllWorkShop();
        }

        public async Task<WorkShop> GetWorkShopById(Guid workShopId)
        {
            return await _workShopRepository.GetWorkShopById(workShopId);
        }
    }
}
