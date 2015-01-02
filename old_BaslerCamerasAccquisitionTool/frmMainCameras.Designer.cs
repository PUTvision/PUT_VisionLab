namespace wifibot_cameras
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.gbMainOptions = new System.Windows.Forms.GroupBox();
            this.gbBaslerAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.btnEnableTimerGrab = new System.Windows.Forms.Button();
            this.btnCameraFlagPreview = new System.Windows.Forms.Button();
            this.btnGetTimesAvg = new System.Windows.Forms.Button();
            this.btnCameraFlagSave = new System.Windows.Forms.Button();
            this.btnEnableTimeMeasuring = new System.Windows.Forms.Button();
            this.btnGetTimeRaw = new System.Windows.Forms.Button();
            this.btnGetTimestamps = new System.Windows.Forms.Button();
            this.btnCamerasGrab = new System.Windows.Forms.Button();
            this.btnGetAllTimes = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnDoOneSave = new System.Windows.Forms.Button();
            this.gbCameraControls = new System.Windows.Forms.GroupBox();
            this.btnImageNumberSet = new System.Windows.Forms.Button();
            this.tbNewImageNumber = new System.Windows.Forms.TextBox();
            this.lblNewImageNumber = new System.Windows.Forms.Label();
            this.tbCurrentImageNumber = new System.Windows.Forms.TextBox();
            this.lblCurrentImageNumber = new System.Windows.Forms.Label();
            this.btnStartDlaAdama = new System.Windows.Forms.Button();
            this.btnBaslerCamerasOpen = new System.Windows.Forms.Button();
            this.gbBaslerCameras = new System.Windows.Forms.GroupBox();
            this.tbFrameDelay = new System.Windows.Forms.TextBox();
            this.cbPK3 = new System.Windows.Forms.CheckBox();
            this.cbPK2 = new System.Windows.Forms.CheckBox();
            this.cbPK1 = new System.Windows.Forms.CheckBox();
            this.cbSC3 = new System.Windows.Forms.CheckBox();
            this.cbRL = new System.Windows.Forms.CheckBox();
            this.cbSC2 = new System.Windows.Forms.CheckBox();
            this.cbSC1 = new System.Windows.Forms.CheckBox();
            this.cbTL = new System.Windows.Forms.CheckBox();
            this.cbBL = new System.Windows.Forms.CheckBox();
            this.cbRR = new System.Windows.Forms.CheckBox();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.cbBR = new System.Windows.Forms.CheckBox();
            this.cbTR = new System.Windows.Forms.CheckBox();
            this.timerGrabImage = new System.Windows.Forms.Timer(this.components);
            this.gbUSBCameras = new System.Windows.Forms.GroupBox();
            this.lblOpenCVNumber = new System.Windows.Forms.Label();
            this.tbC525Number = new System.Windows.Forms.TextBox();
            this.tbSphereNumber = new System.Windows.Forms.TextBox();
            this.btnUSBOpenLogitechC525 = new System.Windows.Forms.Button();
            this.btnUSBOpenLogitechSphere = new System.Windows.Forms.Button();
            this.imageBoxUSBC525 = new Emgu.CV.UI.ImageBox();
            this.imageBoxUSBSphere = new Emgu.CV.UI.ImageBox();
            this.lblUSBC525 = new System.Windows.Forms.Label();
            this.lblUSBSphere = new System.Windows.Forms.Label();
            this.gbMainOptions.SuspendLayout();
            this.gbBaslerAdvancedOptions.SuspendLayout();
            this.gbCameraControls.SuspendLayout();
            this.gbBaslerCameras.SuspendLayout();
            this.gbUSBCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxUSBC525)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxUSBSphere)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMain
            // 
            this.rtbMain.Location = new System.Drawing.Point(390, 13);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMain.Size = new System.Drawing.Size(342, 534);
            this.rtbMain.TabIndex = 0;
            this.rtbMain.Text = "";
            this.rtbMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMain_KeyDown);
            // 
            // gbMainOptions
            // 
            this.gbMainOptions.Controls.Add(this.gbBaslerAdvancedOptions);
            this.gbMainOptions.Controls.Add(this.btnGetTimestamps);
            this.gbMainOptions.Controls.Add(this.btnCamerasGrab);
            this.gbMainOptions.Controls.Add(this.btnGetAllTimes);
            this.gbMainOptions.Controls.Add(this.btnStartServer);
            this.gbMainOptions.Location = new System.Drawing.Point(6, 406);
            this.gbMainOptions.Name = "gbMainOptions";
            this.gbMainOptions.Size = new System.Drawing.Size(371, 141);
            this.gbMainOptions.TabIndex = 1;
            this.gbMainOptions.TabStop = false;
            this.gbMainOptions.Text = "Tylko dla ADMINISTRATORA, Adam nie klikaj";
            // 
            // gbBaslerAdvancedOptions
            // 
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnEnableTimerGrab);
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnCameraFlagPreview);
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnGetTimesAvg);
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnCameraFlagSave);
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnEnableTimeMeasuring);
            this.gbBaslerAdvancedOptions.Controls.Add(this.btnGetTimeRaw);
            this.gbBaslerAdvancedOptions.Location = new System.Drawing.Point(10, 19);
            this.gbBaslerAdvancedOptions.Name = "gbBaslerAdvancedOptions";
            this.gbBaslerAdvancedOptions.Size = new System.Drawing.Size(233, 110);
            this.gbBaslerAdvancedOptions.TabIndex = 15;
            this.gbBaslerAdvancedOptions.TabStop = false;
            this.gbBaslerAdvancedOptions.Text = "Basler";
            // 
            // btnEnableTimerGrab
            // 
            this.btnEnableTimerGrab.BackColor = System.Drawing.Color.Firebrick;
            this.btnEnableTimerGrab.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnableTimerGrab.Location = new System.Drawing.Point(118, 77);
            this.btnEnableTimerGrab.Name = "btnEnableTimerGrab";
            this.btnEnableTimerGrab.Size = new System.Drawing.Size(108, 23);
            this.btnEnableTimerGrab.TabIndex = 7;
            this.btnEnableTimerGrab.Text = "Start acquistion";
            this.btnEnableTimerGrab.UseVisualStyleBackColor = false;
            this.btnEnableTimerGrab.Click += new System.EventHandler(this.btnEnableTimerGrab_Click);
            // 
            // btnCameraFlagPreview
            // 
            this.btnCameraFlagPreview.BackColor = System.Drawing.Color.Firebrick;
            this.btnCameraFlagPreview.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCameraFlagPreview.Location = new System.Drawing.Point(118, 48);
            this.btnCameraFlagPreview.Name = "btnCameraFlagPreview";
            this.btnCameraFlagPreview.Size = new System.Drawing.Size(108, 23);
            this.btnCameraFlagPreview.TabIndex = 14;
            this.btnCameraFlagPreview.Text = "Enable preview";
            this.btnCameraFlagPreview.UseVisualStyleBackColor = false;
            this.btnCameraFlagPreview.Click += new System.EventHandler(this.btnCameraFlagPreview_Click);
            // 
            // btnGetTimesAvg
            // 
            this.btnGetTimesAvg.Location = new System.Drawing.Point(5, 77);
            this.btnGetTimesAvg.Name = "btnGetTimesAvg";
            this.btnGetTimesAvg.Size = new System.Drawing.Size(108, 23);
            this.btnGetTimesAvg.TabIndex = 12;
            this.btnGetTimesAvg.Text = "Get times avg";
            this.btnGetTimesAvg.UseVisualStyleBackColor = true;
            this.btnGetTimesAvg.Click += new System.EventHandler(this.btnGetTimesAvg_Click);
            // 
            // btnCameraFlagSave
            // 
            this.btnCameraFlagSave.BackColor = System.Drawing.Color.Firebrick;
            this.btnCameraFlagSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCameraFlagSave.Location = new System.Drawing.Point(118, 19);
            this.btnCameraFlagSave.Name = "btnCameraFlagSave";
            this.btnCameraFlagSave.Size = new System.Drawing.Size(108, 23);
            this.btnCameraFlagSave.TabIndex = 4;
            this.btnCameraFlagSave.Text = "Enable saving";
            this.btnCameraFlagSave.UseVisualStyleBackColor = false;
            this.btnCameraFlagSave.Click += new System.EventHandler(this.btnCameraFlagSave_Click);
            // 
            // btnEnableTimeMeasuring
            // 
            this.btnEnableTimeMeasuring.BackColor = System.Drawing.Color.Firebrick;
            this.btnEnableTimeMeasuring.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnableTimeMeasuring.Location = new System.Drawing.Point(5, 19);
            this.btnEnableTimeMeasuring.Name = "btnEnableTimeMeasuring";
            this.btnEnableTimeMeasuring.Size = new System.Drawing.Size(108, 23);
            this.btnEnableTimeMeasuring.TabIndex = 8;
            this.btnEnableTimeMeasuring.Text = "Enable measure";
            this.btnEnableTimeMeasuring.UseVisualStyleBackColor = false;
            this.btnEnableTimeMeasuring.Click += new System.EventHandler(this.btnEnableTimeMeasuring_Click);
            // 
            // btnGetTimeRaw
            // 
            this.btnGetTimeRaw.Location = new System.Drawing.Point(5, 48);
            this.btnGetTimeRaw.Name = "btnGetTimeRaw";
            this.btnGetTimeRaw.Size = new System.Drawing.Size(108, 23);
            this.btnGetTimeRaw.TabIndex = 11;
            this.btnGetTimeRaw.Text = "Get times raw";
            this.btnGetTimeRaw.UseVisualStyleBackColor = true;
            this.btnGetTimeRaw.Click += new System.EventHandler(this.btnGetTimeRaw_Click);
            // 
            // btnGetTimestamps
            // 
            this.btnGetTimestamps.Location = new System.Drawing.Point(257, 19);
            this.btnGetTimestamps.Name = "btnGetTimestamps";
            this.btnGetTimestamps.Size = new System.Drawing.Size(108, 23);
            this.btnGetTimestamps.TabIndex = 13;
            this.btnGetTimestamps.Text = "Get timestamps";
            this.btnGetTimestamps.UseVisualStyleBackColor = true;
            this.btnGetTimestamps.Click += new System.EventHandler(this.btnGetTimestamps_Click);
            // 
            // btnCamerasGrab
            // 
            this.btnCamerasGrab.Location = new System.Drawing.Point(246, 77);
            this.btnCamerasGrab.Name = "btnCamerasGrab";
            this.btnCamerasGrab.Size = new System.Drawing.Size(124, 23);
            this.btnCamerasGrab.TabIndex = 3;
            this.btnCamerasGrab.Text = "Send software trigger";
            this.btnCamerasGrab.UseVisualStyleBackColor = true;
            this.btnCamerasGrab.Click += new System.EventHandler(this.btnCamerasGrab_Click);
            // 
            // btnGetAllTimes
            // 
            this.btnGetAllTimes.Location = new System.Drawing.Point(257, 48);
            this.btnGetAllTimes.Name = "btnGetAllTimes";
            this.btnGetAllTimes.Size = new System.Drawing.Size(108, 23);
            this.btnGetAllTimes.TabIndex = 12;
            this.btnGetAllTimes.Text = "Get measurements";
            this.btnGetAllTimes.UseVisualStyleBackColor = true;
            this.btnGetAllTimes.Click += new System.EventHandler(this.btnGetAllTimes_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.Firebrick;
            this.btnStartServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartServer.Location = new System.Drawing.Point(257, 106);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(108, 23);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnDoOneSave
            // 
            this.btnDoOneSave.BackColor = System.Drawing.SystemColors.Info;
            this.btnDoOneSave.Location = new System.Drawing.Point(257, 19);
            this.btnDoOneSave.Name = "btnDoOneSave";
            this.btnDoOneSave.Size = new System.Drawing.Size(108, 23);
            this.btnDoOneSave.TabIndex = 15;
            this.btnDoOneSave.Text = "Save";
            this.btnDoOneSave.UseVisualStyleBackColor = false;
            this.btnDoOneSave.Click += new System.EventHandler(this.btnDoOneSave_Click);
            // 
            // gbCameraControls
            // 
            this.gbCameraControls.Controls.Add(this.btnImageNumberSet);
            this.gbCameraControls.Controls.Add(this.tbNewImageNumber);
            this.gbCameraControls.Controls.Add(this.lblNewImageNumber);
            this.gbCameraControls.Controls.Add(this.tbCurrentImageNumber);
            this.gbCameraControls.Controls.Add(this.lblCurrentImageNumber);
            this.gbCameraControls.Controls.Add(this.btnStartDlaAdama);
            this.gbCameraControls.Controls.Add(this.btnDoOneSave);
            this.gbCameraControls.Location = new System.Drawing.Point(6, 267);
            this.gbCameraControls.Name = "gbCameraControls";
            this.gbCameraControls.Size = new System.Drawing.Size(371, 112);
            this.gbCameraControls.TabIndex = 2;
            this.gbCameraControls.TabStop = false;
            this.gbCameraControls.Text = "Camera controls";
            // 
            // btnImageNumberSet
            // 
            this.btnImageNumberSet.BackColor = System.Drawing.SystemColors.Info;
            this.btnImageNumberSet.Location = new System.Drawing.Point(257, 68);
            this.btnImageNumberSet.Name = "btnImageNumberSet";
            this.btnImageNumberSet.Size = new System.Drawing.Size(108, 23);
            this.btnImageNumberSet.TabIndex = 21;
            this.btnImageNumberSet.Text = "Set image number";
            this.btnImageNumberSet.UseVisualStyleBackColor = false;
            this.btnImageNumberSet.Click += new System.EventHandler(this.btnImageNumberSet_Click);
            // 
            // tbNewImageNumber
            // 
            this.tbNewImageNumber.Location = new System.Drawing.Point(174, 71);
            this.tbNewImageNumber.Name = "tbNewImageNumber";
            this.tbNewImageNumber.Size = new System.Drawing.Size(62, 20);
            this.tbNewImageNumber.TabIndex = 20;
            this.tbNewImageNumber.Text = "0";
            this.tbNewImageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNewImageNumber
            // 
            this.lblNewImageNumber.AutoSize = true;
            this.lblNewImageNumber.Location = new System.Drawing.Point(7, 78);
            this.lblNewImageNumber.Name = "lblNewImageNumber";
            this.lblNewImageNumber.Size = new System.Drawing.Size(101, 13);
            this.lblNewImageNumber.TabIndex = 19;
            this.lblNewImageNumber.Text = "New image number:";
            // 
            // tbCurrentImageNumber
            // 
            this.tbCurrentImageNumber.Enabled = false;
            this.tbCurrentImageNumber.Location = new System.Drawing.Point(174, 42);
            this.tbCurrentImageNumber.Name = "tbCurrentImageNumber";
            this.tbCurrentImageNumber.Size = new System.Drawing.Size(62, 20);
            this.tbCurrentImageNumber.TabIndex = 18;
            this.tbCurrentImageNumber.Text = "0";
            this.tbCurrentImageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCurrentImageNumber
            // 
            this.lblCurrentImageNumber.AutoSize = true;
            this.lblCurrentImageNumber.Location = new System.Drawing.Point(7, 49);
            this.lblCurrentImageNumber.Name = "lblCurrentImageNumber";
            this.lblCurrentImageNumber.Size = new System.Drawing.Size(113, 13);
            this.lblCurrentImageNumber.TabIndex = 17;
            this.lblCurrentImageNumber.Text = "Current image number:";
            // 
            // btnStartDlaAdama
            // 
            this.btnStartDlaAdama.BackColor = System.Drawing.Color.Firebrick;
            this.btnStartDlaAdama.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartDlaAdama.Location = new System.Drawing.Point(6, 19);
            this.btnStartDlaAdama.Name = "btnStartDlaAdama";
            this.btnStartDlaAdama.Size = new System.Drawing.Size(108, 23);
            this.btnStartDlaAdama.TabIndex = 16;
            this.btnStartDlaAdama.Text = "Start";
            this.btnStartDlaAdama.UseVisualStyleBackColor = false;
            this.btnStartDlaAdama.Click += new System.EventHandler(this.btnStartDlaAdama_Click);
            // 
            // btnBaslerCamerasOpen
            // 
            this.btnBaslerCamerasOpen.BackColor = System.Drawing.Color.Firebrick;
            this.btnBaslerCamerasOpen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBaslerCamerasOpen.Location = new System.Drawing.Point(257, 132);
            this.btnBaslerCamerasOpen.Name = "btnBaslerCamerasOpen";
            this.btnBaslerCamerasOpen.Size = new System.Drawing.Size(108, 23);
            this.btnBaslerCamerasOpen.TabIndex = 0;
            this.btnBaslerCamerasOpen.Text = "Open";
            this.btnBaslerCamerasOpen.UseVisualStyleBackColor = false;
            this.btnBaslerCamerasOpen.Click += new System.EventHandler(this.btnBaslerCamerasOpen_Click);
            // 
            // gbBaslerCameras
            // 
            this.gbBaslerCameras.Controls.Add(this.tbFrameDelay);
            this.gbBaslerCameras.Controls.Add(this.cbPK3);
            this.gbBaslerCameras.Controls.Add(this.cbPK2);
            this.gbBaslerCameras.Controls.Add(this.cbPK1);
            this.gbBaslerCameras.Controls.Add(this.cbSC3);
            this.gbBaslerCameras.Controls.Add(this.cbRL);
            this.gbBaslerCameras.Controls.Add(this.cbSC2);
            this.gbBaslerCameras.Controls.Add(this.cbSC1);
            this.gbBaslerCameras.Controls.Add(this.cbTL);
            this.gbBaslerCameras.Controls.Add(this.cbBL);
            this.gbBaslerCameras.Controls.Add(this.cbRR);
            this.gbBaslerCameras.Controls.Add(this.btnBaslerCamerasOpen);
            this.gbBaslerCameras.Controls.Add(this.cbC);
            this.gbBaslerCameras.Controls.Add(this.cbBR);
            this.gbBaslerCameras.Controls.Add(this.cbTR);
            this.gbBaslerCameras.Location = new System.Drawing.Point(12, 12);
            this.gbBaslerCameras.Name = "gbBaslerCameras";
            this.gbBaslerCameras.Size = new System.Drawing.Size(371, 161);
            this.gbBaslerCameras.TabIndex = 3;
            this.gbBaslerCameras.TabStop = false;
            this.gbBaslerCameras.Text = "Basler Cameras";
            // 
            // tbFrameDelay
            // 
            this.tbFrameDelay.Location = new System.Drawing.Point(271, 106);
            this.tbFrameDelay.Name = "tbFrameDelay";
            this.tbFrameDelay.Size = new System.Drawing.Size(78, 20);
            this.tbFrameDelay.TabIndex = 14;
            this.tbFrameDelay.Text = "25000";
            this.tbFrameDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbPK3
            // 
            this.cbPK3.AutoSize = true;
            this.cbPK3.Location = new System.Drawing.Point(319, 65);
            this.cbPK3.Name = "cbPK3";
            this.cbPK3.Size = new System.Drawing.Size(46, 17);
            this.cbPK3.TabIndex = 15;
            this.cbPK3.Text = "PK3";
            this.cbPK3.UseVisualStyleBackColor = true;
            // 
            // cbPK2
            // 
            this.cbPK2.AutoSize = true;
            this.cbPK2.Location = new System.Drawing.Point(319, 42);
            this.cbPK2.Name = "cbPK2";
            this.cbPK2.Size = new System.Drawing.Size(46, 17);
            this.cbPK2.TabIndex = 14;
            this.cbPK2.Text = "PK2";
            this.cbPK2.UseVisualStyleBackColor = true;
            // 
            // cbPK1
            // 
            this.cbPK1.AutoSize = true;
            this.cbPK1.Location = new System.Drawing.Point(319, 19);
            this.cbPK1.Name = "cbPK1";
            this.cbPK1.Size = new System.Drawing.Size(46, 17);
            this.cbPK1.TabIndex = 14;
            this.cbPK1.Text = "PK1";
            this.cbPK1.UseVisualStyleBackColor = true;
            // 
            // cbSC3
            // 
            this.cbSC3.AutoSize = true;
            this.cbSC3.Location = new System.Drawing.Point(152, 65);
            this.cbSC3.Name = "cbSC3";
            this.cbSC3.Size = new System.Drawing.Size(100, 17);
            this.cbSC3.TabIndex = 14;
            this.cbSC3.Text = "21130749 (sc3)";
            this.cbSC3.UseVisualStyleBackColor = true;
            // 
            // cbRL
            // 
            this.cbRL.AutoSize = true;
            this.cbRL.Location = new System.Drawing.Point(151, 111);
            this.cbRL.Name = "cbRL";
            this.cbRL.Size = new System.Drawing.Size(97, 17);
            this.cbRL.TabIndex = 14;
            this.cbRL.Text = "21130751 (RL)";
            this.cbRL.UseVisualStyleBackColor = true;
            // 
            // cbSC2
            // 
            this.cbSC2.AutoSize = true;
            this.cbSC2.Location = new System.Drawing.Point(151, 19);
            this.cbSC2.Name = "cbSC2";
            this.cbSC2.Size = new System.Drawing.Size(100, 17);
            this.cbSC2.TabIndex = 13;
            this.cbSC2.Text = "21125996 (sc2)";
            this.cbSC2.UseVisualStyleBackColor = true;
            // 
            // cbSC1
            // 
            this.cbSC1.AutoSize = true;
            this.cbSC1.Location = new System.Drawing.Point(151, 42);
            this.cbSC1.Name = "cbSC1";
            this.cbSC1.Size = new System.Drawing.Size(100, 17);
            this.cbSC1.TabIndex = 12;
            this.cbSC1.Text = "21130748 (sc1)";
            this.cbSC1.UseVisualStyleBackColor = true;
            // 
            // cbTL
            // 
            this.cbTL.AutoSize = true;
            this.cbTL.Location = new System.Drawing.Point(10, 88);
            this.cbTL.Name = "cbTL";
            this.cbTL.Size = new System.Drawing.Size(120, 17);
            this.cbTL.TabIndex = 12;
            this.cbTL.Text = "21238114 (TopLeft)";
            this.cbTL.UseVisualStyleBackColor = true;
            // 
            // cbBL
            // 
            this.cbBL.AutoSize = true;
            this.cbBL.Location = new System.Drawing.Point(10, 111);
            this.cbBL.Name = "cbBL";
            this.cbBL.Size = new System.Drawing.Size(134, 17);
            this.cbBL.TabIndex = 13;
            this.cbBL.Text = "21238115 (BottomLeft)";
            this.cbBL.UseVisualStyleBackColor = true;
            // 
            // cbRR
            // 
            this.cbRR.AutoSize = true;
            this.cbRR.Location = new System.Drawing.Point(152, 88);
            this.cbRR.Name = "cbRR";
            this.cbRR.Size = new System.Drawing.Size(99, 17);
            this.cbRR.TabIndex = 13;
            this.cbRR.Text = "21130750 (RR)";
            this.cbRR.UseVisualStyleBackColor = true;
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Checked = true;
            this.cbC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbC.Location = new System.Drawing.Point(10, 42);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(114, 17);
            this.cbC.TabIndex = 12;
            this.cbC.Text = "21238112 (Center)";
            this.cbC.UseVisualStyleBackColor = true;
            // 
            // cbBR
            // 
            this.cbBR.AutoSize = true;
            this.cbBR.Location = new System.Drawing.Point(10, 65);
            this.cbBR.Name = "cbBR";
            this.cbBR.Size = new System.Drawing.Size(141, 17);
            this.cbBR.TabIndex = 12;
            this.cbBR.Text = "21238113 (BottomRight)";
            this.cbBR.UseVisualStyleBackColor = true;
            // 
            // cbTR
            // 
            this.cbTR.AutoSize = true;
            this.cbTR.Location = new System.Drawing.Point(10, 19);
            this.cbTR.Name = "cbTR";
            this.cbTR.Size = new System.Drawing.Size(127, 17);
            this.cbTR.TabIndex = 11;
            this.cbTR.Text = "21162137 (TopRight)";
            this.cbTR.UseVisualStyleBackColor = true;
            // 
            // timerGrabImage
            // 
            this.timerGrabImage.Interval = 5;
            this.timerGrabImage.Tick += new System.EventHandler(this.timerGrabImage_Tick);
            // 
            // gbUSBCameras
            // 
            this.gbUSBCameras.Controls.Add(this.lblOpenCVNumber);
            this.gbUSBCameras.Controls.Add(this.tbC525Number);
            this.gbUSBCameras.Controls.Add(this.tbSphereNumber);
            this.gbUSBCameras.Controls.Add(this.btnUSBOpenLogitechC525);
            this.gbUSBCameras.Controls.Add(this.btnUSBOpenLogitechSphere);
            this.gbUSBCameras.Location = new System.Drawing.Point(6, 179);
            this.gbUSBCameras.Name = "gbUSBCameras";
            this.gbUSBCameras.Size = new System.Drawing.Size(372, 82);
            this.gbUSBCameras.TabIndex = 6;
            this.gbUSBCameras.TabStop = false;
            this.gbUSBCameras.Text = "USB Cameras";
            // 
            // lblOpenCVNumber
            // 
            this.lblOpenCVNumber.AutoSize = true;
            this.lblOpenCVNumber.Location = new System.Drawing.Point(127, 39);
            this.lblOpenCVNumber.Name = "lblOpenCVNumber";
            this.lblOpenCVNumber.Size = new System.Drawing.Size(126, 13);
            this.lblOpenCVNumber.TabIndex = 14;
            this.lblOpenCVNumber.Text = "OpenCV camera number:";
            // 
            // tbC525Number
            // 
            this.tbC525Number.Location = new System.Drawing.Point(292, 22);
            this.tbC525Number.Name = "tbC525Number";
            this.tbC525Number.Size = new System.Drawing.Size(48, 20);
            this.tbC525Number.TabIndex = 17;
            this.tbC525Number.Text = "0";
            // 
            // tbSphereNumber
            // 
            this.tbSphereNumber.Location = new System.Drawing.Point(292, 51);
            this.tbSphereNumber.Name = "tbSphereNumber";
            this.tbSphereNumber.Size = new System.Drawing.Size(48, 20);
            this.tbSphereNumber.TabIndex = 16;
            this.tbSphereNumber.Text = "1";
            // 
            // btnUSBOpenLogitechC525
            // 
            this.btnUSBOpenLogitechC525.BackColor = System.Drawing.Color.Firebrick;
            this.btnUSBOpenLogitechC525.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUSBOpenLogitechC525.Location = new System.Drawing.Point(7, 19);
            this.btnUSBOpenLogitechC525.Name = "btnUSBOpenLogitechC525";
            this.btnUSBOpenLogitechC525.Size = new System.Drawing.Size(108, 23);
            this.btnUSBOpenLogitechC525.TabIndex = 15;
            this.btnUSBOpenLogitechC525.Text = "Open C525";
            this.btnUSBOpenLogitechC525.UseVisualStyleBackColor = false;
            this.btnUSBOpenLogitechC525.Click += new System.EventHandler(this.btnUSBOpenLogitechC525_Click);
            // 
            // btnUSBOpenLogitechSphere
            // 
            this.btnUSBOpenLogitechSphere.BackColor = System.Drawing.Color.Firebrick;
            this.btnUSBOpenLogitechSphere.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUSBOpenLogitechSphere.Location = new System.Drawing.Point(6, 48);
            this.btnUSBOpenLogitechSphere.Name = "btnUSBOpenLogitechSphere";
            this.btnUSBOpenLogitechSphere.Size = new System.Drawing.Size(108, 23);
            this.btnUSBOpenLogitechSphere.TabIndex = 14;
            this.btnUSBOpenLogitechSphere.Text = "Open Sphere";
            this.btnUSBOpenLogitechSphere.UseVisualStyleBackColor = false;
            this.btnUSBOpenLogitechSphere.Click += new System.EventHandler(this.btnUSBOpenLogitechSphere_Click);
            // 
            // imageBoxUSBC525
            // 
            this.imageBoxUSBC525.Location = new System.Drawing.Point(738, 32);
            this.imageBoxUSBC525.Name = "imageBoxUSBC525";
            this.imageBoxUSBC525.Size = new System.Drawing.Size(320, 240);
            this.imageBoxUSBC525.TabIndex = 10;
            this.imageBoxUSBC525.TabStop = false;
            // 
            // imageBoxUSBSphere
            // 
            this.imageBoxUSBSphere.Location = new System.Drawing.Point(738, 307);
            this.imageBoxUSBSphere.Name = "imageBoxUSBSphere";
            this.imageBoxUSBSphere.Size = new System.Drawing.Size(320, 240);
            this.imageBoxUSBSphere.TabIndex = 11;
            this.imageBoxUSBSphere.TabStop = false;
            // 
            // lblUSBC525
            // 
            this.lblUSBC525.AutoSize = true;
            this.lblUSBC525.Location = new System.Drawing.Point(739, 13);
            this.lblUSBC525.Name = "lblUSBC525";
            this.lblUSBC525.Size = new System.Drawing.Size(76, 13);
            this.lblUSBC525.TabIndex = 12;
            this.lblUSBC525.Text = "Logitech C525";
            // 
            // lblUSBSphere
            // 
            this.lblUSBSphere.AutoSize = true;
            this.lblUSBSphere.Location = new System.Drawing.Point(739, 291);
            this.lblUSBSphere.Name = "lblUSBSphere";
            this.lblUSBSphere.Size = new System.Drawing.Size(85, 13);
            this.lblUSBSphere.TabIndex = 13;
            this.lblUSBSphere.Text = "Logitech Sphere";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 559);
            this.Controls.Add(this.lblUSBSphere);
            this.Controls.Add(this.lblUSBC525);
            this.Controls.Add(this.imageBoxUSBSphere);
            this.Controls.Add(this.imageBoxUSBC525);
            this.Controls.Add(this.gbUSBCameras);
            this.Controls.Add(this.gbBaslerCameras);
            this.Controls.Add(this.gbCameraControls);
            this.Controls.Add(this.gbMainOptions);
            this.Controls.Add(this.rtbMain);
            this.Name = "frmMain";
            this.Text = "Wifibot camera managment application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbMainOptions.ResumeLayout(false);
            this.gbBaslerAdvancedOptions.ResumeLayout(false);
            this.gbCameraControls.ResumeLayout(false);
            this.gbCameraControls.PerformLayout();
            this.gbBaslerCameras.ResumeLayout(false);
            this.gbBaslerCameras.PerformLayout();
            this.gbUSBCameras.ResumeLayout(false);
            this.gbUSBCameras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxUSBC525)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxUSBSphere)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.GroupBox gbMainOptions;
        private System.Windows.Forms.GroupBox gbCameraControls;
        private System.Windows.Forms.Button btnBaslerCamerasOpen;
        private System.Windows.Forms.Button btnCamerasGrab;
        private System.Windows.Forms.Button btnCameraFlagSave;
        private System.Windows.Forms.GroupBox gbBaslerCameras;
        private System.Windows.Forms.Timer timerGrabImage;
        private System.Windows.Forms.Button btnEnableTimerGrab;
        private System.Windows.Forms.CheckBox cbRL;
        private System.Windows.Forms.CheckBox cbSC2;
        private System.Windows.Forms.CheckBox cbRR;
        private System.Windows.Forms.CheckBox cbSC1;
        private System.Windows.Forms.CheckBox cbBL;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.CheckBox cbBR;
        private System.Windows.Forms.CheckBox cbTL;
        private System.Windows.Forms.CheckBox cbTR;
        private System.Windows.Forms.CheckBox cbSC3;
        private System.Windows.Forms.Button btnEnableTimeMeasuring;
        private System.Windows.Forms.Button btnGetTimesAvg;
        private System.Windows.Forms.Button btnGetTimeRaw;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnGetAllTimes;
        private System.Windows.Forms.Button btnGetTimestamps;
        private System.Windows.Forms.GroupBox gbUSBCameras;
        private Emgu.CV.UI.ImageBox imageBoxUSBC525;
        private Emgu.CV.UI.ImageBox imageBoxUSBSphere;
        private System.Windows.Forms.Button btnCameraFlagPreview;
        private System.Windows.Forms.Button btnDoOneSave;
        private System.Windows.Forms.CheckBox cbPK3;
        private System.Windows.Forms.CheckBox cbPK2;
        private System.Windows.Forms.CheckBox cbPK1;
        private System.Windows.Forms.Button btnUSBOpenLogitechC525;
        private System.Windows.Forms.Button btnUSBOpenLogitechSphere;
        private System.Windows.Forms.TextBox tbC525Number;
        private System.Windows.Forms.TextBox tbSphereNumber;
        private System.Windows.Forms.Label lblUSBC525;
        private System.Windows.Forms.Label lblUSBSphere;
        private System.Windows.Forms.GroupBox gbBaslerAdvancedOptions;
        private System.Windows.Forms.Button btnStartDlaAdama;
        private System.Windows.Forms.Button btnImageNumberSet;
        private System.Windows.Forms.TextBox tbNewImageNumber;
        private System.Windows.Forms.Label lblNewImageNumber;
        private System.Windows.Forms.TextBox tbCurrentImageNumber;
        private System.Windows.Forms.Label lblCurrentImageNumber;
        private System.Windows.Forms.Label lblOpenCVNumber;
        private System.Windows.Forms.TextBox tbFrameDelay;
    }
}

