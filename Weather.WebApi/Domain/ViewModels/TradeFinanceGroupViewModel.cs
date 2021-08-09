using System.Collections.Generic;
using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class TradeFinanceGroupViewModel : ProductGroupViewModel
    {
        public override int AreaId => 3;

        public override IEnumerable<IProductModel> GetProductsModels()
        {
            foreach(var product in this.Products)
            {
                yield return new TradeFinanceModel();
            }
        }
    }
}