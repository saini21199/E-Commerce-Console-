using E_commerce.CustomerOrderDB;
using E_commerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.OrderReceipt
{
    public class Receipt : CustomerOrderItem
    {
        Order order = new Order();

        public void generateReceipt() {
            Console.WriteLine(customerOrder.Count);
            customerOrder.ForEach((prod) => { 
                order.totalPrice += prod.Price;
                order.productOrdered.Add(prod.Name);
            }); 
        }
        public void displayReceipt() {
            Console.WriteLine("Order Reference ID :" + Order.orderId);
            Console.WriteLine("Product Bought :\n");
            order.productOrdered.ForEach((item) => Console.WriteLine(item));
            Console.WriteLine("Total Price : " + order.totalPrice);
        }
    }
}
