using DomainLayer.Haqbahoo.Entities;
using InfrastructionLayer.Haqbahoo.IRepository;
using InfrastructionLayer.Haqbahoo.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Repository
{
    class FeatureRepository : IFeatureRepository
    {
        private readonly ApplicationDbContext _context;
        public FeatureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFeature(Feature feature)
        {
            await _context.Features.AddAsync(feature);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFeature(Guid featureId)
        {
            var feature = await _context.Features.FindAsync(featureId);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> EditFeature(Feature feature)
        {
            var featureFromDb = await _context.Features.FindAsync(feature.Id);
            if (featureFromDb != null)
            {
                featureFromDb.Name = feature.Name;
                if(feature.ImageUrl is not null)
                {
                    featureFromDb.ImageUrl = feature.ImageUrl;

                }
                _context.Features.Update(featureFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Feature>> GetAllFeature()
        {
            return await _context.Features.ToListAsync();
        }

        public async Task<Feature> GetFeatureById(Guid featureId)
        {
            var feature = await _context.Features.FindAsync(featureId);
            if (feature != null)
            {
                return feature;
            }
            return null;
        }
    }
}
