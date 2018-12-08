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

namespace Imagizer
{
    public enum ImageFormatEnum
    {
        Bmp,
        Gif,
        Jpeg,
        Png,
        Tiff
    }

    public enum ResizeMode
    {
        None,
        BothSide,
        LongSide,
        ShortSide,
        ImageSize
    }

    public enum ResizeBothSideMode
    {
        None,
        Percent,
        Pixels
    }

    public enum AspectLockState
    {
        LockHeight,
        LockWidth,
        Disabled
    }

}
