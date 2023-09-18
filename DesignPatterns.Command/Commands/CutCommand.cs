namespace DesignPatterns.Command.Commands;

public class CutCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _startIndex;
    private readonly int _length;
    private string _textCut;

    public CutCommand(TextEditor editor, int startIndex, int length)
    {
        _editor = editor;
        _startIndex = startIndex;
        _length = length;
    }

    public void Execute()
    {
        _textCut = _editor.Text.ToString().Substring(_startIndex, _length);
        _editor.Text.Remove(_startIndex, _length);
        _editor.Clipboard = _textCut;
    }

    public void Undo()
    {
        _editor.Text.Insert(_startIndex, _textCut);
    }
}