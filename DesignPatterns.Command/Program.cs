using DesignPatterns.Command.Commands;

namespace DesignPatterns.Command;

public static class Program
{
    public static void Main()
    {
        var editor = new TextEditor();

        var writeCommand = new WriteCommand(editor, "Hello, world!");
        var cutCommand = new CutCommand(editor, 7, 6);
        var pasteCommand = new PasteCommand(editor, 0);
        var removeCommand = new RemoveCommand(editor, 5, 1);
        var replaceCommand1 = new ReplaceCommand(editor, "dH", "d, h");
        var replaceCommand2 = new ReplaceCommand(editor, "o,", "o!");

        var commands = new ICommand[] { writeCommand, cutCommand, pasteCommand, removeCommand, replaceCommand1, replaceCommand2 };

        var commandsManager = new CommandsManager();
        commandsManager.AddCommands(commands);
        
        commandsManager.ExecuteCommands(() => Console.WriteLine(editor.Text));

        Console.WriteLine(new string('-', 50));
        
        commandsManager.UndoAll(() => Console.WriteLine(editor.Text));
    }
}