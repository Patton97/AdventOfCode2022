using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2022.Days.Day9;

[DebuggerDisplay("{PreviousLocation} -> {CurrentLocation}")]
internal class RopeNode
{
    internal RopeNode Follower { get; init; }
    internal HashSet<Vector2Int> AllLocations => new(this.allLocations);
    private HashSet<Vector2Int> allLocations { get; } = new();
    internal RopeNode()
    {
        this.allLocations.Add(this.CurrentLocation);
    }

    internal Vector2Int PreviousLocation { get; private set; } = new();
    internal Vector2Int CurrentLocation { get; private set; } = new();
    internal void Move(Vector2Int movementVector)
    {
        this.SetLocation(this.CurrentLocation + movementVector);
    }
    internal void SetLocation(Vector2Int newLocation)
    {
        this.PreviousLocation = this.CurrentLocation;
        this.CurrentLocation = newLocation;
        this.allLocations.Add(this.CurrentLocation);

        this.UpdateFollower();
    }

    void UpdateFollower()
    {
        if (this.Follower == null || this.IsFollowerAdjacent(out int deltaX, out int deltaY))
        {
            return;
        }

        var movementVector = new Vector2Int();
        if (deltaX != 0)
        {
            movementVector.X = deltaX / Math.Abs(deltaX);
        }
        if (deltaY != 0)
        {
            movementVector.Y = deltaY / Math.Abs(deltaY);
        }

        this.Follower.Move(movementVector);
    }

    bool IsFollowerAdjacent(out int deltaX, out int deltaY)
    {
        deltaX = this.CurrentLocation.X - this.Follower.CurrentLocation.X;
        deltaY = this.CurrentLocation.Y - this.Follower.CurrentLocation.Y;
        bool areHeadAndTailOverlapping = deltaX == 0 && deltaY == 0;
        if (areHeadAndTailOverlapping)
        {
            return true;
        }
        return -1 <= deltaX && deltaX <= 1
            && -1 <= deltaY && deltaY <= 1;
    }
}

