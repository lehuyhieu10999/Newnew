using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;

namespace FashionShop
{
    public class Menu
    {
        public static string path = @$"C:\Users\ADMIN\Desktop\HuyHieu\Exercises\Kiemtra-Hieu\MyShop\Data\";
        public static string nameFile = "data.json";
        public static Shop shop = new Shop(path, nameFile);

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
                Console.WriteLine("5. Return login");

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
                        MenuUser.CreateUserMenu();
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
                    Allproducts.ShowAllproduct();

                    Console.WriteLine("Enter id of product that you want:");
                    int id = int.Parse(Console.ReadLine());

                    order.ProductsList.Add(Allproducts.Products[id]);
                    int index = shop.listorder.ListOrder.IndexOf(order);
                    shop.listorder.ListOrder[index].ProductsList = order.ProductsList;

                    string fulllink = $"{path}{nameFile}";
                    ReadWriteFile<Listorder>.WriteData(fulllink, shop.listorder);

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
                string fulllink = $"{path}{nameFile}";
                ReadWriteFile<Listorder>.WriteData(fulllink, shop.listorder);

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
                string timeout = DateTime.Now.ToString("ddMMyyyy hh:mm:ss");
                order.Timeout = timeout;
                shop.PrintBill(order);
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
        // Thêm 1 order mới
        public static void AddOrder()
        {
            Order od = new Order();
            Console.Write("Customer's name: ");
            od.CustomerName = Console.ReadLine();
            Console.Write("Address: ");
            od.Add = Console.ReadLine();
            od.Status = 1;
            string pos = "n";
            do
            {
                od.ProductsList.Add(Addproduct());
                Console.Write("Do you need more? y/n:  ");
                pos = Console.ReadLine().ToLower();
            } while (pos.Equals("y"));

            od.TimeOrder = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            shop.Add(od);
            Console.WriteLine("Successfully!!");
        }
        public static Product Addproduct()
        {
            Allproducts.ShowAllproduct();
            Console.WriteLine("Enter id of product you want to buy:");
            int id = int.Parse(Console.ReadLine());
            Product pro = Allproducts.Products[id];
            Console.WriteLine("Enter count:");
            int count = int.Parse(Console.ReadLine());
            pro.count = count;
            return pro;
        }
    }
}
