namespace DagnysBakeryAPI.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string ContactPerson { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public int SupplierId { get; set; }
        public List<Product> Products { get; set; } = new();
    }

}