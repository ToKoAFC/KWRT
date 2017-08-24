using KWRT.CoreModels.Models;
using KWRT.Database.Access.Product;
using KWRT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductAccess _productAccess;

        public ProductService(IProductAccess productAccess)
        {
            _productAccess = productAccess;
        }

        public void AddProduct(VMProduct product)
        {
            try
            {
                var coreProduct = new CoreProduct()
                {
                    Description = product.Description,
                    Name = product.Name
                };
                _productAccess.AddProduct(coreProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add product");
            }
        }

        public List<VMProduct> GetProducts()
        {
            try
            {
                var coreProducts = _productAccess.GetProducts() as List<CoreProduct>;
                var vmProducts = coreProducts.Select(x => new VMProduct()
                {
                    Description = x.Description,
                    Name = x.Name
                }).ToList();
                return vmProducts;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}