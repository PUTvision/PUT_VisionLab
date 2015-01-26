using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// netowrk
using System.Net.Sockets;
using System.Threading;
using System.Net;

// camera
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace SynchronizationTool
{
    public partial class frmSynchronizationTool : Form
    {
        public frmSynchronizationTool()
        {
            InitializeComponent();
        }

        private void frmSynchronizationTool_Load(object sender, EventArgs e)
        {
            AppendTextBox("Application started" + Environment.NewLine);
            lblImageCounter.Text = imgCounter.ToString();
        }

        private void frmSynchronizationTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppendTextBox("Application closing" + Environment.NewLine);

            if (listenThread != null)
            {
                flagListen = false;
                listenThread.Join();
            }
        }

        private int imgCounter = 0;
        private bool flagEnableSave = false;

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            rtbMain.AppendText(value);
        }

        #region webcam code
        private Emgu_Camera.EmguCamera webcam;

        private void WebcamCreateAndOpen()
        {
            webcam = new Emgu_Camera.EmguCamera(0, "logitechSphere", 1600, 1200);
        }

        private void WebcamCaptureAndPreview(int imageNumber, bool enableImageSave)
        {
            webcam.Capture(imageNumber, enableImageSave);

            imgBoxWebcam.Image = webcam.imgResized;
        }
        #endregion

        #region form events

        private void btnOpenWebcam_Click(object sender, EventArgs e)
        {
            WebcamCreateAndOpen();
            timerWebcamPreview.Enabled = true;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            AppendTextBox("Server started. Listening on port " + portNumber.ToString() + "." + Environment.NewLine);
            InitConnection();
            flagListen = true;
        }

        private void btnSendStartCommand_Click(object sender, EventArgs e)
        {
            foreach (var item in listOfClients)
            {
                Send(item.GetStream(), "START " + imgCounter.ToString() + "_");
            }
            
            flagEnableSave = true;
            lblImageCounter.Text = (imgCounter + 1).ToString();
        }

        private void btnSendExitCommand_Click(object sender, EventArgs e)
        {

            foreach (var item in listOfClients)
            {
                Send(item.GetStream(), "START X_");
            }
        }

        #endregion

        #region network code

        private TcpListener tcpListener;
        private Thread listenThread;
        private List<TcpClient> listOfClients = new List<TcpClient>();
        private const int portNumber = 3000;

        private volatile bool flagListen;

        private void InitConnection()
        {
            tcpListener = new TcpListener(IPAddress.Any, portNumber);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
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
                string response = PrepareResponse(messageAsString);
                //Send(clientStream, response);
            }

            listOfClients.Clear();

            tcpClient.Close();
        }

        private string PrepareResponse(string message)
        {
            string response;
            if (message == "Hello Server!")
            {
                response = "Hello Client!";
            }
            else if (message == "Test")
            {
                response = "Test";
            }
            else if (message == "Ask question")
            {
                response = "2+2*2 = ?";
            }
            else if (message == "6")
            {
                response = "Correct!";
            }
            else if (message == "Ready")
            {
                response = "OK, now I know you are ready!";
            }
            else
            {
                response = "Unknown command!";
            }

            return response;
        }

        private void Send(NetworkStream stream, string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        #endregion

        private void timerWebcamPreview_Tick(object sender, EventArgs e)
        {
            if (flagEnableSave)
            {
                WebcamCaptureAndPreview(imgCounter, flagEnableSave);
                imgCounter++;
                flagEnableSave = false;
            }
            else
            {
                WebcamCaptureAndPreview(imgCounter, false);
            }    
        }

        // capturing pgdn key (from presentation pointer) orders a save image action
        private void rtbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 34)
            {
                btnSendStartCommand_Click(null, null);
            }
            /*
            if (e.KeyValue == 33)
            {
                AppendTextBox("PgUp\r\n");
            }
             * */
        }

    }
}
