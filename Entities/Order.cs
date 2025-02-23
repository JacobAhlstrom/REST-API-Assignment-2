namespace DagnysBakeryAPI.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; } = string.Empty;

    // Relation till kund
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // En beställning kan ha flera produkter
    public List<OrderItem> OrderItems { get; set; } = new();
}



