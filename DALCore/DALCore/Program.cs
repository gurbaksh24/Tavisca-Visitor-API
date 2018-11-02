using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DALCore
{
    public class Program
    {
        static IConfiguration config { get; } = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, false).Build();
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //configuration declare  and add json file here

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
                .UseStartup<Startup>();  // Required to send configuration here
    }
}
