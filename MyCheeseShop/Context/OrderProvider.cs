﻿using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class OrderProvider
    {
        private readonly DatabaseContext _context; 
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
}