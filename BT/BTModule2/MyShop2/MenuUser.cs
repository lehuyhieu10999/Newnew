using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    public class MenuUser
    {
        public static string path = @"C:\Users\ADMIN\Desktop\HuyHieu\Exercises\Kiemtra-Hieu\MyShop\Data\";
        public static string nameFile = "account.json";
        public static AdminManager admin = new AdminManager(path, nameFile);
        public static int CreateUserMenu()
        {
            admin.ReadData();
            Console.WriteLine("Enter nameuser:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string pass = Console.ReadLine();
            User user = new User()
            {
                username = name,
                password = pass
            };
            foreach(User us in admin.listuser.Listuser)
            {
                if (us.username == user.username && us.password == user.password  && us.isadmin)
                    return 1;
                else if (us.username == user.username && us.password == user.password && !us.isadmin)
                    return 0;
            }
            return -1;
        }
        // Menu admin
        public static void CreatAdminMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Fashion Shop management");
                Console.WriteLine("2. Show All Members");
                Console.WriteLine("3. Add a new member");
                Console.WriteLine("4. Product Management");
                Console.WriteLine("5. Return login ");

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
            Processadmin(choice);
        }
        public static void Processadmin(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        Menu.CreateMenu();
                        break;
                    }
                case 2:
                    {
                        ShowAllMembersad();
                        break;
                    }
                case 3:
                    {
                        admin.Adduser();
                        break;
                    }
                case 4:
                    {
                        CreatProManagement();
                        break;
                    }
                case 5:
                    {
                        CreateUserMenu();
                        break;
                    }
            }
            CreatAdminMenu();
        }
        // Menu thành viên
        public static void CreatMemberMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Order Management");
                Console.WriteLine("2. Change your password");
                Console.WriteLine("3. Show all user");
                Console.WriteLine("4. Return privious ");

                Console.WriteLine("Your choice: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    choice = number;
                }
                if (number > 4 || number < 1)
                {
                    Console.Clear();
                    Console.Write("Not Allow!");
                }
            } while (choice > 4 || choice < 1);
            Processuser(choice);
        }
        public static void Processuser(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        Menu.CreateMenu();
                        break;
                    }
                case 2:
                    {
                        admin.ChangePass();
                        break;
                    }
                case 3:
                    {
                        ShowAllMembersmem();
                        break;
                    }
                case 4:
                    {
                        CreateUserMenu();
                        break;
                    }
            }
            CreatMemberMenu();
        }
        // Hiển thị toàn bộ danh sách user
        public static void ShowAllMembersmem()
        {
            Console.WriteLine("Permission\tUsername\tPassword");
            foreach (User user in admin.listuser.Listuser)
            {
                Console.WriteLine(user.ToString());
            }
        }
        public static void ShowAllMembersad()
        {
            Console.WriteLine("Permission\tUsername\tPassword");
            foreach (User user in admin.listuser.Listuser)
            {
                Console.WriteLine(user.ToStringAdmin());
            }
        }
        public static void CreatProManagement()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Show all product in shop");
                Console.WriteLine("2. Add product into product list");
                Console.WriteLine("3. Update product");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("5. Find product");
                Console.WriteLine("6. Return privious ");

                Console.WriteLine("Your choice: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    choice = number;
                }
                if (number > 6 || number < 1)
                {
                    Console.Clear();
                    Console.Write("Not Allow!");
                }
            } while (choice > 6 || choice < 1);
            Processproduct(choice);
        }
        public static void Processproduct(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        Allproducts.ShowAllproduct();
                        break;
                    }
                case 2:
                    {
                        Allproducts.Addpro();
                        Allproducts.ShowAllproduct();
                        break;
                    }
                case 3:
                    {
                        Allproducts.Updatepro();
                        Allproducts.ShowAllproduct();
                        break;
                    }
                case 4:
                    {
                        Allproducts.Removepro();
                        Allproducts.ShowAllproduct();
                        break;
                    }
                case 5:
                    {
                        Allproducts.Findpro();
                        break;
                    }

                case 6:
                    {
                        CreatAdminMenu();
                        break;
                    }
            }
            CreatProManagement();
        }
    }
}
