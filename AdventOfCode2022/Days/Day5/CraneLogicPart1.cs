using System.Collections.Generic;

namespace AdventOfCode2022.Days.Day5;

class CraneLogicPart1 : CraneLogic
{
    internal override void PerformMovementOperation(ref Stack<Crate>[] stacks, MovementOperation movementOperation)
    {
        for (int i = 0; i < movementOperation.MoveAmount; ++i)
        {
            this.MoveCrate(stacks[movementOperation.FromStack - 1], stacks[movementOperation.ToStack - 1]);
        }
    }
}
