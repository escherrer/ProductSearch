/*    Remix.NET
 * 
 * Remix.NET is licensed under the MIT license:
 * http://www.opensource.org/licenses/mit-license.html
 * 
 * Copyright (c) 2009 Omar Abdelwahed
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
using System.Collections.Generic;
using System.Xml.Serialization;
using ProductSearch.Utility;

namespace ProductSearch.Model
{
    [XmlRoot("products")]
    public class Products : List<Product>
    {
        [XmlAttribute("currentPage")]
        public string CurrentPage;

        [XmlAttribute("totalPages")]
        public string TotalPages;

        [XmlAttribute("from")]
        public string From;

        [XmlAttribute("to")]
        public string To;

        [XmlAttribute("total")]
        public string Total;

        [XmlAttribute("queryTime")]
        public string QueryTime;

        [XmlAttribute("totalTime")]
        public string TotalTime;

        [XmlAttribute("canonicalUrl")]
        public string CanonicalURL;

        [XmlAttribute("guid")]
        public string Guid;

        public Products() { }

        public Products(string currentpage, string totalpages, string from, string to,
                    string total, string querytime, string totaltime, string canonicalurl)
        {
            this.CurrentPage = currentpage;
            this.TotalPages = totalpages;
            this.From = from;
            this.To = to;
            this.Total = total;
            this.QueryTime = querytime;
            this.TotalTime = totaltime;
            this.CanonicalURL = canonicalurl;
        }

        public override bool Equals(object obj)
        {
            var bRet = false;
            var prods = ((Products)obj);

            if (this.Count == prods.Count)
            {
                for (int x = 0; x < this.Count; x++)
                {
                    Product p1 = this[x];
                    Product p2 = prods[x];
                    bRet = p1.Equals(p2);
                    if (!bRet) break;
                }
            }

            return bRet;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public string ToXml()
        {
            return Utf8XmlSerializer.Serialize(this);
        }
    }
}

