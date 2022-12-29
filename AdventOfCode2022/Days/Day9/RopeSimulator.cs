using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdventOfCode2022.Days.Day9;

internal class RopeSimulator
{
    internal ReadOnlyCollection<RopeNode> Nodes { get; }
    internal RopeNode Head => this.Nodes.First();
    internal RopeNode Tail => this.Nodes.Last();

    internal ReadOnlyCollection<RopeLocation> AllLocations => new(this.allLocations);
    private List<RopeLocation> allLocations = new();

    internal RopeSimulator(uint numElements)
    {
        if (numElements < 2)
        {
            throw new ArgumentException(
                message: "Rope must have at least 2 elements (head + tail)",
                paramName: nameof(numElements));
        }

        var nodes = new RopeNode[numElements];
        for (int i = (int)numElements - 1; i >= 0; --i)
        {
            nodes[i] = new RopeNode()
            {
                Follower = nodes.ElementAtOrDefault(i + 1)
            };
        }
        this.Nodes = new(nodes);
    }

    internal void MoveHead(Vector2Int movementVector)
    {
        int movementAmount = Math.Abs(movementVector.X + movementVector.Y);
        for (int movementIndex = 0; movementIndex < movementAmount; ++movementIndex)
        {
            this.Nodes.First().Move(new Vector2Int(
                x: movementVector.X / movementAmount,
                y: movementVector.Y / movementAmount
            ));
            ReadOnlyCollection<Vector2Int> nodeLocations = this.Nodes
                .Select(node => node.CurrentLocation)
                .ToArray()
                .AsReadOnly();
            var ropeLocation = new RopeLocation(nodeLocations);
            this.allLocations.Add(ropeLocation);
        }
    }

    internal string GetDebugString()
    {
        return string.Join("\n", this.AllLocations.Select(this.RopeLocationToDebugString));
    }

    string RopeLocationToDebugString(RopeLocation ropeLocation)
    {
        return string.Join(
            " | ",
            ropeLocation.NodeLocations
                .Select(location => $"({location.X}, {location.Y})")
        );
    }
}

