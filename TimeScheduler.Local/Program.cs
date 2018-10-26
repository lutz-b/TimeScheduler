using System;
using Newtonsoft;
using Newtonsoft.Json;
using TimeScheduler.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace TimeScheduler.Local
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }

        private static void Test()
        {
            var file = @"C:\Work\TimeScheduler\TimeScheduler.Models\LisasPlan.json";
            var content = File.ReadAllText(file);
            var monday = JsonConvert.DeserializeObject<Day>(content);


            Console.WriteLine("Hello World!");
        }
    }
}
