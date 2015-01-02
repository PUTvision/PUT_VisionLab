using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// threading
using System.Threading;

using Basler_Cameras;
using Emgu_Camera;

using System.Net.Sockets;
using System.Net;

// camera
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace wifibot_cameras
{
    public partial class frmMain : Form
    {
        Cameras cameras;
        Thread oThread;

        bool flagEnableCameras = false;
        bool flagEnableServer = false;
        bool flagEnableWebcams = false;

        bool flagEnablePreview = false;

        bool flagCameraReady = true;
        bool flagKinectReady = true;
        bool flagWebcamsReady = true;

        bool flagDoOneSave = false;

        //int imageCounter;
        PUTVision_Utils.ImageCounter imgCounter;

        public frmMain()
        {
            InitializeComponent();

            Cameras.SetDebug();
        }

        #region form controls event handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            imgCounter = new PUTVision_Utils.ImageCounter();
            tbCurrentImageNumber.Text = this.imgCounter.Value.ToString();

            CheckIsStopWatchIsHighPerformance();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void btnBaslerCamerasOpen_Click(object sender, EventArgs e)
        {
            if (!flagEnableCameras)
            {
                BaslerCamerasCreateAndOpen();

                oThread = new Thread(cameras.Run);
                oThread.Start();

                flagEnableCameras = true;
                btnBaslerCamerasOpen.Text = "Close";
                btnBaslerCamerasOpen.BackColor = Color.ForestGreen;
            }
            else
            {
                cameras.RequestStop();
                oThread.Join();

                flagEnableCameras = false;
                btnBaslerCamerasOpen.Text = "Open";
                btnBaslerCamerasOpen.BackColor = Color.Firebrick;
            }
        }

        private void BaslerCamerasCreateAndOpen()
        {
            cameras = new Cameras();

            cameras.CamerasEvent += new Basler_Cameras.CamerasEventHandler(CamerasEvent);
            cameras.NextFrameEvent += new Basler_Cameras.NextFrameEventHandler(NextFrameEvent);

            int frameDelay = Convert.ToInt32(tbFrameDelay.Text);

            AppendTextBox(cameras.Enumerate(ConvertCheckBoxToCameraNumber()) + "\r\n");
            // PK profile
            //cameras.Open(1500, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Off, 400000, Cameras.AutoFunctionProfile.GainMinimum);
            // AS profile
            cameras.Open(8192, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Continous, 0, Cameras.AutoFunctionProfile.GainMinimum, frameDelay);
            // MF profile
            //cameras.Open(8192, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Continous, 0, Cameras.AutoFunctionProfile.ExposureMinimum, frameDelay);   
        }

        private List<Cameras.CameraNumber> ConvertCheckBoxToCameraNumber()
        {
            List<Cameras.CameraNumber> listOfChoosenCameras = new List<Cameras.CameraNumber>();

            if (cbTR.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.TopRight);
            }
            if (cbTL.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.TopLeft);
            }
            if (cbC.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.Center);
            }
            if (cbBR.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.BottomRight);
            }
            if (cbBL.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.BottomLeft);
            }
            if (cbSC1.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.Additional1);
            }
            if (cbSC2.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.Additional2);
            }
            if (cbSC3.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.Additional3);
            }
            if (cbRR.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.RobotRight);
            }
            if (cbRL.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.RobotLeft);
            }
            if (cbPK1.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.PK1);
            }
            if (cbPK2.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.PK2);
            }
            if (cbPK3.Checked)
            {
                listOfChoosenCameras.Add(Cameras.CameraNumber.PK3);
            }

            return listOfChoosenCameras;
        }

        private void btnStartDlaAdama_Click(object sender, EventArgs e)
        {
            if (timerGrabImage.Enabled)
            {
                //btnCameraFlagPreview_Click(null, null);
                btnEnableTimerGrab_Click(null, null);

                btnStartDlaAdama.Text = "Start";
                btnStartDlaAdama.BackColor = Color.Firebrick;
            }
            else
            {
                //btnCameraFlagPreview_Click(null, null);
                btnEnableTimerGrab_Click(null, null);


                btnStartDlaAdama.Text = "Stop";
                btnStartDlaAdama.BackColor = Color.ForestGreen;
            }
        }

        private void btnEnableTimerGrab_Click(object sender, EventArgs e)
        {
            if (timerGrabImage.Enabled)
            {
                StopAutomaticAcquisition();

                timerGrabImage.Enabled = false;

                btnEnableTimerGrab.Text = "Start acquisition";
                btnEnableTimerGrab.BackColor = Color.Firebrick;
            }
            else
            {
                StartAutomaticAcquistion();

                timerGrabImage.Enabled = true;

                btnEnableTimerGrab.Text = "Stop acquisition";
                btnEnableTimerGrab.BackColor = Color.ForestGreen;
            }
        }

        private void btnCameraFlagSave_Click(object sender, EventArgs e)
        {
            if (cameras.flagEnableImageSave)
            {
                cameras.flagEnableImageSave = false;
                btnCameraFlagSave.Text = "Enable saving";
                btnCameraFlagSave.BackColor = Color.Firebrick;
            }
            else
            {
                cameras.flagEnableImageSave = true;
                btnCameraFlagSave.Text = "Disable saving";
                btnCameraFlagSave.BackColor = Color.ForestGreen;
            }
        }

        private void btnEnableTimeMeasuring_Click(object sender, EventArgs e)
        {
            if (cameras.flagEnableTimeMeasurements)
            {
                cameras.flagEnableTimeMeasurements = false;
                btnEnableTimeMeasuring.Text = "Enable measuring";
                btnEnableTimeMeasuring.BackColor = Color.Firebrick;
            }
            else
            {
                cameras.flagEnableTimeMeasurements = true;
                btnEnableTimeMeasuring.Text = "Disable measuring";
                btnEnableTimeMeasuring.BackColor = Color.ForestGreen;
            }
        }

        private void btnCameraFlagPreview_Click(object sender, EventArgs e)
        {
            if (flagEnablePreview)
            {
                flagEnablePreview = false;

                if (cameras != null)
                {
                    cameras.flagEnableImageShow = false;
                }

                btnCameraFlagPreview.Text = "Enable preview";
                btnCameraFlagPreview.BackColor = Color.Firebrick;
            }
            else
            {
                flagEnablePreview = true;

                if (cameras != null)
                {
                    cameras.flagEnableImageShow = true;
                }

                btnCameraFlagPreview.Text = "Disable preview";
                btnCameraFlagPreview.BackColor = Color.ForestGreen;
            }
        }

        #endregion

        private void CamerasEvent(object o, CamerasEventArg e)
        {
            //The results ...
            //Cameras cameras = (Cameras)o;

            AppendTextBox("\r\n" + e.Message + "\r\n");
        }

        private void NextFrameEvent(object o, NextFrameEventArg e)
        {
            flagCameraReady = true;
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            rtbMain.AppendText(value);
            rtbMain.ScrollToCaret();
        }

        private void CheckIsStopWatchIsHighPerformance()
        {
            if (System.Diagnostics.Stopwatch.IsHighResolution)
            {
                AppendTextBox("StopWatch is high performance\r\n");
            }
            else
            {
                AppendTextBox("StopWatch is not high performance\r\n");
            }
        }

        private void ShowTimes(string times)
        {
            AppendTextBox("\r\nWhole time \t wait for \t\t save to file\r\n");
            AppendTextBox(times);
        }

        private void ShowFPS()
        {
            double fps = (double)imgCounter.Value / (double)timestampList[timestampList.Count - 1] * 1000.0;
            AppendTextBox(String.Format("{0:0.00}", fps));
        }


        System.Diagnostics.Stopwatch timestampStopWatch = new System.Diagnostics.Stopwatch();
        List<long> timestampList = new List<long>();
        long previousTimestamp = 0;

        private void timerGrabImage_Tick(object sender, EventArgs e)
        {
            // additional check if webcams are ready (done because webcam accquisition is not done in another thread)
            if (this.flagEnableWebcams)
            {
                this.flagWebcamsReady = LogitechCamerasCheckIfRead();
            }

            // depending on the active components create the condition (all the active cameras has to be ready)
            bool condition = true;
            if (this.flagEnableCameras)
            {
                condition = condition && (this.flagCameraReady == true);
            }
            if (this.flagEnableServer)
            {
                condition = condition && (this.flagKinectReady == true);
            }
            if (this.flagEnableWebcams)
            {
                condition = condition && (this.flagWebcamsReady == true);
            }

            // wait until condition is fullfilled
            if (condition)
            {
                long currentTimestamp = timestampStopWatch.ElapsedMilliseconds;
                //rtbMain.AppendText((currentTimestamp - previousTimestamp).ToString() + "\r\n");
                previousTimestamp = currentTimestamp;
                // add current time to timestamp list
                timestampList.Add(currentTimestamp);
                // reset flags indicating that elements are ready
                flagCameraReady = false;
                flagKinectReady = false;
                flagWebcamsReady = false;
                // send command for taking the pictures
                if (flagEnableCameras)
                {
                    //cameras.RequestGrab(this.imgCounter.Value, flagDoOneSave);
                    cameras.RequestGrab(this.imgCounter.Value, true);

                    this.imgCounter.Increment(1);
                }
                if (flagEnableServer)
                {
                    Send(listOfClients[0].GetStream(), "START " + this.imgCounter.Value.ToString() + "_");
                    AppendTextBox("Sending command\r\n");
                }
                if (flagEnableWebcams)
                {
                    LogitechCamerasCaptureAndPreview(this.imgCounter.Value, flagDoOneSave);
                }

                // check if flag do one save is set
                if (flagDoOneSave)
                {
                    // increase number of images taken
                    this.imgCounter.Increment(1);
                    tbCurrentImageNumber.Text = this.imgCounter.Value.ToString();
                    flagDoOneSave = false;
                }
            }
        }

        private void StartAutomaticAcquistion()
        {
            timerGrabImage.Enabled = true;
            timestampStopWatch.Start();
            AppendTextBox("Timer started!\r\n");
        }

        private void StopAutomaticAcquisition()
        {
            timerGrabImage.Enabled = false;
            if (flagEnableServer)
            {
                Send(listOfClients[0].GetStream(), "START X_");
            }
            AppendTextBox("Number of images saved: " + imgCounter.Value.ToString() + "\r\n");
            ShowFPS();
        }

        #region server code

        private TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClient> listOfClients = new List<TcpClient>();

        private volatile bool flagListen;

        private void InitConnection()
        {
            if (listenThread == null)
            {
                flagListen = true;
                tcpListener = new TcpListener(IPAddress.Any, 3000);
                listenThread = new Thread(new ThreadStart(ListenForClients));
                listenThread.Start();

                AppendTextBox("Server started" + Environment.NewLine);
            }
        }

        private void CloseConnection()
        {
            if (listenThread != null)
            {
                flagListen = false;
                listenThread.Join();
            }
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (flagListen)
            {
                // Step 0: Client connection
                if (!tcpListener.Pending())
                {
                    Thread.Sleep(500); // choose a number (in milliseconds) that makes sense
                    continue; // skip to next iteration of loop
                }

                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();
                listOfClients.Add(client);

                //create a thread to handle communication with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);

                AppendTextBox("Client connected\r\n");
            }

            tcpListener.Stop();
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;
            ASCIIEncoding encoder = new ASCIIEncoding();

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    AppendTextBox("Client disconnected\r\n");
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    AppendTextBox("Client disconnected\r\n");
                    break;
                }

                //message has successfully been received
                string messageAsString = encoder.GetString(message, 0, bytesRead);
                AppendTextBox(messageAsString + "\r\n");
                AnaylzeReceivedPacket(messageAsString);
            }

            listOfClients.Clear();

            tcpClient.Close();
        }

        private void AnaylzeReceivedPacket(string message)
        {
            if (message == "READY")
            {
                flagKinectReady = true;
            }
        }

        private void Send(NetworkStream stream, string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        #endregion

        #region TODO code

        private void btnGetTimestamps_Click(object sende, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Timestamps:\r\n");
            for (int i = 0; i < timestampList.Count; i++)
            {
                sb.Append(i).Append(": ").Append(timestampList[i]).Append("\r\n");
            }

            AppendTextBox(sb.ToString());
        }

        private void btnGetAllTimes_Click(object sender, EventArgs e)
        {
            List<long> durationWhole = cameras.getListOfDurationOfWholeProcess();
            List<long> durationWait = cameras.getListOfDurationOfWaitForAllCameras();
            List<long> durationSave = cameras.getListOfDurationOfSaveToFile();

            int numberOfMeasurementsFromCamera = durationWhole.Count;

            long currentTimestamp = 0;
            long previousTimestamp = 0;

            int numberOfTimestamps = timestampList.Count;

            StringBuilder sb = new StringBuilder();
            sb.Append("i \t timestamp difference c_whole c_wait c_save").AppendLine();
            for (int i = 0; i < imgCounter.Value; ++i)
            {
                // print data from timestamps if available
                if (i < numberOfMeasurementsFromCamera)
                {
                    currentTimestamp = timestampList[i];
                    long difference = currentTimestamp - previousTimestamp;
                    previousTimestamp = currentTimestamp;

                    sb.Append(i).Append("\t").Append(currentTimestamp).Append("\t").Append(difference).Append("\t");
                }
                // print data from camera if available
                if (i < numberOfMeasurementsFromCamera)
                {
                    sb.Append(durationWhole[i]).Append("\t").Append(durationWait[i]).Append("\t").Append(durationSave[i]);
                }
                sb.AppendLine();
            }
            sb.AppendLine();

            AppendTextBox(sb.ToString());
        }

        private void btnCamerasGrab_Click(object sender, EventArgs e)
        {
            if (flagEnableCameras)
            {
                if (flagCameraReady)
                {
                    // reset flags indicating that elements are ready
                    flagCameraReady = false;
                    // send command for taking the pictures
                    cameras.RequestGrab(imgCounter.Value, true);
                    // increase number of images taken
                    imgCounter.Increment(1);
                    tbCurrentImageNumber.Text = this.imgCounter.Value.ToString();
                }
            }
        }

        private void btnGetTimeRaw_Click(object sender, EventArgs e)
        {
            ShowTimes(cameras.GetTimesRaw());
        }

        private void btnGetTimesAvg_Click(object sender, EventArgs e)
        {
            ShowTimes(cameras.GetTimesAvg());
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!flagEnableServer)
            {
                InitConnection();

                flagEnableServer = true;
                btnStartServer.Text = "Stop server";
                btnStartServer.BackColor = Color.ForestGreen;
            }
            else
            {
                flagEnableServer = false;
                btnStartServer.Text = "Start server";
                btnStartServer.BackColor = Color.Firebrick;
            }
        }

        #endregion


        private void btnDoOneSave_Click(object sender, EventArgs e)
        {
            AppendTextBox(this.imgCounter.Value.ToString() + " ");

            flagDoOneSave = true;
        }

        #region webcams code

        EmguCamera[] tableOfWebcams = new EmguCamera[2];

        private void btnUSBOpenLogitechC525_Click(object sender, EventArgs e)
        {
            EmguCamera newCamera = new EmguCamera(Convert.ToInt32(tbC525Number.Text), "logitechC525", 1280, 720);
            tableOfWebcams[0] = newCamera;

            flagEnableWebcams = true;

            btnUSBOpenLogitechC525.Text = "Opened";
            btnUSBOpenLogitechC525.BackColor = Color.ForestGreen;
            btnUSBOpenLogitechC525.Enabled = false;
        }

        private void btnUSBOpenLogitechSphere_Click(object sender, EventArgs e)
        {
            EmguCamera newCamera = new EmguCamera(Convert.ToInt32(tbSphereNumber.Text), "logitechSphere", 1600, 1200);
            tableOfWebcams[1] = newCamera;

            flagEnableWebcams = true;

            btnUSBOpenLogitechSphere.Text = "Opened";
            btnUSBOpenLogitechSphere.BackColor = Color.ForestGreen;
            btnUSBOpenLogitechSphere.Enabled = false;
        }

        private void btnUSBPreview_Click(object sender, EventArgs e)
        {
            LogitechCamerasCaptureAndPreview(0, false);
        }

        private void LogitechCamerasCaptureAndPreview(int imageNumber, bool enableImageSave)
        {
            foreach (EmguCamera webcam in tableOfWebcams)
            {
                if (webcam != null)
                {
                    webcam.Capture(imageNumber, enableImageSave);
                }
            }

            // preview part
            if (tableOfWebcams[0] != null)
            {
                imageBoxUSBC525.Image = tableOfWebcams[0].imgResized;
            }
            if (tableOfWebcams[1] != null)
            {
                imageBoxUSBSphere.Image = tableOfWebcams[1].imgResized;
            }
        }

        private bool LogitechCamerasCheckIfRead()
        {
            bool condition = true;
            foreach (EmguCamera webcam in tableOfWebcams)
            {
                if (webcam != null)
                {
                    condition = condition && webcam.flagReady;
                }
            }

            return condition;
        }

        #endregion

        /*
        #region image number
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

        #endregion
        */

        // capturing pgdn key (from presentation pointer) orders a save image action
        private void rtbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 34)
            {
                btnDoOneSave_Click(null, null);
            }
            /*
            if (e.KeyValue == 33)
            {
                AppendTextBox("PgUp\r\n");
            }
             * */
        }

        private void btnImageNumberSet_Click(object sender, EventArgs e)
        {
            //this.imgCounter.Set(Button
        }

    }
}
