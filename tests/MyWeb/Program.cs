﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CentralLogProvider;

namespace MyWeb {
    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(builder => {
                    builder.ClearProviders();
                    builder.addLog(new CentralLogOptions { ServiceUrl = "http://localhost:5000/api/logger/addLog" });
                })
                .UseStartup<Startup>();
    }
}
