using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace FashionShop
{
    public static class Allproducts
    {
        public static string path = $@"C:\Users\ADMIN\Desktop\HuyHieu\Newnew\BT\BTModule2\FashionShop\Data\";
        public static string filename = "products.json";

        public static Dictionary<int, Product> Products = ReadData();
        //{
        //    { 1, new Product (1, "Ao khoac nam", 150000) },
        //    { 2, new Product (2, "Ao khoac kaki", 350000) },
        //    { 3, new Product (3, "Ao khoac du", 250000) },
        //    { 4, new Product (4, "Dam xoe nu", 500000) },
        //    { 5, new Product (5, "Ao thun nu", 450000) },
        //    { 6, new Product (6, "Hoodie nam", 320000) },
        //    { 7, new Product (7, "Ao chong nang", 630000)}   
        //};
        public static Dictionary<int, Product> ReadData()
        {
            string fulllink = $@"{path}{filename}";
            ReadWriteFile<Dictionary<int, Product>>.ReadData(fulllink, ref Products);
            return Products;
        }
        public static void ShowAllproduct()
        {
            var list = Products.Keys.ToList();
            list.Sort();
            Console.WriteLine("  ID\t\tNameproduct\t\tPrice");
            //foreach (Product pro in Products.Values)
            //{
            //    Console.WriteLine(pro.ToStringpro());
            //}
            foreach (var key in list)
            {
                Console.WriteLine(Products[key].ToStringpro());
            }
        }
        public static void Addpro()
        {
            ReadData();
            try
            {
                Console.WriteLine("Enter product's id:");
                int id = int.Parse(Console.ReadLine());
                if (Allproducts.Products.ContainsKey(id) == false)
                {
                    Console.WriteLine("Enter product's name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter price:");
                    int price = (int)uint.Parse(Console.ReadLine());
                    Product pro = new Product(id, name, price);
                    Allproducts.Products.Add(id, pro);
                    string fulllink = $@"{path}{filename}";
                    ReadWriteFile<Dictionary<int, Product>>.WriteData(fulllink, Products);
                    Console.WriteLine("Successfully!!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This ID is already exists!");
                    Addpro();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Type:{e.GetType()}, Message : {e.Message} ");
                Addpro();
            }

        }
        public static void Updatepro()
        {
            try
            {
                Console.WriteLine("Enter product's id to update:");
                int id = int.Parse(Console.ReadLine());
                if (Allproducts.Products.ContainsKey(id))
                {
                    Console.WriteLine("Enter new name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new price:");
                    int price = (int)uint.Parse(Console.ReadLine());
                    Product pro = new Product(id, name, price);
                    Allproducts.Products[id] = pro;
                    string fulllink = $@"{path}{filename}";
                    ReadWriteFile<Dictionary<int, Product>>.WriteData(fulllink, Products);
                    Console.WriteLine("Successfully!!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not found!!");
                    Updatepro();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Type:{e.GetType()}, Message : {e.Message} ");
                Updatepro();
            }

        }
        public static void Removepro()
        {
            try
            {
                Console.WriteLine("Enter product's id to remove:");
                int id = int.Parse(Console.ReadLine());
                if (Allproducts.Products.ContainsKey(id))
                {
                    Allproducts.Products.Remove(id);
                    string fulllink = $@"{path}{filename}";
                    ReadWriteFile<Dictionary<int, Product>>.WriteData(fulllink, Products);
                    Console.WriteLine("Successfully!!");
                }
                else
                {
                    Console.WriteLine("Not found!!");
                    Removepro();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Type:{e.GetType()}, Message : {e.Message} ");
                Removepro();
            }
        }
        public static void Findpro()
        {
            try
            {
                Console.WriteLine("Enter id of product you want to find: ");
                int id = int.Parse(Console.ReadLine());
                if (Allproducts.Products.ContainsKey(id))
                {
                    Console.WriteLine(Allproducts.Products[id].ToStringpro());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not found!");
                    Findpro();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Type:{e.GetType()}, Message : {e.Message} ");
                Findpro();
            }
        }
    }
    public class CompareProduct : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return y.ID.CompareTo(x.ID);
        }
    }
}
