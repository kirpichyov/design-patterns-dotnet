namespace DesignPatterns.Adapter;

public class Usage
{
    static void Main(string[] args)
    {
        var xmlFilePath = "path/to/your/xmlfile.xml";
        var yaml = XmlToYamlConverter.ConvertXmlToYaml(xmlFilePath);

        Console.WriteLine(yaml);
    }
}