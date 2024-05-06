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
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
            OnCartUpdated?.Invoke();
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }

        public int Count()
        {
            
            return _items.Count;
        }

        public int GetQuantity(Cheese cheese)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }
        public void RemoveItem(Cheese cheese)
        {
            _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();
        }
        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
        }
    }
}
