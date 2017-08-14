using KWRT.Services;
using KWRT.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KWRT.Web.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly FeatureService _featureService;

        public FeaturesController()
        {   //TODO get service from costructor
            //_productService = productService;
            _featureService = new FeatureService();
        }

        public ActionResult Index()
        {
            var model = _featureService.GetFeatures().Data as List<VMFeature>;            
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