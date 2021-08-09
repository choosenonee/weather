using System.Collections.Generic;
using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class CreditGroupViewModel : ProductGroupViewModel
    {
        public override int AreaId { get => 2; }

        public override IEnumerable<IProductModel> GetProductsModels()
        {
            foreach(var product in this.Products)
            {
                yield return new CreditModel();
            }
        }
    }
}