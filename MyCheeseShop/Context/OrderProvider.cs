using MyCheeseShop.Model;
using SQLitePCL;
namespace MyCheeseShop.Context
{
   
    builder.Services.AddScope<OrderProvider>();
    public async Task CreateOrder(User user, IEnumerable<CartItem> items)
    {
        var order = new Order
        {
            User = user,
            Items = items.Select(items => new OrderItem
            {
                Cheese = items.Cheese,
                Quantity = items.Quantity,
            }).ToList(),
            Created = System.Data.DataSetDateTime.Now,
            Status = OrderStatus.Placed
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(); 

    }    
}
