namespace api.Domain.Models
{
    public class FactoringModel : IProductModel
    {
        public decimal? Amount { get; set; }
        public int Maturity { get; set; }
        public string ProductAsPart { get; set; }
        public string Comment { get; set; }
        public string Currency { get; set; }
    }
}