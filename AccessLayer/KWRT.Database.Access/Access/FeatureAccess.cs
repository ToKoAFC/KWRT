using KWRT.CoreModels.Models;
using KWRT.Database.Migrations;
using KWRT.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Database.Access.Access
{
    public class FeatureAccess
    {
        private readonly KWRTContext _context;
        private volatile Type _dependency;

        public FeatureAccess()
        {
            _context = new KWRTContext();
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public bool AddFeature(CoreFeature feature)
        {
            if (feature == null)
            {
                return false;
            }
            var dbFeature = new KWRTFeature()
            {
                IsActive = feature.IsActive,
                Name = feature.Name,
                CreatedDate = DateTime.Now
            };
            _context.Features.Add(dbFeature);
            _context.SaveChanges(); 
            return true;
        }

        public List<CoreFeature> GetFeatures()
        {
            var dbFeatures = _context.Features.ToList();
            return dbFeatures.Select(x => new CoreFeature()
            {
                IsActive = x.IsActive,
                Name = x.Name,
            }).ToList();
        }
    }
}