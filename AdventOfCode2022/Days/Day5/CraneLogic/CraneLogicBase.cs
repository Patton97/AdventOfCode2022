using System.Collections.Generic;
using AdventOfCode2022.Days.Day5.DTOs;

namespace AdventOfCode2022.Days.Day5.CraneLogic;

abstract class CraneLogicBase
{
    internal abstract void PerformMovementOperation(ref Stack<Crate>[] stacks, MovementOperation movementOperation);

    protected void MoveCrate(Stack<Crate> fromStack, Stack<Crate> toStack)
    {
        if (fromStack.TryPop(out Crate crate))
        {
            toStack.Push(crate);
        }
    }
}
