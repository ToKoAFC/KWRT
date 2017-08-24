using KWRT.Services;
using KWRT.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KWRT.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) { 
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = _productService.GetProducts();
            return View(model);
        }

        public ActionResult AddProduct()
        {
            var model = new VMProduct();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(VMProduct product)
        {
            _productService.AddProduct(product);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}