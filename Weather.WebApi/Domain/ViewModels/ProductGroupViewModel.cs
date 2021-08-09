using System.Collections.Generic;
using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public abstract class ProductGroupViewModel
    {
        public abstract int AreaId { get; }
        public ICollection<ProductViewModel> Products { get; set; }

        public abstract IEnumerable<IProductModel> GetProductsModels();
    }
}