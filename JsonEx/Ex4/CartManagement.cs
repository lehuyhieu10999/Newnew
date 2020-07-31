using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4
{
    public class ListCart
    {
        public List<Cart> Listcart = new List<Cart>();
    }
    class CartManagement
    {
        private string path;
        private string filename;
        public CartManagement(string path, string filename)
        {
            this.path = path;
            this.filename = filename;
            ReadFile();
        }

        public ListCart listcart = new ListCart();
        
        public ListCart ReadFile()
        {
            string fullpath = $@"{path}\{filename}";
            ReadorWriteFile<ListCart>.ReadData(fullpath, ref listcart);
            return listcart;
        }
        // Thêm giỏ hàng
        public void Add(Cart cart)
        {
            listcart.Listcart.Add(cart);
            string fullpath = $@"{path}\{filename}";
            ReadorWriteFile<ListCart>.WriteData(fullpath, listcart);
        }
        // Check giỏ hàng
        public Cart Check(int cartid)
        {
            foreach (var cart in listcart.Listcart )
            {
                if (cart.CartId.Equals(cartid) && cart.Timeout == null)
                {
                    return cart;
                }
            }
            return null;
        }
        // Kiểm tra sản phẩm trong giỏ hàng
        public int Checkpro(int cartid, string name)
        {
            var cart = Check(cartid);

            for (int j = 0; j < cart.products.Count; j++)
            {
                if (cart.products[j].name == name)
                {
                    return j;
                }
               
            }
            return -1;
        }
// In bills
public void PrintBill(Cart cart)
        {
            string billname = $"{DateTime.Now.ToString("ddMMyyyyhhmm")}_table_{cart.CartId}";
            ReadorWriteFile<Cart>.WriteData($@"{path}\{billname}", cart);
            string fulllink = $@"{path}\{filename}";
            ReadorWriteFile<ListCart>.WriteData(fulllink, listcart);
        }
    }
}
