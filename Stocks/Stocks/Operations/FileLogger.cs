using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stocks.Operations
{
    public class FileLogger : ILogger
    {
        public void Error(Exception ex)
        {
            var line = $"ERROR [{DateTime.Now}] { ex.Message}";
            using(var writer = new StreamWriter("stocks.log"))
            {
                writer.WriteLine(line);
            }
        }

        public void Info(string message)
        {
            var line = $"INFO [{DateTime.Now}] { message}";
            using (var writer = new StreamWriter("stocks.log"))
            {
                writer.WriteLine(line);
            }
        }
    }
}
