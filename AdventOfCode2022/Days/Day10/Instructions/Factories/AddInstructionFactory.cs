namespace AdventOfCode2022.Days.Day10.Instructions.Factories;

internal class AddInstructionFactory : InstructionFactory
{
    internal required char TargetRegisterID { get; init; }

    internal override Instruction CreateInstruction(RawInstruction rawInstruction)
    {
        return new AddInstruction
        {
            RawInstruction = rawInstruction,
            CycleCost = 2,
            TargetRegisterID = this.TargetRegisterID,
            IncrementAmount = int.Parse(rawInstruction.ParamString),
        };
    }
}
