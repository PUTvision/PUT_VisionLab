using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlyCapture2Managed;

namespace PUTVison_CameraPointGrey
{
    public class CameraPointGrey : PUTVision_CameraBase.CameraBase
    {

        private ManagedGigECamera[] cameras;
        private ManagedImage[] bufferOfImagesRetrived;
        private ManagedImage[] bufferOfImagesProcessed;
        private bool useSoftwareTrigger = true;
        private TriggerMode triggerMode;

        
        #region Constructors
        public CameraPointGrey()
            : this(0, "defaultPointGray", 640, 480)
        {
        }

        public CameraPointGrey(int _cameraNumber, string _cameraName, uint _frameWidth, uint _frameHeight)
        {
            this.cameraNumber = _cameraNumber;
            this.cameraName = _cameraName;
            this.frameWidth = _frameWidth;
            this.frameHeight = _frameHeight;

            this.PrepareFilename();
        }
        #endregion

        #region Print Functions


        public void PrintCameraInfo(CameraInfo camInfo)
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n*** CAMERA INFORMATION ***\n");
            newStr.AppendFormat("Serial number - {0}\n", camInfo.serialNumber);
            newStr.AppendFormat("Camera model - {0}\n", camInfo.modelName);
            newStr.AppendFormat("Camera vendor - {0}\n", camInfo.vendorName);
            newStr.AppendFormat("Sensor - {0}\n", camInfo.sensorInfo);
            newStr.AppendFormat("Resolution - {0}\n", camInfo.sensorResolution);

            FireEvent_Log(newStr.ToString());
        }

        public void PrintCameraInfoDetailed(CameraInfo camInfo)
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n*** CAMERA INFORMATION ***\n");
            newStr.AppendFormat("Serial number - {0}\n", camInfo.serialNumber);
            newStr.AppendFormat("Camera model - {0}\n", camInfo.modelName);
            newStr.AppendFormat("Camera vendor - {0}\n", camInfo.vendorName);
            newStr.AppendFormat("Sensor - {0}\n", camInfo.sensorInfo);
            newStr.AppendFormat("Resolution - {0}\n", camInfo.sensorResolution);
            newStr.AppendFormat("Firmware version - {0}\n", camInfo.firmwareVersion);
            newStr.AppendFormat("Firmware build time - {0}\n", camInfo.firmwareBuildTime);
            newStr.AppendFormat("GigE version - {0}.{1}\n", camInfo.gigEMajorVersion, camInfo.gigEMinorVersion);
            newStr.AppendFormat("User defined name - {0}\n", camInfo.userDefinedName);
            newStr.AppendFormat("XML URL 1 - {0}\n", camInfo.xmlURL1);
            newStr.AppendFormat("XML URL 2 - {0}\n", camInfo.xmlURL2);
            newStr.AppendFormat("MAC address - {0}\n", camInfo.macAddress.ToString());
            newStr.AppendFormat("IP address - {0}\n", camInfo.ipAddress.ToString());
            newStr.AppendFormat("Subnet mask - {0}\n", camInfo.subnetMask.ToString());
            newStr.AppendFormat("Default gateway - {0}\n", camInfo.defaultGateway.ToString());

            FireEvent_Log(newStr.ToString());
        }

        public void PrintStreamChannelInfo(GigEStreamChannel streamChannelInfo)
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append("\n*** STREAM CHANNEL INFORMATION ***\n");
            newStr.AppendFormat("Network interface - {0}\n", streamChannelInfo.networkInterfaceIndex);
            newStr.AppendFormat("Host post - {0}\n", streamChannelInfo.hostPost);
            newStr.AppendFormat("Do not fragment bit - {0}\n", streamChannelInfo.doNotFragment == true ? "Enabled" : "Disabled");
            newStr.AppendFormat("Packet size - {0}\n", streamChannelInfo.packetSize);
            newStr.AppendFormat("Inter packet delay - {0}\n", streamChannelInfo.interPacketDelay);
            newStr.AppendFormat("Destination IP address - {0}\n", streamChannelInfo.destinationIpAddress);
            newStr.AppendFormat("Source port (on camera) - {0}\n\n", streamChannelInfo.sourcePort);

            FireEvent_Log(newStr.ToString());
        }

        #endregion

        private bool PollForTriggerReady(ManagedGigECamera cam)
        {
            const uint k_softwareTrigger = 0x62C;

            uint regVal = 0;

            do
            {
                regVal = cam.ReadRegister(k_softwareTrigger);
            }
            while ((regVal >> 31) != 0);

            return true;
        }

        private bool PollForTriggerReady(ManagedGigECamera[] cameras)
        {
            const uint k_softwareTrigger = 0x62C;

            uint regVal = 0;

            do
            {
                regVal = 0;
                foreach (var camera in cameras)
                {
                    regVal = regVal | camera.ReadRegister(k_softwareTrigger);
                }
            } while ((regVal >> 31) != 0);

            return true;
        }

        private bool FireSoftwareTrigger(ManagedGigECamera cam)
        {
            const uint k_softwareTrigger = 0x62C;
            const uint k_fireVal = 0x80000000;

            cam.WriteRegister(k_softwareTrigger, k_fireVal);

            return true;
        }

        private bool FireSoftwareTrigger(ManagedGigECamera[] cameras)
        {
            const uint k_softwareTrigger = 0x62C;
            const uint k_fireVal = 0x80000000;

            foreach (var camera in cameras)
            {
                camera.WriteRegister(k_softwareTrigger, k_fireVal);
            }

            return true;
        }

        private void ConfigureSoftwareTrigger(ManagedGigECamera cam)
        {
            // Power on the camera
            const uint k_cameraPower = 0x610;
            const uint k_powerVal = 0x80000000;
            cam.WriteRegister(k_cameraPower, k_powerVal);

            const Int32 k_millisecondsToSleep = 100;
            uint regVal = 0;

            // Wait for camera to complete power-up
            do
            {
                System.Threading.Thread.Sleep(k_millisecondsToSleep);

                regVal = cam.ReadRegister(k_cameraPower);

            } while ((regVal & k_powerVal) == 0);

            if (!useSoftwareTrigger)
            {
                // Check for external trigger support
                TriggerModeInfo triggerModeInfo = cam.GetTriggerModeInfo();
                if (triggerModeInfo.present != true)
                {
                    Console.WriteLine("Camera does not support external trigger! Exiting...\n");
                    return;
                }
            }

            // Get current trigger settings
            triggerMode = cam.GetTriggerMode();

            // Set camera to trigger mode 0
            // A source of 7 means software trigger
            triggerMode.onOff = true;
            triggerMode.mode = 0;
            triggerMode.parameter = 0;

            if (useSoftwareTrigger)
            {
                // A source of 7 means software trigger
                triggerMode.source = 7;
            }
            else
            {
                // Triggering the camera externally using source 0.
                triggerMode.source = 0;
            }

            // Set the trigger mode
            cam.SetTriggerMode(triggerMode);

            // Poll to ensure camera is ready
            bool retVal = PollForTriggerReady(cam);
            if (retVal != true)
            {
                return;
            }
        }

        #region public methods (interface) implementation

        public override void Open()
        {
            ManagedBusManager busMgr = new ManagedBusManager();
            CameraInfo[] camInfos = ManagedBusManager.DiscoverGigECameras();
            FireEvent_Log("Number of cameras discovered: " + camInfos.Length);
            foreach (CameraInfo camInfo in camInfos)
            {
                PrintCameraInfo(camInfo);
            }

            uint numberOfCameras = busMgr.GetNumOfCameras();
            FireEvent_Log("Number of cameras enumerated: " + numberOfCameras);

            cameras = new ManagedGigECamera[numberOfCameras];
            bufferOfImagesRetrived = new ManagedImage[numberOfCameras];
            bufferOfImagesProcessed = new ManagedImage[numberOfCameras];

            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i] = new ManagedGigECamera();
                bufferOfImagesRetrived[i] = new ManagedImage();
                bufferOfImagesProcessed[i] = new ManagedImage();
                ManagedPGRGuid guid = busMgr.GetCameraFromIndex((uint)i);
                cameras[i].Connect(guid);
            }

            foreach (var cam in cameras)
            {
                // Get the camera information
                CameraInfo currentCamInfo = cam.GetCameraInfo();
                PrintCameraInfoDetailed(currentCamInfo);

                uint numStreamChannels = cam.GetNumStreamChannels();
                for (uint i = 0; i < numStreamChannels; i++)
                {
                    PrintStreamChannelInfo(cam.GetGigEStreamChannelInfo(i));
                }

                ConfigureSoftwareTrigger(cam);

                GigEImageSettingsInfo imageSettingsInfo = cam.GetGigEImageSettingsInfo();
                GigEImageSettings imageSettings = new GigEImageSettings();
                imageSettings.offsetX = 0;
                imageSettings.offsetY = 0;
                imageSettings.height = imageSettingsInfo.maxHeight;
                imageSettings.width = imageSettingsInfo.maxWidth;
                imageSettings.pixelFormat = PixelFormat.PixelFormatMono8;
                cam.SetGigEImageSettings(imageSettings);


                // Get embedded image info from camera
                EmbeddedImageInfo embeddedInfo = cam.GetEmbeddedImageInfo();
                // Enable timestamp collection	
                if (embeddedInfo.timestamp.available == true)
                {
                    embeddedInfo.timestamp.onOff = true;
                }
                // Set embedded image info to camera
                cam.SetEmbeddedImageInfo(embeddedInfo);


                // Get the camera configuration
                FC2Config config = cam.GetConfiguration();
                // Set the grab timeout to 5 seconds
                config.grabTimeout = 5000;
                // Set the camera configuration
                cam.SetConfiguration(config);


                // Start capturing images
                //cam.StartCapture(OnImageGrabbed);
                cam.StartCapture();
            }

            //GrabImages();
        }

        public override void Capture(int _imageNumber, bool _enableImageSave, bool _enableImageShow)
        {
            bool retVal;

            // Check that the trigger is ready
            retVal = PollForTriggerReady(cameras);

            // Fire software trigger
            retVal = FireSoftwareTrigger(cameras);
            if (retVal != true)
            {
                FireEvent_Log("Error firing software trigger!\r\n");
                return;
            }

            for (int i = 0; i < cameras.Length; i++)
            {
                // Grab image
                cameras[i].RetrieveBuffer(bufferOfImagesRetrived[i]);
            }

            for (int i = 0; i < cameras.Length; i++)
            {
                if (_enableImageSave)
                {
                    // Create a unique filename
                    StringBuilder sbFilename = new StringBuilder();
                    sbFilename.Append("img_").Append(cameras[i].GetCameraInfo().serialNumber).Append("_").Append(_imageNumber.ToString("D4")).Append(".bmp");

                    bufferOfImagesRetrived[i].Save(sbFilename.ToString(), ImageFileFormat.Bmp);
                }
            }
        }

        public override void Close()
        {
            FireEvent_Log("Stopping the camera\r\n");

            foreach (var cam in cameras)
            {
                // Stop capturing images
                cam.StopCapture();

                // Turn off trigger mode
                triggerMode.onOff = false;
                cam.SetTriggerMode(triggerMode);

                // Disconnect the camera
                cam.Disconnect();
            }
        }

        #endregion

    }
}
