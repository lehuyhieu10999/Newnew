using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {

            var filePath = @"C:\Users\ADMIN\Desktop\HuyHiệu\Newnew\JsonEx\Ex2\Data\data.json";
            var outFilePath = @"C:\Users\ADMIN\Desktop\HuyHiệu\Newnew\JsonEx\Ex2\Data\Outcome.json";
            var result = new Data();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Data>(data);
            }

            var response = new ResponseData()
            {
                students = new List<ResStudent>()
            };
            
            foreach (var std in result.students)
            {
                response.students.Add(new ResStudent()
                {
                    Id = std.Id,
                    Name = std.Name,
                    Gender = std.Gender,
                    Class = std.Class,
                    subjects = std.subjects,
                    average = std.AverageScore(),
                });
            }
            response.students.Sort(new CompareAve());
            using (StreamWriter sw = File.CreateText(outFilePath))
            {
                var data = JsonConvert.SerializeObject(response);
                sw.Write(data);
            }
        }
        public class Subject
        {
            public string name { get; set; }
            public int score { get; set; }

        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Class { get; set; }
            public List<Subject> subjects { get; set; }
            public float AverageScore()
            {
                float total = 0;
                foreach (var item in subjects)
                {
                    if (item.name == "Math")
                    {
                        total += item.score * 2;
                    }
                    else
                    {
                        total += item.score;
                    }
                }
                return total / (subjects.Count + 1);
            }
            public override string ToString()
            {
                return $"{Id}\t\t{Name}\t\t{Gender}\t\t{Class}\t\t{subjects[0].score}\t\t{subjects[1].score}\\t\t{subjects[2].score}t\t{AverageScore()}";
            }

        }

        public class Data
        {
            public List<Student> students { get; set; }

        }

        public class ResponseData
        {
            public List<ResStudent> students { get; set; }
        }
        public class ResStudent : Student
        {
            public float average { get; set; }
            public string rank => Rank();
            public string Rank()
            {
                if (average >= 9)
                {
                    return "Xuat sac";
                }
                if (average >= 8)
                {
                    return "Gioi";
                }
                if (average >= 6.5)
                {
                    return "Kha";
                }
                if (average >= 5)
                {
                    return "TB";
                }
                return "Yeu";
            }
        }
        public class CompareAve : IComparer<ResStudent>
        {
            public int Compare( ResStudent x, ResStudent y)
            {
                return y.average.CompareTo(x.average);
            }
        }

    }
}
