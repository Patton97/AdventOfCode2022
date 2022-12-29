namespace AdventOfCode2022.Days.Day10.Instructions;

internal class NoopInstruction : Instruction
{
    protected override void PerformInstruction(CPU cpu)
    {
        // no-op
    }
}