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

            Console.WriteLine("Enter Product Name\n");
            manageProduct.Name = Console.ReadLine();

            Console.WriteLine("Enter Product Quantity\n");
            manageProduct.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Price\n");
            manageProduct.Price = Convert.ToInt32(Console.ReadLine());

            Inventory.productlist.Add(manageProduct);

            Console.WriteLine("Successfully Added !");
        }

        public void Update() {
            while (true)
            {
                bool found = false;
                Console.WriteLine("Enter Product Id You want to update\n");
                int id = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (var prod in Inventory.productlist) {
                    if (prod.Id == id)
                    {
                        found = true;
                        Console.WriteLine("What You want to update\n");
                        Console.WriteLine("1.Name\n2.Price\n3.Quantity");
                        int input = Convert.ToInt32(Console.ReadLine());
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
                        Console.WriteLine("Successfully Updated !");
                        break;
                    }
                    
                    index++;
                }
                if (found == false)
                {
                    Console.WriteLine("Invalid ID !");
                }
                else break;
            }
        }

        public void display()
        {
            Inventory.productlist.ForEach((prod) => 
            Console.WriteLine("ID : " + prod.Id + "\n" + "Name : "+ prod.Name + "\n" + 
            "Price : "+prod.Price + "\n" + "Quantity : " + prod.Quantity + "\n"));
        }

        public void Remove() {
            while (true)
            {
                bool found = false;
                Console.WriteLine("Enter Product Id You want to Remove\n");
                int id = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (var prod in Inventory.productlist)
                {
                    if (prod.Id == id)
                    {
                        found = true;
                        Inventory.productlist.RemoveAt(index);
                        Console.WriteLine("Successfully Removed !");
                        break;
                    }
                    index++;
                }
                if (found == false)
                {
                    Console.WriteLine("Invalid ID !");
                }
                else break;
            }
        }
    }
}
