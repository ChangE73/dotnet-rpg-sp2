namespace dotnet_rpg.Services.Xml
{
    public interface IXmlValidationService
    {
        bool Validate(string xml, out IList<string> errors);
    }
}
