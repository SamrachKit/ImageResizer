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
            this.rbWmf = new System.Windows.Forms.RadioButton();
            this.rbExif = new System.Windows.Forms.RadioButton();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.lblThreads = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.rbEmf = new System.Windows.Forms.RadioButton();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.rbIco = new System.Windows.Forms.RadioButton();
            this.sbThreads = new System.Windows.Forms.VScrollBar();
            this.gbThreadingSetup = new System.Windows.Forms.GroupBox();
            this.rbBmp = new System.Windows.Forms.RadioButton();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.rbTiff = new System.Windows.Forms.RadioButton();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.btnLockWidth = new System.Windows.Forms.Button();
            this.btnLockHeight = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
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
            this.gbInputDirectory.SuspendLayout();
            this.gbThreadingSetup.SuspendLayout();
            this.gbSize.SuspendLayout();
            this.gbOutputSettings.SuspendLayout();
            this.gbOutputDirectory.SuspendLayout();
            this.gbFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInputDirectory
            // 
            this.gbInputDirectory.Controls.Add(this.cbRecusive);
            this.gbInputDirectory.Controls.Add(this.btnInputBrowse);
            this.gbInputDirectory.Controls.Add(this.txtInputDir);
            this.gbInputDirectory.Location = new System.Drawing.Point(2, 2);
            this.gbInputDirectory.Name = "gbInputDirectory";
            this.gbInputDirectory.Size = new System.Drawing.Size(344, 62);
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
            this.btnInputBrowse.Location = new System.Drawing.Point(304, 16);
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
            this.txtInputDir.Size = new System.Drawing.Size(288, 20);
            this.txtInputDir.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtInputDir, "Specify the input directory here. If \'Include Subdirectories\' is selected then th" +
                    "e directory structure will be duplicated in the destination location.");
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(13, 68);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(64, 16);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "Height";
            this.toolTip1.SetToolTip(this.lblHeight, resources.GetString("lblHeight.ToolTip"));
            // 
            // rbPixels
            // 
            this.rbPixels.Location = new System.Drawing.Point(80, 19);
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
            this.btnSettings.Location = new System.Drawing.Point(64, 84);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(72, 18);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "Settings";
            this.toolTip1.SetToolTip(this.btnSettings, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
            this.btnSettings.Visible = false;
            // 
            // rbPercent
            // 
            this.rbPercent.Checked = true;
            this.rbPercent.Location = new System.Drawing.Point(16, 19);
            this.rbPercent.Name = "rbPercent";
            this.rbPercent.Size = new System.Drawing.Size(72, 16);
            this.rbPercent.TabIndex = 14;
            this.rbPercent.TabStop = true;
            this.rbPercent.Text = "Percent";
            this.toolTip1.SetToolTip(this.rbPercent, "Resizing by percent will scale each picture according to it\'s own original diment" +
                    "ions. This is handy if your images are not all the same size or aspect ratio.");
            this.rbPercent.CheckedChanged += new System.EventHandler(this.rbPercent_CheckedChanged);
            // 
            // rbWmf
            // 
            this.rbWmf.Location = new System.Drawing.Point(64, 68);
            this.rbWmf.Name = "rbWmf";
            this.rbWmf.Size = new System.Drawing.Size(56, 16);
            this.rbWmf.TabIndex = 11;
            this.rbWmf.Text = "WMF";
            this.toolTip1.SetToolTip(this.rbWmf, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
            // 
            // rbExif
            // 
            this.rbExif.Location = new System.Drawing.Point(64, 52);
            this.rbExif.Name = "rbExif";
            this.rbExif.Size = new System.Drawing.Size(56, 16);
            this.rbExif.TabIndex = 10;
            this.rbExif.Text = "EXIF";
            this.toolTip1.SetToolTip(this.rbExif, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(2, 334);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(344, 24);
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
            this.btnGo.Location = new System.Drawing.Point(218, 288);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(128, 40);
            this.btnGo.TabIndex = 22;
            this.btnGo.Text = "Start";
            this.toolTip1.SetToolTip(this.btnGo, "Once you have selected your options, press go and the conversion will begin.");
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // rbEmf
            // 
            this.rbEmf.Location = new System.Drawing.Point(64, 36);
            this.rbEmf.Name = "rbEmf";
            this.rbEmf.Size = new System.Drawing.Size(56, 16);
            this.rbEmf.TabIndex = 9;
            this.rbEmf.Text = "EMF";
            this.toolTip1.SetToolTip(this.rbEmf, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
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
            // rbIco
            // 
            this.rbIco.Location = new System.Drawing.Point(64, 20);
            this.rbIco.Name = "rbIco";
            this.rbIco.Size = new System.Drawing.Size(56, 16);
            this.rbIco.TabIndex = 8;
            this.rbIco.Text = "ICO";
            this.toolTip1.SetToolTip(this.rbIco, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
            // 
            // sbThreads
            // 
            this.sbThreads.Location = new System.Drawing.Point(96, 16);
            this.sbThreads.Maximum = 64;
            this.sbThreads.Minimum = 1;
            this.sbThreads.Name = "sbThreads";
            this.sbThreads.Size = new System.Drawing.Size(20, 16);
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
            this.gbThreadingSetup.Location = new System.Drawing.Point(2, 288);
            this.gbThreadingSetup.Name = "gbThreadingSetup";
            this.gbThreadingSetup.Size = new System.Drawing.Size(136, 40);
            this.gbThreadingSetup.TabIndex = 9;
            this.gbThreadingSetup.TabStop = false;
            this.gbThreadingSetup.Text = "Threading Setup";
            this.toolTip1.SetToolTip(this.gbThreadingSetup, resources.GetString("gbThreadingSetup.ToolTip"));
            // 
            // rbBmp
            // 
            this.rbBmp.Location = new System.Drawing.Point(8, 52);
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
            this.txtHeight.Location = new System.Drawing.Point(53, 65);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(72, 20);
            this.txtHeight.TabIndex = 17;
            this.txtHeight.Text = "0";
            this.toolTip1.SetToolTip(this.txtHeight, resources.GetString("txtHeight.ToolTip"));
            // 
            // rbTiff
            // 
            this.rbTiff.Location = new System.Drawing.Point(8, 84);
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
            this.gbSize.Controls.Add(this.btnLockWidth);
            this.gbSize.Controls.Add(this.btnLockHeight);
            this.gbSize.Controls.Add(this.txtWidth);
            this.gbSize.Controls.Add(this.lblWidth);
            this.gbSize.Controls.Add(this.txtHeight);
            this.gbSize.Controls.Add(this.lblHeight);
            this.gbSize.Controls.Add(this.rbPixels);
            this.gbSize.Controls.Add(this.rbPercent);
            this.gbSize.Enabled = false;
            this.gbSize.Location = new System.Drawing.Point(176, 36);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(160, 113);
            this.gbSize.TabIndex = 5;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            this.toolTip1.SetToolTip(this.gbSize, resources.GetString("gbSize.ToolTip"));
            // 
            // btnLockWidth
            // 
            this.btnLockWidth.Enabled = false;
            this.btnLockWidth.Location = new System.Drawing.Point(130, 41);
            this.btnLockWidth.Name = "btnLockWidth";
            this.btnLockWidth.Size = new System.Drawing.Size(18, 19);
            this.btnLockWidth.TabIndex = 18;
            this.btnLockWidth.Text = "L";
            this.toolTip1.SetToolTip(this.btnLockWidth, "This will lock the aspect ratio. This will allow you to enter in one dimention an" +
                    "d have it auto-calculate the other one for each image.");
            this.btnLockWidth.UseVisualStyleBackColor = true;
            this.btnLockWidth.Click += new System.EventHandler(this.btnLockWidth_Click);
            // 
            // btnLockHeight
            // 
            this.btnLockHeight.Enabled = false;
            this.btnLockHeight.Location = new System.Drawing.Point(130, 66);
            this.btnLockHeight.Name = "btnLockHeight";
            this.btnLockHeight.Size = new System.Drawing.Size(18, 19);
            this.btnLockHeight.TabIndex = 18;
            this.btnLockHeight.Text = "L";
            this.toolTip1.SetToolTip(this.btnLockHeight, "This will lock the aspect ratio. This will allow you to enter in one dimention an" +
                    "d have it auto-calculate the other one for each image.");
            this.btnLockHeight.UseVisualStyleBackColor = true;
            this.btnLockHeight.Click += new System.EventHandler(this.btnLockHeight_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(53, 41);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(72, 20);
            this.txtWidth.TabIndex = 16;
            this.txtWidth.Text = "0";
            this.toolTip1.SetToolTip(this.txtWidth, resources.GetString("txtWidth.ToolTip"));
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(13, 44);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(56, 16);
            this.lblWidth.TabIndex = 16;
            this.lblWidth.Text = "Width";
            this.toolTip1.SetToolTip(this.lblWidth, resources.GetString("lblWidth.ToolTip"));
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
            this.gbOutputSettings.Size = new System.Drawing.Size(344, 208);
            this.gbOutputSettings.TabIndex = 7;
            this.gbOutputSettings.TabStop = false;
            this.gbOutputSettings.Text = "Output Settings";
            // 
            // cbSize
            // 
            this.cbSize.Location = new System.Drawing.Point(176, 19);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(128, 16);
            this.cbSize.TabIndex = 13;
            this.cbSize.Text = "Resize";
            this.toolTip1.SetToolTip(this.cbSize, resources.GetString("cbSize.ToolTip"));
            this.cbSize.CheckedChanged += new System.EventHandler(this.cbSize_CheckedChanged);
            // 
            // cbFormat
            // 
            this.cbFormat.Location = new System.Drawing.Point(11, 19);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(128, 16);
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
            this.gbOutputDirectory.Location = new System.Drawing.Point(8, 152);
            this.gbOutputDirectory.Name = "gbOutputDirectory";
            this.gbOutputDirectory.Size = new System.Drawing.Size(328, 48);
            this.gbOutputDirectory.TabIndex = 7;
            this.gbOutputDirectory.TabStop = false;
            this.gbOutputDirectory.Text = "Output Directory";
            this.toolTip1.SetToolTip(this.gbOutputDirectory, "Specify the desination location here, if it does nto already exist it will be cre" +
                    "ated. WARNING: If a file with the same name already exists in the output directo" +
                    "ry IT WILL BE OVERWRITTEN!");
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(296, 16);
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
            this.txtOutputDir.Size = new System.Drawing.Size(280, 20);
            this.txtOutputDir.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtOutputDir, "Specify the desination location here, if it does nto already exist it will be cre" +
                    "ated. WARNING: If a file with the same name already exists in the output directo" +
                    "ry IT WILL BE OVERWRITTEN!");
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.btnSettings);
            this.gbFormat.Controls.Add(this.rbWmf);
            this.gbFormat.Controls.Add(this.rbExif);
            this.gbFormat.Controls.Add(this.rbEmf);
            this.gbFormat.Controls.Add(this.rbIco);
            this.gbFormat.Controls.Add(this.rbTiff);
            this.gbFormat.Controls.Add(this.rbBmp);
            this.gbFormat.Controls.Add(this.rbPng);
            this.gbFormat.Controls.Add(this.rbGif);
            this.gbFormat.Controls.Add(this.rbJpeg);
            this.gbFormat.Enabled = false;
            this.gbFormat.Location = new System.Drawing.Point(8, 36);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Size = new System.Drawing.Size(160, 113);
            this.gbFormat.TabIndex = 6;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "Format";
            this.toolTip1.SetToolTip(this.gbFormat, "These settings will allow you to change the image format. Leave the box un-checke" +
                    "d for the images to remain in their original format, or select a format and all " +
                    "images will be converted to it.");
            // 
            // rbPng
            // 
            this.rbPng.Location = new System.Drawing.Point(8, 68);
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
            this.rbGif.Location = new System.Drawing.Point(8, 36);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 361);
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
            this.gbOutputSettings.ResumeLayout(false);
            this.gbOutputDirectory.ResumeLayout(false);
            this.gbOutputDirectory.PerformLayout();
            this.gbFormat.ResumeLayout(false);
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
        internal System.Windows.Forms.RadioButton rbWmf;
        internal System.Windows.Forms.RadioButton rbExif;
        internal System.Windows.Forms.ProgressBar progBar;
        internal System.Windows.Forms.Label lblThreads;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.RadioButton rbEmf;
        internal System.Windows.Forms.TextBox txtThreadCount;
        internal System.Windows.Forms.RadioButton rbIco;
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

    }
}

