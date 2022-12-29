namespace AdventOfCode2022.Days.Day10.Instructions;

internal class AddInstruction : Instruction
{
    internal char TargetRegisterID { get; init; }
    internal int IncrementAmount { get; init; }
    protected override void PerformInstruction(CPU cpu)
    {
        cpu.Registers[this.TargetRegisterID].Value += this.IncrementAmount;
    }
}
