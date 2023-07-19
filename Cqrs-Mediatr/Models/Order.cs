namespace Cqrs_Mediatr.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
}