using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2022;

[DebuggerDisplay("({X}, {Y})")]
internal struct Vector2Int
{
    internal int X { get; set; }
    internal int Y { get; set; }
    internal Vector2Int(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Y + b.Y);
    public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Y - b.Y);

    internal static IEnumerable<Vector2Int> GetAllVectorsBetween(Vector2Int fromVector, Vector2Int toVector)
    {
        bool isXShared = fromVector.X == toVector.X;
        bool isYShared = fromVector.Y == toVector.Y;
        if (isXShared && isYShared)
        {
            throw new InvalidOperationException("They're the same fuckin place, genius");
        }
        if (!isXShared && !isYShared)
        {
            throw new InvalidOperationException("Elves don't understand diagonals");
        }

        int GetUnsharedOrdinate(Vector2Int Vector)
        {
            if (isXShared)
            {
                return Vector.Y;
            }
            return Vector.X;
        }

        Vector2Int UnsharedOrdinateToBetweenVector(int unsharedOrdinate)
        {
            if (isXShared)
            {
                return new Vector2Int(fromVector.X, unsharedOrdinate);
            }
            return new Vector2Int(unsharedOrdinate, fromVector.Y);
        }

        int fromUnsharedOrdinate = GetUnsharedOrdinate(fromVector);
        int toUnsharedOrdinate = GetUnsharedOrdinate(toVector);
        return Utils.GetAllIntsBetween(fromUnsharedOrdinate, toUnsharedOrdinate)
            .Select(UnsharedOrdinateToBetweenVector);
    }
}