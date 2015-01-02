using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// pylon
using PylonC.NET;

namespace wifibot_cameras
{
    class Cameras
    {
        public enum CameraNumber { TopRight = 0, TopLeft = 1, Center = 2, BottomRight = 3, BottomLeft = 4, Additional1 = 5, Additional2 = 6, Additional3 = 7, RobotRight = 8, RobotLeft = 9 };

        private int[] CamerasSerialNumbers = { 21162137, 21238114, 21238112, 21238113, 21238115, 21130748, 21125996, 21130749, 21130750, 21130751 };

        private volatile bool shouldStop = false;
        public void RequestStop()
        {
            shouldStop = true;
        }

        private volatile bool shouldGrab = false;
        public void RequestGrab()
        {
            shouldGrab = true;
        } 

        public bool flagEnableImageSave = false;
        public bool flagEnableTimeMeasurements = false;

        public string Filename { get; set; }
        private int imageCounter;

        public enum TriggerType { Software = 0, EndFrame = 1};
        private TriggerType triggerType = TriggerType.Software;

        private List<int> listOfIndexesOfCamerasToUse;
        
        // variables from pylon example
        private const uint NUM_BUFFERS = 20;                                            /* Number of buffers used for grabbing. */
        private const uint GIGE_PACKET_SIZE = 8192;//1500;//8192;                             /* Size of one Ethernet packet. */
        private const uint GIGE_PROTOCOL_OVERHEAD = 36;                                 /* Total number of bytes of protocol overhead. */

        private uint NUM_DEVICES = 1;                                                   /* Number of devices (cameras) to use. */
        private PYLON_DEVICE_HANDLE[] hDev;                                             /* Handles for the pylon devices. */
        private PYLON_STREAMGRABBER_HANDLE[] hGrabber;                                  /* Handle for the pylon stream grabber. */
        private Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[] buffers;     /* Holds handles and buffers used for grabbing. */
        private PYLON_WAITOBJECTS_HANDLE wos;                                           /* Wait objects. */
        private PylonGrabResult_t[] grabResult;                                         /* Stores the result of a grab operation. */

        List<long> listOfDurationOfWholeProcess = new List<long>();
        public List<long> getListOfDurationOfWholeProcess()
        {
            return listOfDurationOfWholeProcess;
        }

        List<long> listOfDurationOfSetTrigger = new List<long>();

        List<long> listOfDurationOfWaitForAllCameras = new List<long>();
        public List<long> getListOfDurationOfWaitForAllCameras()
        {
            return listOfDurationOfWaitForAllCameras;
        }

        List<long> listOfDurationOfSaveToFile = new List<long>();
        public List<long> getListOfDurationOfSaveToFile()
        {
            return listOfDurationOfSaveToFile;
        }

        public static void SetDebug()
        {
            #if DEBUG
                /* This is a special debug setting needed only for GigE cameras. See 'Building Applications with pylon' in the Programmer's Guide. */
                Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "300000" /*ms*/);
            #endif
        }

        public Cameras()
        {
            Pylon.Initialize();

            listOfIndexesOfCamerasToUse = new List<int>();

            Filename = "img";
            imageCounter = 0;

            shouldStop = false;
            shouldGrab = false;

            flagEnableImageSave = false;
        }

        private void Initialize()
        {
            hDev = new PYLON_DEVICE_HANDLE[NUM_DEVICES];
            hGrabber = new PYLON_STREAMGRABBER_HANDLE[NUM_DEVICES];
            buffers = new Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[NUM_DEVICES];
            grabResult = new PylonGrabResult_t[NUM_DEVICES];        
        }

        public string Enumerate(List<CameraNumber> listOfCamerasToUse)
        {
            NUM_DEVICES = (uint)listOfCamerasToUse.Count;

            Initialize();

            uint numDevicesAvail;         /* Number of the available devices. */
            /* Enumerate all camera devices. You must callCPylonEnumerateDevices() before creating a device. */
            numDevicesAvail = Pylon.EnumerateDevices();

            if (numDevicesAvail < NUM_DEVICES)
            {
                //Console.Error.WriteLine("Found {0} devices. At least {1} devices needed to run this sample.", numDevicesAvail, NUM_DEVICES);
                throw new Exception("Not enough devices found.");
            }

            PYLON_DEVICE_INFO_HANDLE deviceInfo = new PYLON_DEVICE_INFO_HANDLE();

            for (int i = 0; i < listOfCamerasToUse.Count; ++i)
            {
                int serialNumberOfCurrentlySearchedCamera = CamerasSerialNumbers[(int)listOfCamerasToUse[i]]; 

                bool flagContniueCameraSearch = true;
                int j = 0;
                while (flagContniueCameraSearch && j < CamerasSerialNumbers.Length)
                {
                    deviceInfo = Pylon.GetDeviceInfoHandle((uint)j);

                    int serialNumberOfCurrentlyAnalysedCamera = Convert.ToInt32(Pylon.DeviceInfoGetPropertyValueByName(deviceInfo, "SerialNumber"));

                    if (serialNumberOfCurrentlyAnalysedCamera == serialNumberOfCurrentlySearchedCamera)
                    {
                        flagContniueCameraSearch = false;
                        listOfIndexesOfCamerasToUse.Add(j);
                    }
                    else
                    {
                        j++;
                    }
                }

                if (true == flagContniueCameraSearch)
                {
                    // error, the camera was not found!
                    throw new Exception("Searched camera was not found.");
                }
            }

            /*
            PYLON_DEVICE_INFO_HANDLE deviceInfo = new PYLON_DEVICE_INFO_HANDLE();
            deviceInfo = Pylon.GetDeviceInfoHandle(0);
            uint numberOfInfo = Pylon.DeviceInfoGetNumProperties(deviceInfo);
            StringBuilder sb = new StringBuilder();
            for (uint j = 0; j < numberOfInfo; j++)
            {
                sb.Append(Pylon.DeviceInfoGetPropertyName(deviceInfo, j) + " x ");
            }
            string properties = sb.ToString();

            StringBuilder result = new StringBuilder();
            result.Append("Found camera, mac address: ").Append(Pylon.DeviceInfoGetPropertyValueByName(deviceInfo, "MacAddress")).Append(", ");
            result.Append("full name: ").Append(Pylon.DeviceInfoGetPropertyValueByName(deviceInfo, "FullName")).Append(", ");
            result.Append("serial number: ").Append(Pylon.DeviceInfoGetPropertyValueByName(deviceInfo, "SerialNumber")).Append("\r\n");
             * */

            return "camera(s) found\r\n";
        }

        public void Open(TriggerType _triggerType)
        {
            triggerType = _triggerType;

            for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
            {
                hDev[deviceIndex] = new PYLON_DEVICE_HANDLE();
            }

            /* Create wait objects. This must be done outside of the loop. */
            wos = Pylon.WaitObjectsCreate();

            /* Open cameras and set parameters. */
            for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
            {
                /* Get handles for the devices. */
                hDev[deviceIndex] = Pylon.CreateDeviceByIndex((uint)listOfIndexesOfCamerasToUse[deviceIndex]);

                /* Before using the device, it must be opened. Open it for configuring parameters and for grabbing images. */
                Pylon.DeviceOpen(hDev[deviceIndex], Pylon.cPylonAccessModeControl | Pylon.cPylonAccessModeStream);

                /* Print out the name of the camera we are using. */
                {
                    bool isReadable = Pylon.DeviceFeatureIsReadable(hDev[deviceIndex], "DeviceModelName");
                    if (isReadable)
                    {
                        string name = Pylon.DeviceFeatureToString(hDev[deviceIndex], "DeviceModelName");
                        Console.WriteLine("Using camera '{0}'", name);
                    }
                }

                /* Set the pixel format to Mono8, where gray values will be output as 8 bit values for each pixel. */
                /* ... Check first to see if the device supports the Mono8 format. */
                bool isAvail;                 /* Used for checking feature availability. */
                isAvail = Pylon.DeviceFeatureIsAvailable(hDev[deviceIndex], "EnumEntry_PixelFormat_Mono8");
                if (!isAvail)
                {
                    /* Feature is not available. */
                    throw new Exception("Device doesn't support the Mono8 pixel format.");
                }

                /* ... Set the pixel format to Mono8. */
                Pylon.DeviceFeatureFromString(hDev[deviceIndex], "PixelFormat", "Mono8");

                // added by Amin:
                Pylon.DeviceFeatureFromString(hDev[deviceIndex], "GainAuto", "Continuous");

                // wybrać jedno z dwóch
                // 1)
                Pylon.DeviceFeatureFromString(hDev[deviceIndex], "ExposureAuto", "Continuous");
                // 2)
                //Pylon.DeviceFeatureFromString(hDev[deviceIndex], "ExposureAuto", "Off");
                //Pylon.DeviceFeatureFromString(hDev[deviceIndex], "ExposureTimeAbs", "3000");
                //string value = Pylon.DeviceFeatureToString(hDev[deviceIndex], "ExposureTimeAbs");

                // wybrać jedną z dwóch opcji (tylko jeśli w poprzednich punktach były wybrane automatyczne parametry):
                // 1) krótszy czas akwizycji, większa ziarnistość obrazu
                Pylon.DeviceFeatureFromString(hDev[deviceIndex], "AutoFunctionProfile", "ExposureMinimum");
                // 2) dłuższy czas akwizycji, mniejsza ziarnostość obrazu
                //Pylon.DeviceFeatureFromString(hDev[deviceIndex], "AutoFunctionProfile", "GainMinimum");
                //string nameAutoFunctionProfile = Pylon.DeviceFeatureToString(hDev[deviceIndex], "AutoFunctionProfile");

                bool isAvailFrameStart;                /* Used for checking feature availability */
                bool isAvailAcquisitionStart;          /* Used for checking feature availability */
                string triggerSelectorValue = "FrameStart"; /* Preselect the trigger for image acquisition */

                if (triggerType == TriggerType.Software)
                {
                    /* Check the available camera trigger mode(s) to select the appropriate one: acquisition start trigger mode (used by previous cameras;
                    do not confuse with acquisition start command) or frame start trigger mode (equivalent to previous acquisition start trigger mode). */
                    isAvailAcquisitionStart = Pylon.DeviceFeatureIsAvailable(hDev[deviceIndex], "EnumEntry_TriggerSelector_AcquisitionStart");
                    isAvailFrameStart = Pylon.DeviceFeatureIsAvailable(hDev[deviceIndex], "EnumEntry_TriggerSelector_FrameStart");

                    /* Check to see if the camera implements the acquisition start trigger mode only. */
                    if (isAvailAcquisitionStart && !isAvailFrameStart)
                    {
                        /* Camera uses the acquisition start trigger as the only trigger mode. */
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", "AcquisitionStart");
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerMode", "On");
                        triggerSelectorValue = "AcquisitionStart";
                    }
                    else
                    {
                        /* Camera may have the acquisition start trigger mode and the frame start trigger mode implemented.
                        In this case, the acquisition trigger mode must be switched off. */
                        if (isAvailAcquisitionStart)
                        {
                            Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", "AcquisitionStart");
                            Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerMode", "Off");
                        }
                        /* To trigger each single frame by software or external hardware trigger: Enable the frame start trigger mode. */
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", "FrameStart");
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerMode", "On");
                    }

                    /* Note: the trigger selector must be set to the appropriate trigger mode 
                    before setting the trigger source or issuing software triggers.
                    Frame start trigger mode for newer cameras, acquisition start trigger mode for previous cameras. */
                    Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", triggerSelectorValue);

                    /* Enable software triggering. */
                    /* ... Select the software trigger as the trigger source. */
                    Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSource", "Software");
                }
                else
                {
                    /* Disable acquisition start trigger if available */
                    isAvail = Pylon.DeviceFeatureIsAvailable(hDev[deviceIndex], "EnumEntry_TriggerSelector_AcquisitionStart");
                    if (isAvail)
                    {
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", "AcquisitionStart");
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerMode", "Off");
                    }

                    /* Disable frame start trigger if available */
                    isAvail = Pylon.DeviceFeatureIsAvailable(hDev[deviceIndex], "EnumEntry_TriggerSelector_FrameStart");
                    if (isAvail)
                    {
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerSelector", "FrameStart");
                        Pylon.DeviceFeatureFromString(hDev[deviceIndex], "TriggerMode", "Off");
                    }
                }

                // IMPORTANT!!!
                // https://www.rhpstore.com/documents/products/413/Ace_Series_Users_Manual.pdf
                // rodział 6


                /* When using software triggering, the Continuous frame mode should be used. Once 
                   acquisition is started, the camera sends one image each time a software trigger is 
                   issued. */
                Pylon.DeviceFeatureFromString(hDev[deviceIndex], "AcquisitionMode", "Continuous");
                // tryb single frame powoduje akwizycję jednej klatki (po odpowiednim triggerze, a następnie wywołanie funkcji acquisition stop
                //Pylon.DeviceFeatureFromString(hDev[deviceIndex], "AcquisitionMode", "SingleFrame");

                PYLON_DEVICE_INFO_HANDLE hDi = Pylon.GetDeviceInfoHandle((uint)deviceIndex);
                string deviceClass = Pylon.DeviceInfoGetPropertyValueByName(hDi, Pylon.cPylonDeviceInfoDeviceClassKey);
                if (deviceClass == "BaslerGigE")
                {
                    /* For GigE cameras, we recommend increasing the packet size for better performance. When the network adapter supports jumbo frames, set the packet 
                       size to a value > 1500, e.g., to 8192. In this sample, we only set the packet size to 1500.
            
                       We also set the Inter-Packet and the Frame Transmission delay so the switch can line up packets better.
                    */

                    Pylon.DeviceSetIntegerFeature(hDev[deviceIndex], "GevSCPSPacketSize", GIGE_PACKET_SIZE);
                    Pylon.DeviceSetIntegerFeature(hDev[deviceIndex], "GevSCPD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * (NUM_DEVICES - 1));
                    Pylon.DeviceSetIntegerFeature(hDev[deviceIndex], "GevSCFTD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * deviceIndex);
                }
            }

            uint[] payloadSize = new uint[NUM_DEVICES];                    /* Size of an image frame in bytes. */
            uint[] nStreams = new uint[NUM_DEVICES];                       /* The number of streams provided by the device. */

            
            PYLON_WAITOBJECT_HANDLE[] hWait = new PYLON_WAITOBJECT_HANDLE[NUM_DEVICES];       /* Handle used for waiting for a grab to be finished. */

            /* Allocate and register buffers for grab. */
            for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
            {
                /* Determine the required size for the grab buffer. */
                payloadSize[deviceIndex] = checked((uint)Pylon.DeviceGetIntegerFeature(hDev[deviceIndex], "PayloadSize"));

                /* Image grabbing is done using a stream grabber.  
                  A device may be able to provide different streams. A separate stream grabber must 
                  be used for each stream. In this sample, we create a stream grabber for the default 
                  stream, i.e., the first stream ( index == 0 ).
                  */

                /* Get the number of streams supported by the device and the transport layer. */
                nStreams[deviceIndex] = Pylon.DeviceGetNumStreamGrabberChannels(hDev[deviceIndex]);

                if (nStreams[deviceIndex] < 1)
                {
                    throw new Exception("The transport layer doesn't support image streams.");
                }

                /* Create and open a stream grabber for the first channel. */
                hGrabber[deviceIndex] = Pylon.DeviceGetStreamGrabber(hDev[deviceIndex], 0);

                Pylon.StreamGrabberOpen(hGrabber[deviceIndex]);


                /* Get a handle for the stream grabber's wait object. The wait object
                   allows waiting for buffers to be filled with grabbed data. */
                hWait[deviceIndex] = Pylon.StreamGrabberGetWaitObject(hGrabber[deviceIndex]);

                /* Add the stream grabber's wait object to our wait objects.
                   This is needed to be able to wait until all cameras have 
                   grabbed an image in our grab loop below. */
                Pylon.WaitObjectsAdd(wos, hWait[deviceIndex]);

                /* We must tell the stream grabber the number and size of the buffers 
                    we are using. */
                /* .. We will not use more than NUM_BUFFERS for grabbing. */
                Pylon.StreamGrabberSetMaxNumBuffer(hGrabber[deviceIndex], NUM_BUFFERS);

                /* .. We will not use buffers bigger than payloadSize bytes. */
                Pylon.StreamGrabberSetMaxBufferSize(hGrabber[deviceIndex], payloadSize[deviceIndex]);

                /*  Allocate the resources required for grabbing. After this, critical parameters 
                    that impact the payload size must not be changed until FinishGrab() is called. */
                Pylon.StreamGrabberPrepareGrab(hGrabber[deviceIndex]);

                /* Before using the buffers for grabbing, they must be registered at
                   the stream grabber. For each registered buffer, a buffer handle
                   is returned. After registering, these handles are used instead of the
                   buffer objects pointers. The buffer objects are held in a dictionary,
                   that provides access to the buffer using a handle as key.
                 */
                buffers[deviceIndex] = new Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>();
                for (int i = 0; i < NUM_BUFFERS; ++i)
                {
                    PylonBuffer<Byte> buffer = new PylonBuffer<byte>(payloadSize[deviceIndex], true);
                    PYLON_STREAMBUFFER_HANDLE handle = Pylon.StreamGrabberRegisterBuffer(hGrabber[deviceIndex], ref buffer);
                    buffers[deviceIndex].Add(handle, buffer);
                }

                /* Feed the buffers into the stream grabber's input queue. For each buffer, the API 
                   allows passing in an integer as additional context information. This integer
                   will be returned unchanged when the grab is finished. In our example, we use the index of the 
                   buffer as context information. */
                int j = 0;
                foreach (KeyValuePair<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> pair in buffers[deviceIndex])
                {
                    Pylon.StreamGrabberQueueBuffer(hGrabber[deviceIndex], pair.Key, j++);
                }

                /* Let the camera acquire images. */
                Pylon.DeviceExecuteCommandFeature(hDev[deviceIndex], "AcquisitionStart");
            }
        }

        public void Run()
        {
            Acquire();

            Close();
        }

        private void GrabAndShow()
        {
            int bufferIndex;  /* Index of the buffer. */
            uint woIndex;

            long duartionOfWaitingForAllCamerasStart = sw.ElapsedMilliseconds;

            /* Wait for the next buffer to be filled. Wait up to 1000 ms. */
            //bool isReady = Pylon.WaitObjectsWaitForAny(wos, 1000, out woIndex);
            bool isReady = Pylon.WaitObjectsWaitForAll(wos, 500);

            if (flagEnableTimeMeasurements)
            {
                listOfDurationOfWaitForAllCameras.Add(sw.ElapsedMilliseconds - duartionOfWaitingForAllCamerasStart);    
            }
            
            if (!isReady)
            {
                /* Timeout occurred. */
                throw new Exception("Grab timeout occurred.");
            }
            else
            {
                long durationOfSavingToFile = 0;

                for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    woIndex = (uint)deviceIndex;
                    /* Since the wait operation was successful, the result of at least one grab 
                       operation is available. Retrieve it. */
                    isReady = Pylon.StreamGrabberRetrieveResult(hGrabber[woIndex], out grabResult[woIndex]);

                    if (triggerType == TriggerType.Software)
                    {
                        //Pylon.DeviceExecuteCommandFeature(hDev[woIndex], "TriggerSoftware");
                    }

                    if (!isReady)
                    {
                        /* Oops. No grab result available? We should never have reached this point. 
                           Since the wait operation above returned without a timeout, a grab result 
                           should be available. */
                        throw new Exception("Failed to retrieve a grab result.");
                    }

                    /* Get the buffer index from the context information. */
                    bufferIndex = grabResult[woIndex].Context;

                    /* Check to see if the image was grabbed successfully. */
                    if (grabResult[woIndex].Status == EPylonGrabStatus.Grabbed)
                    {
                        /*  Success. Perform image processing. Since we passed more than one buffer
                        to the stream grabber, the remaining buffers are filled in the background while
                        we do the image processing. The processed buffer won't be touched by
                        the stream grabber until we pass it back to the stream grabber. */

                        PylonBuffer<Byte> buffer;        /* Reference to the buffer attached to the grab result. */

                        /* Get the buffer from the dictionary. Since we also got the buffer index, 
                           we could alternatively use an array, e.g. buffers[bufferIndex]. */
                        if (!buffers[woIndex].TryGetValue(grabResult[woIndex].hBuffer, out buffer))
                        {
                            /* Oops. No buffer available? We should never have reached this point. Since all buffers are
                               in the dictionary. */
                            throw new Exception("Failed to find the buffer associated with the handle returned in grab result.");
                        }

                        /* Perform processing. */
                        long saveToFileStart = sw.ElapsedMilliseconds;
                        if (flagEnableImageSave)
                        {
                            Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Bmp, Filename + "_" + imageCounter.ToString() + "_" + woIndex.ToString() + ".bmp", buffer, EPylonPixelType.PixelType_Mono8, Convert.ToUInt32(grabResult[woIndex].SizeX), Convert.ToUInt32(grabResult[woIndex].SizeY), 0, EPylonImageOrientation.ImageOrientation_TopDown);
                        }

                        if (flagEnableTimeMeasurements)
                        {
                            durationOfSavingToFile += (sw.ElapsedMilliseconds - saveToFileStart);    
                        }
                        

                        /* Display image */
                        //if (woIndex == 0)
                        {
                            Pylon.ImageWindowDisplayImage<Byte>(woIndex, buffer, grabResult[woIndex]);
                        }
                    }
                    else if (grabResult[woIndex].Status == EPylonGrabStatus.Failed)
                    {
                        Console.Error.WriteLine("Frame {0} wasn't grabbed successfully.  Error code = {1}", 1, grabResult[woIndex].ErrorCode);
                    }

                    /* Once finished with the processing, requeue the buffer to be filled again. */
                    Pylon.StreamGrabberQueueBuffer(hGrabber[woIndex], grabResult[woIndex].hBuffer, bufferIndex);
                }

                if (flagEnableTimeMeasurements)
                {
                    listOfDurationOfSaveToFile.Add(durationOfSavingToFile);
                }

                if (flagEnableImageSave)
                {
                    imageCounter++;
                }
            }
        }

        System.Diagnostics.Stopwatch sw= new System.Diagnostics.Stopwatch();

        public void Acquire()
        {
            try
            {
                for (;;)
                {
                    /* If end of operation was requested, exit the grab loop. */
                    if (shouldStop)
                    {
                        shouldStop = false;
                        break;  /* End of operation requested. */
                    }

                    if (triggerType == TriggerType.Software)
                    {
                        if (shouldGrab)
                        {
                            for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                            {
                                Pylon.DeviceExecuteCommandFeature(hDev[deviceIndex], "TriggerSoftware");
                            }

                            shouldGrab = false;

                            // number of iterations to do
                            int iterationsToDo = 1; // 25;
                            for (int i = 0; i < iterationsToDo; i++)
                            {
                                sw.Restart();

                                GrabAndShow();

                                sw.Stop();
                                if (flagEnableTimeMeasurements)
                                {
                                    listOfDurationOfWholeProcess.Add(sw.ElapsedMilliseconds);
                                }
                            }
                        }
                    }
                    else
                    {
                        sw.Restart();

                        GrabAndShow();

                        sw.Stop();
                        if (flagEnableTimeMeasurements)
                        {
                            listOfDurationOfWholeProcess.Add(sw.ElapsedMilliseconds);
                        }
                    }
   
                }
            }
            catch (Exception e)
            {
                /* Retrieve the error message. */
                string msg = GenApi.GetLastErrorMessage() + "\n" + GenApi.GetLastErrorDetail();
                Console.Error.WriteLine("Exception caught:");
                Console.Error.WriteLine(e.Message);
                if (msg != "\n")
                {
                    Console.Error.WriteLine("Last error message:");
                    Console.Error.WriteLine(msg);
                }

                for (uint deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    try
                    {
                        if (hDev[deviceIndex].IsValid)
                        {
                            /* ... Close and release the pylon device. */
                            if (Pylon.DeviceIsOpen(hDev[deviceIndex]))
                            {
                                Pylon.DeviceClose(hDev[deviceIndex]);
                            }
                            Pylon.DestroyDevice(hDev[deviceIndex]);
                        }
                    }
                    catch (Exception)
                    {
                        /*No further handling here.*/
                    }
                }
            }
        }

        public void Close()
        {
            try
            {
                /* Clean up. */
                /* Stop the image aquisition on the cameras. */
                for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    /*  ... Stop the camera. */
                    Pylon.DeviceExecuteCommandFeature(hDev[deviceIndex], "AcquisitionStop");
                }

                // Remove all wait objects from WaitObjects.
                Pylon.WaitObjectsRemoveAll(wos);
                Pylon.WaitObjectsDestroy(wos);

                PylonGrabResult_t[] grabResult = new PylonGrabResult_t[NUM_DEVICES];        /* Stores the result of a grab operation. */
                for (int deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    /* ... We must issue a cancel call to ensure that all pending buffers are put into the
                       stream grabber's output queue. */
                    Pylon.StreamGrabberCancelGrab(hGrabber[deviceIndex]);

                    /* ... The buffers can now be retrieved from the stream grabber. */
                    bool isReady;
                    do
                    {
                        isReady = Pylon.StreamGrabberRetrieveResult(hGrabber[deviceIndex], out grabResult[deviceIndex]);

                    } while (isReady);

                    /* ... When all buffers are retrieved from the stream grabber, they can be deregistered. After deregistering the buffers, it is safe to free the memory. */

                    foreach (KeyValuePair<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> pair in buffers[deviceIndex])
                    {
                        Pylon.StreamGrabberDeregisterBuffer(hGrabber[deviceIndex], pair.Key);
                        pair.Value.Dispose();
                    }
                    buffers[deviceIndex] = null;

                    /* ... Release grabbing related resources. */
                    Pylon.StreamGrabberFinishGrab(hGrabber[deviceIndex]);

                    /* After calling PylonStreamGrabberFinishGrab(), parameters that impact the payload size (e.g., 
                    the AOI width and height parameters) are unlocked and can be modified again. */

                    /* ... Close the stream grabber. */
                    Pylon.StreamGrabberClose(hGrabber[deviceIndex]);

                    /* ... Close and release the pylon device. The stream grabber becomes invalid
                       after closing the pylon device. Don't call stream grabber related methods after 
                       closing or releasing the device. */
                    Pylon.DeviceClose(hDev[deviceIndex]);
                    Pylon.DestroyDevice(hDev[deviceIndex]);
                }
            }
            catch (Exception e)
            {
                /* Retrieve the error message. */
                string msg = GenApi.GetLastErrorMessage() + "\n" + GenApi.GetLastErrorDetail();
                Console.Error.WriteLine("Exception caught:");
                Console.Error.WriteLine(e.Message);
                if (msg != "\n")
                {
                    Console.Error.WriteLine("Last error message:");
                    Console.Error.WriteLine(msg);
                }

                for (uint deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    try
                    {
                        if (hDev[deviceIndex].IsValid)
                        {
                            /* ... Close and release the pylon device. */
                            if (Pylon.DeviceIsOpen(hDev[deviceIndex]))
                            {
                                Pylon.DeviceClose(hDev[deviceIndex]);
                            }
                            Pylon.DestroyDevice(hDev[deviceIndex]);
                        }
                    }
                    catch (Exception)
                    {
                        /*No further handling here.*/
                    }
                }
            }

            /* ... Shut down the pylon runtime system. Don't call any pylon function after calling PylonTerminate(). */
            Pylon.Terminate();
        }
    }
}
