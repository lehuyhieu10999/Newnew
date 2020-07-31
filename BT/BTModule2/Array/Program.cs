using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
                CreateMenu();
            }
         
        }
        
        public static void CreateMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nEnter your choice from 1 to 5:");
                Console.WriteLine("1. Create new array");
                Console.WriteLine("2. Is Ascending array");
                Console.WriteLine("3. Sort");
                Console.WriteLine("4. Find value");
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
        public static ArrayMethod admin = new ArrayMethod();
        public static int[] arr ;
        public static void Process(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter size:");
                        int size = int.Parse(Console.ReadLine());
                        arr = admin.CreateArray(size);
                        admin.PrintArray(arr);
                        break;
                    }
                case 2:
                    {
                        if (arr == null)
                        {
                            Console.WriteLine("Array is null!. Create array before, please!");
                            CreateMenu();
                        }

                        if (admin.IsSymmetricArray(arr))
                            Console.WriteLine("True");
                        else
                            Console.WriteLine("False");
                        break;
                    }
                case 3:
                    {
                        if (arr == null)
                        {
                            Console.WriteLine("Array is null!. Create array before, please!");
                            CreateMenu();
                        }
                        admin.SelectionSort(arr);
                        admin.PrintArray(arr);
                        break;
                    }
                case 4:
                    {
                        if (arr == null)
                        {
                            Console.WriteLine("Array is null!. Create array before, please!");
                            CreateMenu();
                        }
                        Console.WriteLine("Enter value to find: ");
                        int value = int.Parse(Console.ReadLine());
                        admin.PrintArray(arr);
                        int index = admin.Find(arr, value);
                        if (index == 0)
                            Console.WriteLine("This array is not ascending! ");
                        if (index == -1)
                            Console.WriteLine("Not found!");
                        else
                            Console.WriteLine($"Index is: {index}");
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
    }
}
