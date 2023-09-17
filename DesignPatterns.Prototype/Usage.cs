namespace DesignPatterns.Prototype;

public class Usage
{
    public void Main()
    {
        var project1 = new Project
        {
            Name = "Some project",
            Description = "Can you clone me?"
        };

        project1.Folders.Add(new ProjectFolder()
        {
            Name = "Folder 1",
            Items = new List<FolderItem>()
            {
                new FolderItem()
                {
                    Key = "Key 1",
                    Value = "Value 1",
                    Version = 1,
                }
            }
        });

        var clone = project1.Clone();
    }
}