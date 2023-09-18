using System.Numerics;
using Bogus;

namespace DesignPatterns.Memento;

public class Game
{
    private int _spawnedEnemiesCount;
    private float _chanceToBeAttacked;
    private float _money;
    private float _health;
    private string _currentMap;
    private Vector3 _playerPosition;

    public Game()
    {
        _spawnedEnemiesCount = 3;
        _money = 100.5f;
        _health = 100f;
        _currentMap = "tutorial";
        _playerPosition = new Vector3(10f, 25f, 3.5f);
        _spawnedEnemiesCount = GetEnemiesPerMap(_currentMap);
        _chanceToBeAttacked = GetAttackedChance(_health, _money);
    }
    
    public GameSave Save()
    {
        Console.WriteLine("Game saved");
        
        return new GameSave()
        {
            Money = _money,
            Health = _health,
            CurrentMap = _currentMap,
            PlayerPosition = _playerPosition,
        };
    }

    public void Restore(GameSave save)
    {
        Console.WriteLine("Game loaded");
        
        _currentMap = save.CurrentMap;
        _health = save.Health;
        _money = save.Money;
        _playerPosition = save.PlayerPosition;
        _chanceToBeAttacked = GetAttackedChance(save.Health, save.Money);
        _spawnedEnemiesCount = GetEnemiesPerMap(save.CurrentMap);
    }

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine($"{nameof(_currentMap)}: {_currentMap}");
        Console.WriteLine($"{nameof(_health)}: {_health}");
        Console.WriteLine($"{nameof(_money)}: {_money}");
        Console.WriteLine($"{nameof(_chanceToBeAttacked)}: {_chanceToBeAttacked}");
        Console.WriteLine($"{nameof(_spawnedEnemiesCount)}: {_spawnedEnemiesCount}");
    }

    public void Play()
    {
        Console.WriteLine("Play game.");
        
        var faker = new Faker();
        _currentMap = faker.Random.Word();
        _money = faker.Random.Float(min: 0f, max: 1000000f);
        _health = faker.Random.Float(min: 1f, max: 100f);
        _playerPosition = new Vector3(faker.Random.Float(), faker.Random.Float(), faker.Random.Float());
        _chanceToBeAttacked = GetAttackedChance(_health, _money);
        _spawnedEnemiesCount = GetEnemiesPerMap(_currentMap);
    }

    private float GetAttackedChance(float health, float money)
    {
        return health / 2 * money % 3;
    }
    
    private int GetEnemiesPerMap(string map)
    {
        return map.Length * 10;
    }
}