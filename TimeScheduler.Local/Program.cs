using System;
using Newtonsoft;
using Newtonsoft.Json;
using TimeScheduler.Models;
using System.IO;


namespace TimeScheduler.Local
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Work\TimeScheduler\TimeScheduler.Models\LisasPlan.json";
            var content = File.ReadAllText(file);
            var monday = JsonConvert.DeserializeObject<Day>(content);



            Console.WriteLine("Hello World!");
        }
    }
}
