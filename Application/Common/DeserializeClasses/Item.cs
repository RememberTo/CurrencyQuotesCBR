using System.Xml.Serialization;

namespace Application.Common.DeserializeClasses
{
    public class Item
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        public string Name { get; set; }
        public string EngName { get; set; }
        public string Nominal { get; set; }
        public string ParentCode { get; set; }
        public string ISO_Num_Code { get; set; }
        public string ISO_Char_Code { get; set; }
    }
}
