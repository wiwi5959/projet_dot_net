using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext.Domaine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using App.Repository;

namespace projet_dot_net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext context = new AppContext();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
