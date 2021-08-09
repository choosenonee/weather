using System.Collections.Generic;

namespace api.Domain.ViewModels
{
    public class ProductsViewModel
    {
        public CreditGroupViewModel Credits { get; set; }
        //public ICollection<ProductViewModel> Multiproducts { get; set; }
        public TradeFinanceGroupViewModel TradeFinance { get; set; }
        //public ICollection<ProductViewModel> Factoring { get; set; }
    }
}