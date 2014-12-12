using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUTVision_CameraBase
{
    public abstract class CameraBase
    {
        protected int cameraNumber;
        protected string cameraName;

        protected int frameHeight;
        protected int frameWidth;

        protected string filenamePrefix;

        protected void PrepareFilename()
        {
            this.filenamePrefix = "img_" + this.cameraName + "_";
        }

        public abstract void Open();
        public abstract void Capture(int _imageNumber, bool _enableImageSave, bool _enableImageShow);
        public abstract void Close();

        public event PUTVision_Utils.LogHandler Log;
        protected void FireEvent_Log(string msg)
        {
            if (Log != null)
            {
                PUTVision_Utils.LogEventArgs e = new PUTVision_Utils.LogEventArgs(msg);
                Log(null, e);
            }
        }
    }
}

// stare pomysły
// jaki wspólne pola konfiguracyjne?
// kolor / skala szarosci
// ???

// opcje:
// wyswietlanie / zapisywanie / pomiar czasu

// tryb pracy
// asynchroniczny / synchroniczny

// eventy
// przesylanie informacji (message)
// nastepna klatka (nextFrameEvent)
