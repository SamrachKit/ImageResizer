/*********************************************************************************
    This file is part of Imagizer2.

    Imagizer2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Imagizer2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Imagizer2.  If not, see <http://www.gnu.org/licenses/>.

*********************************************************************************/

namespace Imagizer2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbInputDirectory = new System.Windows.Forms.GroupBox();
            this.cbRecusive = new System.Windows.Forms.CheckBox();
            this.btnInputBrowse = new System.Windows.Forms.Button();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.rbPixels = new System.Windows.Forms.RadioButton();
            this.btnSettings = new System.Windows.Forms.Button();
            this.rbPercent = new System.Windows.Forms.RadioButton();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.lblThreads = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.sbThreads = new System.Windows.Forms.VScrollBar();
            this.gbThreadingSetup = new System.Windows.Forms.GroupBox();
            this.rbBmp = new System.Windows.Forms.RadioButton();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.rbTiff = new System.Windows.Forms.RadioButton();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.pImageSize = new System.Windows.Forms.Panel();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.btnLockHeight = new System.Windows.Forms.Button();
            this.btnLockWidth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageSize = new System.Windows.Forms.TextBox();
            this.rbSetImageSize = new System.Windows.Forms.RadioButton();
            this.txtShortSize = new System.Windows.Forms.TextBox();
            this.rbSetShortSize = new System.Windows.Forms.RadioButton();
            this.txtLongSide = new System.Windows.Forms.TextBox();
            this.rbSetLongSide = new System.Windows.Forms.RadioButton();
            this.rbSetBothSize = new System.Windows.Forms.RadioButton();
            this.gbOutputSettings = new System.Windows.Forms.GroupBox();
            this.cbSize = new System.Windows.Forms.CheckBox();
            this.cbFormat = new System.Windows.Forms.CheckBox();
            this.gbOutputDirectory = new System.Windows.Forms.GroupBox();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.gbFormat = new System.Windows.Forms.GroupBox();
            this.rbPng = new System.Windows.Forms.RadioButton();
            this.rbGif = new System.Windows.Forms.RadioButton();
            this.rbJpeg = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblInfoMessage = new System.Windows.Forms.Label();
            this.gbInputDirectory.SuspendLayout();
            this.gbThreadingSetup.SuspendLayout();
            this.gbSize.SuspendLayout();
            this.pImageSize.SuspendLayout();
            this.gbOutputSettings.SuspendLayout();
            this.gbOutputDirectory.SuspendLayout();
            this.gbFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInputDirectory
            // 
            this.gbInputDirectory.Controls.Add(this.cbRecusive);
            this.gbInputDirectory.Controls.Add(this.btnInputBrowse);
            this.gbInputDirectory.Controls.Add(this.txtInputDir);
            this.gbInputDirectory.Location = new System.Drawing.Point(2, 2);
            this.gbInputDirectory.Name = "gbInputDirectory";
            this.gbInputDirectory.Size = new System.Drawing.Size(460, 62);
            this.gbInputDirectory.TabIndex = 6;
            this.gbInputDirectory.TabStop = false;
            this.gbInputDirectory.Text = "Input Directory";
            this.toolTip1.SetToolTip(this.gbInputDirectory, "Specify the input directory here. If \'Include Subdirectories\' is selected then th" +
        "e directory structure will be duplicated in the destination location.");
            // 
            // cbRecusive
            // 
            this.cbRecusive.AutoSize = true;
            this.cbRecusive.Location = new System.Drawing.Point(8, 42);
            this.cbRecusive.Name = "cbRecusive";
            this.cbRecusive.Size = new System.Drawing.Size(131, 17);
            this.cbRecusive.TabIndex = 2;
            this.cbRecusive.Text = "Include Subdirectories";
            this.toolTip1.SetToolTip(this.cbRecusive, "Specify the input directory here. If \'Include Subdirectories\' is selected then th" +
        "e directory structure will be duplicated in the destination location.");
            this.cbRecusive.UseVisualStyleBackColor = true;
            // 
            // btnInputBrowse
            // 
            this.btnInputBrowse.Location = new System.Drawing.Point(420, 13);
            this.btnInputBrowse.Name = "btnInputBrowse";
            this.btnInputBrowse.Size = new System.Drawing.Size(24, 24);
            this.btnInputBrowse.TabIndex = 1;
            this.btnInputBrowse.Text = "..";
            this.toolTip1.SetToolTip(this.btnInputBrowse, "Specify the input directory here. If \'Include Subdirectories\' is selected then th" +
        "e directory structure will be duplicated in the destination location.");
            this.btnInputBrowse.Click += new System.EventHandler(this.btnInputBrowse_Click);
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(8, 16);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(406, 20);
            this.txtInputDir.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtInputDir, "Specify the input directory here. If \'Include Subdirectories\' is selected then th" +
        "e directory structure will be duplicated in the destination location.");
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(12, 34);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "Height";
            this.toolTip1.SetToolTip(this.lblHeight, resources.GetString("lblHeight.ToolTip"));
            // 
            // rbPixels
            // 
            this.rbPixels.Location = new System.Drawing.Point(83, 57);
            this.rbPixels.Name = "rbPixels";
            this.rbPixels.Size = new System.Drawing.Size(64, 16);
            this.rbPixels.TabIndex = 15;
            this.rbPixels.Text = "Pixels";
            this.toolTip1.SetToolTip(this.rbPixels, "Resizing by pixel will set every single image to a specific size. When used with " +
        "aspect lock mode you can enter one dimention and the other one will be calculate" +
        "d automatically for each picture.");
            this.rbPixels.CheckedChanged += new System.EventHandler(this.rbPixels_CheckedChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(322, 17);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(72, 24);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Settings";
            this.toolTip1.SetToolTip(this.btnSettings, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            this.btnSettings.Visible = false;
            // 
            // rbPercent
            // 
            this.rbPercent.AutoSize = true;
            this.rbPercent.Checked = true;
            this.rbPercent.Location = new System.Drawing.Point(19, 57);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(62, 17);
            this.rbPercent.TabIndex = 14;
            this.rbPercent.TabStop = true;
            this.rbPercent.Text = "Percent";
            this.toolTip1.SetToolTip(this.rbPercent, "Resizing by percent will scale each picture according to it\'s own original diment" +
        "ions. This is handy if your images are not all the same size or aspect ratio.");
            this.rbPercent.CheckedChanged += new System.EventHandler(this.rbPercent_CheckedChanged);
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(2, 412);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(460, 24);
            this.progBar.TabIndex = 8;
            // 
            // lblThreads
            // 
            this.lblThreads.Location = new System.Drawing.Point(8, 16);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(96, 16);
            this.lblThreads.TabIndex = 0;
            this.lblThreads.Text = "Threads:";
            this.toolTip1.SetToolTip(this.lblThreads, resources.GetString("lblThreads.ToolTip"));
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(334, 366);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(128, 40);
            this.btnGo.TabIndex = 22;
            this.btnGo.Text = "Start";
            this.toolTip1.SetToolTip(this.btnGo, "Once you have selected your options, press go and the conversion will begin.");
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(72, 16);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(24, 20);
            this.txtThreadCount.TabIndex = 20;
            this.txtThreadCount.Text = "2";
            this.toolTip1.SetToolTip(this.txtThreadCount, resources.GetString("txtThreadCount.ToolTip"));
            this.txtThreadCount.TextChanged += new System.EventHandler(this.txtThreadCount_TextChanged);
            // 
            // sbThreads
            // 
            this.sbThreads.Location = new System.Drawing.Point(97, 13);
            this.sbThreads.Maximum = 64;
            this.sbThreads.Minimum = 1;
            this.sbThreads.Name = "sbThreads";
            this.sbThreads.Size = new System.Drawing.Size(20, 24);
            this.sbThreads.TabIndex = 21;
            this.toolTip1.SetToolTip(this.sbThreads, resources.GetString("sbThreads.ToolTip"));
            this.sbThreads.Value = 1;
            this.sbThreads.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbThreads_Scroll);
            // 
            // gbThreadingSetup
            // 
            this.gbThreadingSetup.Controls.Add(this.sbThreads);
            this.gbThreadingSetup.Controls.Add(this.txtThreadCount);
            this.gbThreadingSetup.Controls.Add(this.lblThreads);
            this.gbThreadingSetup.Location = new System.Drawing.Point(2, 366);
            this.gbThreadingSetup.Name = "gbThreadingSetup";
            this.gbThreadingSetup.Size = new System.Drawing.Size(121, 40);
            this.gbThreadingSetup.TabIndex = 9;
            this.gbThreadingSetup.TabStop = false;
            this.gbThreadingSetup.Text = "Threading Setup";
            this.toolTip1.SetToolTip(this.gbThreadingSetup, resources.GetString("gbThreadingSetup.ToolTip"));
            // 
            // rbBmp
            // 
            this.rbBmp.Location = new System.Drawing.Point(128, 21);
            this.rbBmp.Name = "rbBmp";
            this.rbBmp.Size = new System.Drawing.Size(56, 16);
            this.rbBmp.TabIndex = 5;
            this.rbBmp.Text = "BMP";
            this.toolTip1.SetToolTip(this.rbBmp, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(52, 31);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(72, 20);
            this.txtHeight.TabIndex = 17;
            this.txtHeight.Text = "0";
            this.toolTip1.SetToolTip(this.txtHeight, resources.GetString("txtHeight.ToolTip"));
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // rbTiff
            // 
            this.rbTiff.Location = new System.Drawing.Point(252, 21);
            this.rbTiff.Name = "rbTiff";
            this.rbTiff.Size = new System.Drawing.Size(64, 16);
            this.rbTiff.TabIndex = 7;
            this.rbTiff.Text = "TIFF";
            this.toolTip1.SetToolTip(this.rbTiff, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.pImageSize);
            this.gbSize.Controls.Add(this.label1);
            this.gbSize.Controls.Add(this.txtImageSize);
            this.gbSize.Controls.Add(this.rbSetImageSize);
            this.gbSize.Controls.Add(this.txtShortSize);
            this.gbSize.Controls.Add(this.rbSetShortSize);
            this.gbSize.Controls.Add(this.txtLongSide);
            this.gbSize.Controls.Add(this.rbSetLongSide);
            this.gbSize.Controls.Add(this.rbSetBothSize);
            this.gbSize.Enabled = false;
            this.gbSize.Location = new System.Drawing.Point(6, 105);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(442, 120);
            this.gbSize.TabIndex = 5;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            this.toolTip1.SetToolTip(this.gbSize, resources.GetString("gbSize.ToolTip"));
            // 
            // pImageSize
            // 
            this.pImageSize.BackColor = System.Drawing.Color.Transparent;
            this.pImageSize.Controls.Add(this.lblWidth);
            this.pImageSize.Controls.Add(this.rbPercent);
            this.pImageSize.Controls.Add(this.rbPixels);
            this.pImageSize.Controls.Add(this.lblHeight);
            this.pImageSize.Controls.Add(this.txtHeight);
            this.pImageSize.Controls.Add(this.txtWidth);
            this.pImageSize.Controls.Add(this.btnLockHeight);
            this.pImageSize.Controls.Add(this.btnLockWidth);
            this.pImageSize.Enabled = false;
            this.pImageSize.Location = new System.Drawing.Point(8, 42);
            this.pImageSize.Name = "pImageSize";
            this.pImageSize.Size = new System.Drawing.Size(159, 78);
            this.pImageSize.TabIndex = 23;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(12, 10);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 16;
            this.lblWidth.Text = "Width";
            this.toolTip1.SetToolTip(this.lblWidth, resources.GetString("lblWidth.ToolTip"));
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(52, 7);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(72, 20);
            this.txtWidth.TabIndex = 16;
            this.txtWidth.Text = "0";
            this.toolTip1.SetToolTip(this.txtWidth, resources.GetString("txtWidth.ToolTip"));
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWidth_KeyPress);
            // 
            // btnLockHeight
            // 
            this.btnLockHeight.Enabled = false;
            this.btnLockHeight.Location = new System.Drawing.Point(129, 32);
            this.btnLockHeight.Name = "btnLockHeight";
            this.btnLockHeight.Size = new System.Drawing.Size(18, 19);
            this.btnLockHeight.TabIndex = 18;
            this.btnLockHeight.Text = "L";
            this.toolTip1.SetToolTip(this.btnLockHeight, "This will lock the aspect ratio. This will allow you to enter in one dimention an" +
        "d have it auto-calculate the other one for each image.");
            this.btnLockHeight.UseVisualStyleBackColor = true;
            this.btnLockHeight.Click += new System.EventHandler(this.btnLockHeight_Click);
            // 
            // btnLockWidth
            // 
            this.btnLockWidth.Enabled = false;
            this.btnLockWidth.Location = new System.Drawing.Point(129, 7);
            this.btnLockWidth.Name = "btnLockWidth";
            this.btnLockWidth.Size = new System.Drawing.Size(18, 19);
            this.btnLockWidth.TabIndex = 18;
            this.btnLockWidth.Text = "L";
            this.toolTip1.SetToolTip(this.btnLockWidth, "This will lock the aspect ratio. This will allow you to enter in one dimention an" +
        "d have it auto-calculate the other one for each image.");
            this.btnLockWidth.UseVisualStyleBackColor = true;
            this.btnLockWidth.Click += new System.EventHandler(this.btnLockWidth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "MegaPixels";
            // 
            // txtImageSize
            // 
            this.txtImageSize.Location = new System.Drawing.Point(297, 69);
            this.txtImageSize.Name = "txtImageSize";
            this.txtImageSize.Size = new System.Drawing.Size(72, 20);
            this.txtImageSize.TabIndex = 25;
            this.txtImageSize.Text = "0";
            this.toolTip1.SetToolTip(this.txtImageSize, resources.GetString("txtImageSize.ToolTip"));
            this.txtImageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImageSize_KeyPress);
            // 
            // rbSetImageSize
            // 
            this.rbSetImageSize.AutoSize = true;
            this.rbSetImageSize.Enabled = false;
            this.rbSetImageSize.Location = new System.Drawing.Point(183, 69);
            this.rbSetImageSize.Name = "rbSetImageSize";
            this.rbSetImageSize.Size = new System.Drawing.Size(108, 17);
            this.rbSetImageSize.TabIndex = 24;
            this.rbSetImageSize.TabStop = true;
            this.rbSetImageSize.Text = "Set image size to:";
            this.rbSetImageSize.UseVisualStyleBackColor = true;
            // 
            // txtShortSize
            // 
            this.txtShortSize.Location = new System.Drawing.Point(297, 45);
            this.txtShortSize.Name = "txtShortSize";
            this.txtShortSize.Size = new System.Drawing.Size(72, 20);
            this.txtShortSize.TabIndex = 23;
            this.txtShortSize.Text = "0";
            this.toolTip1.SetToolTip(this.txtShortSize, resources.GetString("txtShortSize.ToolTip"));
            this.txtShortSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShortSize_KeyPress);
            // 
            // rbSetShortSize
            // 
            this.rbSetShortSize.AutoSize = true;
            this.rbSetShortSize.Enabled = false;
            this.rbSetShortSize.Location = new System.Drawing.Point(183, 45);
            this.rbSetShortSize.Name = "rbSetShortSize";
            this.rbSetShortSize.Size = new System.Drawing.Size(104, 17);
            this.rbSetShortSize.TabIndex = 22;
            this.rbSetShortSize.TabStop = true;
            this.rbSetShortSize.Text = "Set short side to:";
            this.rbSetShortSize.UseVisualStyleBackColor = true;
            // 
            // txtLongSide
            // 
            this.txtLongSide.Location = new System.Drawing.Point(297, 19);
            this.txtLongSide.Name = "txtLongSide";
            this.txtLongSide.Size = new System.Drawing.Size(72, 20);
            this.txtLongSide.TabIndex = 21;
            this.txtLongSide.Text = "0";
            this.toolTip1.SetToolTip(this.txtLongSide, resources.GetString("txtLongSide.ToolTip"));
            this.txtLongSide.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLongSide_KeyPress);
            // 
            // rbSetLongSide
            // 
            this.rbSetLongSide.AutoSize = true;
            this.rbSetLongSide.Enabled = false;
            this.rbSetLongSide.Location = new System.Drawing.Point(183, 19);
            this.rbSetLongSide.Name = "rbSetLongSide";
            this.rbSetLongSide.Size = new System.Drawing.Size(101, 17);
            this.rbSetLongSide.TabIndex = 20;
            this.rbSetLongSide.TabStop = true;
            this.rbSetLongSide.Text = "Set long side to:";
            this.rbSetLongSide.UseVisualStyleBackColor = true;
            // 
            // rbSetBothSize
            // 
            this.rbSetBothSize.AutoSize = true;
            this.rbSetBothSize.Location = new System.Drawing.Point(6, 19);
            this.rbSetBothSize.Name = "rbSetBothSize";
            this.rbSetBothSize.Size = new System.Drawing.Size(140, 17);
            this.rbSetBothSize.TabIndex = 19;
            this.rbSetBothSize.TabStop = true;
            this.rbSetBothSize.Text = "Set one or both sides to:";
            this.rbSetBothSize.UseVisualStyleBackColor = true;
            this.rbSetBothSize.CheckedChanged += new System.EventHandler(this.rbSetBothSize_CheckedChanged);
            // 
            // gbOutputSettings
            // 
            this.gbOutputSettings.Controls.Add(this.cbSize);
            this.gbOutputSettings.Controls.Add(this.cbFormat);
            this.gbOutputSettings.Controls.Add(this.gbOutputDirectory);
            this.gbOutputSettings.Controls.Add(this.gbFormat);
            this.gbOutputSettings.Controls.Add(this.gbSize);
            this.gbOutputSettings.Location = new System.Drawing.Point(2, 72);
            this.gbOutputSettings.Name = "gbOutputSettings";
            this.gbOutputSettings.Size = new System.Drawing.Size(460, 288);
            this.gbOutputSettings.TabIndex = 7;
            this.gbOutputSettings.TabStop = false;
            this.gbOutputSettings.Text = "Output Settings";
            // 
            // cbSize
            // 
            this.cbSize.Location = new System.Drawing.Point(6, 88);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(128, 16);
            this.cbSize.TabIndex = 13;
            this.cbSize.Text = "Resize";
            this.toolTip1.SetToolTip(this.cbSize, resources.GetString("cbSize.ToolTip"));
            this.cbSize.CheckedChanged += new System.EventHandler(this.cbSize_CheckedChanged);
            // 
            // cbFormat
            // 
            this.cbFormat.AutoSize = true;
            this.cbFormat.Location = new System.Drawing.Point(11, 19);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(98, 17);
            this.cbFormat.TabIndex = 2;
            this.cbFormat.Text = "Change Format";
            this.toolTip1.SetToolTip(this.cbFormat, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            this.cbFormat.CheckedChanged += new System.EventHandler(this.cbFormat_CheckedChanged);
            // 
            // gbOutputDirectory
            // 
            this.gbOutputDirectory.Controls.Add(this.btnOutputBrowse);
            this.gbOutputDirectory.Controls.Add(this.txtOutputDir);
            this.gbOutputDirectory.Location = new System.Drawing.Point(6, 231);
            this.gbOutputDirectory.Name = "gbOutputDirectory";
            this.gbOutputDirectory.Size = new System.Drawing.Size(442, 48);
            this.gbOutputDirectory.TabIndex = 7;
            this.gbOutputDirectory.TabStop = false;
            this.gbOutputDirectory.Text = "Output Directory";
            this.toolTip1.SetToolTip(this.gbOutputDirectory, "Specify the desination location here, if it does nto already exist it will be cre" +
        "ated. WARNING: If a file with the same name already exists in the output directo" +
        "ry IT WILL BE OVERWRITTEN!");
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(412, 16);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(24, 24);
            this.btnOutputBrowse.TabIndex = 19;
            this.btnOutputBrowse.Text = "..";
            this.toolTip1.SetToolTip(this.btnOutputBrowse, "Specify the desination location here, if it does nto already exist it will be cre" +
        "ated. WARNING: If a file with the same name already exists in the output directo" +
        "ry IT WILL BE OVERWRITTEN!");
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(8, 16);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(398, 20);
            this.txtOutputDir.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtOutputDir, "Specify the desination location here, if it does nto already exist it will be cre" +
        "ated. WARNING: If a file with the same name already exists in the output directo" +
        "ry IT WILL BE OVERWRITTEN!");
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.btnSettings);
            this.gbFormat.Controls.Add(this.rbTiff);
            this.gbFormat.Controls.Add(this.rbBmp);
            this.gbFormat.Controls.Add(this.rbPng);
            this.gbFormat.Controls.Add(this.rbGif);
            this.gbFormat.Controls.Add(this.rbJpeg);
            this.gbFormat.Enabled = false;
            this.gbFormat.Location = new System.Drawing.Point(8, 36);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Size = new System.Drawing.Size(442, 46);
            this.gbFormat.TabIndex = 6;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "Format";
            this.toolTip1.SetToolTip(this.gbFormat, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // rbPng
            // 
            this.rbPng.Location = new System.Drawing.Point(190, 21);
            this.rbPng.Name = "rbPng";
            this.rbPng.Size = new System.Drawing.Size(56, 16);
            this.rbPng.TabIndex = 6;
            this.rbPng.Text = "PNG";
            this.toolTip1.SetToolTip(this.rbPng, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // rbGif
            // 
            this.rbGif.Location = new System.Drawing.Point(72, 21);
            this.rbGif.Name = "rbGif";
            this.rbGif.Size = new System.Drawing.Size(56, 16);
            this.rbGif.TabIndex = 4;
            this.rbGif.Text = "GIF";
            this.toolTip1.SetToolTip(this.rbGif, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // rbJpeg
            // 
            this.rbJpeg.Checked = true;
            this.rbJpeg.Location = new System.Drawing.Point(8, 21);
            this.rbJpeg.Name = "rbJpeg";
            this.rbJpeg.Size = new System.Drawing.Size(56, 16);
            this.rbJpeg.TabIndex = 3;
            this.rbJpeg.TabStop = true;
            this.rbJpeg.Text = "JPEG";
            this.toolTip1.SetToolTip(this.rbJpeg, "These settings will allow you to change the image format. Leave the box un-checke" +
        "d for the images to remain in their original format, or select a format and all " +
        "images will be converted to it.");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblInfoMessage
            // 
            this.lblInfoMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoMessage.Location = new System.Drawing.Point(2, 412);
            this.lblInfoMessage.Name = "lblInfoMessage";
            this.lblInfoMessage.Size = new System.Drawing.Size(460, 24);
            this.lblInfoMessage.TabIndex = 23;
            this.lblInfoMessage.Text = "lblInfoMessage";
            this.lblInfoMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfoMessage.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 443);
            this.Controls.Add(this.lblInfoMessage);
            this.Controls.Add(this.gbInputDirectory);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.gbThreadingSetup);
            this.Controls.Add(this.gbOutputSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Imagizer2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gbInputDirectory.ResumeLayout(false);
            this.gbInputDirectory.PerformLayout();
            this.gbThreadingSetup.ResumeLayout(false);
            this.gbThreadingSetup.PerformLayout();
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.pImageSize.ResumeLayout(false);
            this.pImageSize.PerformLayout();
            this.gbOutputSettings.ResumeLayout(false);
            this.gbOutputSettings.PerformLayout();
            this.gbOutputDirectory.ResumeLayout(false);
            this.gbOutputDirectory.PerformLayout();
            this.gbFormat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbInputDirectory;
        internal System.Windows.Forms.Button btnInputBrowse;
        internal System.Windows.Forms.TextBox txtInputDir;
        internal System.Windows.Forms.Label lblHeight;
        internal System.Windows.Forms.RadioButton rbPixels;
        internal System.Windows.Forms.Button btnSettings;
        internal System.Windows.Forms.RadioButton rbPercent;
        internal System.Windows.Forms.ProgressBar progBar;
        internal System.Windows.Forms.Label lblThreads;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtThreadCount;
        internal System.Windows.Forms.VScrollBar sbThreads;
        internal System.Windows.Forms.GroupBox gbThreadingSetup;
        internal System.Windows.Forms.RadioButton rbBmp;
        internal System.Windows.Forms.TextBox txtHeight;
        internal System.Windows.Forms.RadioButton rbTiff;
        internal System.Windows.Forms.GroupBox gbSize;
        internal System.Windows.Forms.GroupBox gbOutputSettings;
        internal System.Windows.Forms.GroupBox gbOutputDirectory;
        internal System.Windows.Forms.Button btnOutputBrowse;
        internal System.Windows.Forms.TextBox txtOutputDir;
        internal System.Windows.Forms.GroupBox gbFormat;
        internal System.Windows.Forms.RadioButton rbPng;
        internal System.Windows.Forms.RadioButton rbGif;
        internal System.Windows.Forms.RadioButton rbJpeg;
        internal System.Windows.Forms.CheckBox cbSize;
        internal System.Windows.Forms.CheckBox cbFormat;
        internal System.Windows.Forms.TextBox txtWidth;
        internal System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.CheckBox cbRecusive;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLockHeight;
        private System.Windows.Forms.Button btnLockWidth;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtImageSize;
        private System.Windows.Forms.RadioButton rbSetImageSize;
        internal System.Windows.Forms.TextBox txtShortSize;
        private System.Windows.Forms.RadioButton rbSetShortSize;
        internal System.Windows.Forms.TextBox txtLongSide;
        private System.Windows.Forms.RadioButton rbSetLongSide;
        private System.Windows.Forms.RadioButton rbSetBothSize;
        private System.Windows.Forms.Panel pImageSize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblInfoMessage;
    }
}

