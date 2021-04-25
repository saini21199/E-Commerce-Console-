using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public static int p_Id = -1;
        public Product() {
            p_Id = p_Id + 1;
            Id = p_Id;
        }
    }
}
