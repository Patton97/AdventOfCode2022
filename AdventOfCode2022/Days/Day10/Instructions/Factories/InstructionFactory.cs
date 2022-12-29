namespace AdventOfCode2022.Days.Day10.Instructions.Factories;

internal abstract class InstructionFactory
{
    internal abstract Instruction CreateInstruction(RawInstruction rawInstruction);
}
