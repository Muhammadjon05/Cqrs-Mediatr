using Cqrs_Mediatr.Models;
using LiteDB;

namespace Cqrs_Mediatr.Context;

public class OrderDbContext : IDisposable
{
    public ILiteCollection<Order> Orders;
    private readonly ILiteDatabase _liteDatabase;

    public OrderDbContext()
    {
        _liteDatabase = new LiteDatabase("lite.db");
        Orders = _liteDatabase.GetCollection<Order>("orders");
    }
    public void Dispose()
    {
        _liteDatabase.Dispose();
    }
}