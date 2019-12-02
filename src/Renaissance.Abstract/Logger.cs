using System;
using System.Collections.Generic;

namespace Renaissance.Abstract
{
    public enum LogLevel { Debug, Info, Warn, Error, Fatal }

    public sealed class Logger
    {
        private readonly Dictionary<LogLevel, ConsoleColor> m_colorWrapper;

        public static Logger Instance { get; }

        static Logger() { Instance = new Logger(); }

        private Logger()
        {
            this.m_colorWrapper = new Dictionary<LogLevel, ConsoleColor>()
            {
                {LogLevel.Debug, ConsoleColor.Green },
                {LogLevel.Info, ConsoleColor.Blue },
                {LogLevel.Warn, ConsoleColor.DarkYellow },
                {LogLevel.Error, ConsoleColor.Red },
                {LogLevel.Fatal, ConsoleColor.DarkRed }
            };
        }


        public void Log(LogLevel level, string header, string message, bool printDate = false)
        {
            var date = printDate
                       ? $"| {DateTime.Now}"
                       : default;

            if (Console.ForegroundColor != m_colorWrapper[level])
                Console.ForegroundColor = m_colorWrapper[level];

            Console.WriteLine($"[ {header} {date}] : {message}");
        }
    }
}
