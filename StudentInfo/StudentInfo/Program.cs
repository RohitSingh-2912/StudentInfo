﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentInfo.Services;

namespace StudentInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var servicePort = Environment.GetEnvironmentVariable("SERVICE_PORT");

            var host = WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .Start($"http://*:{servicePort}");

            using (host)
            {
                Console.WriteLine("Use ctrl-c to shutdown the host...");
                host.WaitForShutdown();
            }
        }
    }
}
