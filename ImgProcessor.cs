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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Imagizer2
{
    public class ImgProcessor
    {
        private ConversionParameters _convParms;
        private Thread _processThread;
        private static Object _lockObj = new Object();

        private Thread ProcessThread { get { return _processThread; } set { _processThread = value; } }

        private ImgProcessor(ConversionParameters convParms)
        {
            _convParms = convParms;
        }

        public static void RunImagizer(ConversionParameters convParm)
        {
            DataContainer.Running = true;
            DataContainer.Cancel = false;
            DataContainer.FileList = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(convParm.InputDir);

            foreach (string searchPattern in DataContainer.ImgExtentions)
            {
                foreach (FileInfo file in dirInfo.GetFiles(searchPattern, convParm.IncludeSubDirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                {
                    DataContainer.FileList.Add(file.FullName);
                }
            }

            DataContainer.TotalFiles = DataContainer.FileList.Count;
            DataContainer.ImgProcList = new List<ImgProcessor>();
            for (int i = 0; i < convParm.NumThreads; i++)
            {
                ImgProcessor imgProc = new ImgProcessor(convParm);
                DataContainer.ImgProcList.Add(imgProc);
                ThreadStart startInfo = new ThreadStart(imgProc.ProcessImgQueue);
                imgProc.ProcessThread = new Thread(startInfo);
                imgProc.ProcessThread.Start();
            }
        }

        private void ProcessImgQueue()
        {
            string currentFilename = string.Empty;

            while (!DataContainer.Cancel)
            {
                lock (_lockObj)
                {
                    if (DataContainer.FileList.Count > 0)
                    {
                        currentFilename = DataContainer.FileList[0];
                        DataContainer.FileList.RemoveAt(0);
                    }
                    else
                    {
                        DataContainer.ImgProcList.Remove(this);
                        if (DataContainer.ImgProcList.Count == 0)
                            EventProcessor.Instance.OnConversionComplete(this);
                        break;
                    }
                }

                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + currentFilename);

                string newExtention = string.IsNullOrEmpty(_convParms.NewExtention) ? Path.GetExtension(currentFilename) : _convParms.NewExtention;
                string newFileName = Path.GetDirectoryName(currentFilename) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(currentFilename) + newExtention;
                newFileName = newFileName.Replace(_convParms.InputDir, _convParms.OutputDir);

                if (!Directory.Exists(Path.GetDirectoryName(newFileName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileName));

                if (File.Exists(newFileName))
                    File.Delete(newFileName);

                Image origImage = Image.FromFile(currentFilename, true);
                ImageFormat newImgFormat = origImage.RawFormat;

                if (_convParms.ImageFormat != null)
                    newImgFormat = _convParms.ImageFormat;

                int outputWidth = origImage.Width;
                int outputHeight = origImage.Height;

                if (_convParms.ResizeMode == ResizeMode.Percent)
                {
                    outputWidth = (int)(origImage.Width * ((decimal)_convParms.NewWidth / 100));
                    outputHeight = (int)(origImage.Height * ((decimal)_convParms.NewHeight / 100));
                }
                else if (_convParms.ResizeMode == ResizeMode.Pixels)
                {
                    if (_convParms.AspectLockState == AspectLockState.LockHeight)
                    {
                        //calculate height
                        outputWidth = _convParms.NewWidth;
                        outputHeight = (int)(((double)origImage.Height / origImage.Width) * _convParms.NewWidth);
                    }
                    else if (_convParms.AspectLockState == AspectLockState.LockWidth)
                    {
                        //calculate width
                        outputHeight = _convParms.NewHeight;
                        outputWidth = (int)(((double)origImage.Width / origImage.Height) * _convParms.NewHeight);
                    }
                    else
                    {
                        outputWidth = _convParms.NewWidth;
                        outputHeight = _convParms.NewHeight;
                    }
                }

                Bitmap bp = new Bitmap(outputWidth, outputHeight);
                Graphics g = Graphics.FromImage(bp);
                Rectangle rect = new Rectangle(0, 0, outputWidth, outputHeight);

                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(origImage, rect, 0, 0, origImage.Width, origImage.Height, GraphicsUnit.Pixel);

                foreach (PropertyItem pItem in origImage.PropertyItems)
                {
                    bp.SetPropertyItem(pItem);
                }
                bp.Save(newFileName, newImgFormat);

                int prog = (int)(100 * (((decimal)DataContainer.TotalFiles - (decimal)DataContainer.FileList.Count) / (decimal)DataContainer.TotalFiles));
                EventProcessor.Instance.OnSetProgessBar(this, prog);

                origImage.Dispose();
                bp.Dispose();
                g.Dispose();
            }

            //got here then loop is done
            Thread.CurrentThread.Abort();
        }
    }
}


