namespace DesignPatterns.Memento;

public class GameMenu
{
    private readonly Dictionary<string, GameSave> _saves = new();
    
    public GameSave LoadSave(string name)
    {
        return _saves[name];
    }
    
    public void StoreSave(GameSave save, string name)
    {
        _saves.Add(name, save);
    }
}