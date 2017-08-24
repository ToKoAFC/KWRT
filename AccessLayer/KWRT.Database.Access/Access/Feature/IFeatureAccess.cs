using KWRT.CoreModels.Models;
using System.Collections.Generic;

namespace KWRT.Database.Access.Feature
{
    public interface IFeatureAccess
    {
        bool AddFeature(CoreFeature feature);
        List<CoreFeature> GetFeatures();
    }
}