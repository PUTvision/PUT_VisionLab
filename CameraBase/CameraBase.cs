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
