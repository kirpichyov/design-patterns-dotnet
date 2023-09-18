namespace DesignPatterns.Command.Commands;

public class PasteCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _startIndex;
    private string _prevClipboard;

    public PasteCommand(TextEditor editor, int startIndex)
    {
        _editor = editor;
        _startIndex = startIndex;
    }

    public void Execute()
    {
        _prevClipboard = _editor.Clipboard;
        _editor.Text.Insert(_startIndex, _editor.Clipboard);
    }

    public void Undo()
    {
        _editor.Text.Remove(_startIndex, _prevClipboard.Length);
    }
}