namespace BaslerCameraCalibrationTool
{
    partial class frmBaslerCamerasCalibrationTool
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
            this.btnBaslerCamerasOpen = new System.Windows.Forms.Button();
            this.gbBaslerCameras = new System.Windows.Forms.GroupBox();
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
            this.btnEnableTimerGrab = new System.Windows.Forms.Button();
            this.timerGrabImage = new System.Windows.Forms.Timer(this.components);
            this.lblLogitech = new System.Windows.Forms.Label();
            this.imageBoxLogitech = new Emgu.CV.UI.ImageBox();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.gbBaslerCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxLogitech)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMain
            // 
            this.rtbMain.Location = new System.Drawing.Point(389, 12);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(339, 428);
            this.rtbMain.TabIndex = 0;
            this.rtbMain.Text = "";
            this.rtbMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMain_KeyDown);
            // 
            // btnBaslerCamerasOpen
            // 
            this.btnBaslerCamerasOpen.BackColor = System.Drawing.Color.Firebrick;
            this.btnBaslerCamerasOpen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBaslerCamerasOpen.Location = new System.Drawing.Point(254, 88);
            this.btnBaslerCamerasOpen.Name = "btnBaslerCamerasOpen";
            this.btnBaslerCamerasOpen.Size = new System.Drawing.Size(108, 23);
            this.btnBaslerCamerasOpen.TabIndex = 1;
            this.btnBaslerCamerasOpen.Text = "Open";
            this.btnBaslerCamerasOpen.UseVisualStyleBackColor = false;
            this.btnBaslerCamerasOpen.Click += new System.EventHandler(this.btnBaslerCamerasOpen_Click);
            this.btnBaslerCamerasOpen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMain_KeyDown);
            // 
            // gbBaslerCameras
            // 
            this.gbBaslerCameras.Controls.Add(this.btnBaslerCamerasOpen);
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
            this.gbBaslerCameras.Controls.Add(this.cbC);
            this.gbBaslerCameras.Controls.Add(this.cbBR);
            this.gbBaslerCameras.Controls.Add(this.cbTR);
            this.gbBaslerCameras.Location = new System.Drawing.Point(12, 13);
            this.gbBaslerCameras.Name = "gbBaslerCameras";
            this.gbBaslerCameras.Size = new System.Drawing.Size(371, 161);
            this.gbBaslerCameras.TabIndex = 4;
            this.gbBaslerCameras.TabStop = false;
            this.gbBaslerCameras.Text = "Basler Cameras";
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
            // btnEnableTimerGrab
            // 
            this.btnEnableTimerGrab.BackColor = System.Drawing.Color.Firebrick;
            this.btnEnableTimerGrab.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEnableTimerGrab.Location = new System.Drawing.Point(266, 180);
            this.btnEnableTimerGrab.Name = "btnEnableTimerGrab";
            this.btnEnableTimerGrab.Size = new System.Drawing.Size(108, 23);
            this.btnEnableTimerGrab.TabIndex = 21;
            this.btnEnableTimerGrab.Text = "Start acquistion";
            this.btnEnableTimerGrab.UseVisualStyleBackColor = false;
            this.btnEnableTimerGrab.Click += new System.EventHandler(this.btnEnableTimerGrab_Click);
            // 
            // timerGrabImage
            // 
            this.timerGrabImage.Interval = 5;
            this.timerGrabImage.Tick += new System.EventHandler(this.timerGrabImage_Tick);
            // 
            // lblLogitech
            // 
            this.lblLogitech.AutoSize = true;
            this.lblLogitech.Location = new System.Drawing.Point(19, 229);
            this.lblLogitech.Name = "lblLogitech";
            this.lblLogitech.Size = new System.Drawing.Size(48, 13);
            this.lblLogitech.TabIndex = 22;
            this.lblLogitech.Text = "Logitech";
            // 
            // imageBoxLogitech
            // 
            this.imageBoxLogitech.Location = new System.Drawing.Point(12, 245);
            this.imageBoxLogitech.Name = "imageBoxLogitech";
            this.imageBoxLogitech.Size = new System.Drawing.Size(320, 240);
            this.imageBoxLogitech.TabIndex = 2;
            this.imageBoxLogitech.TabStop = false;
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblImageCounter.Location = new System.Drawing.Point(13, 181);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(109, 39);
            this.lblImageCounter.TabIndex = 23;
            this.lblImageCounter.Text = "label1";
            // 
            // frmBaslerCamerasCalibrationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 486);
            this.Controls.Add(this.lblImageCounter);
            this.Controls.Add(this.imageBoxLogitech);
            this.Controls.Add(this.lblLogitech);
            this.Controls.Add(this.btnEnableTimerGrab);
            this.Controls.Add(this.gbBaslerCameras);
            this.Controls.Add(this.rtbMain);
            this.Name = "frmBaslerCamerasCalibrationTool";
            this.Text = "Calibration tool for Basler cameras";
            this.Load += new System.EventHandler(this.frmBaslerCamerasCalibrationTool_Load);
            this.gbBaslerCameras.ResumeLayout(false);
            this.gbBaslerCameras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxLogitech)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Button btnBaslerCamerasOpen;
        private System.Windows.Forms.GroupBox gbBaslerCameras;
        private System.Windows.Forms.CheckBox cbPK3;
        private System.Windows.Forms.CheckBox cbPK2;
        private System.Windows.Forms.CheckBox cbPK1;
        private System.Windows.Forms.CheckBox cbSC3;
        private System.Windows.Forms.CheckBox cbRL;
        private System.Windows.Forms.CheckBox cbSC2;
        private System.Windows.Forms.CheckBox cbSC1;
        private System.Windows.Forms.CheckBox cbTL;
        private System.Windows.Forms.CheckBox cbBL;
        private System.Windows.Forms.CheckBox cbRR;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.CheckBox cbBR;
        private System.Windows.Forms.CheckBox cbTR;
        private System.Windows.Forms.Button btnEnableTimerGrab;
        private System.Windows.Forms.Timer timerGrabImage;
        private System.Windows.Forms.Label lblLogitech;
        private Emgu.CV.UI.ImageBox imageBoxLogitech;
        private System.Windows.Forms.Label lblImageCounter;

    }
}

