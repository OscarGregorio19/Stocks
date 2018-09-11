using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Operations
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Info(string message);
    }
}
