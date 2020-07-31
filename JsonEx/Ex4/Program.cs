using System;
using System.Threading;

namespace Ex4
{
    class Program
    {
        public static string path = $@"C:\Users\ADMIN\Desktop\HuyHiệu\Newnew\JsonEx\Ex4\Data";
        public static string filename = "data.json";
        public static CartManagement admin = new CartManagement(path, filename);
        static void Main(string[] args)
        {
            admin.ReadFile();
            CreateMenu();
        }
        public static void CreateMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Add cart");
                Console.WriteLine("2. Show cart");
                Console.WriteLine("3. Pay");
                Console.WriteLine("4. Add product");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Your choice: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    choice = number;
                }
                if (number > 5 || number < 1)
                {
                    Console.Clear();
                    Console.Write("Not Allow!");
                }
            } while (choice > 5 || choice < 1);
            Process(choice);
        }

        public static void Process(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        AddCart();
                        break;
                    }
                case 2:
                    {
                        ShowCart();
                        break;
                    }
                case 3:
                    {
                        Pay();
                        break;
                    }
                case 4:
                    {
                        UpdateCart();
                        break;
                    }
                case 5:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
            CreateMenu();
        }

        public static void AddCart()
        {
            Cart cart = new Cart();
            Console.Write("Enter cart Id:");
            cart.CartId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer's Name: ");
            cart.CustomerName = Console.ReadLine();
            cart.Status = 1;
            string choice = "n";
            do
            {
                cart.products.Add(newproduct());
                Console.Write("Do you need more ? Y(yes)/N(no):  ");
                choice = Console.ReadLine().ToLower();
            } while (choice.Equals("y"));

            cart.Timebuy = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            admin.Add(cart);
            
            Console.WriteLine("Successfully!!");
        }
    
        public static void ShowCart()
        {
            ListCart listcart = admin.ReadFile();
            if (listcart != null)
            {
                foreach (Cart cart in listcart.Listcart)
                {
                    Console.WriteLine(cart.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nothing to show!!");
                CreateMenu();
            }
        }
        public static void Pay()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Enter id of table you want to pay: ");
                int id = int.Parse(Console.ReadLine());
                Cart cart = admin.Check(id);
                if (cart != null)
                {
                    if (cart.Status == 1)
                    {
                        cart.Status = 2;
                        Console.Clear();
                        string timeout = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                        cart.Timeout = timeout;
                        Console.WriteLine(cart.ToString());
                        // Ghi hóa đơn
                        admin.PrintBill(cart);
                        Console.WriteLine("Successfully!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(cart.ToString());
                        Console.WriteLine("This order has been paid or has been canceled before!!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cart!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}, {e.Message}");
                CreateMenu();
            }
        }
       
        private static void UpdateCart()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Enter id of cart you want to add: ");
                int id = int.Parse(Console.ReadLine());
                Cart _cart = admin.Check(id);
                
                if (_cart != null)
                {
                    Console.WriteLine("Enter product's name: ");
                    string name = Console.ReadLine();
                    int pos = admin.Checkpro(id, name);
                    if (_cart.Status == 1 && pos == -1)
                    {
                        do
                        {
                            Console.WriteLine("Enter Price:");
                            int price = (int)uint.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Count:");
                            int count = (int)uint.Parse(Console.ReadLine());
                            Product product = new Product()
                            {
                                name = name,
                                price = price,
                                count = count,
                            };
                            _cart.products.Add(product);
                            int ind = admin.listcart.Listcart.IndexOf(_cart);
                            admin.listcart.Listcart[ind].products = _cart.products;
                            Console.Clear();
                            Console.WriteLine(_cart.ToString());
                            Console.WriteLine("Successfully");
                            Console.Write("Do you want to add more? y/n:  ");
                        } while (Console.ReadLine().ToLower() == "y");
                    }
                    else if (_cart.Status == 1 && pos != -1 )
                    {
                        Console.WriteLine("This item already exists!! Enter the amount to add: ");
                        int count = (int)uint.Parse(Console.ReadLine());
                        _cart.products[pos].count += count;
                        string fulllink = $@"{path}\{filename}";
                        ReadorWriteFile<ListCart>.WriteData(fulllink, admin.listcart);
                        Console.WriteLine("Succesfully");
                    }
                    else
                    {
                        Console.WriteLine(_cart.ToString());
                        Console.WriteLine("This table has already been paid or cancel!");
                    }
                }
                else
                {
                    Console.WriteLine("Not found!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}, {e.Message}");
                UpdateCart();
            }
        }

        public static Product newproduct()
        {
            try
            {
                Product pd = new Product();
                Console.Write("Name of product: ");
                pd.name = Console.ReadLine();
                Console.Write("Price: ");
                pd.price = (int)uint.Parse(Console.ReadLine());
                Console.Write("Count: ");
                pd.count = (int)uint.Parse(Console.ReadLine());
                return pd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}, { e.Message}");
                return newproduct();
            }
        }
    }
}

