using KWRT.CoreModels.Models;
using KWRT.Database.Access.Access;
using KWRT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Services
{
    public class ProductService
    {
        private readonly ProductAccess _productAccess;

        public ProductService()
        {
            //TODO add param to constructor
            _productAccess = new ProductAccess();
        }

        public ServiceResult AddProduct(VMProduct product)
        {
            var result = new ServiceResult();
            try
            {
                var coreProduct = new CoreProduct()
                {
                    Description = product.Description,
                    Name = product.Name
                };
                result.Result =_productAccess.AddProduct(coreProduct);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Result = false;
                result.ErrorMessage = "Error in ProductAccess.AddProduct()";
            }
            return result;
        }

        public ServiceResult GetProducts()
        {
            var result = new ServiceResult();
            try
            {
                var coreProducts = _productAccess.GetProducts() as List<CoreProduct>;
                var vmProducts = coreProducts.Select(x => new VMProduct()
                {
                    Description = x.Description,
                    Name = x.Name
                }).ToList();
                result.Data = vmProducts;
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Result = false;
                result.ErrorMessage = "Error in ProductAccess.GetProducts()";
            }
            return result;
        }
    }
}