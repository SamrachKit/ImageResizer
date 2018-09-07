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

using System.Collections.Generic;

namespace Imagizer2
{
    /// <summary>
    /// mainly used to store data that the multiple threads wil access
    /// stats used to improve thread safety
    /// </summary>
    public static class DataContainer
    {
        private static List<string> _fileList;
        private static List<ImgProcessor> _imgProcList;
        private static int _totalFiles;
        private static bool _running;
        private static List<string> _imgExtentions;
        private static bool _cancel = false;

        public static List<string> FileList { get { return _fileList; } set { _fileList = value; } }
        public static List<ImgProcessor> ImgProcList { get { return _imgProcList; } set { _imgProcList = value; } }
        public static int TotalFiles { get { return _totalFiles; } set { _totalFiles = value; } }
        public static bool Running { get { return _running; } set { _running = value; } }
        public static List<string> ImgExtentions { get { return _imgExtentions; } private set { _imgExtentions = value; } }
        public static bool Cancel { get { return _cancel; } set { _cancel = value; } }

        static DataContainer()
        {
            _imgExtentions = new List<string>();
            _imgExtentions.Add("*.jpg");
            _imgExtentions.Add("*.gif");
            _imgExtentions.Add("*.bmp");
            _imgExtentions.Add("*.png");
            _imgExtentions.Add("*.tiff");
            _imgExtentions.Add("*.jpeg");
            _imgExtentions.Add("*.ico");
            _imgExtentions.Add("*.emf");
            _imgExtentions.Add("*.wmf");
            _imgExtentions.Add("*.exif");
        }
    }
}
