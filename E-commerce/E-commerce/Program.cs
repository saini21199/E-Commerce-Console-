using E_commerce.Authencation;
using E_commerce.CustomerOperation;
using E_commerce.CustomerOrderDB;
using E_commerce.InventoryDB;
using E_commerce.InventoryOperation;
using E_commerce.Menu;
using E_commerce.OrderReceipt;
using System;

namespace E_commerce
{
    class Program
    {
        static void Main(string[] args)
        {
            Authentication auth = new Authentication();
            MenuItem menulist = new MenuItem();

            Console.WriteLine("Select any one type \n1.Customer \n2.Inventory Mangaer\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Boolean exit = true;
            while (exit){
                auth.enterCredientials();
                switch (userInput)
                {
                    case 1:  auth.customerValidation();
                        
                        if ( Inventory.productlist.Count > 0)
                        {
                            ItemSelection selectItem = new ItemSelection();
                            while (true)
                            {
                                menulist.displayCustomerMenu();
                                selectItem.selectProduct();
                                Receipt receipt = new Receipt();
                                receipt.generateReceipt();
                                receipt.displayReceipt();
                                Console.WriteLine("Would you like to place a New Order? (Y/N)");
                                CustomerOrderItem.customerOrder.Clear();
                                char ch = Convert.ToChar(Console.ReadLine());
                                Console.Clear();
                                if (ch == 'N'){
                                    Console.WriteLine("Would you like to LogIn as Inventory manager? (Y/N)");
                                    char choice = Convert.ToChar(Console.ReadLine());
                                    Console.Clear();
                                    if (choice == 'Y')
                                    {
                                        userInput = 2;
                                        break;
                                    }
                                    else
                                    {
                                        exit = false;
                                        break;
                                    } 
                                }
                                else
                                    CustomerOrderItem.customerOrder.Clear();
                            }
                        }
                        else {
                            Console.WriteLine("No products Available");
                            Console.WriteLine("Would you like to LogIn as Inventory manager (Y/N)\n");
                            char ch = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                            userInput = 2;
                            if (ch != 'Y')
                                exit = false;
                        }
                        break;

                    case 2:  auth.inventoryValidation();
                        InventoryManager operation = new InventoryManager();
                        while (true)
                        {   
                            int input = menulist.displayInventoryMenu();
                            Console.Clear();
                            switch (input)
                            {
                                case 1:
                                    operation.Add();
                                    break;
                                case 2:
                                    operation.Update();
                                    break;
                                case 3: operation.Remove();
                                    break;
                                case 4:
                                    operation.display();
                                    break;
                            }
                            Console.WriteLine("\nWant to do any other operation? (Y/N)");
                            char ch = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                            if (ch == 'N') {
                                Console.WriteLine("Would you like to LogIn as Customer? (Y/N)");
                                char choice = Convert.ToChar(Console.ReadLine());
                                Console.Clear();
                                if (choice == 'Y')
                                {
                                    userInput = 1;
                                    break;
                                }
                                else {
                                    exit = false;
                                    break; }
                            }
                        }
                        break;
                }
            }
        }
    }
}
