using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Entity
{
    public class Order
    {
        public static int orderId { get; set; }

        public int totalPrice { get; set; }

        public List<string> productOrdered = new List<string>();

        public Order() {
            orderId = orderId + 1;
        }
    }
}
