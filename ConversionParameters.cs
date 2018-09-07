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

using System.Drawing.Imaging;
using System.Xml.Serialization;

namespace Imagizer2
{
    /// <summary>
    /// This class is serialized in and out of the settings file so that selected options persist.
    /// It is also passed to the ImgProcessor class in it's constructor to set things up.
    /// </summary>
    public class ConversionParameters
    {
        int _numThreads;
        string _inputDir;
        string _outputDir;
        ResizeMode _resizeMode;
        int _newWidth;
        int _newHeight;
        ImageFormat _imageFormat;
        string _newExtention;
        bool _includeSubDirs;
        AspectLockState _aspectLockState;

        public int NumThreads { get { return _numThreads; } set { _numThreads = value; } }
        public string InputDir { get { return _inputDir; } set { _inputDir = value; } }
        public string OutputDir { get { return _outputDir; } set { _outputDir = value; } }
        public ResizeMode ResizeMode { get { return _resizeMode; } set { _resizeMode = value; } }
        public int NewWidth { get { return _newWidth; } set { _newWidth = value; } }
        public int NewHeight { get { return _newHeight; } set { _newHeight = value; } }
        [XmlIgnore]
        public ImageFormat ImageFormat { get { return _imageFormat; } set { _imageFormat = value; } }
        public string NewExtention { get { return _newExtention; } set { _newExtention = value; } }
        public bool IncludeSubDirs { get { return _includeSubDirs; } set { _includeSubDirs = value; } }
        public AspectLockState AspectLockState { get { return _aspectLockState; } set { _aspectLockState = value; } }
        /// <summary>
        /// This is used as a wrapper for the ImageFormat class which does not serialize
        /// We just convert it to/from an enum when serializing and de-serializing
        /// </summary>
        public ImageFormatEnum ImageFmtEnum
        {
            get
            {
                if (_imageFormat == ImageFormat.Jpeg)
                    return ImageFormatEnum.Jpeg;

                else if (_imageFormat == ImageFormat.Gif)
                    return ImageFormatEnum.Gif;

                else if (_imageFormat == ImageFormat.Bmp)
                    return ImageFormatEnum.Bmp;

                else if (_imageFormat == ImageFormat.Png)
                    return ImageFormatEnum.Png;

                else if (_imageFormat == ImageFormat.Tiff)
                    return ImageFormatEnum.Tiff;

                else if (_imageFormat == ImageFormat.Wmf)
                    return ImageFormatEnum.Wmf;

                else if (_imageFormat == ImageFormat.Exif)
                    return ImageFormatEnum.Exif;

                else if (_imageFormat == ImageFormat.Emf)
                    return ImageFormatEnum.Emf;

                else if (_imageFormat == ImageFormat.Icon)
                    return ImageFormatEnum.Icon;

                //default to jpg
                return ImageFormatEnum.Jpeg;
            }
            set
            {
                switch (value)
                {
                    case ImageFormatEnum.Bmp:
                        _imageFormat = ImageFormat.Bmp;
                        break;
                    case ImageFormatEnum.Emf:
                        _imageFormat = ImageFormat.Emf;
                        break;
                    case ImageFormatEnum.Exif:
                        _imageFormat = ImageFormat.Exif;
                        break;
                    case ImageFormatEnum.Gif:
                        _imageFormat = ImageFormat.Gif;
                        break;
                    case ImageFormatEnum.Icon:
                        _imageFormat = ImageFormat.Icon;
                        break;
                    case ImageFormatEnum.Jpeg:
                        _imageFormat = ImageFormat.Jpeg;
                        break;
                    case ImageFormatEnum.Png:
                        _imageFormat = ImageFormat.Png;
                        break;
                    case ImageFormatEnum.Tiff:
                        _imageFormat = ImageFormat.Tiff;
                        break;
                    case ImageFormatEnum.Wmf:
                        _imageFormat = ImageFormat.Wmf;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
