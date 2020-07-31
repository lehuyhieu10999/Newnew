using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4
{
    public class Product
    {

        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public int amount => GetAmount();
        public int GetAmount()
        {
            return price * count;
        }
        public override string ToString()
        {
            return $"{name}\t\t{price}  \t\t{count}  \t\t{amount}";
        }




    }
}
