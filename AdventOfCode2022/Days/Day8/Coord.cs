using System.Diagnostics;

namespace AdventOfCode2022.Days.Day8;

[DebuggerDisplay("({X}, {Y})")]
internal readonly record struct Coord(int X, int Y);