namespace DesignPatterns.Command.Commands;

public class WriteCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;
    private int _prevLength;

    public WriteCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _prevLength = _editor.Text.Length;
        _editor.Text.Append(_text, 0, _text.Length);
    }

    public void Undo()
    {
        _editor.Text.Remove(_prevLength, _text.Length);
    }
}