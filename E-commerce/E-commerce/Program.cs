using E_commerce.Authencation;
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

            Console.WriteLine("Select any one type \n1.Customer \n2.Inventory Mangaer");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Boolean loggedIn = false;
            Boolean exit = true;
            while (exit){
                auth.enterCredientials();
                switch (userInput)
                {
                    case 1: loggedIn = auth.customerValidation();
                        if (loggedIn && Inventory.productlist.Count > 0)
                        {
                            while (true)
                            {
                                menulist.displayMenu();
                                menulist.selectProduct();
                                Receipt receipt = new Receipt();
                                receipt.generateReceipt();
                                receipt.displayReceipt();
                                Console.WriteLine("Would you like to place a New Order");
                                char ch = Convert.ToChar(Console.ReadLine());
                                if (ch == 'N'){
                                    Console.WriteLine("Would you like to LogIn as Inventory manager");
                                    char choice = Convert.ToChar(Console.ReadLine());
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
                            Console.WriteLine("No products Available ");
                            Console.WriteLine("Would you like to LogIn as Inventory manager");
                            char ch = Convert.ToChar(Console.ReadLine());
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
                            Console.WriteLine("Want to do any other operation ?");
                            char ch = Convert.ToChar(Console.ReadLine());
                            if (ch == 'N') {
                                Console.WriteLine("Would you like to LogIn as Customer");
                                char choice = Convert.ToChar(Console.ReadLine());
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
