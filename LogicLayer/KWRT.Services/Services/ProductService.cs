using KWRT.CoreModels.Models;
using KWRT.Database.Access.Access;
using KWRT.ViewModels;
using System;

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
                    Name = product.Name,
                    Price = product.Price
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
    }
}