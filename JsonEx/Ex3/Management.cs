using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public class Listtable
    {
        public List<Table> ListTable;

    }
    public class Management
    {

        private string path;
        private string filename;
        public Management(string path,string filename)
        {
            this.path = path;
            this.filename = filename;
            ReadFile();
        }
           
        public Listtable listtable = new Listtable()
        {
            ListTable = new List<Table>()
        };
       
        // Đọc dữ liệu file chứa danh sách các bàn
        public Listtable ReadFile()
        {
            string fullpath = $@"{path}\{filename}";
            ReadorWriteFile<Listtable>.ReadData(fullpath,ref listtable);
            return listtable;
        }

        //Thêm bàn
        public void Add(Table table)
        {
            listtable.ListTable.Add(table);
            string fullpath = $@"{path}\{filename}";
            ReadorWriteFile<Listtable>.WriteData(fullpath, listtable);   
            
        }

        // Tìm kiếm bàn
        public void Search(string tableid)
        {
            tableid = tableid.ToUpper();
            bool check = false;
            foreach (Table table in listtable.ListTable)
            {
                if (table.CustomerName.ToUpper().Contains(tableid))
                {
                    Console.WriteLine(table.ToString());
                    check = true;
                }
            }
            if (!check)
            {
                Console.WriteLine("Not found!");
            }
        }
        // Tìm bàn 
      
        public Table Check(int tableid)
        {
            foreach (Table table in listtable.ListTable)
            {
                if (table.TableId.Equals(tableid) && table.Timeout == null)
                {
                    return table;
                }
            }
            return null;
        }

        // in bill
        public void PrintBill(Table table)
        {
            string billname = $"{DateTime.Now.ToString("ddMMyyyyhhmm")}_table_{table.TableId}";
            ReadorWriteFile<Table>.WriteData($@"{path}\{billname}", table);
            string fulllink = $@"{path}\{filename}";
            ReadorWriteFile<Listtable>.WriteData(fulllink, listtable);
        }
    }
}
