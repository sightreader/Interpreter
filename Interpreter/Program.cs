using Config.Net;
using Fleck;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Net;
using Serilog;
using Interpreter.Config;
using Interpreter.Introducer;

namespace Interpreter
{
    class Program
    {
        private static IntroducerClient introducerClient;

        static void SetupLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("interpreter.log",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();
        }

        static Config.IConfig LoadConfig()
        {
            return new ConfigurationBuilder<Config.IConfig>()
                  .UseJsonConfig("config.json")
                  .Build();
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;

            SetupLogging();
            var config = LoadConfig();

            introducerClient = new IntroducerClient(config.Introducer);
            introducerClient.Connect();

            Console.ReadLine();
        }

        private static void CurrentDomainOnProcessExit(object sender, EventArgs eventArgs)
        {
            if (introducerClient != null)
            {
                introducerClient.Disconnect();
            }
        }
    }
}
