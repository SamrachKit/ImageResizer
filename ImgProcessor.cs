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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Imagizer
{
    public class ImgProcessor
    {
        private ConversionParameters _convParms;
        private static Object _lockObj = new Object();

        private Thread ProcessThread { get; set; }

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

                double imageAspectRatio = (double)origImage.Width / origImage.Height;
                int outputWidth = origImage.Width;
                int outputHeight = origImage.Height;

                switch (_convParms.ResizeMode)
                {
                    case ResizeMode.None:
                        break;
                    case ResizeMode.BothSide:
                        if (_convParms.ResizeBothSideMode == ResizeBothSideMode.Percent)
                        {
                            outputWidth = (int)(origImage.Width * ((decimal)_convParms.ResizeWidth / 100));
                            outputHeight = (int)(origImage.Height * ((decimal)_convParms.ResizeHeight / 100));
                        }
                        else if (_convParms.ResizeBothSideMode == ResizeBothSideMode.Pixels)
                        {
                            if (_convParms.AspectLockState == AspectLockState.LockHeight)
                            {
                                //calculate height
                                outputWidth = _convParms.ResizeWidth;
                                outputHeight = (int)(1 / imageAspectRatio * _convParms.ResizeWidth);
                            }
                            else if (_convParms.AspectLockState == AspectLockState.LockWidth)
                            {
                                //calculate width
                                outputHeight = _convParms.ResizeHeight;
                                outputWidth = (int)(imageAspectRatio * _convParms.ResizeHeight);
                            }
                            else
                            {
                                outputWidth = _convParms.ResizeWidth;
                                outputHeight = _convParms.ResizeHeight;
                            }
                        }
                        break;
                    case ResizeMode.LongSide:
                        int longSide = _convParms.ResizeLong;
                        if (outputWidth > outputHeight)
                        {   //calculate height
                            outputWidth = longSide;
                            outputHeight = (int)(1 / imageAspectRatio * longSide);
                        }
                        else
                        {   //calculate width
                            outputHeight = longSide;
                            outputWidth = (int)(imageAspectRatio * longSide);
                        }
                        break;
                    case ResizeMode.ShortSide:
                        int shortSide = _convParms.ResizeShort;
                        if (outputWidth < outputHeight)
                        {   //calculate height
                            outputWidth = shortSide;
                            outputHeight = (int)(1 / imageAspectRatio * shortSide);
                        }
                        else
                        {   //calculate width
                            outputHeight = shortSide;
                            outputWidth = (int)(imageAspectRatio * shortSide);
                        }
                        break;
                    case ResizeMode.ImageSize:
                        double newImageSize = _convParms.ResizeImageSize * 1000000;
                        outputHeight = (int)Math.Sqrt(newImageSize / imageAspectRatio);
                        outputWidth = (int)(newImageSize / outputHeight);
                        break;
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

                int prog = (int)(100 * ((DataContainer.TotalFiles - (decimal)DataContainer.FileList.Count) / DataContainer.TotalFiles));
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


