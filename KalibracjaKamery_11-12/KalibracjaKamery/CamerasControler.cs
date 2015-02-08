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
using PUTVision_BaslerCenter;



namespace KalibracjaKamery
{

    public partial class Cameras_controler : Form
    {
        public BaslerCenter basler;
        PylonBuffer<Byte> imageToSave=null;
        int modeSelect = 1;
        int fps;

        EPylonPixelType pixelType = EPylonPixelType.PixelType_BayerBG8;
        
        static uint photoNumber = 1;
        static bool recording = true;
        
        string pathFolder = System.Environment.CurrentDirectory + "\\";
        Thread camerasLive;
        string[] camerasToOpen;

        bool pulseBit = false;
        string overwritteNote = "";
        string alertNote = "";
        bool flagSave = false;
        bool flagWriteToDisk = false;

        bool zoomToFit = true;
        bool savingTime = false;
        bool reverseInAxisX = true;

        bool colorful = true;


        public Cameras_controler()
        {

            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            Display_photo_number.Text = photoNumber.ToString();
            UpdateDeviceList();
            Select_file_format.SelectedIndex = 0;
            Show_path_to_saving_folder.Text = pathFolder;
            NameOfFolder.Text = "";
            User_folder_select.Checked = true;
            timer1.Start();

            System.Windows.Forms.ToolTip ToolTipUserPath = new System.Windows.Forms.ToolTip();
            ToolTipUserPath.SetToolTip(this.User_folder_select, "In this option\nyou can choose the folder,\nwhere files will be saving.");

            System.Windows.Forms.ToolTip ToolTipStandardPath = new System.Windows.Forms.ToolTip();
            ToolTipStandardPath.SetToolTip(this.Standard_folder_select, "In this option\nfiles will be saving\nnear this aplication.\nYou can add the folder\nto organize it.");

        }

        private void SaveImage()
        {
            try
            {
                savingTime = true;
                string whereSave = pathFolder + NameOfFolder.Text;
                System.IO.Directory.CreateDirectory(whereSave);

                uint sizeX, sizeY;
                basler ReturnFrameSize(out sizeX, out sizeY);

                if (Select_file_format.SelectedIndex == 0)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Bmp, PathToSave(), imageToSave, pixelType
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (Select_file_format.SelectedIndex == 1)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Jpeg, PathToSave(), imageToSave, pixelType
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (Select_file_format.SelectedIndex == 2)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Png, PathToSave(), imageToSave, pixelType
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (Select_file_format.SelectedIndex == 3)
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Tiff, PathToSave(), imageToSave, pixelType 
                        , sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }
                else
                { photoNumber--; }

                photoNumber++;

                Save_picture.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.photoIcon));

                TimerCallback timerCallback = this.ShowPhotoIcon;
                System.Threading.Timer ShowIcon = new System.Threading.Timer(timerCallback, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                Console.Beep(800, 200);


            }
            catch (Exception e)
            {
                alertNote = "File is not saved!";
            }
            Display_photo_number.Text = Convert.ToString(photoNumber);
        }

        private void ShowPhotoIcon(object state)
        {
            savingTime = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            tester.Text = List_of_cameras.CheckedItems.Count.ToString();
            /*if (List_of_cameras.SelectedItems.Count > 10)
            {
                for (uint i = 0; i < camerasToOpen.Length; i++)
                {
                   tester.Text += camerasToOpen[i].ToString()+" ";
                }
            }*/
            //tester.Text =cameras.ToString() +" " + listaKamer.SelectedItems.Count.ToString() +" "+ listaKamer.VirtualListSize.ToString();
            Display_FPS.Text = fps.ToString();
            fps = 0;
            pulseBit = !pulseBit;
            zoomToFit = true;
            Show_path_to_saving_folder.Text = pathFolder;
            CheckFileExist();
            if (Mode_select_UP.Enabled == false)
            {
                Mode_select_DOWN.Enabled = true;
                Save_picture.Enabled = false;
                List_of_cameras.Enabled = true;
                Colorful.Enabled = true;
                Reverse_in_axis_X.Enabled = true;
                Mode_select_UP.Text = "Turn ON";
            }
            if (pulseBit)
            {
                AlertInfo.Text = overwritteNote;
            }
            else
            {
                AlertInfo.Text = alertNote;
            }

        }

        private void nowy(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.B || e.KeyCode == Keys.Add)
            {
                Console.Beep();
            }
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

                ListView.ListViewItemCollection items = List_of_cameras.Items;

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
                        List_of_cameras.Items.Add(item);
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
                        List_of_cameras.Items.Remove(item);
                    }
                }
            }
            catch (Exception e)
            {
                alertNote = "Can not refresh the list of cameras";
                // ShowException(e, m_imageProvider.GetLastErrorMessage());
            }
        }

        private void Save_picture_fokus_ON(object sender, EventArgs e)
        {
            if (recording == true)
            {
                Save_picture.Focus();
            }

        }

        private string PathToSave()
        {
            string whereSave = pathFolder + NameOfFolder.Text;
            string fotoS = photoNumber.ToString();
            int length = fotoS.Length;
            for (int i = 0; i < 4 - length; i++)
            {
                fotoS = "0" + fotoS;
            }
            whereSave += "\\" + Name_of_file.Text + "_" + fotoS + "." + Select_file_format.SelectedItem.ToString();
            return whereSave;
        }

        private void CheckFileExist()
        {
            if (File.Exists(PathToSave()) && !savingTime == true)
            {
                Save_picture.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.alertIcon));
                overwritteNote = "File will be overwritten!";
            }
            else if (recording && !savingTime == true)
            {
                overwritteNote = "";
                Save_picture.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.savingColorIcon));

            }
            else if (!savingTime == true)
            {
                overwritteNote = "";
                Save_picture.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.saving));
            }
        }

        private void CamerasControler_Load(object sender, EventArgs e)
        {
            if (Save_picture.Enabled == true)
            { Save_picture.Focus(); }
        }


        #region Checked changed

        private void List_of_cameras_SelectedIndexChanged(object sender, EventArgs e)
        {


            Mode_select_UP.Enabled = true;
        }

        private void Reverse_in_axis_X_CheckedChanged(object sender, EventArgs e)
        {
            reverseInAxisX = Reverse_in_axis_X.Checked;
        }

        private void Standard_path_select_CheckedChanged(object sender, EventArgs e)
        {
            pathFolder = System.Environment.CurrentDirectory + "\\";
            NameOfFolder.Text = "NewFolder";
            NameOfFolder.Visible = true;
            openGeneralFolder.Visible = true;
            Open_folder_tree.Visible = false;
            pathFolder = System.Environment.CurrentDirectory + "\\";
        }

        private void User_path_select_CheckedChanged(object sender, EventArgs e)
        {

            NameOfFolder.Text = "";
            NameOfFolder.Visible = false;
            openGeneralFolder.Visible = false;
            Open_folder_tree.Visible = true;

        }

        private void Colorful_CheckedChanged(object sender, EventArgs e)
        {
            colorful = Colorful.Checked;
        }

        #endregion


        #region Buttons click

        private void Save_picture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B || e.KeyCode == Keys.Add)
            {
                Save_picture_Click(sender, e);
            }
        }

        private void Save_picture_Click(object sender, EventArgs e)
        {
            if (flagSave != true)
            {
                this.flagSave = true;
                while (flagWriteToDisk != true)
                {

                }
                SaveImage();
                flagWriteToDisk = false;
            }
        }

        private void Mode_select_UP_Click(object sender, EventArgs e)
        {

            if (modeSelect== 1)
            {
                
                try
                {
                    if (List_of_cameras.CheckedItems.Count > 0)
                    {

                    camerasToOpen = null;
                    basler = null;
                    Working_cameras.Items.Clear();
                    Checked_List_Box.Items.Clear();

                    camerasToOpen = new string[List_of_cameras.CheckedItems.Count];
                    basler = new CameraBasler((uint)List_of_cameras.CheckedItems.Count);
                    basler.NUM_DEVICES = (uint)List_of_cameras.CheckedItems.Count;
                    basler.wszystkieNazwy = new string[List_of_cameras.CheckedItems.Count];

                    for (int i = 0; i < (int)List_of_cameras.CheckedItems.Count; i++)
                    {
                        ListViewItem selectedCamera = List_of_cameras.CheckedItems[i];
                        /* Retrieve the device data from the list view item. */
                        DeviceEnumerator.Device camera = selectedCamera.Tag as DeviceEnumerator.Device;
                        camerasToOpen[i] = camera.Name;
                        basler.wszystkieNazwy[i]=camera.Name;

                        Working_cameras.Items.Add(camera.Name);
                        Checked_List_Box.Items.Add(camera.Name);
                        
                        
                        //PYLON_DEVICE_INFO_HANDLE hDi = Pylon.GetDeviceInfoHandle((uint)camera.Index);                    
                    }
                    basler.Recording();
                    alertNote = "";
                }
                //Mode_select_UP.Enabled = true;
            }

                catch
                {
                    alertNote = "Camera is not selected";
                }
                /*Save_picture.Enabled = true;
                Save_picture.Focus();

                List_of_cameras.Enabled = false;
                Mode_select_DOWN.Enabled = false;
                Colorful.Enabled = false;
                Reverse_in_axis_X.Enabled = false;
                basler[0].fps=3;

                camerasLive = new Thread(Nagrywanie);
                camerasLive.Start();
                Mode_select_UP.Text = "Turn OFF";*/
            }

            else if (recording == true)
            {
                Mode_select_DOWN.Enabled = true;
                recording = false;
                Save_picture.Enabled = false;
                List_of_cameras.Enabled = true;
                Colorful.Enabled = true;
                Reverse_in_axis_X.Enabled = true;
                Mode_select_UP.Text = "Turn ON";
                Mode_select_UP.Enabled = false;
                alertNote = "";
            }


        }

        private void Mode_select_DOWN_Click(object sender, EventArgs e)
        {
            Mode_select_UP.Enabled = false;
            UpdateDeviceList();
        }

        private void Reset_photo_number_Click(object sender, EventArgs e)
        {
            photoNumber = 1;
            Display_photo_number.Text = Convert.ToString(photoNumber);
            Save_picture.Focus();

        }

        private void Open_file_folder_Click(object sender, EventArgs e)
        {
            string checkFolder = pathFolder + NameOfFolder.Text;
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

        private void Open_folder_tree_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = pathFolder;
            dialog.ShowDialog();
            Show_path_to_saving_folder.Text = dialog.SelectedPath;
            pathFolder = dialog.SelectedPath;
        }

        private void Change_numbering_Click(object sender, EventArgs e)
        {
           /* try
            {
                photoNumber = Convert.ToUInt32(Start_numbering_on.Text.ToString());
                Display_photo_number.Text = Convert.ToString(photoNumber);
            }
            catch
            {

                alertNote = "Wrong value";
                Display_photo_number.Text = Convert.ToString(photoNumber);
            }
            Save_picture.Focus();*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (basler != null)
            {
                //basler.permissionToWork = false;
            }

            Pylon.Terminate();
            Environment.Exit(1);

        }

        #endregion



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

