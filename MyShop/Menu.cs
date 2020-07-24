using System;
using System.Xml.Serialization;

namespace MyShop
{
    public class Menu
    {
        public static Shop shop = new Shop();

        public static void CreateMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Add order:");
                Console.WriteLine("2. Search Orders:");
                Console.WriteLine("3. Find customers");
                Console.WriteLine("4. All Order:");
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
                        AddOrder();
                        break;
                    }
                case 2:
                    {
                        SearchOrder();
                        break;
                    }
                case 3:
                    {
                        FindCustomer();
                        break;
                    }
                case 4:
                    {
                        ShowAllOrder();
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

        public static void CreateExtraMenu(Order oder)
        {
            try
            {

                Console.WriteLine("\nEnter number from 1 to 4:");
                Console.WriteLine("1. Add Product:");
                Console.WriteLine("2. Update Order's Status:");
                Console.WriteLine("3. Pay:");
                Console.WriteLine("4. Return Main Menu");

                Console.WriteLine("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice > 4 || choice < 1)
                {
                    Console.Clear();
                    Console.WriteLine(oder.ToString());
                };
                CreateExtraProcess(choice, oder);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errol type: {e.GetType().Name},Message: {e.Message}");
                Console.WriteLine("Please enter a number of Integer!");
                Console.WriteLine("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice > 4 || choice < 1)
                {
                    Console.Clear();
                    Console.WriteLine(oder.ToString());
                };
                CreateExtraProcess(choice, oder);
            }

        }
        
        static void CreateExtraProcess(int choice, Order order)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        UpdateOrder(order);
                        break;
                    }
                case 2:
                    {
                        UpdateStatus(order);
                        break;
                    }
                case 3:
                    {
                        Pay(order);
                        break;
                    }
                case 4:
                    {
                        CreateMenu();
                        break;
                    }
            }
            CreateExtraMenu(order);
        }
        /* Xử lý trên order*/
        // Cập nhật đơn hàng
        public static void UpdateOrder(Order order)
        {
            if (order.Status == 1)
            {
                do
                {
                    order.Products.Add(newproduct());
                    int index = shop.listorder.ListOrder.IndexOf(order);
                    shop.listorder.ListOrder[index].Products = order.Products;
                    Console.Clear();
                    Console.WriteLine(order.ToString());
                    Console.WriteLine("Successfully!");
                    Console.Write("Do you want to add more? y(Yes)/n(No):  ");
                }
                while (Console.ReadLine().ToLower() == "y");
            }
            else
            {
                Console.WriteLine(order.ToString());
                Console.WriteLine(" This order has been paid or has been canceled before!!");
            }
        }
        // Update Order's Status
        public static void UpdateStatus(Order order)
        {
            try
            {
                Console.Write("1.Waiting\n2.Paid\n3.Cancel\nChoice: ");
                int stt = int.Parse(Console.ReadLine());
                int index = shop.listorder.ListOrder.IndexOf(order);
                order.Status = (stt == 1) ? 1 : (stt == 2) ? 2 : 3;
                shop.listorder.ListOrder[index].Status = order.Status;
                Console.Clear();
                Console.WriteLine(order.ToString());
                Console.WriteLine("Update successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a number of Interger, please!!");
                Console.WriteLine(order.ToString());
                UpdateStatus(order);
            }
        }
        // Tính tiền đơn hàng
        public static void Pay(Order order)
        {
            if (order.Status == 1)
            {
                order.Status = 2;
                Console.Clear();
                Console.WriteLine(order.ToString());
                Console.WriteLine("Successfully!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine(order.ToString());
                Console.WriteLine("This order has been paid or has been canceled before!!");
            }
        }

        /*Xử lý trên menu chính*/

        // Hiển thị toàn bộ đơn hàng
        public static void ShowAllOrder()
        {
            foreach (Order order in shop.listorder.ListOrder)
            {
                Console.WriteLine(order.ToString());
            }
        }
        // Tìm kiếm đơn hàng
        public static void SearchOrder()
        {
            try
            {
                Console.Write("Enter Order's ID:  ");
                int id = int.Parse(Console.ReadLine());
                Order order = shop.Check(id);
                if (order != null)
                {
                    Console.WriteLine(order.ToString());
                    CreateExtraMenu(order);
                }
                else
                {
                    Console.WriteLine("Not found!");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                SearchOrder();
            }
        }
        // Tìm kiếm khách hàng
        public static void FindCustomer()
        {
            Console.Write("Enter Cutomer's Name or Address: ");
            shop.SearchbyKey(Console.ReadLine());
        }
        public static void AddOrder()
        {
            Order oder = new Order();
            Console.Write("Enter Customer's Name: ");
            oder.CustomerName = Console.ReadLine();
            Console.Write("Address: ");
            oder.Add = Console.ReadLine();
            oder.Status = 1;
            string choice = "n";
            do
            {
                oder.Products.Add(newproduct());
                Console.Write("Do you want to buy more ? Y(yes)/N(no):  ");
                choice = Console.ReadLine().ToLower();
            } while (choice.Equals("y"));

            oder.TimeOrder = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            shop.Add(oder);
            Console.WriteLine("Successfully!!");
        }
        public static Product newproduct()
        {
            try
            {
                Product pd = new Product();
                Console.Write("Name's Product: ");
                pd.name = Console.ReadLine();
                Console.Write("Price: ");
                pd.price = MustNumber();
                Console.Write("Count: ");
                pd.count = MustNumber();
                return pd;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}, { e.Message}");
                return newproduct();
            }
        }

        public static int MustNumber()
        {
            bool check;
            int pri;
            do
            {
                check = int.TryParse(Console.ReadLine(), out pri);
                if (check == false)
                {

                    Console.WriteLine("Enter a number of Integer, please!! ");
                }

            } while (check == false);
            return pri;
        }
    }
}


