using E_commerce.CustomerOrderDB;
using E_commerce.Entity;
using E_commerce.InventoryDB;
using System;
using System.Collections.Generic;

namespace E_commerce.Menu
{
    public class MenuItem : CustomerOrderItem
    {
        public void displayCustomerMenu() {
                Console.Write("Available Product List\n");
                Console.WriteLine("\nID \tName \tPrice \tQuantity \n");
                Inventory.productlist.ForEach((eachProduct) => {
                    Console.WriteLine(eachProduct.Id + " \t" + eachProduct.Name + "\t" + 
                        eachProduct.Price + "\t" + eachProduct.Quantity);
                });
        }

        public int displayInventoryMenu() {
            Console.WriteLine("INVENTORY MENU\n");
            Console.WriteLine("Select any one option\n");
            Console.WriteLine("1.Add\n2.Update\n3.Remove\n4.View\n");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
    }
}
