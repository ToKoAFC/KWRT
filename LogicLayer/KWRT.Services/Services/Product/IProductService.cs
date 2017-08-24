using KWRT.ViewModels;
using System.Collections.Generic;

namespace KWRT.Services.Product
{
    public interface IProductService
    {
        void AddProduct(VMProduct product);
        List<VMProduct> GetProducts();

    }
}
