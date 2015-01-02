using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using Basler_Cameras;

using Emgu_Camera;

// camera
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace BaslerCameraCalibrationTool
{
    public partial class frmBaslerCamerasCalibrationTool : Form
    {
        Cameras cameras;
        Thread oThread;

        EmguCamera webcam;

        bool flagEnableCameras = false;
        bool flagEnableWebcam = false;

        bool flagCameraReady = true;
        bool flagWebcamsReady = true;

        bool flagSaveImage = false;

        PUTVision_Utils.ImageCounter imgCounter = new PUTVision_Utils.ImageCounter();

        public frmBaslerCamerasCalibrationTool()
        {
            InitializeComponent();

            Cameras.SetDebug();
        }

        private void frmBaslerCamerasCalibrationTool_Load(object sender, EventArgs e)
        {
            lblImageCounter.Text = "0";
        }

        private void btnBaslerCamerasOpen_Click(object sender, EventArgs e)
        {
            if (!flagEnableCameras)
            {
                BaslerCamerasCreateAndOpen();
                //WebcamCreateAndOpen();

                oThread = new Thread(cameras.Run);
                oThread.Start();

                flagEnableCameras = true;
                //flagEnableWebcam = true;
                btnBaslerCamerasOpen.Text = "Close";
                btnBaslerCamerasOpen.BackColor = Color.ForestGreen;
            }
            else
            {
                cameras.RequestStop();
                oThread.Join();

                flagEnableCameras = false;
                flagEnableWebcam = false;
                btnBaslerCamerasOpen.Text = "Open";
                btnBaslerCamerasOpen.BackColor = Color.Firebrick;
            }
        }

        private void BaslerCamerasCreateAndOpen()
        {
            cameras = new Cameras();

            cameras.CamerasEvent += new Basler_Cameras.CamerasEventHandler(CamerasEvent);
            cameras.NextFrameEvent += new Basler_Cameras.NextFrameEventHandler(NextFrameEvent);

            cameras.flagEnableImageShow = true;
            cameras.flagEnableTimeMeasurements = true;

            AppendTextBox(cameras.Enumerate(ConvertCheckBoxToCameraNumber()) + "\r\n");
            // PK profile
            //cameras.Open(1500, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Off, 400000, Cameras.AutoFunctionProfile.GainMinimum);
            // AS profile
            cameras.Open(8192, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Continous, 0, Cameras.AutoFunctionProfile.GainMinimum, 0);
            // MF profile
            //cameras.Open(8192, Cameras.GainAuto.Continouos, Cameras.ExposureAuto.Continous, 0, Cameras.AutoFunctionProfile.ExposureMinimum, frameDelay);   
        }

        private void WebcamCreateAndOpen()
        {
            webcam = new EmguCamera(0, "logitechC525", 1280, 720);
        }

        private void WebcamCaptureAndPreview(int imageNumber, bool enableImageSave)
        {
            webcam.Capture(imageNumber, enableImageSave);

            imageBoxLogitech.Image = webcam.imgResized;
        }

        System.Diagnostics.Stopwatch timestampStopWatch = new System.Diagnostics.Stopwatch();
        List<long> timestampList = new List<long>();
        long previousTimestamp = 0;

        private void timerGrabImage_Tick(object sender, EventArgs e)
        {
            // additional check if webcams are ready (done because webcam accquisition is not done in another thread)
            if(flagEnableWebcam)
            {
                this.flagWebcamsReady = webcam.flagReady;
            }

            // depending on the active components create the condition (all the active cameras has to be ready)
            bool condition = true;
            if (this.flagEnableCameras)
            {
                condition = condition && (this.flagCameraReady == true);
            }
            if (this.flagEnableWebcam)
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
                flagWebcamsReady = false;
                // send command for taking the pictures
                if (flagEnableCameras)
                {
                    cameras.RequestGrab(this.imgCounter.Value, flagSaveImage);  
                }
                if (flagEnableWebcam)
                {
                    WebcamCaptureAndPreview(this.imgCounter.Value, flagSaveImage);
                }

                if (flagSaveImage)
                {
                    flagSaveImage = false;
                        
                    this.imgCounter.Increment(1);
                }
            }
        }

        // capturing pgdn key (from presentation pointer) orders a save image action
        private void rtbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 34)
            {
                lblImageCounter.Text = (imgCounter.Value+1).ToString();
                AppendTextBox("!");
                flagSaveImage = true;
            }
            /*
            if (e.KeyValue == 33)
            {
                AppendTextBox("PgUp\r\n");
            }
             * */
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

        private void StartAutomaticAcquistion()
        {
            timerGrabImage.Enabled = true;
            timestampStopWatch.Start();
            AppendTextBox("Timer started!\r\n");
        }

        private void StopAutomaticAcquisition()
        {
            timerGrabImage.Enabled = false;
            AppendTextBox("Number of images saved: " + imgCounter.Value.ToString() + "\r\n");
            ShowFPS();
        }

        private void ShowFPS()
        {
            double fps = (double)imgCounter.Value / (double)timestampList[timestampList.Count - 1] * 1000.0;
            AppendTextBox(String.Format("{0:0.00}", fps));
        }

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
    }
}
