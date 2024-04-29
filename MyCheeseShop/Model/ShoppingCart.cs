namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];

        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Cheese = cheese, Quanitity = quantity });
            }
            else
            {
                item.Quanitity += quantity;
            }
            OnCartUpdated?.Invoke();
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }


    }
}
