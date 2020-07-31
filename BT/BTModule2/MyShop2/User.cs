using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    public class User
    {
        public bool isadmin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return $"{(isadmin ? "admin" : "Member")}\t\t{username} \t\t {("******")}";
        }
        public string ToStringAdmin()
        {
            return $"{(isadmin ? "admin" : "Member")}\t\t{username} \t\t {password}";
        }
    }
}
