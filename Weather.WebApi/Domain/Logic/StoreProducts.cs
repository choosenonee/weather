using System.Collections.Generic;
using System.Linq;
using api.Domain.Models;
using api.Domain.ViewModels;

namespace api.Domain.Logic
{
    public class StoreProducts
    {
        public IEnumerable<IProductModel> Store(ProductsViewModel products)
        {
            //1. return credit
            List<IProductModel> aa = products.Credits.GetProductsModels().ToList();
            aa.AddRange(products.TradeFinance.GetProductsModels());
            return aa;
            //2 return tf
        }
    }
}