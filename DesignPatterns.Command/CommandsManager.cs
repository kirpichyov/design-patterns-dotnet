namespace DesignPatterns.Command;

public class CommandsManager
{
    private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();
    private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commandQueue.Enqueue(command);
    }
    
    public void AddCommands(IEnumerable<ICommand> commands)
    {
        foreach (var command in commands)
        {
            _commandQueue.Enqueue(command);
        }
    }

    public void ExecuteCommands(Action onExecuted = null)
    {
        while (_commandQueue.Count > 0)
        {
            var command = _commandQueue.Dequeue();
            command.Execute();
            _commandHistory.Push(command);
            
            onExecuted?.Invoke();
        }
    }

    public void Undo()
    {
        if (_commandHistory.Count <= 0)
        {
            return;
        }

        var command = _commandHistory.Pop();
        command.Undo();
    }

    public void UndoAll(Action onExecuted)
    {
        while (_commandHistory.Count > 0)
        {
            Undo();
            onExecuted?.Invoke();
        }
    }
}