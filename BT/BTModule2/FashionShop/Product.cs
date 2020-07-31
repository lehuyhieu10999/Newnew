using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop
{
    public class Product
    {
        public Product(int ID, string name, int price)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
        }
        public int ID { get; set; }
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
            return $"   {ID}\t\t{name}\t\t{price}\t{count}\t{Amount}";
        }
        public string ToStringpro()
        {
            return $"   {ID}\t\t{name}\t\t{price}";
        }
    }
}
