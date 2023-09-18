namespace DesignPatterns.Command.Commands;

public class RemoveCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly int _startIndex;
    private readonly int _length;
    private string _removed;

    public RemoveCommand(TextEditor textEditor, int startIndex, int length)
    {
        _textEditor = textEditor;
        _startIndex = startIndex;
        _length = length;
    }

    public void Execute()
    {
        _removed = _textEditor.Text.ToString().Substring(_startIndex, _length);
        _textEditor.Text.Remove(_startIndex, _length);
    }

    public void Undo()
    {
        _textEditor.Text.Insert(_startIndex, _removed);
    }
}