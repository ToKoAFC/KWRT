using KWRT.ViewModels;
using System.Collections.Generic;

namespace KWRT.Services.Feature
{
    public interface IFeatureService
    {
        void AddFeature(VMFeature feature);
        List<VMFeature> GetFeatures();
    }
}
