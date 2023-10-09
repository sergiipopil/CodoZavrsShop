﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public static class LogService
    {
        private const string ExceptionLogFile = "..//..//../Logs/ExceptionLogs.txt";
        public static void Log(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n============Exception==========\n");
            Console.WriteLine($"{exception.Message}");
            Console.WriteLine("\n============Exception==========\n");
            Console.ResetColor();

            StringBuilder sb = new StringBuilder();
            sb.Append($"{DateTime.Now}\r\n");
            sb.Append($"Exception message:{exception.Message}\r\n");
            if (!String.IsNullOrEmpty(exception.StackTrace))
            {
                sb.Append($"StackTrace:{exception.StackTrace}");
            }
            AddToFile(sb.ToString());
        }
        private static void AddToFile(string message)
        {
            using var file = new System.IO.StreamWriter(ExceptionLogFile, true);
            file.WriteLine(message);
            file.Close();
        }
    }
}
