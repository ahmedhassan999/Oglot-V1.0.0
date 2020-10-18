using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OglotV1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder().UseKestrel().UseStartup<Startup>().Build();
            //host.Run();
            CreateHostBuilder(args).Build().Run();
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
               //webBuilder.UseIISIntegration();
               
               webBuilder.UseStartup<Startup>();
           });
    }
}
