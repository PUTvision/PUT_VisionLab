using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PylonC.NET;

using PUTVision_CameraBasler;


namespace PUTVision_BaslerCenter
{
    public class BaslerCenter 
    {
        public CameraBasler[] cameras;
        protected uint NUM_DEVICES = 0;        /* Handles for the pylon devices. */
        protected bool permissionToWork = true;
        protected bool working = false;
        public Thread live;

        private BaslerCenter[] center;

        #region Constructors
        public BaslerCenter(uint NUM_DEV)
        {
            this.cameras = new CameraBasler[NUM_DEV];        /* Handles for the pylon devices. */
            /*for (int deviceIndex = 0; deviceIndex < NUM_DEV; ++deviceIndex)
            {
                this.cameras[deviceIndex]= new CameraBasler();
            }*/
        }



        public BaslerCenter(BaslerCenter[] center)
        {
            // TODO: Complete member initialization
            this.center = center;
        }
        #endregion

        // think what to do with specialized open function...
        // (uint packetSize, GainAuto gainAuto, ExposureAuto exposureAuto, int exposureTimeAbs, AutoFunctionProfile autoFunctionProfile, int startingFrameDelay)

        #region ICamer interface implementation
        // explicit interface implementation is not preffered (i.e. (=tj./tzn. in Polish) with Amin_ICamera.ICamera. prefix) 

        // dodać (do ogólnego):
        // int numberOfCameras

        #endregion

        public void Start()
        {

            if (true)//this.permissionToWork && !this.working)
            {

            int reservedeviceIndex = 0; /*if you can not open the camera, you will know which one*/

            try
            {
                this.working = true;
                uint NUM_BUFFERS = 12;        /* Number of buffers used for grabbing. */
                const uint GIGE_PACKET_SIZE = 1500; /* Size of one Ethernet packet. */
                const uint GIGE_PROTOCOL_OVERHEAD = 36;/* Buffer used for grabbing. */
                    /* Number of the available devices. */
                    bool isAvail;                 /* Used for checking feature availability. */
                    bool isReady;                 /* Used as an output parameter. */
                    int i;                        /* Counter. */
                    int deviceIndex = 0;              /* Index of device used in the following variables. */
                    PYLON_WAITOBJECTS_HANDLE wos; /* Wait objects. */
                    PYLON_WAITOBJECT_HANDLE woTimer;/* Timer wait object. */

                    /* These are camera specific variables: */
                    PYLON_STREAMGRABBER_HANDLE[] hGrabber = new PYLON_STREAMGRABBER_HANDLE[NUM_DEVICES]; /* Handle for the pylon stream grabber. */
                    PYLON_WAITOBJECT_HANDLE[] hWait = new PYLON_WAITOBJECT_HANDLE[NUM_DEVICES];       /* Handle used for waiting for a grab to be finished. */
                    uint[] payloadSize = new uint[NUM_DEVICES];                    /* Size of an image frame in bytes. */
                    PylonGrabResult_t[] grabResult = new PylonGrabResult_t[NUM_DEVICES];        /* Stores the result of a grab operation. */
                    uint[] nStreams = new uint[NUM_DEVICES];                       /* The number of streams provided by the device. */
                    Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[] buffers = new Dictionary<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>>[NUM_DEVICES]; /* Holds handles and buffers used for grabbing. */

#if DEBUG
                    /* This is a special debug setting needed only for GigE cameras.
                See 'Building Applications with pylon' in the Programmer's Guide. */
                    Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "300000" /*ms*/);
#endif

                    /* Before using any pylon methods, the pylon runtime must be initialized. */
                    Pylon.Initialize();

                    /* Enumerate all camera devices. You must call 
                    PylonEnumerateDevices() before creating a device. */
                    uint numDevicesAvail = Pylon.EnumerateDevices();


                    if (numDevicesAvail < NUM_DEVICES)
                    {
                        Console.Error.WriteLine("Found {0} devices. At least {1} devices needed to run this sample.", numDevicesAvail, NUM_DEVICES);
                        throw new Exception("Not enough devices found.");
                    }

                    /* Create wait objects. This must be done outside of the loop. */
                    wos = Pylon.WaitObjectsCreate();

                    /* In this sample, we want to grab for a given amount of time, then stop.
                    Create a timer that tiggers an AutoResetEvent, wrap the AutoResetEvent in a pylon C.NET wait object, and add it to
                    the wait object set. */
                    AutoResetEvent timoutEvent = new AutoResetEvent(false); /* The timeout event to wait for. */
                    TimerCallbackWrapper timerCallbackWrapper = new TimerCallbackWrapper(timoutEvent); /* Receives the timer callback and sets the timeout event. */
                    System.Threading.Timer timer = new System.Threading.Timer(timerCallbackWrapper.TimerCallback); /* The timeout timer. */

                    woTimer = Pylon.WaitObjectFromW32(timoutEvent.SafeWaitHandle, true);

                    Pylon.WaitObjectsAdd(wos, woTimer);

                    /* Open camera and set parameters. */
                    for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                    {
                        reservedeviceIndex=deviceIndex;
                        //this.cameras[deviceIndex].hDev = Pylon.CreateDeviceByIndex((uint)deviceIndex);
                        /* Get handles for the devices. */
                        this.cameras[deviceIndex].AssingDevice();


                        /* Before using the device, it must be opened. Open it for configuring
                        parameters and for grabbing images. */
                        Pylon.DeviceOpen(this.cameras[deviceIndex].hDev, Pylon.cPylonAccessModeControl | Pylon.cPylonAccessModeStream);

                        /* Print out the name of the camera we are using. */
                        {
                            bool isReadable = Pylon.DeviceFeatureIsReadable(this.cameras[deviceIndex].hDev, "DeviceModelName");
                            if (isReadable)
                            {
                                string name = Pylon.DeviceFeatureToString(this.cameras[deviceIndex].hDev, "DeviceModelName");
                                Console.WriteLine("Using camera '{0}'", name);
                            }
                        }

                        //Pylon.DeviceSetBooleanFeature(this.cameras[deviceIndex].hDev, "ReverseX", this.reverseInAxisX);

                        Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "UserSetSelector", "UserSet1");
                        Pylon.DeviceExecuteCommandFeature(this.cameras[deviceIndex].hDev, "UserSetLoad");
                        //Pylon.DeviceSetIntegerFeature(this.cameras[deviceIndex].hDev, "Gain", 500);

                        if (this.cameras[deviceIndex].ReturnColor())
                        {
                            isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_PixelFormat_BayerBG8");
                            if (isAvail)
                            {
                                /* Feature is available. */
                                this.cameras[deviceIndex].SetPixelType(EPylonPixelType.PixelType_BayerGR8);
                                Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "PixelFormat", "BayerBG8");
                                
                            }
                            else
                            {
                                isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_PixelFormat_Mono8");
                                if (isAvail)
                                {
                                    try
                                    {
                                        /* ... Set the pixel format to Mono8. */
                                        this.cameras[deviceIndex].SetPixelType(EPylonPixelType.PixelType_Mono8);
                                        Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "PixelFormat", "Mono8");

                                    }
                                    catch { }
                                }
                                else
                                {
                                    /* Feature is not available. */
                                    throw new Exception("Device doesn't support the Mono8 pixel format.");
                                }
                            }

                        }
                        else
                        {   /* Set the pixel format to Mono8, where gray values will be output as 8 bit values for each pixel. */
                            /* ... Check first to see if the device supports the Mono8 format. */
                            isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_PixelFormat_Mono8");
                            if (isAvail)
                            {
                                try
                                {
                                    /* ... Set the pixel format to Mono8. */
                                    this.cameras[deviceIndex].SetPixelType(EPylonPixelType.PixelType_Mono8);
                                    Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "PixelFormat", "Mono8");
                                    
                                }
                                catch { }
                            }
                            else
                            {
                                /* Feature is not available. */
                                throw new Exception("Device doesn't support the Mono8 pixel format.");
                            }

                        }

                        /* Disable acquisition start trigger if available */
                        isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_TriggerSelector_AcquisitionStart");
                        if (isAvail)
                        {
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerSelector", "AcquisitionStart");
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerMode", "Off");
                        }

                        /* Disable frame burst start trigger if available */
                        isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_TriggerSelector_FrameBurstStart");
                        if (isAvail)
                        {
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerSelector", "FrameBurstStart");
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerMode", "Off");
                        }

                        /* Disable frame start trigger if available */
                        isAvail = Pylon.DeviceFeatureIsAvailable(this.cameras[deviceIndex].hDev, "EnumEntry_TriggerSelector_FrameStart");
                        if (isAvail)
                        {
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerSelector", "FrameStart");
                            Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "TriggerMode", "Off");
                        }

                        /* We will use the Continuous frame mode, i.e., the camera delivers
                        images continuously. */
                        Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "AcquisitionMode", "Continuous");

                        PYLON_DEVICE_INFO_HANDLE hDi = Pylon.GetDeviceInfoHandle((uint)deviceIndex);
                        string deviceClass = Pylon.DeviceInfoGetPropertyValueByName(hDi, Pylon.cPylonDeviceInfoDeviceClassKey);

                        if (deviceClass == "BaslerGigE")
                        {
                            /* For GigE cameras, we recommend increasing the packet size for better 
                               performance. When the network adapter supports jumbo frames, set the packet 
                               size to a value > 1500, e.g., to 8192. In this sample, we only set the packet size
                               to 1500.
            
                               We also set the Inter-Packet and the Frame Transmission delay
                               so the switch can line up packets better.
                            */

                            Pylon.DeviceSetIntegerFeature(this.cameras[deviceIndex].hDev, "GevSCPSPacketSize", GIGE_PACKET_SIZE);
                            Pylon.DeviceSetIntegerFeature(this.cameras[deviceIndex].hDev, "GevSCPD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * (NUM_DEVICES - 1));
                            Pylon.DeviceSetIntegerFeature(this.cameras[deviceIndex].hDev, "GevSCFTD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * deviceIndex);
                        }
                        else if (deviceClass == "Basler1394")
                        {
                            /* For FireWire we just set the PacketSize node to limit the bandwidth we're using. */

                            /* We first divide the available bandwidth (4915 for FW400, 9830 for FW800)
                               by the number of devices we are using. */
                            long newPacketSize = 4915 / NUM_DEVICES;
                            long recommendedPacketSize = 0;

                            /* Get the recommended packet size from the camera. */
                            recommendedPacketSize = Pylon.DeviceGetIntegerFeature(this.cameras[deviceIndex].hDev, "RecommendedPacketSize");

                            if (newPacketSize < recommendedPacketSize)
                            {
                                /* Get the increment value for the packet size.
                                   We must make sure that the new value we're setting is divisible by the increment of that feature. */
                                long packetSizeInc = 0;
                                packetSizeInc = Pylon.DeviceGetIntegerFeatureInc(this.cameras[deviceIndex].hDev, "PacketSize");

                                /* Adjust the new packet size so is divisible by its increment. */
                                newPacketSize -= newPacketSize % packetSizeInc;
                            }
                            else
                            {
                                /* The recommended packet size should always be valid. No need to check against the increment. */
                                newPacketSize = recommendedPacketSize;
                            }

                            /* Set the new packet size. */
                            Pylon.DeviceSetIntegerFeature(this.cameras[deviceIndex].hDev, "PacketSize", newPacketSize);
                            Console.WriteLine("Using packetsize: {0}", newPacketSize);
                        }

                    }
                    for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                    {
                        /* Allocate and register buffers for grab. */
                        /* Determine the required size for the grab buffer. */
                        payloadSize[deviceIndex] = checked((uint)Pylon.DeviceGetIntegerFeature(this.cameras[deviceIndex].hDev, "PayloadSize"));

                        /* Image grabbing is done using a stream grabber.  
                          A device may be able to provide different streams. A separate stream grabber must 
                          be used for each stream. In this sample, we create a stream grabber for the default 
                          stream, i.e., the first stream ( index == 0 ).
                          */

                        /* Get the number of streams supported by the device and the transport layer. */
                        nStreams[deviceIndex] = Pylon.DeviceGetNumStreamGrabberChannels(this.cameras[deviceIndex].hDev);

                        if (nStreams[deviceIndex] < 1)
                        {
                            throw new Exception("The transport layer doesn't support image streams.");
                        }

                        /* Create and open a stream grabber for the first channel. */
                        hGrabber[deviceIndex] = Pylon.DeviceGetStreamGrabber(this.cameras[deviceIndex].hDev, 0);

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
                        for (i = 0; i < NUM_BUFFERS; ++i)
                        {
                            PylonBuffer<Byte> buffer = new PylonBuffer<byte>(payloadSize[deviceIndex], true);
                            PYLON_STREAMBUFFER_HANDLE handle = Pylon.StreamGrabberRegisterBuffer(hGrabber[deviceIndex], ref buffer);
                            buffers[deviceIndex].Add(handle, buffer);
                        }

                        /* Feed the buffers into the stream grabber's input queue. For each buffer, the API 
                           allows passing in an integer as additional context information. This integer
                           will be returned unchanged when the grab is finished. In our example, we use the index of the 
                           buffer as context information. */
                        i = 0;
                        foreach (KeyValuePair<PYLON_STREAMBUFFER_HANDLE, PylonBuffer<Byte>> pair in buffers[deviceIndex])
                        {
                            Pylon.StreamGrabberQueueBuffer(hGrabber[deviceIndex], pair.Key, i++);
                        }


                    }
                    /* The stream grabber is now prepared. As soon the camera starts acquiring images,
                       the image data will be grabbed into the provided buffers.  */

                    /* Let the camera acquire images. */
                    //Pylon.DeviceFeatureFromString(this.cameras[deviceIndex].hDev, "UserSetSelector", "Default");

                    for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                    {
                        /* Let the camera acquire images. */
                        Pylon.DeviceExecuteCommandFeature(this.cameras[deviceIndex].hDev, "AcquisitionStart");
                    }

                    /* Set the timer to 5 s and start it. */
                    timer.Change(Timeout.Infinite, Timeout.Infinite);

                    /* Counts the number of grabbed images. */


                    /* Grab until the timer expires. */
                    for (; ; )
                    {

                        int bufferIndex;  /* Index of the buffer. */
                        uint woIndex;

                        /* Wait for the next buffer to be filled. Wait up to 1000 ms. */
                        isReady = Pylon.WaitObjectsWaitForAny(wos, 1000, out woIndex);

                        if (!isReady)
                        {
                            /* Timeout occurred. */
                            throw new Exception("Grab timeout occurred.");
                        }

                        /* If the timer has expired, exit the grab loop. */
                        if (woIndex == 0)
                        {
                            Console.Error.WriteLine("Game over.");
                            break;  /* Timer expired. */
                        }

                        /* Account for the timer. */
                        --woIndex;

                        /* Since the wait operation was successful, the result of at least one grab 
                           operation is available. Retrieve it. */
                        isReady = Pylon.StreamGrabberRetrieveResult(hGrabber[woIndex], out grabResult[woIndex]);

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
                            //basler[deviceIndex].sizeX= (uint)grabResult[woIndex].SizeX;

                            // basler[deviceIndex].sizeY = (uint)grabResult[woIndex].SizeY;

                            /* Display image */

                            Pylon.ImageWindowDisplayImage<Byte>(woIndex, buffer, grabResult[woIndex]);

                            if (this.cameras[deviceIndex].ReturnZoomToFit())
                            {
                                System.Windows.Forms.SendKeys.SendWait("^{MULTIPLY}");
                                this.cameras[deviceIndex].SetZoomToFit(false);
                            }

                            if (this.cameras[deviceIndex].ReturnFlagSave())
                            {
                                this.cameras[deviceIndex].SetImageToSave(buffer);
                                this.cameras[deviceIndex].SetFlagSave(false);
                                this.cameras[deviceIndex].SetFlagWriteToDisk(true);
                            }


                        }
                        else if (grabResult[woIndex].Status == EPylonGrabStatus.Failed)
                        {
                            this.cameras[deviceIndex].SetAlertNote("Camera wasn't grabbed successfully");

                        }

                        /* Once finished with the processing, requeue the buffer to be filled again. */
                        Pylon.StreamGrabberQueueBuffer(hGrabber[woIndex], grabResult[woIndex].hBuffer, bufferIndex);

                        //basler[deviceIndex].fps++;

                        if (!permissionToWork)
                        {
                            break;
                        }
                    }

                    /* Clean up. */
                    /* Stop the image aquisition on the cameras. */
                    for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                    {
                        /*  ... Stop the camera. */
                        Pylon.DeviceExecuteCommandFeature(this.cameras[deviceIndex].hDev, "AcquisitionStop");
                    }

                    // Remove all wait objects from WaitObjects.
                    Pylon.WaitObjectsRemoveAll(wos);
                    Pylon.WaitObjectDestroy(woTimer);
                    Pylon.WaitObjectsDestroy(wos);

                    for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                    {
                        /* ... We must issue a cancel call to ensure that all pending buffers are put into the
                           stream grabber's output queue. */
                        Pylon.StreamGrabberCancelGrab(hGrabber[deviceIndex]);

                        /* ... The buffers can now be retrieved from the stream grabber. */
                        do
                        {
                            isReady = Pylon.StreamGrabberRetrieveResult(hGrabber[deviceIndex], out grabResult[deviceIndex]);

                        } while (isReady);

                        /* ... When all buffers are retrieved from the stream grabber, they can be deregistered.
                               After deregistering the buffers, it is safe to free the memory. */

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
                        Pylon.DeviceClose(this.cameras[deviceIndex].hDev);
                        Pylon.DestroyDevice(this.cameras[deviceIndex].hDev);
                    }

                    /* Dispose timer and event. */
                    timer.Dispose();
                    timoutEvent.Close();


                    /* ... Shut down the pylon runtime system. Don't call any pylon function after 
                       calling PylonTerminate(). */
                    Pylon.Terminate();
                }
                catch (Exception e)
                {
                    this.cameras[reservedeviceIndex].SetAlertNote("Can not open the camera!");
                    this.working = false;
                    /* Retrieve the error message. */
                    string msg = GenApi.GetLastErrorMessage() + "\n" + GenApi.GetLastErrorDetail();
                    Console.Error.WriteLine("Exception caught:");
                    Console.Error.WriteLine(e.Message);

                    if (msg != "\n")
                    {
                        Console.Error.WriteLine("Last error message:");
                        Console.Error.WriteLine(msg);

                    }

                    for (uint deviceIndex = 0; deviceIndex < this.NUM_DEVICES; ++deviceIndex)
                    {
                        try
                        {
                            if (this.cameras[deviceIndex].hDev.IsValid)
                            {
                                /* ... Close and release the pylon device. */
                                if (Pylon.DeviceIsOpen(this.cameras[deviceIndex].hDev))
                                {
                                    Pylon.DeviceClose(this.cameras[deviceIndex].hDev);
                                }
                                Pylon.DestroyDevice(this.cameras[deviceIndex].hDev);
                            }
                        }
                        catch (Exception)
                        {
                            /*No further handling here.*/
                        }
                    }

                }
                Pylon.Terminate();
            }
            this.working = false;
        }


        public void Recording()
        {
            this.permissionToWork = true;
            this.live = new Thread(this.Start);
            this.live.Start();
        }


  

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

    private AutoResetEvent timeoutEvent;
}
