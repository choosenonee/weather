using api.Domain.Models;
using api.Domain.ViewModels;

namespace api.Domain.Logic
{
    public class ProductsFactory
    {
        public CreditModel GetCreditModel(ProductViewModel product)
        {
            return new CreditModel();
        }

        public TradeFinanceModel GetTradeFinanceModel(ProductViewModel product)
        {
            return new TradeFinanceModel();
        }

        public FactoringModel GetFactoringModel(ProductViewModel product)
        {
            return new FactoringModel();
        }

        public MultiproductModel GetMultiproductModel()
        {
            return new MultiproductModel();
        }
    }
}