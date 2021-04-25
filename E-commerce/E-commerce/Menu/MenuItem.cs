using E_commerce.CustomerOrderDB;
using E_commerce.Entity;
using E_commerce.InventoryDB;
using System;
using System.Collections.Generic;

namespace E_commerce.Menu
{
    public class MenuItem : CustomerOrderItem
    {

        public void displayMenu() {
                Console.Write("Available Product List\n");
                Console.WriteLine("ID \tName \tPrice \tQuantity \n");
                Inventory.productlist.ForEach((eachProduct) => {
                    Console.WriteLine(eachProduct.Id + " \t" + eachProduct.Name + "\t" + 
                        eachProduct.Price + "\t" + eachProduct.Quantity);
                });
        }

        public void selectProduct(){
            Boolean invalid = true;
            Boolean exit = false;
            while (!exit)
            {   
                invalid = true;
                Console.WriteLine("Enter Product Id you want to buy");
                int selectedProductId = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (var prod in Inventory.productlist)
                {
                    if (prod.Id == selectedProductId)
                    {
                        invalid = false;
                        customerOrder.Add(prod);
                        Inventory.productlist[index].Quantity -= 1;
                        Console.WriteLine("Product added to your cart!\n");
                        Console.WriteLine("Do you want to buy more products (Y/N)");
                        char ch = Convert.ToChar(Console.ReadLine());
                        if (ch == 'N')
                            exit = true;
                    }

                    index++;
                }

                //Inventory.productlist.ForEach( (prod) => {
                //    if (prod.Id == selectedProductId)
                //    {   
                //        invalid = false;
                //        customerOrder.Add(prod);
                //        Console.WriteLine("Product added to your cart!\n");
                //        Console.WriteLine("Do you want to buy more products (Y/N)");
                //        char ch = Convert.ToChar(Console.ReadLine());
                //        if (ch == 'N')
                //            exit = true;
                //    }
                //});
                if (invalid)
                    Console.WriteLine("Invalid Product ID");
            }
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
