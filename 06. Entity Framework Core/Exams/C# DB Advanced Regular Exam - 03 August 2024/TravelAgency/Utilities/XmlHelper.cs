using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TravelAgency.Utilities;

public class XmlHelper
{
    public static T Deserialize<T>(string inputXml, string rootName)
    {
        if (string.IsNullOrWhiteSpace(inputXml))
            throw new ArgumentException("Input XML cannot be null or empty.", nameof(inputXml));

        var xmlRoot = new XmlRootAttribute(rootName);
        var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using var stringReader = new StringReader(inputXml);
        if (xmlSerializer.Deserialize(stringReader) is not T result)
            throw new InvalidOperationException($"Deserialization failed. Unable to convert XML to {typeof(T).Name}.");

        return result;
    }

    public static string Serialize<T>(T obj, string rootName, bool omitXmlDeclaration = true, bool xmlIndent = true, bool xmlEmptyNamespace = true)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");

        var xmlRoot = new XmlRootAttribute(rootName);
        var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlWriterSettings xmlSettings = new()
        {
            Encoding = Encoding.UTF8,
            Indent = xmlIndent,
            OmitXmlDeclaration = omitXmlDeclaration
        };

        XmlSerializerNamespaces? namespeces = new XmlSerializerNamespaces();

        if (xmlEmptyNamespace)
        {
            namespeces.Add(String.Empty, String.Empty);
        }

        using var stringWriter = new StringWriter(); // Utf8StringWriter
        using var xmlWriter = XmlWriter.Create(stringWriter, xmlSettings);
        xmlSerializer.Serialize(xmlWriter, obj, namespeces);
        return stringWriter.ToString();
    }
}

