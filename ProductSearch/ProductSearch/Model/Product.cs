using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Remix
{
    [XmlType("product")]
    public class Product
    {
        [XmlElement("sku")]
        public string Sku = "";

        [XmlElement("productId")]
        public string ProductId = "";

        [XmlElement("name")]
        public string Name = "";

        [XmlElement("artistName")]
        public string ArtistName = "";

        [XmlElement("type")]
        public string Type = "";

        [XmlElement("regularPrice")]
        public string RegularPrice = "";

        [XmlElement("salePrice")]
        public string SalePrice = "";

        [XmlElement("url")]
        public string BBYUrl = "";

        [XmlElement("thumbnailImage")]
        public string imageUrl = "";

        [XmlElement("inStoreAvailability")]
        public string InStoreAvailability = "";

        [XmlElement("onlineAvailability")]
        public string OnlineAvailability = "";

        private List<Store> _stores = new List<Store>();

        [XmlArray("stores")]
        public List<Store> Stores
        {
            get { return _stores; }
            set { _stores = value; }
        }

        [XmlAttribute("guid")]
        public string Guid;

        public Product() { }

        public Product(string imageUrl, string salePrice)
        {
            this.imageUrl = imageUrl;
            this.SalePrice = salePrice;
        }

        public Product(string sku, string productid, string name, string artistname, string type,
                       string regularprice, string saleprice, string bbyurl,
                       string instoreavailability, string onlineavailability)
        {
            this.Sku = sku;
            this.ProductId = productid;
            this.Name = name;
            this.ArtistName = artistname;
            this.Type = type;
            this.RegularPrice = regularprice;
            this.SalePrice = saleprice;
            this.BBYUrl = bbyurl;
            this.InStoreAvailability = instoreavailability;
            this.OnlineAvailability = onlineavailability;
        }

        public override bool Equals(object obj)
        {
            return obj is Product &&
                   ((Product)obj).Sku == Sku &&
                   ((Product)obj).ProductId == ProductId &&
                   ((Product)obj).Name == Name &&
                   ((Product)obj).ArtistName == ArtistName &&
                   ((Product)obj).Type == Type;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public String ToXml()
        {
            return UTF8XmlSerializer.Serialize(this);
        }
    }
}