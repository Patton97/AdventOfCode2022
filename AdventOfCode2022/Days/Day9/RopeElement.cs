using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2022.Days.Day9;

[DebuggerDisplay("Previous: {PreviousLocation} | Current: {CurrentLocation}")]
internal class RopeElement
{
    internal HashSet<Vector2Int> AllLocations => new(this.allLocations);
    private HashSet<Vector2Int> allLocations { get; } = new();
    internal RopeElement()
    {
        this.allLocations.Add(this.CurrentLocation);
    }

    internal Vector2Int PreviousLocation { get; private set; } = new();
    internal Vector2Int CurrentLocation { get; private set; } = new();
    internal void Move(Vector2Int movementVector)
    {
        this.PreviousLocation = this.CurrentLocation;
        this.SetLocation(this.CurrentLocation + movementVector);
    }
    internal void SetLocation(Vector2Int newLocation)
    {
        this.CurrentLocation = newLocation;
        this.allLocations.Add(this.CurrentLocation);
    }
}

