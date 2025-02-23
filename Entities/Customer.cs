namespace DagnysBakeryAPI.Entities;

    public class Customer
{
    public int Id { get; set; }
    public string StoreName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public string InvoiceAddress { get; set; } = string.Empty;

    // En kund kan ha flera beställningar
    public List<Order> Orders { get; set; } = new();
}


