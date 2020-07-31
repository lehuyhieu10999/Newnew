using System;
using System.Collections.Generic;
using System.Text;


namespace FashionShop
{
    public class Listorder
    {
        public List<Order> ListOrder = new List<Order>();

    }
    public class Shop
    {
        public static string path;
        public static string nameFileData;
        public int orderid;
        public Listorder listorder = new Listorder();
        public Shop(string _path, string namedata)
        {
            path = _path;
            nameFileData = namedata;
            ReadData();
            orderid = listorder.ListOrder.Count;
        }
        public void ReadData()
        {
            string fulllink = $@"{path}{nameFileData}";
            ReadWriteFile<Listorder>.ReadData(fulllink, ref listorder);
        }
        //Thêm đơn hàng
        public void Add(Order oder)
        {
            orderid++;
            oder.OrderId = orderid;
            listorder.ListOrder.Add(oder);
            string fulllink = $"{path}{nameFileData}";
            ReadWriteFile<Listorder>.WriteData(fulllink, listorder);
        }
        // Cập nhật đơn hàng, thêm sản phẩm
        public void UpdateOrder(int orderid, Product product)
        {
            Order oder = Check(orderid);
            if (oder != null && oder.Status == 1)
            {
                oder.ProductsList.Add(product);
            }
        }
        // Cập nhật trạng thái đơn hàng
        public void UpdateStatus(Order oder, int stt)
        {
            oder.Status = stt;
        }
        // Tìm kiếm đơn hàng
        public void SearchbyKey(string key)
        {
            key = key.ToLower();
            bool result = false;
            foreach (Order order in listorder.ListOrder)
            {
                if (order.CustomerName.ToLower().Contains(key) || order.Add.ToLower().Contains(key))
                {
                    Console.WriteLine(order.ToString());
                    result = true;
                }
            }
            if (!result)
            {
                Console.WriteLine("Not found!");
            }
        }
        // Kiểm tra đơn hàng trong ListOrder
        public Order Check(int orderid)
        {
            foreach (Order order in listorder.ListOrder)
            {
                if (order.OrderId.Equals(orderid))
                {
                    return order;
                }
            }
            return null;
        }
        public void PrintBill(Order od)
        {
            string billname = $"{DateTime.Now.ToString("ddMMyyyy")}_order_{od.OrderId}";
            ReadWriteFile<Order>.WriteData($@"{path}{billname}", od);
            string fulllink = $"{path}{nameFileData}";
            ReadWriteFile<Listorder>.WriteData(fulllink, listorder);
        }

    }
}
