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

using System.Drawing.Imaging;
using System.Xml.Serialization;

namespace Imagizer
{
    /// <summary>
    /// This class is serialized in and out of the settings file so that selected options persist.
    /// It is also passed to the ImgProcessor class in it's constructor to set things up.
    /// </summary>
    public class ConversionParameters
    {
        public string InputDir { get; set; }

        public bool IncludeSubDirs { get; set; }

        public string NewExtention { get; set; }

        public bool Resize { get; set; }

        public ResizeMode ResizeMode { get; set; }

        public ResizeBothSideMode ResizeBothSideMode { get; set; }

        public int ResizeWidth { get; set; }
        public int ResizeHeight { get; set; }
        public int ResizeLong { get; set; }
        public int ResizeShort { get; set; }
        public float ResizeImageSize { get; set; }
        
        public string OutputDir { get; set; }

        public int NumThreads { get; set; }

        [XmlIgnore]
        public ImageFormat ImageFormat { get; set; }

        public AspectLockState AspectLockState { get; set; }
        /// <summary>
        /// This is used as a wrapper for the ImageFormat class which does not serialize
        /// We just convert it to/from an enum when serializing and de-serializing
        /// </summary>
        public ImageFormatEnum ImageFmtEnum
        {
            get
            {
                if (ImageFormat == ImageFormat.Jpeg)
                    return ImageFormatEnum.Jpeg;

                else if (ImageFormat == ImageFormat.Gif)
                    return ImageFormatEnum.Gif;

                else if (ImageFormat == ImageFormat.Bmp)
                    return ImageFormatEnum.Bmp;

                else if (ImageFormat == ImageFormat.Png)
                    return ImageFormatEnum.Png;

                else if (ImageFormat == ImageFormat.Tiff)
                    return ImageFormatEnum.Tiff;

                //default to jpg
                return ImageFormatEnum.Jpeg;
            }
            set
            {
                switch (value)
                {
                    case ImageFormatEnum.Bmp:
                        ImageFormat = ImageFormat.Bmp;
                        break;
                    case ImageFormatEnum.Gif:
                        ImageFormat = ImageFormat.Gif;
                        break;
                    case ImageFormatEnum.Jpeg:
                        ImageFormat = ImageFormat.Jpeg;
                        break;
                    case ImageFormatEnum.Png:
                        ImageFormat = ImageFormat.Png;
                        break;
                    case ImageFormatEnum.Tiff:
                        ImageFormat = ImageFormat.Tiff;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
