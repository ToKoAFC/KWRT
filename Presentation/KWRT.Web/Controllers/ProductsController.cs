﻿using KWRT.Services;
using KWRT.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KWRT.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController()
        {   //TODO get service from costructor
            //_productService = productService;
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            var model = _productService.GetProducts().Data as List<VMProduct>;
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