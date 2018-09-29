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


namespace Imagizer2
{
    public class EventProcessor
    {
        private static EventProcessor _instance;

        public delegate void ConversionCompleteEventHandler(object sender);
        public event ConversionCompleteEventHandler ConversionComplete;

        public delegate void SetProgressBarEventHandler(object sender, int percent);
        public event SetProgressBarEventHandler SetProgressBar;

        public static EventProcessor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventProcessor();
                return _instance;
            }
        }

        public void OnConversionComplete(ImgProcessor imgProc)
        {
            ConversionComplete?.Invoke(imgProc);
        }

        public void OnSetProgessBar(ImgProcessor imgProc, int percent)
        {
            SetProgressBar?.Invoke(imgProc, percent);
        }
    }
}
