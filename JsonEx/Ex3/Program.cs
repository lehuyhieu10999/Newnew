using System;
using System.Collections.Generic;
using System.IO;

namespace Ex3
{
    class Program
    {
        public static  string path = $@"C:\Users\ADMIN\Desktop\HuyHiệu\Newnew\JsonEx\Ex3\Bill";
        public static string filename = "data.json";
        public static Management admin = new Management(path,filename);
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
                Console.WriteLine("1. Add table");
                Console.WriteLine("2. Show all table");
                Console.WriteLine("3. Pay");
                Console.WriteLine("4. Add drink");
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
                        AddTable();
                        break;
                    }
                case 2:
                    {
                        ShowAllOrder();
                        break;
                    }
                case 3:
                    {
                        Pay();
                        break;
                    }
                case 4:
                    {
                        UpdateTable();
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

        public static void AddTable()
        {
            Table table = new Table();
            Console.Write("Enter table Id:");
            table.TableId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer's Name: ");
            table.CustomerName = Console.ReadLine();
            table.Status = 1;
            string choice = "n";
            do
            {
                table.drinks.Add(Newdrink());
                Console.Write("Do you need more ? Y(yes)/N(no):  ");
                choice = Console.ReadLine().ToLower();
            } while (choice.Equals("y"));

            table.TimeOrder = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            admin.Add(table);
            Console.WriteLine("Successfully!!");
        }
        // Hiển thị toàn bộ bàn
        public static void ShowAllOrder()
        {
            Listtable listtable = admin.ReadFile();
            if (listtable != null)
            {
                foreach (Table tb in listtable.ListTable)
                {
                    Console.WriteLine(tb.ToString());
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Nothing to show!!");
                CreateMenu();
            }
        }
        public static void Pay()
        {
            try
            {
                Console.WriteLine("Enter id of table you want to pay: ");
                int id = int.Parse(Console.ReadLine());
                Table table = admin.Check(id);
                if (table != null)
                {
                    if (table.Status == 1)
                    {
                        table.Status = 2;
                        Console.Clear();
                        string timeout = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                        table.Timeout = timeout;
                        Console.WriteLine(table.ToString());
                        // Ghi hóa đơn
                        admin.PrintBill(table);
                        Console.WriteLine("Successfully!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(table.ToString());
                        Console.WriteLine("This order has been paid or has been canceled before!!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid table!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}, {e.Message}");
                Pay();
            }
        }
        // Thêm đồ uống
        private static void UpdateTable()
        {
            try
            {
                Console.WriteLine("Enter id of table you want to add: ");
                int id = int.Parse(Console.ReadLine());
                Table _table = admin.Check(id);
                if (_table != null)
                {
                    if (_table.Status == 1)
                    {
                        do
                        {
                            _table.drinks.Add(Newdrink());
                            int ind = admin.listtable.ListTable.IndexOf(_table);
                            admin.listtable.ListTable[ind].drinks = _table.drinks;
                            string fulllink = $@"{path}\{filename}";
                            ReadorWriteFile<Listtable>.WriteData(fulllink, admin.listtable);
                            Console.Clear();
                            Console.WriteLine(_table.ToString());
                            Console.WriteLine("Successfully");
                            Console.Write("Do you want to add more? y/n:  ");
                        } while (Console.ReadLine().ToLower() == "y");
                    }
                    else
                    {
                        Console.WriteLine(_table.ToString());
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
                UpdateTable();
            }
        }

        public static Drinks Newdrink()
        {
            try
            {
                Drinks drink = new Drinks();
                Console.Write("Name of drink: ");
                drink.name = Console.ReadLine();
                Console.Write("Price: ");
                drink.price = (int)uint.Parse(Console.ReadLine());
                Console.Write("Count: ");
                drink.count = (int)uint.Parse(Console.ReadLine());
                return drink;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}, { e.Message}");
                return Newdrink();
            }
        }
    }
}
