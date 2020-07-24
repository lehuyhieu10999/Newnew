using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    public class Listorder
    {
        public List<Order> ListOrder;
        
    }
    public class Shop
    {
        public int orderid;
        public Listorder listorder = new Listorder()
        {
            ListOrder = new List<Order>()
        };
        //Thêm đơn hàng
        public void Add(Order oder)
        {
            orderid++;
            oder.OrderId = orderid;
            listorder.ListOrder.Add(oder);
        }
        // Cập nhật đơn hàng, thêm sản phẩm
        public void UpdateOrder(int orderid, Product product)
        {
            Order oder = Check(orderid);
            if (oder != null && oder.Status == 1)
            {
                oder.Products.Add(product);
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

    }

}
