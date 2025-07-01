using System.Xml;
using System.Xml.Xsl;

namespace dotnet_rpg.Services.Xml
{
    public class XsltTransformationService : IXsltTransformationService
    {
        private readonly string _xsltPath;
        private readonly IWebHostEnvironment _env;

        public XsltTransformationService(IWebHostEnvironment env)
        {
            _env = env;
            _xsltPath = Path.Combine(_env.ContentRootPath, "XML", "characterListToHtml.xslt");
        }

        public string TransformCharactersToHtml(string xml)
        {
            var xslt = new XslCompiledTransform();
            xslt.Load(_xsltPath);
            using var reader = XmlReader.Create(new StringReader(xml));
            using var sw = new StringWriter();
            xslt.Transform(reader, null, sw);
            return sw.ToString();
        }
    }
}
