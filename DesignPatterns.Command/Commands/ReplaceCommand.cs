namespace DesignPatterns.Command.Commands;

public class ReplaceCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly string _target;
    private readonly string _replaceWith;

    public ReplaceCommand(TextEditor textEditor, string target, string replaceWith)
    {
        _textEditor = textEditor;
        _target = target;
        _replaceWith = replaceWith;
    }

    public void Execute()
    {
        _textEditor.Text.Replace(_target, _replaceWith);
    }

    public void Undo()
    {
        _textEditor.Text.Replace(_replaceWith, _target);
    }
}