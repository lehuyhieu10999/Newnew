using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public int Amount => amount();

        public int amount()
        {
            return price * count;
        }

        public override string ToString()
        {
            return $"{name}\t\t{price}  \t{count}  \t{Amount}";
        }
    }
}
