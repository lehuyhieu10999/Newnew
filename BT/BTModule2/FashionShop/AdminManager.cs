using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
namespace FashionShop
{
    public class ListUser
    {
        public List<User> Listuser = new List<User>();
    }
    public class AdminManager
    {
        public static string path;
        public static string nameFileData;
        public ListUser listuser = new ListUser();
        public AdminManager(string _path, string namedata)
        {
            path = _path;
            nameFileData = namedata;
            ReadData();
        }
        public void ReadData()
        {
            string fulllink = $@"{path}{nameFileData}";
            ReadWriteFile<ListUser>.ReadData(fulllink, ref listuser);
        }
        // Kiểm tra user
        public User IsUser(string username)
        {

            foreach (User user in listuser.Listuser)
            {
                if (user.username.Equals(username))
                {
                    return user;
                }
            }
            return null;
        }
        public bool Isadmin(string adminname)
        {

            foreach (User user in listuser.Listuser)
            {
                if (user.isadmin)
                {
                    return true;
                }
            }
            return false;
        }
        // Thêm user
        public void Adduser()
        {
            listuser.Listuser.Add(newuser());
            string fulllink = $"{path}{nameFileData}";
            ReadWriteFile<ListUser>.WriteData(fulllink, listuser);
            Console.WriteLine("Successfully!");
        }
        // Đổi mật khẩu
        public void ChangePass()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            User user = IsUser(username);
            if (user != null)
            {
                Console.WriteLine("Enter current password:");
                string pass = Console.ReadLine();
                if (user.password == pass)
                {
                    Console.WriteLine("Enter new password");
                    string newpass = Console.ReadLine();
                    Console.WriteLine("Enter new password again:");
                    string newpass2 = Console.ReadLine();
                    if (newpass == newpass2)
                    {
                        user.password = newpass;
                        string fulllink = $"{path}{nameFileData}";
                        ReadWriteFile<ListUser>.WriteData(fulllink, listuser);
                        Console.WriteLine("Successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password! Enter again, please!");
                    ChangePass();
                }
            }
            else
            {
                Console.WriteLine("Username does not exist !!");
                ChangePass();
            }
        }

        public static User newuser()
        {
            try
            {
                User user = new User();
                Console.Write("Enter Username: ");
                user.username = Console.ReadLine();
                Console.Write("Enter password ");
                user.password = Console.ReadLine();
                Console.Write("Are you admin? Yes(y)/No(n) ");
                string isad = Console.ReadLine();
                if (isad == "y")
                    user.isadmin = true;
                else
                    user.isadmin = false;
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}, { e.Message}");
                return newuser();
            }
        }
    }
}
