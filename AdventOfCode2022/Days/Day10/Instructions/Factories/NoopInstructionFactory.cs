namespace AdventOfCode2022.Days.Day10.Instructions.Factories;

internal class NoopInstructionFactory : InstructionFactory
{
    internal override Instruction CreateInstruction(RawInstruction rawInstruction)
    {
        return new NoopInstruction
        {
            RawInstruction = rawInstruction,
            CycleCost = 1,
        };
    }
}
