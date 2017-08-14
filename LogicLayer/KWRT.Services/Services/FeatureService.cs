using KWRT.CoreModels.Models;
using KWRT.Database.Access.Access;
using KWRT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Services
{
    public class FeatureService
    {
        private readonly FeatureAccess _featureAccess;

        public FeatureService()
        {
            _featureAccess = new FeatureAccess();
        }

        public ServiceResult AddFeature(VMFeature feature)
        {
            var result = new ServiceResult();
            try
            {
                var coreFeature = new CoreFeature()
                {
                    IsActive = feature.IsActive,
                    Name = feature.Name
                };
                result.Result =_featureAccess.AddFeature(coreFeature);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Result = false;
                result.ErrorMessage = "Error in FeatureAccess.AddFeature()";
            }
            return result;
        }

        public ServiceResult GetFeatures()
        {
            var result = new ServiceResult();
            try
            {
                var coreFeatures = _featureAccess.GetFeatures() as List<CoreFeature>;
                var vmFeatures = coreFeatures.Select(x => new VMFeature()
                {
                    IsActive = x.IsActive,
                    Name = x.Name
                }).ToList();
                result.Data = vmFeatures;
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Result = false;
                result.ErrorMessage = "Error in FeatureAcces.GetFeatures()";
            }
            return result;
        }
    }
}