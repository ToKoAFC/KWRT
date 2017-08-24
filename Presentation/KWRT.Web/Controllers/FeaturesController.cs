using KWRT.Services.Feature;
using KWRT.ViewModels;
using System.Web.Mvc;

namespace KWRT.Web.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {  
            _featureService = featureService;
        }

        public ActionResult Index()
        {
            var model = _featureService.GetFeatures();           
            return View(model);
        }

        public ActionResult AddFeature()
        {
            var model = new VMFeature();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFeature(VMFeature feature)
        {
            _featureService.AddFeature(feature);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}