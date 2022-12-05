using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days.Day5;

class MovementOperationParser
{
    private readonly static Regex movementOperationLineRegex = new Regex(@"(?:move\s)(\d+)(?:\sfrom\s)(\d+)(?:\sto\s)(\d+)", RegexOptions.Compiled);
    internal MovementOperation ParseMovementOperation(string movementOperationLine)
    {
        Match match = movementOperationLineRegex.Match(movementOperationLine);
        return new MovementOperation()
        {
            MoveAmount = int.Parse(match.Groups[1].Value),
            FromStack = int.Parse(match.Groups[2].Value),
            ToStack = int.Parse(match.Groups[3].Value),
        };
    }
}
