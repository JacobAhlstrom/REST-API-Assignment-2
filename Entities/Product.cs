namespace DagnysBakeryAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public int PackSize { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
    }

}