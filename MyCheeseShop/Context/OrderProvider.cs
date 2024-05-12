using MyCheeseShop.Model;
using Microsoft.EntityFrameworkCore;
namespace MyCheeseShop.Context
{


    public async Task CreateOrder(User user, IEnumerable<CartItem> items)
    {
        // Create a new order
        var order = new Order
        {
            User = user,
            Items = items.Select(item => new OrderItem
            {
                Cheese = item.Cheese,
                Quantity = item.Quantity,
            }).ToList(),
            Created = DateTime.Now,
            Status = OrderStatus.Placed
        };

        // Add the order to the database
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }
}
