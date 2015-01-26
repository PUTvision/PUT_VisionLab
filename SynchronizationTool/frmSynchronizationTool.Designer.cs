namespace SynchronizationTool
{
    partial class frmSynchronizationTool
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
            this.imgBoxWebcam = new Emgu.CV.UI.ImageBox();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnSendStartCommand = new System.Windows.Forms.Button();
            this.btnSendExitCommand = new System.Windows.Forms.Button();
            this.btnOpenWebcam = new System.Windows.Forms.Button();
            this.timerWebcamPreview = new System.Windows.Forms.Timer(this.components);
            this.lblImageCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBoxWebcam
            // 
            this.imgBoxWebcam.Location = new System.Drawing.Point(338, 12);
            this.imgBoxWebcam.Name = "imgBoxWebcam";
            this.imgBoxWebcam.Size = new System.Drawing.Size(1270, 720);
            this.imgBoxWebcam.TabIndex = 2;
            this.imgBoxWebcam.TabStop = false;
            // 
            // rtbMain
            // 
            this.rtbMain.Location = new System.Drawing.Point(12, 12);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(320, 480);
            this.rtbMain.TabIndex = 3;
            this.rtbMain.Text = "";
            this.rtbMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMain_KeyDown);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(12, 541);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(148, 34);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnSendStartCommand
            // 
            this.btnSendStartCommand.Location = new System.Drawing.Point(12, 581);
            this.btnSendStartCommand.Name = "btnSendStartCommand";
            this.btnSendStartCommand.Size = new System.Drawing.Size(148, 34);
            this.btnSendStartCommand.TabIndex = 5;
            this.btnSendStartCommand.Text = "Send start command";
            this.btnSendStartCommand.UseVisualStyleBackColor = true;
            this.btnSendStartCommand.Click += new System.EventHandler(this.btnSendStartCommand_Click);
            // 
            // btnSendExitCommand
            // 
            this.btnSendExitCommand.Location = new System.Drawing.Point(12, 621);
            this.btnSendExitCommand.Name = "btnSendExitCommand";
            this.btnSendExitCommand.Size = new System.Drawing.Size(148, 34);
            this.btnSendExitCommand.TabIndex = 6;
            this.btnSendExitCommand.Text = "Send exit command";
            this.btnSendExitCommand.UseVisualStyleBackColor = true;
            this.btnSendExitCommand.Click += new System.EventHandler(this.btnSendExitCommand_Click);
            // 
            // btnOpenWebcam
            // 
            this.btnOpenWebcam.Location = new System.Drawing.Point(12, 501);
            this.btnOpenWebcam.Name = "btnOpenWebcam";
            this.btnOpenWebcam.Size = new System.Drawing.Size(148, 34);
            this.btnOpenWebcam.TabIndex = 7;
            this.btnOpenWebcam.Text = "Open webcam";
            this.btnOpenWebcam.UseVisualStyleBackColor = true;
            this.btnOpenWebcam.Click += new System.EventHandler(this.btnOpenWebcam_Click);
            // 
            // timerWebcamPreview
            // 
            this.timerWebcamPreview.Interval = 20;
            this.timerWebcamPreview.Tick += new System.EventHandler(this.timerWebcamPreview_Tick);
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblImageCounter.Location = new System.Drawing.Point(11, 694);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(284, 55);
            this.lblImageCounter.TabIndex = 8;
            this.lblImageCounter.Text = "NoInitialized";
            // 
            // frmSynchronizationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 762);
            this.Controls.Add(this.lblImageCounter);
            this.Controls.Add(this.btnOpenWebcam);
            this.Controls.Add(this.btnSendExitCommand);
            this.Controls.Add(this.btnSendStartCommand);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.rtbMain);
            this.Controls.Add(this.imgBoxWebcam);
            this.Name = "frmSynchronizationTool";
            this.Text = "Synchronization tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSynchronizationTool_FormClosing);
            this.Load += new System.EventHandler(this.frmSynchronizationTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxWebcam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imgBoxWebcam;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnSendStartCommand;
        private System.Windows.Forms.Button btnSendExitCommand;
        private System.Windows.Forms.Button btnOpenWebcam;
        private System.Windows.Forms.Timer timerWebcamPreview;
        private System.Windows.Forms.Label lblImageCounter;
    }
}

