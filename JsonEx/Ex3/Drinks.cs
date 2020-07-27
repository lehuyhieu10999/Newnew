using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public class Drinks
    {
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public int amount => Amount();

        public int Amount()
        {
            return price * count;
        }

        public override string ToString()
        {
            return $"{name}\t\t{price}  \t{count}  \t{amount}";
        }
    }
}
