using System;
using System.Collections.Generic;
using System.Text;

namespace LogService
{
    public class ConsoleLogProvider : ILogProvider
    {
        public void LogError(string msg)
        {
            Console.Write($"error{msg}");
        }

        public void LogInfo(string msg)
        {
            Console.Write($"info{msg}");
        }
    }
}
