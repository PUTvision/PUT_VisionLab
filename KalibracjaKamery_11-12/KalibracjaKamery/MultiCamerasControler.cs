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
using PUTVision_CameraBasler;
using PUTVision_CameraBase;



namespace KalibracjaKamery
{

    public partial class MultiCamerasControler : Form
    {
        public BaslerCenter basler;
       
        static bool recording = false;

        string alertNote = "";

        bool savingTime = false;

        int selectedCamera=0;

        public MultiCamerasControler()
        {

            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            UpdateDeviceList();
            Select_file_format.SelectedIndex = 0;
            Name_Of_Folder.Text = "";

            System.Windows.Forms.ToolTip ToolTipListToOpen = new System.Windows.Forms.ToolTip();
            ToolTipListToOpen.SetToolTip(this.List_of_cameras, "Checked cameras will be open.");

            System.Windows.Forms.ToolTip ToolTipListToSave = new System.Windows.Forms.ToolTip();
            ToolTipListToSave.SetToolTip(this.List_Cameras_To_Save_Image, "View of checked cameras\n will be save to file");
            
        }

        private void SaveImage(uint i)
        {
            savingTime = true;

            int lengthAdres = basler.cameras[i].ReturnCompletePathToSave().Length; 
            string whereSave = this.basler.cameras[i].ReturnPath() + this.basler.cameras[i].ReturnFolderName();
            if (lengthAdres < 255)
            {
                System.IO.Directory.CreateDirectory(whereSave);
                PylonBuffer<byte> pylonBuffer = new PylonBuffer<byte>(basler.cameras[i].ReturnImageToSave());
                uint sizeX, sizeY;
                basler.cameras[i].ReturnFrameSize(out sizeX, out sizeY);

                if (basler.cameras[i].ReturnFileFormat() == "bmp")
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Bmp, basler.cameras[i].ReturnCompletePathToSave(), pylonBuffer,
                        basler.cameras[i].ReturnPixelType(), sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (basler.cameras[i].ReturnFileFormat() == "jpeg")
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Jpeg, basler.cameras[i].ReturnCompletePathToSave(), pylonBuffer,
                       basler.cameras[i].ReturnPixelType(), sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }

                else if (basler.cameras[i].ReturnFileFormat() == "png")
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Png, basler.cameras[i].ReturnCompletePathToSave(), pylonBuffer,
                       basler.cameras[i].ReturnPixelType(), sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown); ;
                }

                else if (basler.cameras[i].ReturnFileFormat() == "tiff")
                {
                    Pylon.ImagePersistenceSave(EPylonImageFileFormat.ImageFileFormat_Tiff, basler.cameras[i].ReturnCompletePathToSave(), pylonBuffer,
                       basler.cameras[i].ReturnPixelType(), sizeX, sizeY, 0, EPylonImageOrientation.ImageOrientation_TopDown);
                }


                Save_picture_button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.photoIcon));

                TimerCallback timerCallback = this.ShowPhotoIcon;
                System.Threading.Timer ShowIcon = new System.Threading.Timer(timerCallback, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(-1));
                Console.Beep(800, 200);

            }
            else 
            {
                basler.cameras[i].SetAlertNote("This path is to long");
            }
        }

        private void ShowPhotoIcon(object state)
        {
            savingTime = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //tester.Text = List_of_cameras.CheckedItems.Count.ToString();
            if (List_of_cameras.CheckedItems.Count>0)
            {
                for (uint i = 0; i < List_of_cameras.CheckedItems.Count; i++)
                {
                    try
                    {
                        Display_FPS.Text = basler.cameras[selectedCamera].ReturnFps().ToString();
                        basler.cameras[i].SetZoomToFit(true);
                        basler.cameras[i].RestetFps();
                        

                    }
                    catch { }
                    
                }
            }
            
 
            CheckFileExist(basler);
            if (Switch_Cameras.Enabled == false)
            {
                Refresh_Camera_List.Enabled = true;
                Save_picture_button.Enabled = false;
                List_of_cameras.Enabled = true;
                Colorful.Enabled = true;
                Switch_Cameras.Text = "Turn ON";
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
                Save_picture_button.Focus();
            }

        }

        private void CheckFileExist(BaslerCenter center)
        {
            try
            {
                if (center.cameras.Length > 0)
                {
                    for (int i = 0; i < center.cameras.Length; i++)
                    {
                        if (File.Exists(center.cameras[i].ReturnCompletePathToSave()) && !savingTime == true)
                        {
                            Save_picture_button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.alertIcon));
                            basler.cameras[i].SetOverwrittenNote();
                        }
                        else if (recording && !savingTime == true)
                        {
                            basler.cameras[i].ResetOverwrittenNote();
                            Save_picture_button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.savingColorIcon));

                        }
                        else if (!savingTime == true)
                        {
                            basler.cameras[i].ResetOverwrittenNote();
                            Save_picture_button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.saving));
                        }
                    }
                }
            }
            catch { }
        }

        private void CamerasControler_Load(object sender, EventArgs e)
        {
            if (Save_picture_button.Enabled == true)
            { Save_picture_button.Focus(); }
        }

        #region Checked changed

        private void List_of_cameras_Changed(object sender, EventArgs e)
        {
            Switch_Cameras.Enabled = true;
        }

        private void Working_cameras_Changed(object sender, EventArgs e)
        {
            selectedCamera = Working_cameras.SelectedIndex;
            Display_photo_number.Text = basler.cameras[selectedCamera].ReturnPhotoNumber().ToString();
            Name_of_file.Text = basler.cameras[selectedCamera].ReturnFileName(); ;
            Name_Of_Folder.Text = basler.cameras[selectedCamera].ReturnFolderName();
            Display_information.Text = basler.cameras[selectedCamera].ReturnAlertNote();
            Display_Overwritten_Alert.Text = basler.cameras[selectedCamera].ReturnOverwrittenNote();
            for (int i = 0; i < Select_file_format.Items.Count; i++)
            {
                if (basler.cameras[selectedCamera].ReturnFileFormat() == Select_file_format.Items[i].ToString())
                {
                    Select_file_format.SelectedIndex = i;
                }

            }
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

                if (List_Cameras_To_Save_Image.CheckedItems.Count > 0)
                {
                    for (int j = 0; j <(int) List_Cameras_To_Save_Image.CheckedItems.Count; j++)
                    {
                       // ListViewItem selectedCameras = List_Cameras_To_Save_Image.CheckedItems[j];
                        /* Retrieve the device data from the list view item. */
                       // DeviceEnumerator.Device cameraToSave = selectedCameras.Tag as DeviceEnumerator.Device; 
                        string cameraToSave = List_Cameras_To_Save_Image.CheckedItems[j].Text;
                        for (uint i = 0; i < basler.cameras.Length; i++)
                        {
                            if (cameraToSave == basler.cameras[i].ReturnCameraName())
                            {
                                try
                                {
                                    if (basler.cameras[i].ReturnFlagSave() != true)
                                    {
                                        basler.cameras[i].SetFlagSave(true);
                                        while (basler.cameras[i].ReturnFlagWriteToDisk() != true)
                                        {

                                        }
                                        SaveImage(i);
                                        basler.cameras[i].IncreasePhotoNumber();
                                        Display_photo_number.Text = basler.cameras[selectedCamera].ReturnPhotoNumber().ToString();
                                        basler.cameras[i].SetFlagWriteToDisk(false);
                                    }

                                }

                                catch
                                {
                                    basler.cameras[i].SetAlertNote("File is not saved!");
                                }
                            }
                        }
                    }
                }
            
        }

        private void Switch_Cameras_Click(object sender, EventArgs e)
        {
            
            if (recording == false)
            {
                
                try
                {
                    if (List_of_cameras.CheckedItems.Count > 0)
                    {
                    recording=true;
                    Working_cameras.Items.Clear();
                    List_Cameras_To_Save_Image.Clear();
                    basler = new BaslerCenter();
                    basler.SetNUM_DEVICES((uint)List_of_cameras.CheckedItems.Count);
                    basler.addCameras((uint)List_of_cameras.CheckedItems.Count);

                    for (int i = 0; i < (int)List_of_cameras.CheckedItems.Count; i++)
                    {
                        ListViewItem selectedCameras = List_of_cameras.CheckedItems[i];
                        /* Retrieve the device data from the list view item. */
                        DeviceEnumerator.Device camera = selectedCameras.Tag as DeviceEnumerator.Device;
                        basler.cameras[i].SetCameraName(camera.Name);
                        basler.cameras[i].SetFolderName(camera.Name);
                        basler.cameras[i].SetColor(Colorful.Checked);
                        Working_cameras.Items.Add(camera.Name);
                        List_Cameras_To_Save_Image.Items.Add(camera.Name);
                                          
                    }
                    Colorful.Enabled = false;
                    basler.SetPermissionToWork(true);
                    basler.Recording();
                    alertNote = "";
                    List_Cameras_To_Save_Image.Visible = true;
                    Switch_Cameras.Text = "Turn OFF";
                    Save_picture_button.Enabled = true;
                    Working_cameras.Enabled = true;
                    Working_cameras.SelectedIndex = 0;
                    Saving_group_box.Enabled = true;
                    Select_file_format.Enabled = true;
                    Save_picture_button.Focus();
                        
                }
                //Mode_select_UP.Enabled = true;
            }

                catch
                {
                    alertNote = "Camera is not selected";
                }
                
            }
            else if (recording == true)
            {
                
               basler.SetPermissionToWork(false);
               recording=false;
               Switch_Cameras.Text = "Turn ON";
               Working_cameras.Items.Clear();
               List_Cameras_To_Save_Image.Clear();
               List_Cameras_To_Save_Image.Visible = false;
               Working_cameras.Enabled = false;
               Saving_group_box.Enabled = false;
               Select_file_format.Enabled = false;

               Refresh_Camera_List.Enabled = true;

               Save_picture_button.Enabled = false;
               List_of_cameras.Enabled = true;
               Colorful.Enabled = true;
               alertNote = "";
            }


        }

        private void Refresh_Camera_List_Click(object sender, EventArgs e)
        {
            Switch_Cameras.Enabled = false;
            UpdateDeviceList();
        }

        private void Reset_photo_number_Click(object sender, EventArgs e)
        {
            //basler.cameras[selectedCamera].;
            basler.cameras[selectedCamera].SetPhotoNumber(1);
            Display_photo_number.Text = Convert.ToString(basler.cameras[selectedCamera].ReturnPhotoNumber());
            Save_picture_button.Focus();

        }

        private void Open_file_folder_Click(object sender, EventArgs e)
        {
            string checkFolder = basler.cameras[selectedCamera].ReturnPath() + basler.cameras[selectedCamera].ReturnFolderName();
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
            dialog.SelectedPath =basler.cameras[selectedCamera].ReturnPath();
            dialog.ShowDialog();
            //Show_path_to_saving_folder.Text = dialog.SelectedPath;
            basler.cameras[selectedCamera].SetPath(dialog.SelectedPath+"//");
        }

        private void Change_settings_Click(object sender, EventArgs e)
        {
            try
            {
                basler.cameras[selectedCamera].SetPhotoNumber(Convert.ToInt32(Start_numbering_on.Text.ToString()));
                Display_photo_number.Text = Start_numbering_on.Text.ToString();
            }
            catch
            {

                basler.cameras[selectedCamera].SetAlertNote("Wrong value");
                Display_photo_number.Text = Convert.ToString(basler.cameras[selectedCamera].ReturnPhotoNumber());
            }

            basler.cameras[selectedCamera].SetFileName(Name_of_file.Text);
            basler.cameras[selectedCamera].SetFolderName(Name_Of_Folder.Text);
            basler.cameras[selectedCamera].SetFileFormat(Select_file_format.SelectedText);
            basler.cameras[selectedCamera].SetFileFormat(Select_file_format.SelectedItem.ToString());
            

            Save_picture_button.Focus();
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

