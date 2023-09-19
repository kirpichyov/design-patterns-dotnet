using Bogus;

public class TreeType
{
    public string Name { get; }
    public string Color { get; }

    public TreeType(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Displaying a {Name} tree of color {Color} at coordinates ({x}, {y})");
    }
}

public class TreeFactory
{
    private static Dictionary<string, TreeType> treeTypes = new Dictionary<string, TreeType>();

    public static TreeType GetTreeType(string name, string color)
    {
        if (!treeTypes.ContainsKey(name))
        {
            treeTypes[name] = new TreeType(name, color);
        }
        return treeTypes[name];
    }
}

public class Tree
{
    private readonly TreeType _treeType;
    private readonly int _x;
    private readonly int _y;

    public Tree(TreeType treeType, int x, int y)
    {
        _treeType = treeType;
        _x = x;
        _y = y;
    }

    public void Display()
    {
        _treeType.Display(_x, _y);
    }
}

public class Program
{
    private static readonly Faker Faker = new();
    
    public static void Main()
    {
        var oakType = TreeFactory.GetTreeType("Oak", "Brown");
        var oldOakType = TreeFactory.GetTreeType("Birch", "White");
        var palmType = TreeFactory.GetTreeType("Palm", "Green");

        var treeTypes = new[] { oakType, oldOakType, palmType };

        var trees = Enumerable.Range(1, 9999)
            .Select(_ => new Tree(treeTypes[Random.Shared.Next(0, treeTypes.Length)], x: Faker.Random.Int(), y: Faker.Random.Int()));

        foreach (var tree in trees)
        {
            tree.Display();
        }
    }
}