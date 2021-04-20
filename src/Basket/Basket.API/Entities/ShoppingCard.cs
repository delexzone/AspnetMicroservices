using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCard
    {
        public string Username { get; set; }
        public IList<ShoppingCardItem> Items { get; set; } = new List<ShoppingCardItem>();

        public ShoppingCard()
        {

        }

        public ShoppingCard(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }
    }
}