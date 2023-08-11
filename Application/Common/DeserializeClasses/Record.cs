using System.Xml.Serialization;

namespace Application.Common.DeserializeClasses
{
    public class Record
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlAttribute("Id")]
        public string Id { get; set; }
       
        [XmlElement("Nominal")]
        public short Nominal { get; set; }

        [XmlElement("Value")]
        public decimal Value { get; set; }
    }
}
