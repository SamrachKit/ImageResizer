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

using System.Collections.Generic;

namespace Imagizer2
{
    /// <summary>
    /// mainly used to store data that the multiple threads wil access
    /// stats used to improve thread safety
    /// </summary>
    public static class DataContainer
    {
        public static List<string> FileList { get; set; }
        public static List<ImgProcessor> ImgProcList { get; set; }
        public static int TotalFiles { get; set; }
        public static bool Running { get; set; }
        public static List<string> ImgExtentions { get; private set; }
        public static bool Cancel { get; set; } = false;

        static DataContainer()
        {
            ImgExtentions = new List<string>();
            ImgExtentions.Add("*.jpg");
            ImgExtentions.Add("*.gif");
            ImgExtentions.Add("*.bmp");
            ImgExtentions.Add("*.png");
            ImgExtentions.Add("*.tiff");
            ImgExtentions.Add("*.jpeg");
        }
    }
}
