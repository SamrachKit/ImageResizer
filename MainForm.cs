/*********************************************************************************
    This file is part of Imagizer.

    Imagizer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Imagizer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Imagizer.  If not, see <http://www.gnu.org/licenses/>.

*********************************************************************************/

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace Imagizer
{
    public partial class MainForm : Form
    {
        private readonly EventProcessor.ConversionCompleteEventHandler _conversionCompleteHandler;
        private readonly EventProcessor.SetProgressBarEventHandler _setProgressBarHandler;
        private delegate void LocalDelegate();
        private delegate void LocalDelegateParm(int val);
        private delegate void LocalDelegateStringParm(string val);
        private int _startTicks;
        private AspectLockState _aspectLockState;

        public MainForm()
        {
            InitializeComponent();
            this.Text = string.Format("Imagizer v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
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
        }

        private void SetMessageBox(string message)
        {
            if (!this.IsDisposed)
                this.Invoke((LocalDelegateStringParm)DelegateSetMessageBox, message);
        }

        private void DelegateSetMessageBox(string message)
        {
            WriteInfoMessage(message);
        }

        private void ConversionComplete()
        {
            if (DataContainer.Running)
            {
                int endTicks = Environment.TickCount;
                SetProgBar(100);
                SetMessageBox(String.Format("Done: {0} files in {1:F0} seconds.",
                    DataContainer.TotalFiles,
                    ((float)endTicks - _startTicks) / 1000));
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

        private void AllowValidNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AllowValidDecimalsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        float GetFloat(string stringValue)
        {
            float.TryParse(stringValue, out float floatValue);
            return floatValue;
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
            catch (Exception ex)
            {
                Debug.WriteLine("Can't save setting: " + ex.Message);
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
            gbSize.Enabled = cbResize.Checked;
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
            if(ValidateParameter() == true)
                DoStartConversion();
        }

        private void rbSetBothSize_CheckedChanged(object sender, EventArgs e)
        {
            pImageSize.Enabled = rbSetBothSize.Checked;
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowValidNumbersOnly(sender, e);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowValidNumbersOnly(sender, e);
        }

        private void txtLongSide_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowValidNumbersOnly(sender, e);
        }

        private void txtShortSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowValidNumbersOnly(sender, e);
        }

        private void txtImageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowValidDecimalsOnly(sender, e);
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
            catch(Exception e)
            {
                Debug.WriteLine("Can't load setting: " + e.Message);
                //just toss it here because it probably means our settings are blank or corrupt
            }
        }

        private bool ValidateParameter()
        {
            errorProvider1.Clear();

            if (!IsTextBoxValidPath(txtInputDir))
                return false;

            if (!IsTextBoxValidPath(txtOutputDir))
                return false;

            if (txtInputDir.Text == txtOutputDir.Text)
            {
                WriteErrorMessage("Input and Output Directory must not be the same folder.");
                errorProvider1.SetError(txtInputDir, "Must not be the same as Output Directory");
                errorProvider1.SetError(txtOutputDir, "Must not be the same as Input Directory");

                return false;
            }

            // Validation for Resize Parameters
            if (cbResize.Checked) 
            {
                if (rbSetBothSize.Checked)
                {
                    if (!IsTextBoxNumberic(txtWidth))
                         return false;
                    if (!IsTextBoxNumberic(txtHeight))
                        return false;
                }

                if (rbSetLongSide.Checked)
                    if (!IsTextBoxNumberic(txtLongSide))
                        return false;
 
                if( rbSetShortSize.Checked)
                     if (!IsTextBoxNumberic(txtShortSize))
                        return false;

                if(rbSetImageSize.Checked)
                    if (!IsTextBoxNumberic(txtImageSize))
                        return false;
            }
            return true;
        }

        private bool IsTextBoxNumberic(TextBox boxToCheck)
        {
            if (GetFloat(boxToCheck.Text) == 0)
            {
                errorProvider1.SetError(boxToCheck, "Must be greater then 0");
                return false;
            }
            else
                return true;
        }

        private bool IsTextBoxValidPath(TextBox boxToCheck)
        {
            if (boxToCheck.Text == string.Empty)
            {
                errorProvider1.SetError(boxToCheck, "Must not be empty");
                return false;
            }

            if(! Directory.Exists(boxToCheck.Text))
            {
                errorProvider1.SetError(boxToCheck, "Path is invalid.");
                return false;
            }

            return true;
        }

        private void WriteInfoMessage(string message)
        {
            lblInfoMessage.Text = message;
            lblInfoMessage.ForeColor = System.Drawing.Color.Black;
            lblInfoMessage.Visible = true;
        }

        private void WriteErrorMessage(string message)
        {
            lblInfoMessage.Text = message;
            lblInfoMessage.ForeColor = System.Drawing.Color.Red;
            lblInfoMessage.Visible = true;
        }

        private void ClearInfoMessage()
        {
            lblInfoMessage.Text = "";
            errorProvider1.SetError(lblInfoMessage, "");
            lblInfoMessage.Visible = false;
        }

        private void DoStartConversion()
        {
            ClearInfoMessage();
            progBar.Value = 0;

            if (DataContainer.Running)
            {
                MessageBox.Show("Already Running!", "Imagizer Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConversionParameters conversionParameters;
            try
            {
                conversionParameters = GetConversionParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imagizer Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            var conversionParameters = new ConversionParameters
            {
                // Input Directory
                InputDir = txtInputDir.Text,

                // Include Subdirectories
                IncludeSubDirs = cbRecusive.Checked
            };

            // Output Settings
            // Format
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
            }

            // Resize
            try
            {
                if (cbResize.Checked)
                {
                    if(rbSetBothSize.Checked)
                    {
                        // Set one or both side to
                        conversionParameters.ResizeMode = ResizeMode.BothSide;
                        conversionParameters.ResizeHeight = int.Parse(txtHeight.Text);
                        conversionParameters.ResizeWidth = int.Parse(txtWidth.Text);
                        if (rbPixels.Checked)
                            conversionParameters.ResizeBothSideMode = ResizeBothSideMode.Pixels;
                        else if (cbResize.Checked && rbPercent.Checked)
                            conversionParameters.ResizeBothSideMode = ResizeBothSideMode.Percent;

                        conversionParameters.AspectLockState = _aspectLockState;
                    }
                    else if (rbSetLongSide.Checked)
                    {
                        // Set long side to
                        conversionParameters.ResizeMode = ResizeMode.LongSide;
                        conversionParameters.ResizeLong = int.Parse(txtLongSide.Text);
                    }
                    else if (rbSetShortSize.Checked)
                    {
                        // Set short side to
                        conversionParameters.ResizeMode = ResizeMode.ShortSide;
                        conversionParameters.ResizeShort = int.Parse(txtShortSize.Text);
                    }
                    if(rbSetImageSize.Checked)
                    {
                        conversionParameters.ResizeMode = ResizeMode.ImageSize;
                        conversionParameters.ResizeImageSize = float.Parse(txtImageSize.Text);
                    }
                }
                else
                    conversionParameters.ResizeMode = ResizeMode.None;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Make sure there are only numbers and not letters or{0}something in the height and width boxes.", Environment.NewLine), ex);
            }

            conversionParameters.Resize = cbResize.Checked;

            // Output Directory
            conversionParameters.OutputDir = txtOutputDir.Text;

            // Threading Setup
            conversionParameters.NumThreads = int.Parse(txtThreadCount.Text);

            return conversionParameters;
        }

        /// <summary>
        /// Takes a ConversionParameters and loads all of the settings (mostly to the form)
        /// This is typically used after de-serializing from a settings file
        /// </summary>
        /// <param name="conversionParameters">ConversionParameters object</param>
        private void SetConversionParameters(ConversionParameters conversionParameters)
        {
            // Input Directory
            txtInputDir.Text = conversionParameters.InputDir;

            // Include Subdirectories
            cbRecusive.Checked = conversionParameters.IncludeSubDirs;

            // Output Settings
            if (conversionParameters.ImageFormat != null && conversionParameters.NewExtention != null)
                cbFormat.Checked = true;

            // Format
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

            // Resize
            cbResize.Checked = true;

            switch (conversionParameters.ResizeMode)
            {
                case ResizeMode.BothSide:
                    rbSetBothSize.Checked = true;
                    txtLongSide.Text = conversionParameters.ResizeLong.ToString();

                    txtHeight.Text = conversionParameters.ResizeHeight.ToString();
                    txtWidth.Text = conversionParameters.ResizeWidth.ToString();

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

                    rbPercent.Checked = false;
                    rbPixels.Checked = false;

                    switch (conversionParameters.ResizeBothSideMode)
                    {
                        case ResizeBothSideMode.Percent:
                            rbPercent.Checked = true;
                            cbResize.Checked = true;
                            break;
                        case ResizeBothSideMode.Pixels:
                            rbPixels.Checked = true;
                            cbResize.Checked = true;
                            break;
                    }

                    break;
                case ResizeMode.LongSide:
                    rbSetLongSide.Checked = true;
                    txtLongSide.Text = conversionParameters.ResizeLong.ToString();
                    break;
                case ResizeMode.ShortSide:
                    rbSetShortSize.Checked = true;
                    txtShortSize.Text = conversionParameters.ResizeShort.ToString();
                    break;
                case ResizeMode.ImageSize:
                    rbSetImageSize.Checked = true;
                    txtImageSize.Text = conversionParameters.ResizeImageSize.ToString();
                    break;
                default:
                    cbResize.Checked = false;
                    break;
            }

            // Output Directory
            txtOutputDir.Text = conversionParameters.OutputDir;

            // Threading Setup
            txtThreadCount.Text = conversionParameters.NumThreads.ToString();
        }
        #endregion

        private void rbSetLongSide_CheckedChanged(object sender, EventArgs e)
        {
            txtLongSide.Enabled = rbSetLongSide.Checked;
        }

        private void rbSetShortSize_CheckedChanged(object sender, EventArgs e)
        {
            txtShortSize.Enabled = rbSetShortSize.Checked;
        }

        private void rbSetImageSize_CheckedChanged(object sender, EventArgs e)
        {
            txtImageSize.Enabled = rbSetImageSize.Checked;
        }
    }
}
