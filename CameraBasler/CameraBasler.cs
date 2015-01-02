using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PylonC.NET;

namespace PUTVison_CameraBasler
{
    public class CameraBasler : PUTVision_CameraBase.CameraBase, PUTVision_ICamera.ICamera
    {
        // maybe in the future add List<Capture> for ability to use more than one camera


        // const acts like static mebmer of a class
        private const int frameToShowWidth = 320;
        private int FrameToShowWidth { get { return frameToShowWidth; } }
        private const int frameToShowHeight = 240;
        private int FrameToShowHeight { get { return frameToShowHeight; } }

        #region Pylon variables
        // variables from pylon example
        private const uint NUM_BUFFERS = 50;                                            /* Number of buffers used for grabbing. */
        private uint GIGE_PACKET_SIZE = 1500;//8192;                                    /* Size of one Ethernet packet. */
        private const uint GIGE_PROTOCOL_OVERHEAD = 36;                                 /* Total number of bytes of protocol overhead. */

        private uint NUM_DEVICES = 1;                                                   /* Number of devices (cameras) to use. */
        private PYLON_DEVICE_HANDLE[] hDev;                                             /* Handles for the pylon devices. */
        private PYLON_STREAMGRABBER_HANDLE[] hGrabber;                                  /* Handle for the pylon stream grabber. */
        private Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[] buffers;     /* Holds handles and buffers used for grabbing. */
        private PYLON_WAITOBJECTS_HANDLE wos;                                           /* Wait objects. */
        private PylonGrabResult_t[] grabResult;                                         /* Stores the result of a grab operation. */
        #endregion

        #region Constructors
        public CameraBasler()
            : this(0, "defaultBasler", 640, 480)
        {
        }

        public CameraBasler(int _cameraNumber, string _cameraName, int _frameWidth, int _frameHeight)
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
    }
}
