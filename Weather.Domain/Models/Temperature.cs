namespace Weather.Domain.Models
{
    public abstract class Temperature : IUnit
    {
        public float Value { get; set; }
        public Units Unit { get; set; }
        public string Symbol { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
