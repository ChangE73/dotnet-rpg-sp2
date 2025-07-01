using System.Xml.Linq;
using System.Xml.Serialization;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Helpers
{
    public static class XmlHelper
    {
        public static string SerializeCharacter(GetCharacterDto character)
        {
            var serializer = new XmlSerializer(typeof(GetCharacterDto));
            using var writer = new StringWriter();
            serializer.Serialize(writer, character);
            return writer.ToString();
        }

        public static GetCharacterDto DeserializeCharacter(string xml)
        {
            var serializer = new XmlSerializer(typeof(GetCharacterDto));
            using var reader = new StringReader(xml);
            return (GetCharacterDto)serializer.Deserialize(reader)!;
        }

        public static XDocument LoadDocument(string path) => XDocument.Load(path);

        public static IEnumerable<string> GetCharacterNamesWithStrengthGreaterThan(XDocument doc, int minStrength = 10)
        {
            return doc.Descendants("GetCharacterDto")
                .Where(e => (int?)e.Element("Strength") > minStrength)
                .Select(e => (string?)e.Element("Name") ?? string.Empty);
        }
    }
}
