using Newtonsoft.Json;
using System.IO;

namespace FashionShop
{
    static class ReadWriteFile<T>
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
