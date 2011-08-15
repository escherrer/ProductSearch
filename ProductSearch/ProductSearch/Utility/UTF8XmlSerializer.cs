/*    Remix.NET
##    Copyright 2008 Omar Abdelwahed
##
##    This file is part of Remix.NET.
##
##    Remix.NET is free software: you can redistribute it and/or modify
##    it under the terms of the GNU General Public License as published by
##    the Free Software Foundation, either version 3 of the License, or
##    (at your option) any later version.
##
##    Remix.NET is distributed in the hope that it will be useful,
##    but WITHOUT ANY WARRANTY; without even the implied warranty of
##    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
##    GNU General Public License for more details.
##
##    You should have received a copy of the GNU General Public License
##    along with Shelftalkers.  If not, see <http://www.gnu.org/licenses/>.
*/
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ProductSearch.Utility
{
    public class Utf8XmlSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var stream = new MemoryStream();
            using (var writer = new XmlTextWriter(stream, new UTF8Encoding(false)))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                new XmlSerializer(typeof(T)).Serialize(writer, obj);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xml));
        }
    }
}