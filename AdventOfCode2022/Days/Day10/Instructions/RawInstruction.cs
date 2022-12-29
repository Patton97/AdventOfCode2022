using System.Diagnostics;

namespace AdventOfCode2022.Days.Day10.Instructions;

[DebuggerDisplay("{InstructionName} {ParamString}")]
internal readonly record struct RawInstruction(string InstructionName, string ParamString)
{
    internal static RawInstruction Parse(string line)
    {
        string[] lineSegments = line.Split(" ");
        return new RawInstruction
        {
            InstructionName = lineSegments[0],
            ParamString = line.Substring(lineSegments[0].Length),
        };
    }
};
