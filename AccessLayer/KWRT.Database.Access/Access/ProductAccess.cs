using KWRT.CoreModels.Models;
using KWRT.Database.Migrations;
using KWRT.Database.Models;

namespace KWRT.Database.Access.Access
{
    public class ProductAccess
    {
        private readonly KWRTContext _context;

        public ProductAccess(KWRTContext context)
        {
            _context = context;
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
                Price = product.Price,
                IsDelete = false
            };
            _context.Products.Add(dbProduct);
            return true;
        }
    }
}