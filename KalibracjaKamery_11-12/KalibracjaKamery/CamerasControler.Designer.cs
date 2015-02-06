namespace KalibracjaKamery
{
    partial class Cameras_controler
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
            this.Mode_select_UP = new System.Windows.Forms.Button();
            this.Display_FPS = new System.Windows.Forms.TextBox();
            this.Mode_select_DOWN = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NameOfFolder = new System.Windows.Forms.TextBox();
            this.Name_of_file = new System.Windows.Forms.TextBox();
            this.Start_numbering_on = new System.Windows.Forms.TextBox();
            this.Change_numbering = new System.Windows.Forms.Button();
            this.List_of_cameras = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Display_photo_number = new System.Windows.Forms.Label();
            this.Select_file_format = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Reset_photo_number = new System.Windows.Forms.Button();
            this.Saving_group_box = new System.Windows.Forms.GroupBox();
            this.Show_path_to_saving_folder = new System.Windows.Forms.TextBox();
            this.User_folder_select = new System.Windows.Forms.RadioButton();
            this.Open_folder_tree = new System.Windows.Forms.Button();
            this.OpenFileFolder = new System.Windows.Forms.Button();
            this.Standard_folder_select = new System.Windows.Forms.RadioButton();
            this.openGeneralFolder = new System.Windows.Forms.Button();
            this.Save_picture = new System.Windows.Forms.Button();
            this.AlertInfo = new System.Windows.Forms.Label();
            this.Reverse_in_axis_X = new System.Windows.Forms.CheckBox();
            this.Colorful = new System.Windows.Forms.CheckBox();
            this.tester = new System.Windows.Forms.TextBox();
            this.Working_cameras = new System.Windows.Forms.ComboBox();
            this.Checked_List_Box = new System.Windows.Forms.CheckedListBox();
            this.Saving_group_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mode_select_UP
            // 
            this.Mode_select_UP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Mode_select_UP.Enabled = false;
            this.Mode_select_UP.Location = new System.Drawing.Point(2, 15);
            this.Mode_select_UP.Name = "Mode_select_UP";
            this.Mode_select_UP.Size = new System.Drawing.Size(90, 60);
            this.Mode_select_UP.TabIndex = 0;
            this.Mode_select_UP.Text = "Turn ON";
            this.Mode_select_UP.UseVisualStyleBackColor = true;
            this.Mode_select_UP.Click += new System.EventHandler(this.Mode_select_UP_Click);
            // 
            // Display_FPS
            // 
            this.Display_FPS.Enabled = false;
            this.Display_FPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Display_FPS.Location = new System.Drawing.Point(51, 607);
            this.Display_FPS.Multiline = true;
            this.Display_FPS.Name = "Display_FPS";
            this.Display_FPS.Size = new System.Drawing.Size(120, 50);
            this.Display_FPS.TabIndex = 2;
            this.Display_FPS.Tag = "";
            this.Display_FPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Display_FPS.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            // 
            // Mode_select_DOWN
            // 
            this.Mode_select_DOWN.Location = new System.Drawing.Point(2, 80);
            this.Mode_select_DOWN.Name = "Mode_select_DOWN";
            this.Mode_select_DOWN.Size = new System.Drawing.Size(90, 50);
            this.Mode_select_DOWN.TabIndex = 3;
            this.Mode_select_DOWN.Text = "Refresh the list of cameras ";
            this.Mode_select_DOWN.UseVisualStyleBackColor = true;
            this.Mode_select_DOWN.Click += new System.EventHandler(this.Mode_select_DOWN_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // Name_of_file
            // 
            this.Name_of_file.Location = new System.Drawing.Point(96, 81);
            this.Name_of_file.Name = "Name_of_file";
            this.Name_of_file.Size = new System.Drawing.Size(71, 20);
            this.Name_of_file.TabIndex = 6;
            this.Name_of_file.Text = "Foto";
            // 
            // Start_numbering_on
            // 
            this.Start_numbering_on.Location = new System.Drawing.Point(139, 134);
            this.Start_numbering_on.Name = "Start_numbering_on";
            this.Start_numbering_on.Size = new System.Drawing.Size(76, 20);
            this.Start_numbering_on.TabIndex = 9;
            // 
            // Change_numbering
            // 
            this.Change_numbering.Location = new System.Drawing.Point(9, 160);
            this.Change_numbering.Name = "Change_numbering";
            this.Change_numbering.Size = new System.Drawing.Size(206, 23);
            this.Change_numbering.TabIndex = 10;
            this.Change_numbering.Text = "Confirm the change of numbering";
            this.Change_numbering.UseVisualStyleBackColor = true;
            this.Change_numbering.Click += new System.EventHandler(this.Change_numbering_Click);
            // 
            // List_of_cameras
            // 
            this.List_of_cameras.CheckBoxes = true;
            this.List_of_cameras.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.List_of_cameras.Location = new System.Drawing.Point(2, 151);
            this.List_of_cameras.Name = "List_of_cameras";
            this.List_of_cameras.Size = new System.Drawing.Size(217, 86);
            this.List_of_cameras.TabIndex = 11;
            this.List_of_cameras.UseCompatibleStateImageBehavior = false;
            this.List_of_cameras.View = System.Windows.Forms.View.SmallIcon;
            this.List_of_cameras.SelectedIndexChanged += new System.EventHandler(this.List_of_cameras_SelectedIndexChanged);
            this.List_of_cameras.Click += new System.EventHandler(this.List_of_cameras_SelectedIndexChanged);
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
            this.label5.Location = new System.Drawing.Point(6, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Photo number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Display_photo_number
            // 
            this.Display_photo_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Display_photo_number.ForeColor = System.Drawing.Color.Black;
            this.Display_photo_number.Location = new System.Drawing.Point(2, 255);
            this.Display_photo_number.Name = "Display_photo_number";
            this.Display_photo_number.Size = new System.Drawing.Size(217, 90);
            this.Display_photo_number.TabIndex = 16;
            this.Display_photo_number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Display_photo_number.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            // 
            // Select_file_format
            // 
            this.Select_file_format.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Select_file_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_file_format.Items.AddRange(new object[] {
            "bmp",
            "jpeg",
            "png",
            "tiff"});
            this.Select_file_format.Location = new System.Drawing.Point(139, 107);
            this.Select_file_format.Name = "Select_file_format";
            this.Select_file_format.Size = new System.Drawing.Size(76, 21);
            this.Select_file_format.TabIndex = 17;
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
            // Reset_photo_number
            // 
            this.Reset_photo_number.Location = new System.Drawing.Point(175, 244);
            this.Reset_photo_number.Name = "Reset_photo_number";
            this.Reset_photo_number.Size = new System.Drawing.Size(48, 22);
            this.Reset_photo_number.TabIndex = 19;
            this.Reset_photo_number.Text = "Reset";
            this.Reset_photo_number.UseVisualStyleBackColor = true;
            this.Reset_photo_number.Click += new System.EventHandler(this.Reset_photo_number_Click);
            // 
            // Saving_group_box
            // 
            this.Saving_group_box.Controls.Add(this.Show_path_to_saving_folder);
            this.Saving_group_box.Controls.Add(this.User_folder_select);
            this.Saving_group_box.Controls.Add(this.Open_folder_tree);
            this.Saving_group_box.Controls.Add(this.OpenFileFolder);
            this.Saving_group_box.Controls.Add(this.Standard_folder_select);
            this.Saving_group_box.Controls.Add(this.openGeneralFolder);
            this.Saving_group_box.Controls.Add(this.label2);
            this.Saving_group_box.Controls.Add(this.NameOfFolder);
            this.Saving_group_box.Controls.Add(this.label3);
            this.Saving_group_box.Controls.Add(this.Select_file_format);
            this.Saving_group_box.Controls.Add(this.label6);
            this.Saving_group_box.Controls.Add(this.label4);
            this.Saving_group_box.Controls.Add(this.Name_of_file);
            this.Saving_group_box.Controls.Add(this.Change_numbering);
            this.Saving_group_box.Controls.Add(this.Start_numbering_on);
            this.Saving_group_box.Location = new System.Drawing.Point(2, 328);
            this.Saving_group_box.Name = "Saving_group_box";
            this.Saving_group_box.Size = new System.Drawing.Size(221, 249);
            this.Saving_group_box.TabIndex = 20;
            this.Saving_group_box.TabStop = false;
            this.Saving_group_box.Text = "Saving";
            // 
            // Show_path_to_saving_folder
            // 
            this.Show_path_to_saving_folder.Enabled = false;
            this.Show_path_to_saving_folder.Location = new System.Drawing.Point(9, 187);
            this.Show_path_to_saving_folder.Multiline = true;
            this.Show_path_to_saving_folder.Name = "Show_path_to_saving_folder";
            this.Show_path_to_saving_folder.Size = new System.Drawing.Size(206, 62);
            this.Show_path_to_saving_folder.TabIndex = 24;
            // 
            // User_folder_select
            // 
            this.User_folder_select.AutoSize = true;
            this.User_folder_select.Location = new System.Drawing.Point(9, 19);
            this.User_folder_select.Name = "User_folder_select";
            this.User_folder_select.Size = new System.Drawing.Size(76, 17);
            this.User_folder_select.TabIndex = 26;
            this.User_folder_select.TabStop = true;
            this.User_folder_select.Text = "User folder";
            this.User_folder_select.UseVisualStyleBackColor = true;
            this.User_folder_select.CheckedChanged += new System.EventHandler(this.User_path_select_CheckedChanged);
            // 
            // Open_folder_tree
            // 
            this.Open_folder_tree.Location = new System.Drawing.Point(96, 52);
            this.Open_folder_tree.Name = "Open_folder_tree";
            this.Open_folder_tree.Size = new System.Drawing.Size(119, 23);
            this.Open_folder_tree.TabIndex = 23;
            this.Open_folder_tree.Text = "Open folder tree";
            this.Open_folder_tree.UseVisualStyleBackColor = true;
            this.Open_folder_tree.Click += new System.EventHandler(this.Open_folder_tree_Click);
            // 
            // OpenFileFolder
            // 
            this.OpenFileFolder.Location = new System.Drawing.Point(173, 81);
            this.OpenFileFolder.Name = "OpenFileFolder";
            this.OpenFileFolder.Size = new System.Drawing.Size(42, 20);
            this.OpenFileFolder.TabIndex = 20;
            this.OpenFileFolder.Text = "Show";
            this.OpenFileFolder.UseVisualStyleBackColor = true;
            this.OpenFileFolder.Click += new System.EventHandler(this.Open_file_folder_Click);
            // 
            // Standard_folder_select
            // 
            this.Standard_folder_select.AutoSize = true;
            this.Standard_folder_select.Location = new System.Drawing.Point(96, 19);
            this.Standard_folder_select.Name = "Standard_folder_select";
            this.Standard_folder_select.Size = new System.Drawing.Size(97, 17);
            this.Standard_folder_select.TabIndex = 25;
            this.Standard_folder_select.TabStop = true;
            this.Standard_folder_select.Text = "Standard folder";
            this.Standard_folder_select.UseVisualStyleBackColor = true;
            this.Standard_folder_select.CheckedChanged += new System.EventHandler(this.Standard_path_select_CheckedChanged);
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
            // Save_picture
            // 
            this.Save_picture.BackgroundImage = global::KalibracjaKamery.Properties.Resources.saving;
            this.Save_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Save_picture.Enabled = false;
            this.Save_picture.Location = new System.Drawing.Point(104, 15);
            this.Save_picture.Name = "Save_picture";
            this.Save_picture.Size = new System.Drawing.Size(115, 115);
            this.Save_picture.TabIndex = 21;
            this.Save_picture.UseVisualStyleBackColor = true;
            this.Save_picture.Click += new System.EventHandler(this.Save_picture_Click);
            this.Save_picture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Save_picture_KeyDown);
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
            // Reverse_in_axis_X
            // 
            this.Reverse_in_axis_X.AutoSize = true;
            this.Reverse_in_axis_X.Checked = true;
            this.Reverse_in_axis_X.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Reverse_in_axis_X.Location = new System.Drawing.Point(11, 583);
            this.Reverse_in_axis_X.Name = "Reverse_in_axis_X";
            this.Reverse_in_axis_X.Size = new System.Drawing.Size(108, 17);
            this.Reverse_in_axis_X.TabIndex = 27;
            this.Reverse_in_axis_X.Text = "Reverse in axis X";
            this.Reverse_in_axis_X.UseVisualStyleBackColor = true;
            this.Reverse_in_axis_X.CheckedChanged += new System.EventHandler(this.Reverse_in_axis_X_CheckedChanged);
            // 
            // Colorful
            // 
            this.Colorful.AutoSize = true;
            this.Colorful.Checked = true;
            this.Colorful.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Colorful.Location = new System.Drawing.Point(143, 583);
            this.Colorful.Name = "Colorful";
            this.Colorful.Size = new System.Drawing.Size(50, 17);
            this.Colorful.TabIndex = 28;
            this.Colorful.Text = "Color";
            this.Colorful.UseVisualStyleBackColor = true;
            this.Colorful.CheckedChanged += new System.EventHandler(this.Colorful_CheckedChanged);
            // 
            // tester
            // 
            this.tester.Location = new System.Drawing.Point(123, 606);
            this.tester.Name = "tester";
            this.tester.Size = new System.Drawing.Size(100, 20);
            this.tester.TabIndex = 29;
            // 
            // Working_cameras
            // 
            this.Working_cameras.FormattingEnabled = true;
            this.Working_cameras.Location = new System.Drawing.Point(104, 629);
            this.Working_cameras.Name = "Working_cameras";
            this.Working_cameras.Size = new System.Drawing.Size(121, 21);
            this.Working_cameras.TabIndex = 30;
            // 
            // Checked_List_Box
            // 
            this.Checked_List_Box.Location = new System.Drawing.Point(72, 283);
            this.Checked_List_Box.Name = "Checked_List_Box";
            this.Checked_List_Box.Size = new System.Drawing.Size(120, 94);
            this.Checked_List_Box.TabIndex = 0;
            // 
            // Cameras_controler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 662);
            this.Controls.Add(this.Checked_List_Box);
            this.Controls.Add(this.Working_cameras);
            this.Controls.Add(this.tester);
            this.Controls.Add(this.Colorful);
            this.Controls.Add(this.Reverse_in_axis_X);
            this.Controls.Add(this.AlertInfo);
            this.Controls.Add(this.Save_picture);
            this.Controls.Add(this.Saving_group_box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Reset_photo_number);
            this.Controls.Add(this.Display_photo_number);
            this.Controls.Add(this.List_of_cameras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mode_select_DOWN);
            this.Controls.Add(this.Display_FPS);
            this.Controls.Add(this.Mode_select_UP);
            this.Name = "Cameras_controler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CamerasControler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.CamerasControler_Load);
            this.Click += new System.EventHandler(this.Save_picture_fokus_ON);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nowy);
            this.Saving_group_box.ResumeLayout(false);
            this.Saving_group_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Mode_select_UP;
        private System.Windows.Forms.TextBox Display_FPS;
        private System.Windows.Forms.Button Mode_select_DOWN;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameOfFolder;
        private System.Windows.Forms.TextBox Name_of_file;
        private System.Windows.Forms.TextBox Start_numbering_on;
        private System.Windows.Forms.Button Change_numbering;
        private System.Windows.Forms.ListView List_of_cameras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Display_photo_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Select_file_format;
        private System.Windows.Forms.Button Reset_photo_number;
        private System.Windows.Forms.GroupBox Saving_group_box;
        private System.Windows.Forms.Button Save_picture;
        private System.Windows.Forms.Label AlertInfo;
        private System.Windows.Forms.Button openGeneralFolder;
        private System.Windows.Forms.Button OpenFileFolder;
        private System.Windows.Forms.Button Open_folder_tree;
        private System.Windows.Forms.TextBox Show_path_to_saving_folder;
        private System.Windows.Forms.RadioButton Standard_folder_select;
        private System.Windows.Forms.RadioButton User_folder_select;
        private System.Windows.Forms.CheckBox Reverse_in_axis_X;
        private System.Windows.Forms.CheckBox Colorful;
        private System.Windows.Forms.TextBox tester;
        private System.Windows.Forms.ComboBox Working_cameras;
        private System.Windows.Forms.CheckedListBox Checked_List_Box;
    }
}

