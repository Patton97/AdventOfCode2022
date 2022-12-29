using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdventOfCode2022.Days.Day9;

internal readonly record struct RopeLocation(Vector2Int HeadLocation, Vector2Int TailLocation);

internal class RopeSimulator
{
    internal RopeElement Head { get; } = new RopeElement();
    internal RopeElement Tail { get; } = new RopeElement();
    internal ReadOnlyCollection<RopeLocation> AllLocations => new(this.allLocations);
    private List<RopeLocation> allLocations = new();

    internal void PerformMovement(Vector2Int movementVector)
    {
        int movementAmount = Math.Abs(movementVector.X + movementVector.Y);
        for (int i = 0; i < movementAmount; ++i)
        {
            this.MoveHead(movementVector with
            {
                X = movementVector.X / movementAmount,
                Y = movementVector.Y / movementAmount
            });
            this.allLocations.Add(new RopeLocation(this.Head.CurrentLocation, this.Tail.CurrentLocation));
        }
    }

    private void MoveHead(Vector2Int movementVector)
    {
        this.Head.Move(movementVector);
        if (movementVector.X < 0)
        {
            ++movementVector.X;
        }
        if (movementVector.X > 0)
        {
            --movementVector.X;
        }
        if (movementVector.Y < 0)
        {
            ++movementVector.Y;
        }
        if (movementVector.Y > 0)
        {
            --movementVector.Y;
        }
        this.UpdateTail();
    }

    private void UpdateTail()
    {
        if (this.AreHeadAndTailAdjacent())
        {
            return;
        }

        this.Tail.SetLocation(this.Head.PreviousLocation);
    }

    bool AreHeadAndTailAdjacent()
    {
        int deltaX = this.Head.CurrentLocation.X - this.Tail.CurrentLocation.X;
        int deltaY = this.Head.CurrentLocation.Y - this.Tail.CurrentLocation.Y;

        bool areHeadAndTailOverlapping = deltaX == 0 && deltaY == 0;
        if (areHeadAndTailOverlapping)
        {
            return true;
        }
        return -1 <= deltaX && deltaX <= 1
            && -1 <= deltaY && deltaY <= 1;
    }
}

