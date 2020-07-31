using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex4
{
    static class ReadorWriteFile<T>
    {
        public static void ReadData(string fullpath, ref T data)
        {
            using (StreamReader sr = File.OpenText(fullpath))
            {
                var obj = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<T>(obj);
            }
        }

        public static void WriteData(string fullpath, T data)
        {
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                var resData = JsonConvert.SerializeObject(data);
                sw.WriteLine(resData);
            }
        }
    }

}
