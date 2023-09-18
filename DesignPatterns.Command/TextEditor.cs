using System.Text;

namespace DesignPatterns.Command;

public class TextEditor
{
    public StringBuilder Text { get; } = new();
    public string Clipboard { get; set; }
}