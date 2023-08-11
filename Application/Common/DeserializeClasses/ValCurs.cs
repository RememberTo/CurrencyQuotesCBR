using System.Xml.Serialization;

namespace Application.Common.DeserializeClasses
{
    [XmlRoot("ValCurs")]
    public class ValCurs
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlAttribute("DateRange1")]
        public string DateRange1 { get; set; }

        [XmlAttribute("DateRange2")]
        public string DateRange2 { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("Record")]
        public List<Record> Records { get; set; }
    }
}
