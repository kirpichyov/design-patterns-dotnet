using DesignPatterns.Decorator.Decorators;

namespace DesignPatterns.Decorator;

public class Usage
{
    public static void Main()
    {
        const string data = "This is data.";
        
        var file = new FileDataSource("C:/some-file.txt");
        var encryptedFile = new EncryptionDecorator(file);
        var encryptedCompressedFile = new CompressionDecorator(encryptedFile);

        encryptedCompressedFile.WriteData(data);
    }
}