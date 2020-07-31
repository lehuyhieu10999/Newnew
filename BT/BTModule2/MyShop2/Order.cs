using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Add { get; set; }
        public string TimeOrder { get; set; }
        public string Timeout { get; set; }
        public int Status { get; set; }
        public int TotalAmount => totalamount();

        public List<Product> ProductsList = new List<Product>();

       
        private int totalamount()
        {
            int total = 0;
            foreach (var product in ProductsList)
            {
                total += product.Amount;
            }
            return total;
        }

        public override string ToString()
        {
            string str = $"\nOrderId: {OrderId}\nCustomer: {CustomerName}\nAddress: {Add}\n" +
                $"Time Order: {TimeOrder}\nTimeout:{Timeout}" +
                $"\nStatus: {((Status == 1) ? "Waiting ..." : (Status == 2) ? "Paid" : "Cancel")}" +
                $"\nProduct:\n  ID\t\tName\t\t\tPrice\tCount\tAmount";
            foreach (var product in ProductsList)
            {
                str += $"\n{product.ToString()}";
            }
            str += $"\nTotal Amount: {TotalAmount}\n\t\t----------***------------";
            return str;
        }
    }
}
