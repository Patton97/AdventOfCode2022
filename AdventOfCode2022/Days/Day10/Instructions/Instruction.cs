using System.Diagnostics;

namespace AdventOfCode2022.Days.Day10.Instructions;

[DebuggerDisplay("{RawInstruction}")]
internal abstract class Instruction
{
    internal required RawInstruction RawInstruction { get; init; }
    internal required uint CycleCost { get; init; }
    internal void Execute(CPU cpu)
    {
        this.PerformCycles(cpu);
        this.PerformInstruction(cpu);
    }
    private void PerformCycles(CPU cpu)
    {
        for (int i = 0; i < this.CycleCost; ++i)
        {
            cpu.PerformCycle();
        }
    }
    protected abstract void PerformInstruction(CPU cpu);
}
