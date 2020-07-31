using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4
{

    public class Cart
    {
        public List<Product> products = new List<Product>();
        public int CartId { get; set; }
        public string CustomerName { get; set; }
        public string Timebuy { get; set; }
        public string Timeout { get; set; }
        public int Status { get; set; }
        public int totalAmount => Totalamount();
        private int Totalamount()
        {
            int total = 0;
            foreach (var product in products)
            {
                total += product.amount;
            }
            return total;
        }
        public override string ToString()
        {
            string str = $"\nCartID: {CartId}\nCustomer: {CustomerName}\n" +
                $"Timebuy: {Timebuy}\nTimeout: {Timeout}\n" +
                $"Status: {((Status == 1) ? "Waiting ..." : (Status == 2) ? "Paid" : "Cancel")}" +
                $"\nProducts:\nNameProduct\tPrice\t\tCount\t\tAmount";

            foreach (var product in products)
            {
                str += $"\n{product.ToString()}";
            }
            str += $"\nTotal Amount: {totalAmount}\n\t\t----------*******------------";
            return str;
        }

    }
}
