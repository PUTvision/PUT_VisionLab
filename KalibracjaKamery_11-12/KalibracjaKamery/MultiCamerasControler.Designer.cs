namespace KalibracjaKamery
{
    partial class MultiCamerasControler
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
            this.Switch_Cameras = new System.Windows.Forms.Button();
            this.Display_FPS = new System.Windows.Forms.TextBox();
            this.Refresh_Camera_List = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Name_Of_Folder = new System.Windows.Forms.TextBox();
            this.Name_of_file = new System.Windows.Forms.TextBox();
            this.Start_numbering_on = new System.Windows.Forms.TextBox();
            this.Change_settings_button = new System.Windows.Forms.Button();
            this.List_of_cameras = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Display_photo_number = new System.Windows.Forms.Label();
            this.Select_file_format = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Reset_photo_number_button = new System.Windows.Forms.Button();
            this.Saving_group_box = new System.Windows.Forms.GroupBox();
            this.Display_Overwritten_Alert = new System.Windows.Forms.TextBox();
            this.Display_information = new System.Windows.Forms.TextBox();
            this.Open_folder_tree_button = new System.Windows.Forms.Button();
            this.Open_file_folder_button = new System.Windows.Forms.Button();
            this.Open_general_folder_button = new System.Windows.Forms.Button();
            this.Colorful = new System.Windows.Forms.CheckBox();
            this.Save_picture_button = new System.Windows.Forms.Button();
            this.Working_cameras = new System.Windows.Forms.ComboBox();
            this.List_Cameras_To_Save_Image = new System.Windows.Forms.ListView();
            this.AlertInfo = new System.Windows.Forms.Label();
            this.Saving_group_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // Switch_Cameras
            // 
            this.Switch_Cameras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Switch_Cameras.Enabled = false;
            this.Switch_Cameras.Location = new System.Drawing.Point(2, 15);
            this.Switch_Cameras.Name = "Switch_Cameras";
            this.Switch_Cameras.Size = new System.Drawing.Size(90, 60);
            this.Switch_Cameras.TabIndex = 0;
            this.Switch_Cameras.Text = "Turn ON";
            this.Switch_Cameras.UseVisualStyleBackColor = true;
            this.Switch_Cameras.Click += new System.EventHandler(this.Switch_Cameras_Click);
            // 
            // Display_FPS
            // 
            this.Display_FPS.Enabled = false;
            this.Display_FPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Display_FPS.Location = new System.Drawing.Point(56, 622);
            this.Display_FPS.Multiline = true;
            this.Display_FPS.Name = "Display_FPS";
            this.Display_FPS.Size = new System.Drawing.Size(107, 36);
            this.Display_FPS.TabIndex = 2;
            this.Display_FPS.Tag = "";
            this.Display_FPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Display_FPS.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            // 
            // Refresh_Camera_List
            // 
            this.Refresh_Camera_List.Location = new System.Drawing.Point(2, 80);
            this.Refresh_Camera_List.Name = "Refresh_Camera_List";
            this.Refresh_Camera_List.Size = new System.Drawing.Size(90, 50);
            this.Refresh_Camera_List.TabIndex = 3;
            this.Refresh_Camera_List.Text = "Refresh the list of cameras ";
            this.Refresh_Camera_List.UseVisualStyleBackColor = true;
            this.Refresh_Camera_List.Click += new System.EventHandler(this.Refresh_Camera_List_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 629);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "FPS";
            // 
            // Name_Of_Folder
            // 
            this.Name_Of_Folder.Location = new System.Drawing.Point(96, 165);
            this.Name_Of_Folder.Name = "Name_Of_Folder";
            this.Name_Of_Folder.Size = new System.Drawing.Size(71, 20);
            this.Name_Of_Folder.TabIndex = 5;
            this.Name_Of_Folder.Text = "NewFolder";
            // 
            // Name_of_file
            // 
            this.Name_of_file.Location = new System.Drawing.Point(96, 193);
            this.Name_of_file.Name = "Name_of_file";
            this.Name_of_file.Size = new System.Drawing.Size(71, 20);
            this.Name_of_file.TabIndex = 6;
            this.Name_of_file.Text = "Foto";
            // 
            // Start_numbering_on
            // 
            this.Start_numbering_on.Location = new System.Drawing.Point(139, 246);
            this.Start_numbering_on.Name = "Start_numbering_on";
            this.Start_numbering_on.Size = new System.Drawing.Size(76, 20);
            this.Start_numbering_on.TabIndex = 9;
            // 
            // Change_settings_button
            // 
            this.Change_settings_button.Location = new System.Drawing.Point(9, 272);
            this.Change_settings_button.Name = "Change_settings_button";
            this.Change_settings_button.Size = new System.Drawing.Size(206, 23);
            this.Change_settings_button.TabIndex = 10;
            this.Change_settings_button.Text = "Confirm change settings";
            this.Change_settings_button.UseVisualStyleBackColor = true;
            this.Change_settings_button.Click += new System.EventHandler(this.Change_settings_Click);
            // 
            // List_of_cameras
            // 
            this.List_of_cameras.CheckBoxes = true;
            this.List_of_cameras.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.List_of_cameras.Location = new System.Drawing.Point(2, 136);
            this.List_of_cameras.Name = "List_of_cameras";
            this.List_of_cameras.Size = new System.Drawing.Size(221, 86);
            this.List_of_cameras.TabIndex = 11;
            this.List_of_cameras.UseCompatibleStateImageBehavior = false;
            this.List_of_cameras.View = System.Windows.Forms.View.SmallIcon;
            this.List_of_cameras.SelectedIndexChanged += new System.EventHandler(this.List_of_cameras_Changed);
            this.List_of_cameras.Click += new System.EventHandler(this.List_of_cameras_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name of folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name of file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Start numbering on:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(5, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Photo number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Display_photo_number
            // 
            this.Display_photo_number.BackColor = System.Drawing.SystemColors.Control;
            this.Display_photo_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Display_photo_number.ForeColor = System.Drawing.Color.Black;
            this.Display_photo_number.Location = new System.Drawing.Point(4, 36);
            this.Display_photo_number.Name = "Display_photo_number";
            this.Display_photo_number.Size = new System.Drawing.Size(211, 90);
            this.Display_photo_number.TabIndex = 16;
            this.Display_photo_number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Display_photo_number.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            // 
            // Select_file_format
            // 
            this.Select_file_format.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Select_file_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_file_format.Enabled = false;
            this.Select_file_format.Items.AddRange(new object[] {
            "bmp",
            "jpeg",
            "png",
            "tiff"});
            this.Select_file_format.Location = new System.Drawing.Point(139, 219);
            this.Select_file_format.Name = "Select_file_format";
            this.Select_file_format.Size = new System.Drawing.Size(76, 21);
            this.Select_file_format.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "File Format";
            // 
            // Reset_photo_number_button
            // 
            this.Reset_photo_number_button.Location = new System.Drawing.Point(162, 21);
            this.Reset_photo_number_button.Name = "Reset_photo_number_button";
            this.Reset_photo_number_button.Size = new System.Drawing.Size(48, 22);
            this.Reset_photo_number_button.TabIndex = 19;
            this.Reset_photo_number_button.Text = "Reset";
            this.Reset_photo_number_button.UseVisualStyleBackColor = true;
            this.Reset_photo_number_button.Click += new System.EventHandler(this.Reset_photo_number_Click);
            // 
            // Saving_group_box
            // 
            this.Saving_group_box.Controls.Add(this.AlertInfo);
            this.Saving_group_box.Controls.Add(this.Display_Overwritten_Alert);
            this.Saving_group_box.Controls.Add(this.Reset_photo_number_button);
            this.Saving_group_box.Controls.Add(this.Display_information);
            this.Saving_group_box.Controls.Add(this.Open_folder_tree_button);
            this.Saving_group_box.Controls.Add(this.Open_file_folder_button);
            this.Saving_group_box.Controls.Add(this.label5);
            this.Saving_group_box.Controls.Add(this.Open_general_folder_button);
            this.Saving_group_box.Controls.Add(this.label2);
            this.Saving_group_box.Controls.Add(this.Name_Of_Folder);
            this.Saving_group_box.Controls.Add(this.label3);
            this.Saving_group_box.Controls.Add(this.Select_file_format);
            this.Saving_group_box.Controls.Add(this.label6);
            this.Saving_group_box.Controls.Add(this.label4);
            this.Saving_group_box.Controls.Add(this.Name_of_file);
            this.Saving_group_box.Controls.Add(this.Change_settings_button);
            this.Saving_group_box.Controls.Add(this.Start_numbering_on);
            this.Saving_group_box.Controls.Add(this.Display_photo_number);
            this.Saving_group_box.Enabled = false;
            this.Saving_group_box.Location = new System.Drawing.Point(2, 259);
            this.Saving_group_box.Name = "Saving_group_box";
            this.Saving_group_box.Size = new System.Drawing.Size(221, 357);
            this.Saving_group_box.TabIndex = 20;
            this.Saving_group_box.TabStop = false;
            this.Saving_group_box.Text = "Saving";
            // 
            // Display_Overwritten_Alert
            // 
            this.Display_Overwritten_Alert.Location = new System.Drawing.Point(9, 327);
            this.Display_Overwritten_Alert.Multiline = true;
            this.Display_Overwritten_Alert.Name = "Display_Overwritten_Alert";
            this.Display_Overwritten_Alert.Size = new System.Drawing.Size(206, 28);
            this.Display_Overwritten_Alert.TabIndex = 29;
            // 
            // Display_information
            // 
            this.Display_information.Location = new System.Drawing.Point(9, 301);
            this.Display_information.Multiline = true;
            this.Display_information.Name = "Display_information";
            this.Display_information.Size = new System.Drawing.Size(206, 28);
            this.Display_information.TabIndex = 27;
            // 
            // Open_folder_tree_button
            // 
            this.Open_folder_tree_button.Location = new System.Drawing.Point(96, 137);
            this.Open_folder_tree_button.Name = "Open_folder_tree_button";
            this.Open_folder_tree_button.Size = new System.Drawing.Size(119, 23);
            this.Open_folder_tree_button.TabIndex = 23;
            this.Open_folder_tree_button.Text = "Open folder tree";
            this.Open_folder_tree_button.UseVisualStyleBackColor = true;
            this.Open_folder_tree_button.Click += new System.EventHandler(this.Open_folder_tree_Click);
            // 
            // Open_file_folder_button
            // 
            this.Open_file_folder_button.Location = new System.Drawing.Point(173, 193);
            this.Open_file_folder_button.Name = "Open_file_folder_button";
            this.Open_file_folder_button.Size = new System.Drawing.Size(42, 20);
            this.Open_file_folder_button.TabIndex = 20;
            this.Open_file_folder_button.Text = "Show";
            this.Open_file_folder_button.UseVisualStyleBackColor = true;
            this.Open_file_folder_button.Click += new System.EventHandler(this.Open_file_folder_Click);
            // 
            // Open_general_folder_button
            // 
            this.Open_general_folder_button.Location = new System.Drawing.Point(173, 164);
            this.Open_general_folder_button.Name = "Open_general_folder_button";
            this.Open_general_folder_button.Size = new System.Drawing.Size(42, 20);
            this.Open_general_folder_button.TabIndex = 19;
            this.Open_general_folder_button.Text = "Show";
            this.Open_general_folder_button.UseVisualStyleBackColor = true;
            this.Open_general_folder_button.Click += new System.EventHandler(this.openGeneralFolder_Click);
            // 
            // Colorful
            // 
            this.Colorful.AutoSize = true;
            this.Colorful.Checked = true;
            this.Colorful.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Colorful.Location = new System.Drawing.Point(169, 622);
            this.Colorful.Name = "Colorful";
            this.Colorful.Size = new System.Drawing.Size(50, 17);
            this.Colorful.TabIndex = 28;
            this.Colorful.Text = "Color";
            this.Colorful.UseVisualStyleBackColor = true;
            // 
            // Save_picture_button
            // 
            this.Save_picture_button.BackgroundImage = global::KalibracjaKamery.Properties.Resources.saving;
            this.Save_picture_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Save_picture_button.Enabled = false;
            this.Save_picture_button.Location = new System.Drawing.Point(104, 15);
            this.Save_picture_button.Name = "Save_picture_button";
            this.Save_picture_button.Size = new System.Drawing.Size(115, 115);
            this.Save_picture_button.TabIndex = 21;
            this.Save_picture_button.UseVisualStyleBackColor = true;
            this.Save_picture_button.Click += new System.EventHandler(this.Save_picture_Click);
            this.Save_picture_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Save_picture_KeyDown);
            // 
            // Working_cameras
            // 
            this.Working_cameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Working_cameras.Location = new System.Drawing.Point(2, 232);
            this.Working_cameras.Name = "Working_cameras";
            this.Working_cameras.Size = new System.Drawing.Size(221, 21);
            this.Working_cameras.TabIndex = 30;
            this.Working_cameras.SelectedIndexChanged += new System.EventHandler(this.Working_cameras_Changed);
            // 
            // List_Cameras_To_Save_Image
            // 
            this.List_Cameras_To_Save_Image.CheckBoxes = true;
            this.List_Cameras_To_Save_Image.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.List_Cameras_To_Save_Image.Location = new System.Drawing.Point(2, 136);
            this.List_Cameras_To_Save_Image.Name = "List_Cameras_To_Save_Image";
            this.List_Cameras_To_Save_Image.Size = new System.Drawing.Size(221, 86);
            this.List_Cameras_To_Save_Image.TabIndex = 31;
            this.List_Cameras_To_Save_Image.UseCompatibleStateImageBehavior = false;
            this.List_Cameras_To_Save_Image.View = System.Windows.Forms.View.SmallIcon;
            this.List_Cameras_To_Save_Image.Visible = false;
            // 
            // AlertInfo
            // 
            this.AlertInfo.AutoSize = true;
            this.AlertInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlertInfo.ForeColor = System.Drawing.Color.Red;
            this.AlertInfo.Location = new System.Drawing.Point(7, 330);
            this.AlertInfo.Name = "AlertInfo";
            this.AlertInfo.Size = new System.Drawing.Size(0, 20);
            this.AlertInfo.TabIndex = 22;
            // 
            // MultiCamerasControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 662);
            this.Controls.Add(this.List_Cameras_To_Save_Image);
            this.Controls.Add(this.Working_cameras);
            this.Controls.Add(this.Save_picture_button);
            this.Controls.Add(this.Colorful);
            this.Controls.Add(this.Saving_group_box);
            this.Controls.Add(this.Refresh_Camera_List);
            this.Controls.Add(this.Switch_Cameras);
            this.Controls.Add(this.List_of_cameras);
            this.Controls.Add(this.Display_FPS);
            this.Controls.Add(this.label1);
            this.Name = "MultiCamerasControler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Multi cameras controler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.CamerasControler_Load);
            this.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            this.Saving_group_box.ResumeLayout(false);
            this.Saving_group_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Switch_Cameras;
        private System.Windows.Forms.TextBox Display_FPS;
        private System.Windows.Forms.Button Refresh_Camera_List;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Name_Of_Folder;
        private System.Windows.Forms.TextBox Name_of_file;
        private System.Windows.Forms.TextBox Start_numbering_on;
        private System.Windows.Forms.Button Change_settings_button;
        private System.Windows.Forms.ListView List_of_cameras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Display_photo_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Select_file_format;
        private System.Windows.Forms.Button Reset_photo_number_button;
        private System.Windows.Forms.GroupBox Saving_group_box;
        private System.Windows.Forms.Button Save_picture_button;
        private System.Windows.Forms.Button Open_general_folder_button;
        private System.Windows.Forms.Button Open_file_folder_button;
        private System.Windows.Forms.Button Open_folder_tree_button;
        private System.Windows.Forms.CheckBox Colorful;
        private System.Windows.Forms.ComboBox Working_cameras;
        private System.Windows.Forms.ListView List_Cameras_To_Save_Image;
        private System.Windows.Forms.TextBox Display_information;
        private System.Windows.Forms.Label AlertInfo;
        private System.Windows.Forms.TextBox Display_Overwritten_Alert;
    }
}

