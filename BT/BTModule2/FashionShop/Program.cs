using System;

namespace FashionShop
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Login();
            }
        }
        public static void Login()
        {
            int permiss = MenuUser.CreateUserMenu();
            if (permiss == 1)
            {
                MenuUser.CreatAdminMenu();
            }
            else if (permiss == 0)
            {
                MenuUser.CreatMemberMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Can't found you!!!");
                Login();
            }
        }
    }
}
