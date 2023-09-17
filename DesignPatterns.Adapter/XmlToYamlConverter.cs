using System.Xml.Linq;
using YamlDotNet.Serialization;

namespace DesignPatterns.Adapter;

public class XmlToYamlConverter
{
    public static string ConvertXmlToYaml(string xmlFilePath)
    {
        // Load the XML document
        XDocument xmlDoc = XDocument.Load(xmlFilePath);

        // Create a dictionary to hold the XML data
        var data = new YamlDotNet.RepresentationModel.YamlMappingNode();

        // Recursively parse the XML and populate the dictionary
        ParseXmlElement(xmlDoc.Root, data);

        // Serialize the dictionary to YAML
        var serializer = new SerializerBuilder().Build();
        return serializer.Serialize(data);
    }

    private static void ParseXmlElement(XElement element, YamlDotNet.RepresentationModel.YamlMappingNode parentNode)
    {
        // Create a new dictionary for this XML element
        var node = new YamlDotNet.RepresentationModel.YamlMappingNode();

        foreach (var childElement in element.Elements())
        {
            if (childElement.HasElements)
            {
                // If the child element has children, recursively parse it
                ParseXmlElement(childElement, node);
            }
            else
            {
                // Otherwise, add the child element's value to the dictionary
                node.Add(childElement.Name.LocalName, childElement.Value);
            }
        }

        // Add the dictionary for this XML element to the parent node
        parentNode.Add(element.Name.LocalName, node);
    }
}