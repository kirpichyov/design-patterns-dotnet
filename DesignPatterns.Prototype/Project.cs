namespace DesignPatterns.Prototype;

public class Project : ICloneable<Project>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProjectFolder> Folders { get; set; }
    
    public Project Clone()
    {
        return new Project()
        {
            Name = Name,
            Description = Description,
            Folders = new List<ProjectFolder>(Folders.Select(folder => folder.Clone())),
        };
    }
}

public class ProjectFolder : ICloneable<ProjectFolder>
{
    public string Name { get; set; }
    public ICollection<FolderItem> Items { get; init; }
    
    public ProjectFolder Clone()
    {
        return new ProjectFolder()
        {
            Name = Name,
            Items = new List<FolderItem>(Items.Select(item => item.Clone())),
        };
    }
}

public class FolderItem : ICloneable<FolderItem>
{
    public string Key { get; init; }
    public string Value { get; init; }
    public string Description { get; init; }
    public int Version { get; init; }
    
    public FolderItem Clone()
    {
        return new FolderItem()
        {
            Key = Key,
            Value = Value,
            Description = Description,
            Version = Version,
        };
    }
}