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

    public class ImageCounter
    {
        private int value;

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public ImageCounter()
        {
            this.value = 0;
        }

        public void Set(int valueNew)
        {
            this.value = valueNew;
        }

        public void Increment(int valueToIncrement)
        {
            this.value += valueToIncrement;
        }
    }
}

