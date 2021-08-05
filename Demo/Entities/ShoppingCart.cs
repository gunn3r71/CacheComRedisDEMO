using System;
using System.Collections.Generic;

namespace Demo.Entities
{
    class ShoppingCart : Base
    {
        public int QuantityOfItems { get; set; }
        public IList<Order> Orders { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
