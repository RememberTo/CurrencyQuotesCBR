using Application.Common.DeserializeClasses;
using Domain.Entities;
using System.Xml.Serialization;

namespace Application.Common
{
    public class XMLParser
    {
        internal static IEnumerable<Rate> ParseCurrencyRatesFromXml(string xmlContent)
        {
            var serializer = new XmlSerializer(typeof(ValCurs));
            xmlContent = xmlContent.Replace("<Value>", "<Value>").Replace(",", ".");
            using (var reader = new StringReader(xmlContent))
            {
                var valCurs = serializer.Deserialize(reader) as ValCurs;
                return valCurs.Records.Select(record => new Rate
                {
                    Date = DateTime.Parse(record.Date),
                    Nominal = record.Nominal,
                    Value = record.Value
                }).ToList();
            }
        }

        internal static IEnumerable<Currency> ParseAvailableCurrencyFromXml(string content)
        {
            var currencies = new List<Currency>();

            var serializer = new XmlSerializer(typeof(Valuta));

            using (var reader = new StringReader(content))
            {
                var valuta = serializer.Deserialize(reader) as Valuta;

                if (valuta != null && valuta.Items != null)
                {
                    foreach (var item in valuta.Items)
                    {
                        var currency = new Currency
                        {
                            ID = item.ID,
                            NumCode = item.ISO_Num_Code,
                            CharCode = string.IsNullOrEmpty(item.ISO_Char_Code) ? "Nullable_"+item.ID : item.ISO_Char_Code,
                        };

                        currencies.Add(currency);
                    }
                }
            }

            return currencies;
        }
    }
}
