using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// camera
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace Emgu_Camera
{
    public class EmguCamera
    {
        private Capture capture;

        private Image<Bgr, byte> imgOriginalFromCamera;
        public Image<Bgr, byte> imgResized { get; set; }
        public Image<Gray, byte> imgResizedGrayscale { get; set; }

        private int cameraNumber;
        private string cameraName;
        private int frameHeight;
        private int frameWidth;

        public volatile bool flagReady = true;

        private const int frameToShowWidth = 1200;
        private const int frameToShowHeight = 900;

        public string ExceptionMessage { get; set; }

        public EmguCamera()
        {
            this.cameraNumber = 0;
            this.cameraName = "default";
            this.frameWidth = 640;
            this.frameHeight = 480;
            this.ExceptionMessage = "";

            Init();
        }

        public EmguCamera(int cameraNumber, string cameraName, int frameWidth, int frameHeight)
        {
            this.cameraNumber = cameraNumber;
            this.cameraName = cameraName;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.ExceptionMessage = "";

            Init();
        }

        private void Init()
        {
            try
            {
                // initialize camera
                this.capture = new Capture(this.cameraNumber);
                this.capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, frameWidth);
                this.capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, frameHeight);

                /*
                message = "AUTOGRAB:" + this.cap.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_AUTOGRAB).ToString() + "\r\n" +
                          "CV_CAP_PROP_CONVERT_RGB:" + this.cap.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_CONVERT_RGB).ToString() + "\r\n" +
                          "CV_CAP_PROP_FPS:" + this.cap.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_FPS).ToString() + "\r\n" +
                          "CV_CAP_PROP_MODE:" + this.cap.GetCaptureProperty(CAP_PROP.CV_CAP_PROP_MODE).ToString() "\r\n" +
                          ":" + this.cap.GetCaptureProperty(CAP_PROP.
                 * */
            }
            catch (Exception e)
            {
                ExceptionMessage = e.Message;
            }
        }

        public void Capture(int imageNumber, bool enableImageSave)
        {
            flagReady = false;
            /*
            using (Capture capture = new Capture())
            {
                capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, frameHeight);
                capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, frameWidth);
                //capture.QueryFrame();
                nextFrame = capture.QueryFrame().Copy(); //You must copy else frame will be disposed off
                gray = nextFrame.Convert<Gray, byte>().Resize(0.5, INTER.CV_INTER_LINEAR);
            }
             * */



            //cap.Grab();
            //nextFrame = cap.RetrieveBgrFrame(cameraNumber);

            imgOriginalFromCamera = capture.QueryFrame();
            imgOriginalFromCamera = capture.QueryFrame();
            {
                if (imgOriginalFromCamera != null)
                {
                    {
                        imgResized = imgOriginalFromCamera.Resize(frameToShowWidth, frameToShowHeight, INTER.CV_INTER_NN);
                        imgResizedGrayscale = imgResized.Convert<Gray, byte>();
                        if (enableImageSave)
                        {
                            imgOriginalFromCamera.Save("img_" + cameraName + "_" + imageNumber.ToString("D4") + ".bmp");
                        }
                    }
                }
            }

            flagReady = true;

            //cap.Dispose();
        }
    }
}
