using System.Diagnostics;

namespace AdventOfCode2022.Days.Day8;

[DebuggerDisplay("({Coord.X}, {Coord.Y}) | {Height}")]
internal record Tree(int Height, Vector2Int Coord)
{
    internal bool IsTreeVisibleWhenBehind(Tree otherTree)
    {
        return otherTree.Height < this.Height;
    }
}