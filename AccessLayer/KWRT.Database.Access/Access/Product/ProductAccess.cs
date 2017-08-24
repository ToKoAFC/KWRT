using KWRT.CoreModels.Models;
using KWRT.Database.Access.Product;
using KWRT.Database.Migrations;
using KWRT.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KWRT.Database.Access.Product
{
    public class ProductAccess : IProductAccess
    {
        private readonly KWRTContext _context;
        private volatile Type _dependency;

        public ProductAccess()
        {
            //TODO move to param // Autofac
            //_context = context;
            _context = new KWRTContext();
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public bool AddProduct(CoreProduct product)
        {
            if (product == null)
            {
                return false;
            }
            var dbProduct = new KWRTProduct()
            {
                Description = product.Description,
                Name = product.Name,
                IsDelete = false,
                CreatedDate = DateTime.Now
            };
            _context.Products.Add(dbProduct);
            _context.SaveChanges(); 
            return true;
        }

        public List<CoreProduct> GetProducts()
        {
            var dbProducts = _context.Products.Where(x => !x.IsDelete).ToList();
            return dbProducts.Select(x => new CoreProduct()
            {
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }
    }
}