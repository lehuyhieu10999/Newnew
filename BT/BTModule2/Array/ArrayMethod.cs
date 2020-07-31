using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Array
{
    class ArrayMethod
    {
        public int[] CreateArray(int size)
        {
            int[] arr = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(30, 60);
            }
            return arr;
        }
        public bool IsSymmetricArray(int[] arr)
        {
            int length = arr.Length;
            if (length == 1)
                return true;
            if (length == 2 && arr[length - 1] == arr[length - 2])
                return true;
            for (int i = 0; i < length / 2; i++)
            {
                if (arr[i] != arr[length - 1 - i])
                    return false;
            }
            return true;
        }

        public void SelectionSort(int[] arr)
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int currentMin = arr[i];
                int currentMinIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentMin > arr[j])
                    {
                        currentMin = arr[j];
                        currentMinIndex = j;
                    }
                }
                if (currentMinIndex != i)
                {
                    arr[currentMinIndex] = arr[i];
                    arr[i] = currentMin;
                }
            }
        }
        public bool IsAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }
        public int Find(int[] arr, int value)
        {
            if (IsAscending(arr))
            {
                int low = 0;
                int high = arr.Length - 1;
                while (high >= low)
                {
                    int mid = (low + high) / 2;
                    if (value < arr[mid])
                        high = mid - 1;
                    else if (value == arr[mid])
                        return mid;
                    else low = mid + 1;
                }
                return -1;
            }

            return 0;
        }


        public void PrintArray(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}
