using E_commerce.Credential;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Authencation
{
    public class Authentication : DefaultCredential
    {
        private string userId { get; set; }
        private string userPassword { get; set; }

        public void enterCredientials() {

            Console.WriteLine("Enter ID :");
            userId = Console.ReadLine();
            Console.WriteLine("\nEnter Password :");
            userPassword = Console.ReadLine();

        }
        public Boolean customerValidation() {
            
            while (true) {
                if (userId == defaultCustomerId && userPassword == defaultCustomerPassword)
                {
                    Console.WriteLine("\nSuccessfully Logged In!\n");
                    return true;
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Invalid Credentials!!\n");
                    enterCredientials();
                }
                
            }            
        }

        public Boolean inventoryValidation()
        {
            while (true)
            {
                if (userId == defaultInventoryManagerId && userPassword == defaultInventoryManagerId)
                {
                        Console.WriteLine("\nSuccessfully Logged In!\n");
                        return true ;
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Credentials!!\n");
                    enterCredientials();
                }
            }
        }
    }
}
