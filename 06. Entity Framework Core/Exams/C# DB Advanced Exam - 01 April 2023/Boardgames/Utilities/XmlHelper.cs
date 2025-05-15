using System.Xml.Serialization;

namespace Invoices.Utilities;

public static class XmlHelper
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

    public static string Serialize<T>(T obj, string rootName, bool emptyNamespace = true)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");

        var xmlRoot = new XmlRootAttribute(rootName);
        var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        var namespeces = new XmlSerializerNamespaces();

        if (emptyNamespace)
        {
            namespeces.Add("", "");
        }

        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, obj, namespeces);
        return stringWriter.ToString();
    }
}
