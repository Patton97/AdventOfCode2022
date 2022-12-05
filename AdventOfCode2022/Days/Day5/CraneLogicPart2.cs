using System.Collections.Generic;

namespace AdventOfCode2022.Days.Day5;

class CraneLogicPart2 : CraneLogic
{
    internal override void PerformMovementOperation(ref Stack<Crate>[] stacks, MovementOperation movementOperation)
    {
        var tempStack = new Stack<Crate>();
        for (int i = 0; i < movementOperation.MoveAmount; ++i)
        {
            this.MoveCrate(stacks[movementOperation.FromStack - 1], tempStack);
        }
        for (int i = 0; i < movementOperation.MoveAmount; ++i)
        {
            this.MoveCrate(tempStack, stacks[movementOperation.ToStack - 1]);
        }
    }
}
