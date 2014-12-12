using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUTVision_Utils
{
    public class PUTVision_Utils
    {
    }

    public delegate void LogHandler(object o, LogEventArgs e);

    public class LogEventArgs : EventArgs
    {
        public readonly string message;

        public LogEventArgs(string _message)
        {
            this.message = _message;
        }
    }
}

