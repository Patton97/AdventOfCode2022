using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2022.Days.Day8;

[DebuggerDisplay("({X}, {Y})")]
internal record Coord(int X, int Y)
{
    internal static IEnumerable<Coord> GetAllCoordsBetween(Coord fromCoord, Coord toCoord)
    {
        bool isXShared = fromCoord.X == toCoord.X;
        bool isYShared = fromCoord.Y == toCoord.Y;
        if (isXShared && isYShared)
        {
            throw new InvalidOperationException("They're the same fuckin place, genius");
        }
        if (!isXShared && !isYShared)
        {
            throw new InvalidOperationException("Elves don't understand diagonals");
        }

        int GetUnsharedOrdinate(Coord coord)
        {
            if (isXShared)
            {
                return coord.Y;
            }
            return coord.X;
        }

        Coord UnsharedOrdinateToBetweenCoord(int unsharedOrdinate)
        {
            if (isXShared)
            {
                return new Coord(fromCoord.X, unsharedOrdinate);
            }
            return new Coord(unsharedOrdinate, fromCoord.Y);
        }

        int fromUnsharedOrdinate = GetUnsharedOrdinate(fromCoord);
        int toUnsharedOrdinate = GetUnsharedOrdinate(toCoord);
        return Utils.GetAllIntsBetween(fromUnsharedOrdinate, toUnsharedOrdinate)
            .Select(UnsharedOrdinateToBetweenCoord);
    }
}