using E_commerce.Entity;
using E_commerce.InventoryDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.InventoryOperation
{
    public class InventoryManager : Product
    {
        public void Add() {

            Product manageProduct = new Product();

            Console.WriteLine("Enter Product Name:");
            manageProduct.Name = Console.ReadLine();
            Console.WriteLine("\nEnter Product Quantity:");
            manageProduct.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Product Price:");
            manageProduct.Price = Convert.ToInt32(Console.ReadLine());

            Inventory.productlist.Add(manageProduct);

            Console.WriteLine("\nSuccessfully Added!");
        }

        public void Update() {
            while (true)
            {
                bool found = false;
                Console.WriteLine("Enter Product Id you want to update :");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int index = 0;
                foreach (var prod in Inventory.productlist) {
                    if (prod.Id == id)
                    {
                        found = true;
                        Console.WriteLine("What You want to update\n");
                        Console.WriteLine("1.Name\n2.Price\n3.Quantity\n");
                        int input = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter Updated Product value");
                        switch (input) {
                            case 1: 
                                string Name = Console.ReadLine();
                                Inventory.productlist[index].Name = Name;
                                break;
                            case 2: 
                                int Quantity = Convert.ToInt32(Console.ReadLine());
                                Inventory.productlist[index].Quantity = Quantity;
                                break;
                            case 3:
                                int Price = Convert.ToInt32(Console.ReadLine());
                                Inventory.productlist[index].Price = Price;
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine("Successfully Updated!");
                        break;
                    }
                    
                    index++;
                }
                if (found == false)
                {
                    Console.WriteLine("Invalid ID !\n");
                }
                else break;
            }
        }

        public void display()
        {
            if (Inventory.productlist.Count <= 0)
                Console.WriteLine("No Available Inventory\n");
            else
            {
                Console.WriteLine("Available Inventory\n");
                Console.WriteLine("ID \tName \tPrice \tQuantity \n");
                Inventory.productlist.ForEach((eachProduct) =>
                {
                    Console.WriteLine(eachProduct.Id + " \t" + eachProduct.Name + "\t" +
                        eachProduct.Price + "\t" + eachProduct.Quantity);
                });
            }
        }

        public void Remove() {
            while (true)
            {
                bool found = false;
                Console.WriteLine("Enter Product Id You want to Remove :");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int index = 0;
                foreach (var prod in Inventory.productlist)
                {
                    if (prod.Id == id)
                    {
                        found = true;
                        Inventory.productlist.RemoveAt(index);
                        Console.WriteLine("Successfully Removed!");
                        break;
                    }
                    index++;
                }
                if (found == false)
                {
                    Console.WriteLine("Invalid ID !\n");
                }
                else break;
            }
        }
    }
}
