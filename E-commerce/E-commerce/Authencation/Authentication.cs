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
            Console.WriteLine("Enter Password");
            userPassword = Console.ReadLine();

        }
        public Boolean customerValidation() {
            
            while (true) {
                if (userId == defaultCustomerId && userPassword == defaultCustomerPassword)
                {
                    Console.WriteLine("Successfully Logged In !");
                    return true;
                }
                else {
                    Console.WriteLine("Invalid Credentials!!!");
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
                        Console.WriteLine("Successfully Logged In !");
                        return true ;
                    
                }
                else
                {
                    Console.WriteLine("Invalid Credentials!!!");
                    enterCredientials();
                }
            }
        }
    }
}
