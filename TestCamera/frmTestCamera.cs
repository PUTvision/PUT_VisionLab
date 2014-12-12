using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUTVision_TestCamera
{
    public partial class frmTestCamera : Form
    {
        PUTVision_CameraBase.CameraBase camera;

        public frmTestCamera()
        {
            InitializeComponent();

            this.camera = new PUTVison_CameraPointGrey.CameraPointGrey(0, "PointGrey_Camera", 640, 480);
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            this.camera.Open();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            rtbMain.AppendText("Testing tasks\r\n");

            const int numberOfTasksToDo = 1;
            Task[] tasks = new Task[numberOfTasksToDo];

            rtbMain.AppendText("Starting tasks\r\n");
            tasks[0] = Task.Factory.StartNew(() => this.camera.Capture(666, true, true));
            rtbMain.AppendText("Waiting to finish\r\n");
            Task.WaitAll(tasks);
            rtbMain.AppendText("All tasks have finished\r\n");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.camera.Close();
        }
    }
}
