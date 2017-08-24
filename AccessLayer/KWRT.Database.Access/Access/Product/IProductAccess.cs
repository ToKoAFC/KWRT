using KWRT.CoreModels.Models;
using System.Collections.Generic;

namespace KWRT.Database.Access.Product
{
    public interface IProductAccess
    {
        bool AddProduct(CoreProduct product);
        List<CoreProduct> GetProducts();
    }
}
