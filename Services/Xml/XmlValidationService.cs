using System.Xml.Linq;
using System.Xml.Schema;

namespace dotnet_rpg.Services.Xml
{
    public class XmlValidationService : IXmlValidationService
    {
        private readonly string _schemaPath;
        private readonly IWebHostEnvironment _env;

        public XmlValidationService(IWebHostEnvironment env)
        {
            _env = env;
            _schemaPath = Path.Combine(_env.ContentRootPath, "XML", "character.xsd");
        }

        public bool Validate(string xml, out IList<string> errors)
        {   
            var localErrors = new List<string>();
            errors = localErrors; // Assign out parameter after initialization

            var schemas = new XmlSchemaSet();
            schemas.Add(null, _schemaPath);

            var doc = XDocument.Parse(xml);
            doc.Validate(schemas, (o, e) => localErrors.Add(e.Message));

            return localErrors.Count == 0;
        }

    }
}
