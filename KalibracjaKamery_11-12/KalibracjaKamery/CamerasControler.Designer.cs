﻿namespace KalibracjaKamery
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
            this.KameraON = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.refreshListOfCameras = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nazwaFolderu = new System.Windows.Forms.TextBox();
            this.nazwaZdjecia = new System.Windows.Forms.TextBox();
            this.poczatekNumeracji = new System.Windows.Forms.TextBox();
            this.zacznijOd = new System.Windows.Forms.Button();
            this.listaKamer = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zdjecieNumer = new System.Windows.Forms.Label();
            this.rozszerzenie = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resetujNumer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OpenFileFolder = new System.Windows.Forms.Button();
            this.openGeneralFolder = new System.Windows.Forms.Button();
            this.Zdjecie = new System.Windows.Forms.Button();
            this.overWrieAlert = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KameraON
            // 
            this.KameraON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.KameraON.Enabled = false;
            this.KameraON.Location = new System.Drawing.Point(2, 16);
            this.KameraON.Name = "KameraON";
            this.KameraON.Size = new System.Drawing.Size(91, 58);
            this.KameraON.TabIndex = 0;
            this.KameraON.Text = "Turn ON a selected camera";
            this.KameraON.UseVisualStyleBackColor = true;
            this.KameraON.Click += new System.EventHandler(this.KameraON_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(51, 564);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 75);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Click += new System.EventHandler(this.Zdjecie_fokus_ON);
            // 
            // refreshListOfCameras
            // 
            this.refreshListOfCameras.Location = new System.Drawing.Point(2, 80);
            this.refreshListOfCameras.Name = "refreshListOfCameras";
            this.refreshListOfCameras.Size = new System.Drawing.Size(91, 46);
            this.refreshListOfCameras.TabIndex = 3;
            this.refreshListOfCameras.Text = "Refresh the list of cameras ";
            this.refreshListOfCameras.UseVisualStyleBackColor = true;
            this.refreshListOfCameras.Click += new System.EventHandler(this.refreshListOfCameras_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "FPS";
            // 
            // nazwaFolderu
            // 
            this.nazwaFolderu.Location = new System.Drawing.Point(96, 20);
            this.nazwaFolderu.Name = "nazwaFolderu";
            this.nazwaFolderu.Size = new System.Drawing.Size(71, 20);
            this.nazwaFolderu.TabIndex = 5;
            this.nazwaFolderu.Text = "NowyFolder";
            // 
            // nazwaZdjecia
            // 
            this.nazwaZdjecia.Location = new System.Drawing.Point(96, 48);
            this.nazwaZdjecia.Name = "nazwaZdjecia";
            this.nazwaZdjecia.Size = new System.Drawing.Size(71, 20);
            this.nazwaZdjecia.TabIndex = 6;
            this.nazwaZdjecia.Text = "Foto";
            // 
            // poczatekNumeracji
            // 
            this.poczatekNumeracji.Location = new System.Drawing.Point(139, 101);
            this.poczatekNumeracji.Name = "poczatekNumeracji";
            this.poczatekNumeracji.Size = new System.Drawing.Size(70, 20);
            this.poczatekNumeracji.TabIndex = 9;
            // 
            // zacznijOd
            // 
            this.zacznijOd.Location = new System.Drawing.Point(9, 127);
            this.zacznijOd.Name = "zacznijOd";
            this.zacznijOd.Size = new System.Drawing.Size(200, 25);
            this.zacznijOd.TabIndex = 10;
            this.zacznijOd.Text = "Confirm the change of numbering";
            this.zacznijOd.UseVisualStyleBackColor = true;
            this.zacznijOd.Click += new System.EventHandler(this.zacznijOd_Click);
            // 
            // listaKamer
            // 
            this.listaKamer.Location = new System.Drawing.Point(2, 151);
            this.listaKamer.MultiSelect = false;
            this.listaKamer.Name = "listaKamer";
            this.listaKamer.Size = new System.Drawing.Size(217, 86);
            this.listaKamer.TabIndex = 11;
            this.listaKamer.UseCompatibleStateImageBehavior = false;
            this.listaKamer.View = System.Windows.Forms.View.Tile;
            this.listaKamer.SelectedIndexChanged += new System.EventHandler(this.listaKamer_SelectedIndexChanged);
            this.listaKamer.Click += new System.EventHandler(this.listaKamer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name of folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name of file";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
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
            this.label5.Location = new System.Drawing.Point(60, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Photo number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zdjecieNumer
            // 
            this.zdjecieNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zdjecieNumer.ForeColor = System.Drawing.Color.Black;
            this.zdjecieNumer.Location = new System.Drawing.Point(2, 255);
            this.zdjecieNumer.Name = "zdjecieNumer";
            this.zdjecieNumer.Size = new System.Drawing.Size(217, 90);
            this.zdjecieNumer.TabIndex = 16;
            this.zdjecieNumer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zdjecieNumer.Click += new System.EventHandler(this.Zdjecie_fokus_ON);
            // 
            // rozszerzenie
            // 
            this.rozszerzenie.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rozszerzenie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rozszerzenie.Items.AddRange(new object[] {
            "bmp",
            "jpeg",
            "png",
            "tiff"});
            this.rozszerzenie.Location = new System.Drawing.Point(139, 74);
            this.rozszerzenie.Name = "rozszerzenie";
            this.rozszerzenie.Size = new System.Drawing.Size(70, 21);
            this.rozszerzenie.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Type file";
            // 
            // resetujNumer
            // 
            this.resetujNumer.Location = new System.Drawing.Point(57, 348);
            this.resetujNumer.Name = "resetujNumer";
            this.resetujNumer.Size = new System.Drawing.Size(118, 23);
            this.resetujNumer.TabIndex = 19;
            this.resetujNumer.Text = "Reset Photo number";
            this.resetujNumer.UseVisualStyleBackColor = true;
            this.resetujNumer.Click += new System.EventHandler(this.resetujNumer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OpenFileFolder);
            this.groupBox1.Controls.Add(this.openGeneralFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nazwaFolderu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rozszerzenie);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nazwaZdjecia);
            this.groupBox1.Controls.Add(this.zacznijOd);
            this.groupBox1.Controls.Add(this.poczatekNumeracji);
            this.groupBox1.Location = new System.Drawing.Point(2, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 171);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saving";
            // 
            // OpenFileFolder
            // 
            this.OpenFileFolder.Location = new System.Drawing.Point(173, 45);
            this.OpenFileFolder.Name = "OpenFileFolder";
            this.OpenFileFolder.Size = new System.Drawing.Size(42, 23);
            this.OpenFileFolder.TabIndex = 20;
            this.OpenFileFolder.Text = "Show";
            this.OpenFileFolder.UseVisualStyleBackColor = true;
            this.OpenFileFolder.Click += new System.EventHandler(this.OpenFileFolder_Click);
            // 
            // openGeneralFolder
            // 
            this.openGeneralFolder.Location = new System.Drawing.Point(173, 18);
            this.openGeneralFolder.Name = "openGeneralFolder";
            this.openGeneralFolder.Size = new System.Drawing.Size(42, 23);
            this.openGeneralFolder.TabIndex = 19;
            this.openGeneralFolder.Text = "Show";
            this.openGeneralFolder.UseVisualStyleBackColor = true;
            this.openGeneralFolder.Click += new System.EventHandler(this.openGeneralFolder_Click);
            // 
            // Zdjecie
            // 
            this.Zdjecie.BackgroundImage = global::KalibracjaKamery.Properties.Resources.saving;
            this.Zdjecie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Zdjecie.Enabled = false;
            this.Zdjecie.Location = new System.Drawing.Point(109, 16);
            this.Zdjecie.Name = "Zdjecie";
            this.Zdjecie.Size = new System.Drawing.Size(110, 110);
            this.Zdjecie.TabIndex = 21;
            this.Zdjecie.UseVisualStyleBackColor = true;
            this.Zdjecie.Click += new System.EventHandler(this.Zdjecie_Click);
            this.Zdjecie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zdjecie_KeyDown);
            // 
            // overWrieAlert
            // 
            this.overWrieAlert.AutoSize = true;
            this.overWrieAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.overWrieAlert.ForeColor = System.Drawing.Color.Red;
            this.overWrieAlert.Location = new System.Drawing.Point(-2, 129);
            this.overWrieAlert.Name = "overWrieAlert";
            this.overWrieAlert.Size = new System.Drawing.Size(0, 20);
            this.overWrieAlert.TabIndex = 22;
            this.overWrieAlert.Visible = false;
            // 
            // CamerasControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 662);
            this.Controls.Add(this.overWrieAlert);
            this.Controls.Add(this.Zdjecie);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resetujNumer);
            this.Controls.Add(this.zdjecieNumer);
            this.Controls.Add(this.listaKamer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshListOfCameras);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.KameraON);
            this.Name = "CamerasControler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CamerasControler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Click += new System.EventHandler(this.Zdjecie_fokus_ON);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nowy);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button KameraON;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button refreshListOfCameras;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazwaFolderu;
        private System.Windows.Forms.TextBox nazwaZdjecia;
        private System.Windows.Forms.TextBox poczatekNumeracji;
        private System.Windows.Forms.Button zacznijOd;
        private System.Windows.Forms.ListView listaKamer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label zdjecieNumer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox rozszerzenie;
        private System.Windows.Forms.Button resetujNumer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Zdjecie;
        private System.Windows.Forms.Label overWrieAlert;
        private System.Windows.Forms.Button openGeneralFolder;
        private System.Windows.Forms.Button OpenFileFolder;
    }
}

