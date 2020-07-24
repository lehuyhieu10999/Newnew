using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;


namespace JsonEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\ADMIN\Desktop\Huy Hiệu\Newnew\JsonEx\JsonEx\Data\input.json";
            var result = new Data();
           
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Data>(data);
            }
           
            
            // 1.
            var response = new Response()
            {
                objects = new List<SumObject>()
            };
            
            SumObject sumObject = new SumObject()
            {
                sum_1 = result.objects[0].a + result.objects[0].b + result.objects[0].c,
                sum_2 = result.objects[1].a + result.objects[1].b + result.objects[1].c,
                sum_3 = result.objects[2].a + result.objects[2].b + result.objects[2].c
            };

            var outFilePath = @"C:\Users\ADMIN\Desktop\Huy Hiệu\Newnew\JsonEx\JsonEx\Data\output1.json";
            using (StreamWriter sw = File.CreateText(outFilePath))
            {
                var data = JsonConvert.SerializeObject(sumObject);
                sw.Write(data);
            }
           
            
            // 2.
            foreach(var item in result.objects)
            {

                item.a *= 2;
                item.b *= 2;
                item.c *= 2;

            }
            var outFilePath2 = @"C:\Users\ADMIN\Desktop\Huy Hiệu\Newnew\JsonEx\JsonEx\Data\output2.json";
            using (StreamWriter sw = File.CreateText(outFilePath2))
            {
                var data = JsonConvert.SerializeObject(result);
                sw.Write(data);
            }


        }
        class Data
        {
            public List<Object> objects { get; set; }
        }
        public class Object
        {
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
        }
        public class SumObject
        {
            public int sum_1 { get; set; }
            public int sum_2 { get; set; }
            public int sum_3 { get; set; }
        }
       
        // trả về của data
        public class Response
        {
            public List<SumObject> objects { get; set; }
        }
       
    }
}
