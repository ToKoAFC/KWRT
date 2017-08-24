using KWRT.CoreModels.Models;
using KWRT.Database.Access.Feature;
using KWRT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Services.Feature
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureAccess _featureAccess;

        public FeatureService(IFeatureAccess featureAccess)
        {
            _featureAccess = featureAccess;
        }

        public void AddFeature(VMFeature feature)
        {
            try
            {
                var coreFeature = new CoreFeature()
                {
                    IsActive = feature.IsActive,
                    Name = feature.Name
                };
                _featureAccess.AddFeature(coreFeature);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add feature.");
            }
        }

        public List<VMFeature> GetFeatures()
        {
            try
            {
                var coreFeatures = _featureAccess.GetFeatures();
                var vmFeatures = coreFeatures.Select(x => new VMFeature()
                {
                    IsActive = x.IsActive,
                    Name = x.Name
                }).ToList();
                return vmFeatures;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get features.");
            }
        }
    }
}