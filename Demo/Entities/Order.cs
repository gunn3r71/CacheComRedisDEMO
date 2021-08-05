using System;
using System.Collections.Generic;

namespace Demo.Entities
{
    public class Order : Base
    {
        public Order(IList<OrderItem> items, Guid clientId)
        {
            Items = items;
            AmountToPay = 0;
            ClientId = clientId;
        }

        public IList<OrderItem> Items { get; set; }
        public double AmountToPay { get; private set; }
        public int QuantityOfItems { get; set; }
        public Guid ClientId { get; set; }

        public void CalculateAmountToPay()
        {
            foreach (var item in Items)
            {
                AmountToPay += item.TotalValue;
            }
        }

        public void CalculateQuantityOfItems()
        {
            QuantityOfItems = Items.Count;
        }
    }
}