using DesignPatterns.Decorator.Decorators;

namespace DesignPatterns.Decorator;

public class Usage
{
    public static async Task Main()
    {
        var file = new FileDataSource("C:/some-file.txt", "");
        var encryptedFile = new EncryptionDecorator(file);
        var encryptedCompressedFile = new CompressionDecorator(encryptedFile);

        Console.WriteLine(file.Content);
        
        await encryptedCompressedFile.WriteData("this is file data!");
        Console.WriteLine(file.Content);

        var read = await encryptedCompressedFile.ReadData();
        Console.WriteLine(read);
    }
}