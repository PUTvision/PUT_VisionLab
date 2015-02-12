namespace KalibracjaKamery
{
    partial class CamerasControler
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Switch_Camera = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.refreshListOfCameras = new System.Windows.Forms.Button();
            this.timer_1000ms = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NameOfFolder = new System.Windows.Forms.TextBox();
            this.NameOfFile = new System.Windows.Forms.TextBox();
            this.NewPhotoNumber = new System.Windows.Forms.TextBox();
            this.SetPhotoNumber = new System.Windows.Forms.Button();
            this.listOfCameras = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DisplayPhotoNumber = new System.Windows.Forms.Label();
            this.FileFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ResetPhotoNumber = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShowSavingPath = new System.Windows.Forms.TextBox();
            this.UserPath = new System.Windows.Forms.RadioButton();
            this.OpenFolderTree = new System.Windows.Forms.Button();
            this.OpenFileFolder = new System.Windows.Forms.Button();
            this.StandardPath = new System.Windows.Forms.RadioButton();
            this.openGeneralFolder = new System.Windows.Forms.Button();
            this.Save_photo = new System.Windows.Forms.Button();
            this.AlertInfo = new System.Windows.Forms.Label();
            this.UseColor = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Switch_Camera
            // 
            this.Switch_Camera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Switch_Camera.Enabled = false;
            this.Switch_Camera.Location = new System.Drawing.Point(2, 15);
            this.Switch_Camera.Name = "Switch_Camera";
            this.Switch_Camera.Size = new System.Drawing.Size(90, 60);
            this.Switch_Camera.TabIndex = 0;
            this.Switch_Camera.Text = "Turn ON";
            this.Switch_Camera.UseVisualStyleBackColor = true;
            this.Switch_Camera.Click += new System.EventHandler(this.Switch_Camera_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(51, 607);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 50);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Click += new System.EventHandler(this.Save_photo_fokus_ON);
            // 
            // refreshListOfCameras
            // 
            this.refreshListOfCameras.Location = new System.Drawing.Point(2, 80);
            this.refreshListOfCameras.Name = "refreshListOfCameras";
            this.refreshListOfCameras.Size = new System.Drawing.Size(90, 50);
            this.refreshListOfCameras.TabIndex = 3;
            this.refreshListOfCameras.Text = "Refresh the list of cameras ";
            this.refreshListOfCameras.UseVisualStyleBackColor = true;
            this.refreshListOfCameras.Click += new System.EventHandler(this.refreshListOfCameras_Click);
            // 
            // timer_1000ms
            // 
            this.timer_1000ms.Tick += new System.EventHandler(this.timer_1000ms_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "FPS";
            // 
            // NameOfFolder
            // 
            this.NameOfFolder.Location = new System.Drawing.Point(96, 53);
            this.NameOfFolder.Name = "NameOfFolder";
            this.NameOfFolder.Size = new System.Drawing.Size(71, 20);
            this.NameOfFolder.TabIndex = 5;
            this.NameOfFolder.Text = "NewFolder";
            // 
            // NameOfFile
            // 
            this.NameOfFile.Location = new System.Drawing.Point(96, 81);
            this.NameOfFile.Name = "NameOfFile";
            this.NameOfFile.Size = new System.Drawing.Size(71, 20);
            this.NameOfFile.TabIndex = 6;
            this.NameOfFile.Text = "Foto";
            // 
            // NewPhotoNumber
            // 
            this.NewPhotoNumber.Location = new System.Drawing.Point(139, 134);
            this.NewPhotoNumber.Name = "NewPhotoNumber";
            this.NewPhotoNumber.Size = new System.Drawing.Size(76, 20);
            this.NewPhotoNumber.TabIndex = 9;
            // 
            // SetPhotoNumber
            // 
            this.SetPhotoNumber.Location = new System.Drawing.Point(9, 160);
            this.SetPhotoNumber.Name = "SetPhotoNumber";
            this.SetPhotoNumber.Size = new System.Drawing.Size(206, 23);
            this.SetPhotoNumber.TabIndex = 10;
            this.SetPhotoNumber.Text = "Confirm the change of numbering";
            this.SetPhotoNumber.UseVisualStyleBackColor = true;
            this.SetPhotoNumber.Click += new System.EventHandler(this.SetPhotoNumber_Click);
            // 
            // listOfCameras
            // 
            this.listOfCameras.Location = new System.Drawing.Point(2, 151);
            this.listOfCameras.Name = "listOfCameras";
            this.listOfCameras.Size = new System.Drawing.Size(217, 86);
            this.listOfCameras.TabIndex = 11;
            this.listOfCameras.UseCompatibleStateImageBehavior = false;
            this.listOfCameras.View = System.Windows.Forms.View.Tile;
            this.listOfCameras.SelectedIndexChanged += new System.EventHandler(this.listOfCameras_Changed);
            this.listOfCameras.Click += new System.EventHandler(this.listOfCameras_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name of folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name of file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Start numbering from:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Photo number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayPhotoNumber
            // 
            this.DisplayPhotoNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DisplayPhotoNumber.ForeColor = System.Drawing.Color.Black;
            this.DisplayPhotoNumber.Location = new System.Drawing.Point(2, 255);
            this.DisplayPhotoNumber.Name = "DisplayPhotoNumber";
            this.DisplayPhotoNumber.Size = new System.Drawing.Size(217, 90);
            this.DisplayPhotoNumber.TabIndex = 16;
            this.DisplayPhotoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DisplayPhotoNumber.Click += new System.EventHandler(this.Save_photo_fokus_ON);
            // 
            // FileFormat
            // 
            this.FileFormat.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.FileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileFormat.Items.AddRange(new object[] {
            "bmp",
            "jpeg",
            "png",
            "tiff"});
            this.FileFormat.Location = new System.Drawing.Point(139, 107);
            this.FileFormat.Name = "FileFormat";
            this.FileFormat.Size = new System.Drawing.Size(76, 21);
            this.FileFormat.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "File Format";
            // 
            // ResetPhotoNumber
            // 
            this.ResetPhotoNumber.Location = new System.Drawing.Point(175, 244);
            this.ResetPhotoNumber.Name = "ResetPhotoNumber";
            this.ResetPhotoNumber.Size = new System.Drawing.Size(48, 22);
            this.ResetPhotoNumber.TabIndex = 19;
            this.ResetPhotoNumber.Text = "Reset";
            this.ResetPhotoNumber.UseVisualStyleBackColor = true;
            this.ResetPhotoNumber.Click += new System.EventHandler(this.ResetPhotoNumber_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShowSavingPath);
            this.groupBox1.Controls.Add(this.UserPath);
            this.groupBox1.Controls.Add(this.OpenFolderTree);
            this.groupBox1.Controls.Add(this.OpenFileFolder);
            this.groupBox1.Controls.Add(this.StandardPath);
            this.groupBox1.Controls.Add(this.openGeneralFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NameOfFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FileFormat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NameOfFile);
            this.groupBox1.Controls.Add(this.SetPhotoNumber);
            this.groupBox1.Controls.Add(this.NewPhotoNumber);
            this.groupBox1.Location = new System.Drawing.Point(2, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 249);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saving";
            // 
            // ShowSavingPath
            // 
            this.ShowSavingPath.Enabled = false;
            this.ShowSavingPath.Location = new System.Drawing.Point(9, 187);
            this.ShowSavingPath.Multiline = true;
            this.ShowSavingPath.Name = "ShowSavingPath";
            this.ShowSavingPath.Size = new System.Drawing.Size(206, 62);
            this.ShowSavingPath.TabIndex = 24;
            // 
            // UserPath
            // 
            this.UserPath.AutoSize = true;
            this.UserPath.Location = new System.Drawing.Point(9, 19);
            this.UserPath.Name = "UserPath";
            this.UserPath.Size = new System.Drawing.Size(72, 17);
            this.UserPath.TabIndex = 26;
            this.UserPath.TabStop = true;
            this.UserPath.Text = "User Path";
            this.UserPath.UseVisualStyleBackColor = true;
            this.UserPath.CheckedChanged += new System.EventHandler(this.UserPath_Changed);
            // 
            // OpenFolderTree
            // 
            this.OpenFolderTree.Location = new System.Drawing.Point(96, 52);
            this.OpenFolderTree.Name = "OpenFolderTree";
            this.OpenFolderTree.Size = new System.Drawing.Size(119, 23);
            this.OpenFolderTree.TabIndex = 23;
            this.OpenFolderTree.Text = "Open folder tree";
            this.OpenFolderTree.UseVisualStyleBackColor = true;
            this.OpenFolderTree.Click += new System.EventHandler(this.Select_the_folder_Click);
            // 
            // OpenFileFolder
            // 
            this.OpenFileFolder.Location = new System.Drawing.Point(173, 81);
            this.OpenFileFolder.Name = "OpenFileFolder";
            this.OpenFileFolder.Size = new System.Drawing.Size(42, 20);
            this.OpenFileFolder.TabIndex = 20;
            this.OpenFileFolder.Text = "Show";
            this.OpenFileFolder.UseVisualStyleBackColor = true;
            this.OpenFileFolder.Click += new System.EventHandler(this.OpenFileFolder_Click);
            // 
            // StandardPath
            // 
            this.StandardPath.AutoSize = true;
            this.StandardPath.Location = new System.Drawing.Point(96, 19);
            this.StandardPath.Name = "StandardPath";
            this.StandardPath.Size = new System.Drawing.Size(93, 17);
            this.StandardPath.TabIndex = 25;
            this.StandardPath.TabStop = true;
            this.StandardPath.Text = "Standard Path";
            this.StandardPath.UseVisualStyleBackColor = true;
            this.StandardPath.CheckedChanged += new System.EventHandler(this.StandardPath_Changed);
            // 
            // openGeneralFolder
            // 
            this.openGeneralFolder.Location = new System.Drawing.Point(173, 52);
            this.openGeneralFolder.Name = "openGeneralFolder";
            this.openGeneralFolder.Size = new System.Drawing.Size(42, 20);
            this.openGeneralFolder.TabIndex = 19;
            this.openGeneralFolder.Text = "Show";
            this.openGeneralFolder.UseVisualStyleBackColor = true;
            this.openGeneralFolder.Click += new System.EventHandler(this.openGeneralFolder_Click);
            // 
            // Save_photo
            // 
            this.Save_photo.BackgroundImage = global::KalibracjaKamery.Properties.Resources.saving;
            this.Save_photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Save_photo.Enabled = false;
            this.Save_photo.Location = new System.Drawing.Point(104, 15);
            this.Save_photo.Name = "Save_photo";
            this.Save_photo.Size = new System.Drawing.Size(115, 115);
            this.Save_photo.TabIndex = 21;
            this.Save_photo.UseVisualStyleBackColor = true;
            this.Save_photo.Click += new System.EventHandler(this.Save_photo_Click);
            this.Save_photo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Save_photo_KeyDown);
            // 
            // AlertInfo
            // 
            this.AlertInfo.AutoSize = true;
            this.AlertInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlertInfo.ForeColor = System.Drawing.Color.Red;
            this.AlertInfo.Location = new System.Drawing.Point(-2, 129);
            this.AlertInfo.Name = "AlertInfo";
            this.AlertInfo.Size = new System.Drawing.Size(0, 20);
            this.AlertInfo.TabIndex = 22;
            // 
            // UseColor
            // 
            this.UseColor.AutoSize = true;
            this.UseColor.Checked = true;
            this.UseColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseColor.Location = new System.Drawing.Point(143, 583);
            this.UseColor.Name = "UseColor";
            this.UseColor.Size = new System.Drawing.Size(50, 17);
            this.UseColor.TabIndex = 28;
            this.UseColor.Text = "Color";
            this.UseColor.UseVisualStyleBackColor = true;
            this.UseColor.CheckedChanged += new System.EventHandler(this.UseColor_CheckedChanged);
            // 
            // CamerasControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 662);
            this.Controls.Add(this.UseColor);
            this.Controls.Add(this.AlertInfo);
            this.Controls.Add(this.Save_photo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResetPhotoNumber);
            this.Controls.Add(this.DisplayPhotoNumber);
            this.Controls.Add(this.listOfCameras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshListOfCameras);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Switch_Camera);
            this.Name = "CamerasControler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CamerasControler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.Save_photo_fokus_ON);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Switch_Camera;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button refreshListOfCameras;
        private System.Windows.Forms.Timer timer_1000ms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameOfFolder;
        private System.Windows.Forms.TextBox NameOfFile;
        private System.Windows.Forms.TextBox NewPhotoNumber;
        private System.Windows.Forms.Button SetPhotoNumber;
        private System.Windows.Forms.ListView listOfCameras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DisplayPhotoNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox FileFormat;
        private System.Windows.Forms.Button ResetPhotoNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Save_photo;
        private System.Windows.Forms.Label AlertInfo;
        private System.Windows.Forms.Button openGeneralFolder;
        private System.Windows.Forms.Button OpenFileFolder;
        private System.Windows.Forms.Button OpenFolderTree;
        private System.Windows.Forms.TextBox ShowSavingPath;
        private System.Windows.Forms.RadioButton StandardPath;
        private System.Windows.Forms.RadioButton UserPath;
        private System.Windows.Forms.CheckBox UseColor;
    }
}

