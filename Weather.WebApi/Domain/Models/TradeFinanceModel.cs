using System.Collections.Generic;

namespace api.Domain.Models
{
    public class TradeFinanceModel : IProductModel
    {
        // public decimal? Amount { get; set; }
        // public int Maturity { get; set; }
        // public decimal? Fee { get; set; }
        // public string Currency { get; set; }
        // public ICollection<FeeModel> Fees {get;set;}
        public decimal? Amount { get; set; }
        public int Maturity { get; set; }
        public string ProductAsPart { get; set; }
        public string Comment { get; set; }
        public string Currency { get; set; }
    }
}