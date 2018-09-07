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

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Imagizer2
{
    public partial class MainForm : Form
    {
        private readonly EventProcessor.ConversionCompleteEventHandler _conversionCompleteHandler;
        private readonly EventProcessor.SetProgressBarEventHandler _setProgressBarHandler;
        private delegate void LocalDelegate();
        private delegate void LocalDelegateParm(int val);
        private int _startTicks;
        private AspectLockState _aspectLockState;

        public MainForm()
        {
            InitializeComponent();
            this.Text = string.Format("Imagizer2 v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            txtThreadCount.Text = Environment.ProcessorCount.ToString();
            DataContainer.Running = false;

            LoadSettings();

            _conversionCompleteHandler = new EventProcessor.ConversionCompleteEventHandler(Instance_ConversionComplete);
            _setProgressBarHandler = new EventProcessor.SetProgressBarEventHandler(Instance_SetProgressBar);

            EventProcessor.Instance.ConversionComplete += _conversionCompleteHandler;
            EventProcessor.Instance.SetProgressBar += _setProgressBarHandler;
        }

        #region Methods

        private void SetProgBar(int percent)
        {
            if (!this.IsDisposed && !DataContainer.Cancel)
                this.Invoke((LocalDelegateParm)DelegateSetProgBar, percent);
        }

        private void DelegateSetProgBar(int percent)
        {
            progBar.Value = percent;
        }

        private void Reset()
        {
            if (!this.IsDisposed)
                this.Invoke((LocalDelegate)DelegateReset);
        }

        private void DelegateReset()
        {
            btnGo.Text = "Start";
            btnGo.Enabled = true;
            gbThreadingSetup.Enabled = true;
            progBar.Value = 0;
        }

        private void ConversionComplete()
        {
            if (DataContainer.Running)
            {
                int endTicks = Environment.TickCount;
                SetProgBar(100);
                MessageBox.Show("Complete!" + Environment.NewLine + DataContainer.TotalFiles.ToString() + " files in " + ((decimal)endTicks - (decimal)_startTicks) / 1000 + " seconds.");
                Reset();
                DataContainer.Running = false;
            }
        }

        private void SetAspectLockbuttons(bool mode)
        {
            btnLockWidth.Enabled = mode;
            btnLockHeight.Enabled = mode;
        }

        private void SetNoAspectLockMode()
        {
            btnLockHeight.Text = "L";
            btnLockWidth.Text = "L";
            txtHeight.Enabled = true;
            txtWidth.Enabled = true;
            _aspectLockState = AspectLockState.Disabled;
        }

        private void SetLockWidthMode()
        {
            if (_aspectLockState != AspectLockState.LockWidth)
            {
                btnLockHeight.Text = "L";
                btnLockWidth.Text = "U";
                txtHeight.Enabled = true;
                txtWidth.Enabled = false;
                _aspectLockState = AspectLockState.LockWidth;
            }
            else
            {
                SetNoAspectLockMode();
            }
        }

        private void SetLockHeightMode()
        {
            if (_aspectLockState != AspectLockState.LockHeight)
            {
                btnLockHeight.Text = "U";
                btnLockWidth.Text = "L";
                txtWidth.Enabled = true;
                txtHeight.Enabled = false;
                _aspectLockState = AspectLockState.LockHeight;
            }
            else
            {
                SetNoAspectLockMode();
            }
        }

        private void txtThreadCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sbThreads.Value = int.Parse(txtThreadCount.Text);
            }
            catch { }
        }

        private void SelectDirectoryToTextBox(Control textBox, string title, bool showCreateDirButton)
        {
            using (FolderBrowserDialog fbDialog = new FolderBrowserDialog())
            {
                fbDialog.ShowNewFolderButton = showCreateDirButton;
                fbDialog.SelectedPath = textBox.Text;
                fbDialog.Description = title;

                if (fbDialog.ShowDialog(this) == DialogResult.OK)
                    textBox.Text = fbDialog.SelectedPath;
            }
        }

        #endregion

        #region Event Handlers

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataContainer.Cancel = true;
            EventProcessor.Instance.ConversionComplete -= _conversionCompleteHandler;
            EventProcessor.Instance.SetProgressBar -= _setProgressBarHandler;

            if (DataContainer.FileList != null && DataContainer.FileList.Count > 0)
                DataContainer.FileList.Clear();

            try
            {
                ConversionParameters conversionParameters = GetConversionParameters();
                ImagizerSettings.Default.SettingXml = SerializationUtility.SerializeObject(conversionParameters);
                ImagizerSettings.Default.Save();
            }
            catch
            {
                //we threw ourselves an error, so we will not continue.
                //A messagebox should have aklready been displayed
                return;
            }
        }

        private void rbPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPercent.Checked)
            {
                SetAspectLockbuttons(false);
                SetNoAspectLockMode();
            }

        }

        private void rbPixels_CheckedChanged(object sender, EventArgs e)
        {

            if (rbPixels.Checked)
            {
                SetAspectLockbuttons(true);
            }
        }

        void Instance_SetProgressBar(object sender, int percent)
        {
            SetProgBar(percent);
        }

        void Instance_ConversionComplete(object sender)
        {
            ConversionComplete();
        }

        private void cbFormat_CheckedChanged(object sender, EventArgs e)
        {
            gbFormat.Enabled = cbFormat.Checked;
        }

        private void cbSize_CheckedChanged(object sender, EventArgs e)
        {
            gbSize.Enabled = cbSize.Checked;
        }

        private void btnInputBrowse_Click(object sender, EventArgs e)
        {
            SelectDirectoryToTextBox(txtInputDir, "Select the source directory", false);
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            SelectDirectoryToTextBox(txtOutputDir, "Select the destination directory", true);
        }

        private void sbThreads_Scroll(object sender, ScrollEventArgs e)
        {
            txtThreadCount.Text = sbThreads.Value.ToString();
        }

        private void btnLockWidth_Click(object sender, EventArgs e)
        {
            SetLockWidthMode();
        }

        private void btnLockHeight_Click(object sender, EventArgs e)
        {
            SetLockHeightMode();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DoStartConversion();
        }

        #endregion

        #region Settings Load Save

        private void LoadSettings()
        {
            ConversionParameters conversionParameters;

            if (string.IsNullOrEmpty(ImagizerSettings.Default.SettingXml))
                return;
            try
            {
                conversionParameters = SerializationUtility.DeserializeObject<ConversionParameters>(ImagizerSettings.Default.SettingXml);
                SetConversionParameters(conversionParameters);
            }
            catch
            {
                //just toss it here because it probably means outr settings are blank or corrupt
            }
        }

        private void DoStartConversion()
        {
            if (DataContainer.Running)
            {
                MessageBox.Show("Already Running!", "Imagizer2 Error!");
                return;
            }

            ConversionParameters conversionParameters;
            try
            {
                conversionParameters = GetConversionParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            gbThreadingSetup.Enabled = false;
            btnGo.Text = "Working";
            btnGo.Enabled = false;

            if (!Directory.Exists(conversionParameters.OutputDir))
                Directory.CreateDirectory(conversionParameters.OutputDir);

            _startTicks = Environment.TickCount;

            ImgProcessor.RunImagizer(conversionParameters);
        }
        /// <summary>
        /// Reads parameters from application (mostly the form) and creates a
        /// ConversionParameters which can then be serialized into a settings file
        /// </summary>
        /// <returns></returns>
        private ConversionParameters GetConversionParameters()
        {
            ConversionParameters conversionParameters = new ConversionParameters();

            if (txtInputDir.Text == string.Empty || txtOutputDir.Text == string.Empty || txtInputDir.Text == txtOutputDir.Text)
            {
                throw new ApplicationException(string.Format("You must fill out both the input and output folder,{0}and they have to be different folders,{0}they cannot point to the same place.", Environment.NewLine));
            }

            conversionParameters.InputDir = txtInputDir.Text;
            conversionParameters.OutputDir = txtOutputDir.Text;

            if (cbFormat.Checked)
            {
                if (rbJpeg.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Jpeg;
                    conversionParameters.NewExtention = ".jpg";
                }
                else if (rbGif.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Gif;
                    conversionParameters.NewExtention = ".gif";
                }
                else if (rbBmp.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Bmp;
                    conversionParameters.NewExtention = ".bmp";
                }
                else if (rbPng.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Png;
                    conversionParameters.NewExtention = ".png";
                }
                else if (rbTiff.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Tiff;
                    conversionParameters.NewExtention = ".tiff";
                }
                else if (rbWmf.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Wmf;
                    conversionParameters.NewExtention = ".wmf";
                }
                else if (rbExif.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Exif;
                    conversionParameters.NewExtention = ".exif";
                }
                else if (rbEmf.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Emf;
                    conversionParameters.NewExtention = ".emf";
                }
                else if (rbIco.Checked)
                {
                    conversionParameters.ImageFormat = ImageFormat.Icon;
                    conversionParameters.NewExtention = ".ico";
                }
            }

            try
            {
                if (cbSize.Checked)
                {
                    conversionParameters.NewHeight = int.Parse(txtHeight.Text);
                    conversionParameters.NewWidth = int.Parse(txtWidth.Text);

                    if (rbPixels.Checked)
                        conversionParameters.ResizeMode = ResizeMode.Pixels;

                    else if (cbSize.Checked && rbPercent.Checked)
                        conversionParameters.ResizeMode = ResizeMode.Percent;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Make sure there are only numbers and not letters or{0}something in the height and width boxes.", Environment.NewLine), ex);
            }

            conversionParameters.AspectLockState = _aspectLockState;
            conversionParameters.NumThreads = int.Parse(txtThreadCount.Text);
            conversionParameters.IncludeSubDirs = cbRecusive.Checked;
            return conversionParameters;
        }

        /// <summary>
        /// Takes a ConversionParameters and loads all of the settings (mostly to the form)
        /// This is typically used after de-serializing from a settings file
        /// </summary>
        /// <param name="conversionParameters">ConversionParameters object</param>
        private void SetConversionParameters(ConversionParameters conversionParameters)
        {
            txtThreadCount.Text = conversionParameters.NumThreads.ToString();
            txtInputDir.Text = conversionParameters.InputDir;
            txtOutputDir.Text = conversionParameters.OutputDir;

            _aspectLockState = AspectLockState.Disabled;

            switch (conversionParameters.AspectLockState)
            {
                case AspectLockState.LockHeight:
                    SetLockHeightMode();
                    break;
                case AspectLockState.LockWidth:
                    SetLockWidthMode();
                    break;
            }

            if (conversionParameters.ImageFormat != null && conversionParameters.NewExtention != null)
                cbFormat.Checked = true;

            if (conversionParameters.ImageFormat == ImageFormat.Jpeg)
                rbJpeg.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Gif)
                rbGif.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Bmp)
                rbBmp.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Png)
                rbPng.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Tiff)
                rbTiff.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Wmf)
                rbWmf.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Exif)
                rbExif.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Emf)
                rbEmf.Checked = true;

            else if (conversionParameters.ImageFormat == ImageFormat.Icon)
                rbIco.Checked = true;

            txtHeight.Text = conversionParameters.NewHeight.ToString();
            txtWidth.Text = conversionParameters.NewWidth.ToString();

            cbRecusive.Checked = conversionParameters.IncludeSubDirs;

            rbPercent.Checked = false;
            rbPixels.Checked = false;

            switch (conversionParameters.ResizeMode)
            {
                case ResizeMode.Percent:
                    rbPercent.Checked = true;
                    cbSize.Checked = true;
                    break;
                case ResizeMode.Pixels:
                    rbPixels.Checked = true;
                    cbSize.Checked = true;
                    break;
            }
        }
        #endregion
    }
}
