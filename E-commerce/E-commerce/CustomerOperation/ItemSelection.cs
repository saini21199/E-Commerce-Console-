using E_commerce.CustomerOrderDB;
using E_commerce.InventoryDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.CustomerOperation
{
    public class ItemSelection
    {
        public void selectProduct()
        {
            Boolean invalid = true;
            Boolean exit = false;
            while (!exit)
            {
                invalid = true;
                Console.WriteLine("Enter Product Id you want to buy");
                int selectedProductId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int index = 0;
                foreach (var prod in Inventory.productlist)
                {
                    if (prod.Id == selectedProductId)
                    {
                        invalid = false;
                        CustomerOrderItem.customerOrder.Add(prod);
                        Inventory.productlist[index].Quantity -= 1;
                        Console.WriteLine("Product added to your cart!\n");
                        Console.WriteLine("Do you want to buy more products (Y/N)");
                        char ch = Convert.ToChar(Console.ReadLine());
                        Console.Clear();
                        if (ch == 'N')
                            exit = true;
                    }

                    index++;
                }

                if (invalid)
                    Console.WriteLine("Invalid Product ID\n");
            }
        }
    }
}
