using System.Numerics;

namespace DesignPatterns.Memento;

public sealed record GameSave
{
    public Vector3 PlayerPosition { get; init; }
    public string CurrentMap { get; init; }
    public float Health { get; init; }
    public float Money { get; init; }
}