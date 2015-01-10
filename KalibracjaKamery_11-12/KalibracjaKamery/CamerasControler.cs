using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using PylonC.NETSupportLibrary;
using System.IO;
using PylonC.NET;
using System.Threading;



namespace KalibracjaKamery
{

    public partial class CamerasControler : Form
    {
        static PylonBuffer<byte> imgBuf = null;
        static uint sizeX = 0;
        static uint sizeY=0;
        static uint photoNR = 1;
        static bool recording = false;
        static int fps=0;
        string pathFolder = System.Environment.CurrentDirectory + "\\";
        Thread watek;
        uint indexForCameraOpenFunction = 0;
        bool alertBit = false;
        bool pulseBit = false;
        string note = "";

        bool flagSave = false;
        bool flagWriteToDisk = false;
        byte[] imageToSave;
        bool zoomToFit = true;
        bool savingTime = false;

        public CamerasControler()
        {

            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            zdjecieNumer.Text = photoNR.ToString();
            UpdateDeviceList();
            FileFormat.SelectedIndex = 0;
            ShowSavingPath.Text = pathFolder;
            NameOfFolder.Text = "";
            UserPath.Checked = true;

            System.Windows.Forms.ToolTip ToolTipUserPath = new System.Windows.Forms.ToolTip();
            ToolTipUserPath.SetToolTip(this.UserPath, "In this option\nyou can choose the folder,\nwhere files will be saving.");

            System.Windows.Forms.ToolTip ToolTipStandardPath = new System.Windows.Forms.ToolTip();
            ToolTipStandardPath.SetToolTip(this.StandardPath, "In this option\nfiles will be saving\nnear this aplication.\nYou can add the folder\nto organize it.");


        }
        void Nagrywanie()
        {
            if (recording == true)
            { 
                const uint NUM_DEVICES = 1;
                const uint NUM_BUFFERS = 2;        /* Number of buffers used for grabbing. */
                const uint GIGE_PACKET_SIZE = 1500; /* Size of one Ethernet packet. */
                const uint GIGE_PROTOCOL_OVERHEAD = 36;/* Buffer used for grabbing. */
                PYLON_DEVICE_HANDLE hDev = new PYLON_DEVICE_HANDLE();        /* Handles for the pylon devices. */

            try
            {
                uint numDevicesAvail;         /* Number of the available devices. */
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
                numDevicesAvail = Pylon.EnumerateDevices();

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
               
                /* Get handles for the devices. */
                hDev = Pylon.CreateDeviceByIndex(indexForCameraOpenFunction);

                /* Before using the device, it must be opened. Open it for configuring
                parameters and for grabbing images. */
                Pylon.DeviceOpen(hDev, Pylon.cPylonAccessModeControl | Pylon.cPylonAccessModeStream);

                /* Print out the name of the camera we are using. */
                {
                    bool isReadable = Pylon.DeviceFeatureIsReadable(hDev, "DeviceModelName");
                    if (isReadable)
                    {
                        string name = Pylon.DeviceFeatureToString(hDev, "DeviceModelName");
                        Console.WriteLine("Using camera '{0}'", name);
                    }
                }

                /* Set the pixel format to Mono8, where gray values will be output as 8 bit values for each pixel. */
                /* ... Check first to see if the device supports the Mono8 format. */
                isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_PixelFormat_Mono8");
                if (!isAvail)
                {
                    /* Feature is not available. */
                    throw new Exception("Device doesn't support the Mono8 pixel format.");
                }

                /* ... Set the pixel format to Mono8. */
                Pylon.DeviceFeatureFromString(hDev, "PixelFormat", "Mono8");


                /* Disable acquisition start trigger if available */
                isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_AcquisitionStart");
                if (isAvail)
                {
                    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "AcquisitionStart");
                    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                }

                /* Disable frame burst start trigger if available */
                isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_FrameBurstStart");
                if (isAvail)
                {
                    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "FrameBurstStart");
                    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                }

                /* Disable frame start trigger if available */
                isAvail = Pylon.DeviceFeatureIsAvailable(hDev, "EnumEntry_TriggerSelector_FrameStart");
                if (isAvail)
                {
                    Pylon.DeviceFeatureFromString(hDev, "TriggerSelector", "FrameStart");
                    Pylon.DeviceFeatureFromString(hDev, "TriggerMode", "Off");
                }

                /* We will use the Continuous frame mode, i.e., the camera delivers
                images continuously. */
                Pylon.DeviceFeatureFromString(hDev, "AcquisitionMode", "Continuous");

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

                    Pylon.DeviceSetIntegerFeature(hDev, "GevSCPSPacketSize", GIGE_PACKET_SIZE);
                    Pylon.DeviceSetIntegerFeature(hDev, "GevSCPD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * (NUM_DEVICES - 1));
                    Pylon.DeviceSetIntegerFeature(hDev, "GevSCFTD", (GIGE_PACKET_SIZE + GIGE_PROTOCOL_OVERHEAD) * deviceIndex);
                }
                else if (deviceClass == "Basler1394")
                {
                    /* For FireWire we just set the PacketSize node to limit the bandwidth we're using. */

                    /* We first divide the available bandwidth (4915 for FW400, 9830 for FW800)
                       by the number of devices we are using. */
                    long newPacketSize = 4915 / NUM_DEVICES;
                    long recommendedPacketSize = 0;

                    /* Get the recommended packet size from the camera. */
                    recommendedPacketSize = Pylon.DeviceGetIntegerFeature(hDev, "RecommendedPacketSize");

                    if (newPacketSize < recommendedPacketSize)
                    {
                        /* Get the increment value for the packet size.
                           We must make sure that the new value we're setting is divisible by the increment of that feature. */
                        long packetSizeInc = 0;
                        packetSizeInc = Pylon.DeviceGetIntegerFeatureInc(hDev, "PacketSize");

                        /* Adjust the new packet size so is divisible by its increment. */
                        newPacketSize -= newPacketSize % packetSizeInc;
                    }
                    else
                    {
                        /* The recommended packet size should always be valid. No need to check against the increment. */
                        newPacketSize = recommendedPacketSize;
                    }

                    /* Set the new packet size. */
                    Pylon.DeviceSetIntegerFeature(hDev, "PacketSize", newPacketSize);
                    Console.WriteLine("Using packetsize: {0}", newPacketSize);
                }



                /* Allocate and register buffers for grab. */
                /* Determine the required size for the grab buffer. */
                payloadSize[deviceIndex] = checked((uint)Pylon.DeviceGetIntegerFeature(hDev, "PayloadSize"));

                /* Image grabbing is done using a stream grabber.  
                  A device may be able to provide different streams. A separate stream grabber must 
                  be used for each stream. In this sample, we create a stream grabber for the default 
                  stream, i.e., the first stream ( index == 0 ).
                  */

                /* Get the number of streams supported by the device and the transport layer. */
                nStreams[deviceIndex] = Pylon.DeviceGetNumStreamGrabberChannels(hDev);

                if (nStreams[deviceIndex] < 1)
                {
                    throw new Exception("The transport layer doesn't support image streams.");
                }

                /* Create and open a stream grabber for the first channel. */
                hGrabber[deviceIndex] = Pylon.DeviceGetStreamGrabber(hDev, 0);

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



                /* The stream grabber is now prepared. As soon the camera starts acquiring images,
                   the image data will be grabbed into the provided buffers.  */

                /* Let the camera acquire images. */
                Pylon.DeviceExecuteCommandFeature(hDev, "AcquisitionStart");


                /* Set the timer to 5 s and start it. */
                timer.Change(Timeout.Infinite, Timeout.Infinite);

                /* Counts the number of grabbed images. */


                /* Grab until the timer expires. */
                for (; ; )
                {
                   
                    int bufferIndex;  /* Index of the buffer. */
                    Byte min, max;
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
                        sizeX = (uint)grabResult[woIndex].SizeX;
                        sizeY = (uint)grabResult[woIndex].SizeY;
                        getMinMax(buffer.Array, grabResult[woIndex].SizeX, grabResult[woIndex].SizeY, out min, out max);
                        Console.WriteLine("Grabbed frame {0} from camera {1} into buffer {2}. Min. val={3}, Max. val={4}",
                            fps, woIndex, bufferIndex, min, max);

                        /* Display image */
                        Pylon.ImageWindowDisplayImage<Byte>(woIndex, buffer, grabResult[woIndex]);

                        if (zoomToFit == true)
                        {
                            System.Windows.Forms.SendKeys.SendWait("^{MULTIPLY}");
                            zoomToFit = false;
                        }
                        imgBuf = buffer;
                       

                        if (flagSave == true)
                        {
                            imageToSave = (byte[])imgBuf.Array.Clone();
                            flagSave = false;
                            flagWriteToDisk = true;
                        }
                       

                    }
                    else if (grabResult[woIndex].Status == EPylonGrabStatus.Failed)
                    {
                        Console.Error.WriteLine("Frame {0} wasn't grabbed successfully.  Error code = {1}",
                            fps, grabResult[woIndex].ErrorCode);
                    }

                    /* Once finished with the processing, requeue the buffer to be filled again. */
                    Pylon.StreamGrabberQueueBuffer(hGrabber[woIndex], grabResult[woIndex].hBuffer, bufferIndex);

                    fps++;
                    
                    if (recording == false)
                    { break; }
                }

                /* Clean up. */
                /* Stop the image aquisition on the cameras. */
                for (deviceIndex = 0; deviceIndex < NUM_DEVICES; ++deviceIndex)
                {
                    /*  ... Stop the camera. */
                    Pylon.DeviceExecuteCommandFeature(hDev, "AcquisitionStop");
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
                    Pylon.DeviceClose(hDev);
                    Pylon.DestroyDevice(hDev);
                }

                /* Dispose timer and event. */
                timer.Dispose();
                timoutEvent.Close();

                Console.Error.WriteLine("\nPress enter to exit.");
                Console.ReadLine();

                /* ... Shut down the pylon runtime system. Don't call any pylon function after 
                   calling PylonTerminate(). */
                Pylon.Terminate();
            }
            catch (Exception e)
            {
                note = "Can not open the camera!";
                alertBit = true;
 
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
                        if (hDev.IsValid)
                        {
                            /* ... Close and release the pylon device. */
                            if (Pylon.DeviceIsOpen(hDev))
                            {
                                Pylon.DeviceClose(hDev);
                            }
                            Pylon.DestroyDevice(hDev);
                        }
                    }
                    catch (Exception)
                    {
                        /*No further handling here.*/
                    }
                }

            }
        }

        }

        /* Simple "image processing" function returning the minimum and maximum gray 
        value of an 8 bit gray value image. */
        static void getMinMax(Byte[] imageBuffer, long width, long height, out Byte min, out Byte max)
        {
            min = 255; max = 0;
            long imageDataSize = width * height;

            for (long i = 0; i < imageDataSize; ++i)
            {
                Byte val = imageBuffer[i];
                if (val > max)
                    max = val;
                if (val < min)
                    min = val;
            }
    
        }

        private void Zdjecie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B || e.KeyCode == Keys.Add)
            {
                Zdjecie_Click(sender, e);
            }

        }

        private void Zdjecie_Click(object sender, EventArgs e)
        {
            if (flagSave != true)
            {
                this.flagSave = true;
                while(flagWriteToDisk != true)
                {

                }
                SaveImage();
                flagWriteToDisk = false;
            }
        }

        private void SaveImage()
        {
            try
            {
                savingTime = true;
                string whereSave = pathFolder + NameOfFolder.Text;
                System.IO.Directory.CreateDirectory(whereSave);

                PylonBuffer<byte> pylonBuffer = new PylonBuffer<byte>(imageToSave);

                if (FileFormat.SelectedIndex == 0)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Bmp, PathToSave(), pylonBuffer, EPylonPixelType.PixelType_Mono8
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (FileFormat.SelectedIndex == 1)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Jpeg, PathToSave(), pylonBuffer, EPylonPixelType.PixelType_Mono8
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (FileFormat.SelectedIndex == 2)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Png, PathToSave(), pylonBuffer, EPylonPixelType.PixelType_Mono8
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (FileFormat.SelectedIndex == 3)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Tiff, PathToSave(), pylonBuffer, EPylonPixelType.PixelType_Mono8
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }
                else
                { photoNR--; }

                photoNR++;
                
                Zdjecie.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.photoIcon));

                TimerCallback timerCallback = this.ShowPhotoIcon;
                System.Threading.Timer ShowIcon = new System.Threading.Timer(timerCallback, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                Console.Beep(800, 200);

            }
            catch (Exception e)
            {
                note = "File is not saved!";
                alertBit = true;
            }
            zdjecieNumer.Text = Convert.ToString(photoNR);
        }

        private void KameraON_Click(object sender, EventArgs e)
        {

            if (recording == false)
            {
                recording = true;
                listaKamer.Enabled = false;
                refreshListOfCameras.Enabled = false;
            
                watek = new Thread(Nagrywanie);
                watek.Start();

                //System.Windows.Forms.SendKeys.SendWait("^{TAB}");
                Zdjecie.Enabled = true; 
                KameraON.Text = "Turn OFF a camera";
                Zdjecie.Focus();
                CheckFileExist();
                TimerCallback timerCallback = this.ChangeWindow;
                System.Threading.Timer ShowIcon = new System.Threading.Timer(timerCallback, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));

            }

            else if(recording==true)
            {

                refreshListOfCameras.Enabled = true;
                recording = false;
                Zdjecie.Enabled = false;
                listaKamer.Enabled = true;
                KameraON.Text = "Turn ON a selected camera";
                KameraON.Enabled = false;
                CheckFileExist();
                alertBit = false;
                pulseBit = false;

            }
            
           
        }

        private void ChangeWindow(object state)
        {
            System.Windows.Forms.SendKeys.SendWait("%{TAB}");
        }

        private void ShowPhotoIcon(object state)
        {
            savingTime = false;
           // CheckFileExist();
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text =fps.ToString();
            fps = 0;
            pulseBit = !pulseBit;
            zoomToFit = true;
            ShowSavingPath.Text = pathFolder;
            CheckFileExist();
            if (alertBit && pulseBit)
            {
                AlertInfo.Text = note;
                AlertInfo.Visible = true;

            }
            else
            {
                AlertInfo.Visible = false;
            }
        }

        private void nowy(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.B || e.KeyCode == Keys.Add)
            {
                Console.Beep();
            }
        }

        private void zacznijOd_Click(object sender, EventArgs e)
        {
            try
            {
                photoNR = Convert.ToUInt32(poczatekNumeracji.Text.ToString());
                zdjecieNumer.Text = Convert.ToString(photoNR);
            }
            catch 
            {

                note = "Wrong value";
                zdjecieNumer.Text = Convert.ToString(photoNR);
            }
            Zdjecie.Focus();
            
        }
        private void ShowException(Exception e, string additionalErrorMessage)
        {
            string more = "\n\nLast error message (may not belong to the exception):\n" + additionalErrorMessage;
            MessageBox.Show("Exception caught:\n" + e.Message + (additionalErrorMessage.Length > 0 ? more : ""), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateDeviceList()
        {
            try
            {
                /* Ask the device enumerator for a list of devices. */
                List<DeviceEnumerator.Device> list = DeviceEnumerator.EnumerateDevices();

                ListView.ListViewItemCollection items = listaKamer.Items;

                /* Add each new device to the list. */
                foreach (DeviceEnumerator.Device device in list)
                {
                    bool newitem = true;
                    /* For each enumerated device check whether it is in the list view. */
                    foreach (ListViewItem item in items)
                    {
                        /* Retrieve the device data from the list view item. */
                        DeviceEnumerator.Device tag = item.Tag as DeviceEnumerator.Device;                

                        if (tag.FullName == device.FullName)
                        {
                            /* Update the device index. The index is used for opening the camera. It may change when enumerating devices. */
                            tag.Index = device.Index;
                            /* No new item needs to be added to the list view */
                            newitem = false;
                            break;
                        }
                    }

                    /* If the device is not in the list view yet the add it to the list view. */
                    if (newitem)
                    {
                        ListViewItem item = new ListViewItem(device.Name);
                        if (device.Tooltip.Length > 0)
                        {
                            item.ToolTipText = device.Tooltip;
                        }
                        item.Tag = device;

                        /* Attach the device data. */
                        listaKamer.Items.Add(item);
                    }
                }

                /* Delete old devices which are removed. */
                foreach (ListViewItem item in items)
                {
                    bool exists = false;

                    /* For each device in the list view check whether it has not been found by device enumeration. */
                    foreach (DeviceEnumerator.Device device in list)
                    {
                        if (((DeviceEnumerator.Device)item.Tag).FullName == device.FullName)
                        {
                            exists = true;
                            break;
                        }
                    }
                    /* If the device has not been found by enumeration then remove from the list view. */
                    if (!exists)
                    {
                        listaKamer.Items.Remove(item);
                    }
                }
            }
            catch (Exception e)
            {
                note = "Can not refresh the list of cameras";
                alertBit = true;
               // ShowException(e, m_imageProvider.GetLastErrorMessage());
            }
        }

        private void Zdjecie_fokus_ON(object sender, EventArgs e)
        {
            if (recording == true)
            {
                Zdjecie.Focus();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            recording = false;
            Pylon.Terminate();
            Environment.Exit(1);

        }

        private void ResetPhotoNumber_Click(object sender, EventArgs e)
        {
            photoNR = 1;
            zdjecieNumer.Text = Convert.ToString(photoNR);
            Zdjecie.Focus();
            
        }

        private void listaKamer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ListView.ListViewItemCollection items = listaKamer.Items;
                if (listaKamer.SelectedItems.Count > 0)
                {

                    ListViewItem wybrany = listaKamer.SelectedItems[0];
                    /* Retrieve the device data from the list view item. */
                    DeviceEnumerator.Device camera = wybrany.Tag as DeviceEnumerator.Device;
                    indexForCameraOpenFunction = camera.Index;
                }
                KameraON.Enabled = true;
            }
            catch {
                     note = "Camera is not selected";
                     alertBit = true;
                  }
        }

        private void refreshListOfCameras_Click(object sender, EventArgs e)
        {
            KameraON.Enabled = false;
            UpdateDeviceList();
        }

        private string PathToSave()
        {
            string whereSave = pathFolder + NameOfFolder.Text;
            string fotoS = photoNR.ToString();
            int length = fotoS.Length;
            for (int i = 0; i < 4 - length; i++)
            {
                fotoS = "0" + fotoS;
            }
            whereSave += "\\" + NameOfFile.Text + "_" + fotoS + "." + FileFormat.SelectedItem.ToString();
            return whereSave;
        }
        private void CheckFileExist()
        {
            if (recording == true)
            {
                if (File.Exists(PathToSave()) && savingTime == false)
                {
                    Zdjecie.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.alertIcon));
                    note = "File will be overwritten!";
                    alertBit = true;
                }
                else if(savingTime == false)
                {
                    alertBit = false;
                    Zdjecie.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.savingColorIcon));

                }
            }
            else 
            {
                alertBit = false;
                Zdjecie.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.saving));
            }
        }

        private void openGeneralFolder_Click(object sender, EventArgs e)
        {
                string checkFolder = System.Environment.CurrentDirectory;
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = windir + @"\explorer.exe";
                prc.StartInfo.Arguments = checkFolder;
                prc.Start();
        }

        private void OpenFileFolder_Click(object sender, EventArgs e)
        {
            string checkFolder = pathFolder + NameOfFolder.Text ;
            if (Directory.Exists(checkFolder))
            {
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = windir + @"\explorer.exe";
                prc.StartInfo.Arguments = checkFolder;
                prc.Start();
            }
            else 
            {
                alertBit = true;
                note = "Can not open this folder";
            }
        }

        private void Select_the_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = pathFolder;
            dialog.ShowDialog();
            ShowSavingPath.Text = dialog.SelectedPath;
            pathFolder = dialog.SelectedPath;
        }

        private void UserPath_CheckedChanged(object sender, EventArgs e)
        {

            NameOfFolder.Text = "";
            NameOfFolder.Visible = false;
            openGeneralFolder.Visible = false;
            OpenFolderTree.Visible = true;
            
        }

        private void StandardPath_CheckedChanged(object sender, EventArgs e)
        {
            pathFolder = System.Environment.CurrentDirectory + "\\";
            NameOfFolder.Text = "NewFolder";
            NameOfFolder.Visible = true;
            openGeneralFolder.Visible = true;
            OpenFolderTree.Visible = false;
            pathFolder = System.Environment.CurrentDirectory + "\\";
        }

        private void CamerasControler_Load(object sender, EventArgs e)
        {
            if (Zdjecie.Enabled == true)
            { Zdjecie.Focus(); }
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

