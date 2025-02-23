namespace DagnysBakeryAPI.Entities;

public class OrderItem
{
    public int Id { get; set; }

    // Relation till order
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    // Relation till produkt
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    // Summerat pris (beräknas vid inläsning)
    public decimal TotalPrice => Quantity * UnitPrice;
}



