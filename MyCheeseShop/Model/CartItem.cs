namespace MyCheeseShop.Model
{
    public class CartItem
    {
        public Cheese Cheese { get; set; }
        public int Quanitity { get; set; }
        public decimal Total => Cheese.Price * Quanitity;

        public int Quantity { get; internal set; }
    }
}
