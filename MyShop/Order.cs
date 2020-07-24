using System.Collections.Generic;

namespace MyShop
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Add { get; set; }
        public string TimeOrder { get; set; }
        public int Status { get; set; }
        public int TotalAmount => totalamount();

        public List<Product> Products = new List<Product>();

        private int totalamount()
        {
            int total = 0;
            foreach (var product in Products)
            {
                total += product.Amount;
            }
            return total;
        }

        public override string ToString()
        {
            string str = $"\nOrderId: {OrderId}\nCustomer: {CustomerName}\nAddress: {Add}\n" +
                $"Time Order: {TimeOrder}\n" +
                $"Status: {((Status == 1) ? "Waiting ..." : (Status == 2) ? "Paid" : "Cancel")}" +
                $"\nProduct:\nName\t\tPrice\tCount\tAmount";
            foreach (var product in Products)
            {
                str += $"\n{product.ToString()}";
            }
            str += $"\nTotal Amount: {TotalAmount}\n\t\t----------***------------";
            return str;
        }
    }
}
