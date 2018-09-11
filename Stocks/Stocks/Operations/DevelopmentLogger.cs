using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Stocks.Operations
{
    public class DevelopmentLogger : ILogger
    {
        public void Error(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        public void Info(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
