using Stocks.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Test.Mocks
{
    public class MockLogger : ILogger
    {
        public bool ErrorInvoked
        {
            get;
            private set;
        }

        public bool InfoInvoked
        {
            get;
            private set;
        }

        public void Error(Exception ex)
        {
            ErrorInvoked = true;
        }

        public void Info(string message)
        {
            InfoInvoked = true;
        }
    }
}
