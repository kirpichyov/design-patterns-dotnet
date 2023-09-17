namespace DesignPatterns.Composite;

using System;
using System.Collections.Generic;

public abstract class Graphic
{
    public abstract void Render();
    public abstract void Select();
    public abstract void Deselect();
}

public class Circle : Graphic
{
    public override void Render()
    {
        Console.WriteLine("Rendering a circle");
    }

    public override void Select()
    {
        Console.WriteLine("Shape selected. Outline style applied.");
    }

    public override void Deselect()
    {
        Console.WriteLine("Shape deselected. Default style applied.");
    }
}

public class Square : Graphic
{
    public override void Render()
    {
        Console.WriteLine("Rendering a square");
    }

    public override void Select()
    {
        Console.WriteLine("Shape selected. Outline style applied.");
    }

    public override void Deselect()
    {
        Console.WriteLine("Shape deselected. Default style applied.");
    }
}

public class GraphicGroup : Graphic
{
    private readonly List<Graphic> _graphics = new();

    public void AddGraphic(Graphic graphic)
    {
        _graphics.Add(graphic);
    }

    public override void Render()
    {
        Console.WriteLine("Rendering a group of graphics:");
        foreach (var graphic in _graphics)
        {
            graphic.Render();
        }
    }

    public override void Select()
    {
        Console.WriteLine("Shape selected. Outline style applied.");
    }

    public override void Deselect()
    {
        Console.WriteLine("Shape deselected. Default style applied.");
    }
}

public class Program
{
    public static void Main()
    {
        var circle = new Circle();
        var square = new Square();

        var group = new GraphicGroup();
        group.AddGraphic(circle);
        group.AddGraphic(square);

        group.Render();
        group.Select();
        group.Deselect();
    }
}