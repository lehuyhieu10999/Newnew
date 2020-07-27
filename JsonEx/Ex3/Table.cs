using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public class Table
    {
        public int TableId { get; set; }
        public string CustomerName { get; set; }
        public string TimeOrder { get; set; }
        public string Timeout { get; set; }
        public int Status { get; set; }
        public int totalAmount => Totalamount();


        public List<Drinks> drinks = new List<Drinks>();

        private int Totalamount()
        {
            int total = 0;
            foreach (var drink in drinks)
            {
                total += drink.amount;
            }
            return total;
        }

        public override string ToString()
        {
            string str = $"\nOrderId: {TableId}\nCustomer: {CustomerName}\n" +
                $"Time Order: {TimeOrder}\nTimeout: {Timeout}\n" + 
                $"Status: {((Status == 1) ? "Waiting ..." : (Status == 2) ? "Paid" : "Cancel")}" +
                $"\nProduct:\nName\t\tPrice\tCount\tAmount";
           
            foreach (var drink in drinks)
            {
                str += $"\n{drink.ToString()}";
            }
            str += $"\nTotal Amount: {totalAmount}\n\t\t----------*******------------";
            return str;
        }
    }
}
