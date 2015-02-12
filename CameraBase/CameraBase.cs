using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUTVision_CameraBase 
{
    public abstract class CameraBase
    {
        protected bool colorful = true;
        protected int cameraNumber = 0;
        protected string cameraName = "camera";

        protected uint frameHeight=100;
        protected uint frameWidth=200;

        protected int photoNumber = 1;
        protected int fps = 0;

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

        #region Freame size

        public void SetFrameSize(uint sizeX, uint sizeY)
        {
            this.frameWidth = sizeX;
            this.frameHeight = sizeY;
        }
        public void ReturnFrameSize(out uint width, out uint Height)
        {
            width = this.frameWidth;
            Height = this.frameHeight;
        }
        #endregion

        #region Photo Number
        public void IncreasePhotoNumber()
        {
            this.photoNumber++;
        }

        public void SetPhotoNumber(int number)
        {
            this.photoNumber=number;
        }

        public void RestetPhotoNumber()
        {
            this.photoNumber = 0;
        }

        public int ReturnPhotoNumber()
        {
            return this.photoNumber;
        }
        #endregion

        #region Fps
        public void IncreaseFps()
        {
            this.fps++;
        }

        public void RestetFps()
        {
            this.fps = 0;
        }

        public int ReturnFps()
        {
            return this.fps;
        }
        #endregion

        #region Color
        public bool ReturnColor()
        {
            return this.colorful;
        }

        public void SetColor(bool color)
        {
            this.colorful = color;
        }
        #endregion


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
