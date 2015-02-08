using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PylonC.NET;


namespace PUTVision_CameraBasler
{
    public class CameraBasler : PUTVision_CameraBase.CameraBase
    {
        // const acts like static mebmer of a class
        protected const int frameToShowWidth = 320;
        protected int FrameToShowWidth { get { return frameToShowWidth; } }
        protected const int frameToShowHeight = 240;
        protected int FrameToShowHeight { get { return frameToShowHeight; } }

        #region Pylon variables
        // variables from pylon example
        protected const uint NUM_BUFFERS = 50;                                            /* Number of buffers used for grabbing. */
        protected uint GIGE_PACKET_SIZE = 1500;//8192;                                    /* Size of one Ethernet packet. */
        protected const uint GIGE_PROTOCOL_OVERHEAD = 36;
        /* Total number of bytes of protocol overhead. */

        //protected uint NUM_DEVICES = 1;                                                   /* Number of devices (cameras) to use. */
        //protected PYLON_DEVICE_HANDLE hDev = new PYLON_DEVICE_HANDLE();                                             /* Handles for the pylon devices. */
       // protected PYLON_STREAMGRABBER_HANDLE[] hGrabber;                                  /* Handle for the pylon stream grabber. */
        //protected Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[] buffers;     /* Holds handles and buffers used for grabbing. */
        //protected PYLON_WAITOBJECTS_HANDLE wos;                                           /* Wait objects. */
       // protected PylonGrabResult_t[] grabResult;                                         /* Stores the result of a grab operation. */
        #endregion
        public PYLON_DEVICE_HANDLE hDev = new PYLON_DEVICE_HANDLE();        /* Handles for the pylon devices. */

        protected PylonBuffer<Byte> imageToSave = null;
        protected EPylonPixelType pixelType = EPylonPixelType.PixelType_BayerBG8;
        protected string overwritteNote = "";
        protected string alertNote = "";
        protected bool flagSave = false;
        protected bool flagWriteToDisk = false;
        public bool zoomToFit = true;

        //protected bool reverseInAxisX = true;

        protected CameraBasler[] basler;

        #region Constructors
        public CameraBasler()
        {
            
        }

        /*public CameraBasler()
            : this(0, "defaultBasler", 640, 480)
        {
            this.working = false;
        }*/

        public CameraBasler(int _cameraNumber, string _cameraName, uint _frameWidth, uint _frameHeight)
        {
            this.cameraNumber = _cameraNumber;
            this.cameraName = _cameraName;
            this.frameWidth = _frameWidth;
            this.frameHeight = _frameHeight;

            this.PrepareFilename();

            #if DEBUG
                /* This is a special debug setting needed only for GigE cameras. See 'Building Applications with pylon' in the Programmer's Guide. */
                Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "300000" /*ms*/);
            #endif

            Pylon.Initialize();
        }

        public CameraBasler(CameraBasler[] basler)
        {
            // TODO: Complete member initialization
            this.basler = basler;
        }
        #endregion
        // think what to do with specialized open function...
        // (uint packetSize, GainAuto gainAuto, ExposureAuto exposureAuto, int exposureTimeAbs, AutoFunctionProfile autoFunctionProfile, int startingFrameDelay)

        #region ICamer interface implementation
        // explicit interface implementation is not preffered (i.e. (=tj./tzn. in Polish) with Amin_ICamera.ICamera. prefix) 

        // dodać (do ogólnego):
        // int numberOfCameras
        public override void Open()
        {
        }
        
        public override void Capture(int _imageNumber, bool _enableImageSave, bool _enableImageShow)
        {
        }
        public override void Close()
        {
        }
        #endregion

        #region Set Image To Save
        public void SetImageToSave(PylonBuffer<Byte> imagebuffer)
        {
            this.imageToSave = imagebuffer;
        }

        public PylonBuffer<Byte> ReturnImageToSave()
        {
            return this.imageToSave;
        }
        #endregion

        #region FPS
        void IncreaseFPS()
        {
            this.fps++;
        }

        public void RestetFPS()
        {
            this.fps=0;
        }

        public int ReturnFPS()
        {
            return this.fps;
        }
        #endregion

        #region Camera Name
        public void AssingDevice()
        {
            uint numDevicesAvail = Pylon.EnumerateDevices();
            for (uint i = 0; i < numDevicesAvail; i++)
            {
                try
                {
                    PYLON_DEVICE_INFO_HANDLE hDi_to_check_all = Pylon.GetDeviceInfoHandle((uint)i);
                    string deviceName = Pylon.DeviceInfoGetPropertyValueByName(hDi_to_check_all, Pylon.cPylonDeviceInfoFriendlyNameKey);

                    if (this.cameraName == deviceName)
                    {
                        this.hDev = Pylon.CreateDeviceByIndex((uint)i);
                    }
                }
                catch { }
            }
        }

        public string ReturnCameraName()
        {
            return this.cameraName;
        }

        public void SetCameraName(string name)
        {
            this.cameraName=name;
        }
        #endregion

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

        #region Pixel Type
        public void SetPixelType(EPylonPixelType type)
        {
            this.pixelType = type;
        }

        public EPylonPixelType ReturnPixelType()
        {
            return this.pixelType;
        }
        #endregion

        #region Flag Save
        public bool ReturnFlagSave()
        {
            return this.flagSave;
        }

        public void SetFlagSave(bool flag)
        {
            this.flagSave = flag;
        }
        #endregion

        #region Flag Write to Disk
        public bool ReturnFlagWriteToDisk()
        {
            return this.flagWriteToDisk;
        }

        public void SetFlagWriteToDisk(bool flag)
        {
            this.flagWriteToDisk = flag;
        }
        #endregion

        #region Alert Note
        public void SetAlertNote(string note)
        {
            this.alertNote = note;
        }

        public void ResetAlertNote()
        {
            this.alertNote = "";
        }

        public string ReturnAlertNote()
        {
            return this.alertNote;
        }
        #endregion

        #region Overwritten Note
        public void SetOverwrittenNote()
        {
            this.overwritteNote= "File will be overwritting!";
        }

        public void ResetOverwrittenNote()
        {
            this.overwritteNote= "";
        }

        public string ReturnOverwrittenNote()
        {
            return this.overwritteNote;
        }
        #endregion

        #region Zoom To Fit
        public bool ReturnZoomToFit()
        {
            return this.zoomToFit;
        }

        public void SetZoomToFit(bool zoom)
        {
            this.zoomToFit = zoom;
        }
        #endregion


    }
}
class TimerCallbackWrapper
{
    public TimerCallbackWrapper(AutoResetEvent triggeredTimeoutEvent)
    {
        timeoutEvent = triggeredTimeoutEvent;
    }

    public void TimerCallback(Object state)
    {
        timeoutEvent.Set();
    }

    protected AutoResetEvent timeoutEvent;
}
