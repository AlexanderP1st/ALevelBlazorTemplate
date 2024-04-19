using System.Data;

namespace MyCheeseShop.Model
{
    public class Order
    {
        public int Id {get; set;}

        public User User {get; set;}

        public List<OrderItem> Items {get; set;}

        public DataSetDateTime Created {get; set;}

        public OrderStatus Status {get; set;}
     }
}
