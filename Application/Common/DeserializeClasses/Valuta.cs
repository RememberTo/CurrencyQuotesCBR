using System.Xml.Serialization;

namespace Application.Common.DeserializeClasses
{
    public class Valuta
    {
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
    }
}
