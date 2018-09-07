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
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Imagizer2
{
    public static class SerializationUtility
    {
        public static T DeserializeObject<T>(String pXmlizedString)
        {
            return (T)DeserializeObject(pXmlizedString, typeof(T));
        }

        /// <summary>
        /// Method to reconstruct an Object from XML string
        /// </summary>
        /// <param name="pXmlizedString"></param>
        /// <returns></returns>
        public static Object DeserializeObject(String pXmlizedString, Type thisType)
        {
            try
            {
                StringReader reader = new StringReader(pXmlizedString);
                XmlSerializer xs2 = new XmlSerializer(thisType);
                return xs2.Deserialize(reader);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Method to convert a custom Object to XML string
        /// </summary>
        /// <param name="pObject">Object that is to be serialized to XML</param>
        /// <returns>XML string</returns>
        public static String SerializeObject(Object objToSerialize)
        {
            try
            {
                Type thisType = objToSerialize.GetType();
                StringWriter writer = new StringWriter();
                XmlSerializer xs = new XmlSerializer(thisType);

                xs.Serialize(writer, objToSerialize);
                return writer.ToString();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        public static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters, 0, characters.Length);
            return (constructedString);
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
    }
}
