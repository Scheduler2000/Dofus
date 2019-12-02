using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Networking;

namespace Renaissance.Auth
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.Title = "Renaissance Authentication";
            DrawAscii();

            try
            {
                ServiceLocator.Provider = AuthStartup.Configure();
                var authServer = ServiceLocator.Provider.GetService<AuthServer>();
                await authServer.Initialize();
            }
            catch (Exception ex)
            { Logger.Instance.Log(LogLevel.Fatal, "MAIN", ex.ToString()); }
        }

        private static void DrawAscii()
        {
            Random rnd = new Random();
            string[] logo = new string[]
            {
             " ____                      _                                    ",
            @"|  _ \  ___  _ __    __ _ (_) ___  ___   __ _  _ __    ___  ___ ",
            @"| |_) |/ _ \| '_ \  / _` || |/ __|/ __| / _` || '_ \  / __|/ _ \",
            @"|  _ <|  __/| | | || (_| || |\__ \\__ \| (_| || | | || (__|  __/",
            @"|_| \_\\___||_| |_| \__,_||_||___/|___/ \__,_||_| |_| \___|\___|",
            "                                                                 ",
            "---------------------[Author : Scheduler]-------------------------",
            "                     [Version : 2.53.9.0]                         "
            };

            for (int i = 0; i < logo.Length; i++)
            {
                if (i % 2 == 0)
                    Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 15);
                int totalWidth = (Console.BufferWidth + logo[i].Length) / 2;
                Console.WriteLine(logo[i].PadLeft(totalWidth));
            }
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
