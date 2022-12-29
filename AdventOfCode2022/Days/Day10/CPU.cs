using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdventOfCode2022.Days.Day10.Instructions;

namespace AdventOfCode2022.Days.Day10;

internal class CPU
{
    internal readonly record struct CycleCompletedEventArgs();

    internal delegate void CycleCompletedEventHandler(CPU sender, CycleCompletedEventArgs e);

    internal event CycleCompletedEventHandler CycleCompleted;

    internal ReadOnlyDictionary<char, Register> Registers { get; }
    internal uint CycleCounter { get; private set; }
    Queue<Instruction> instructions = new();

    internal CPU(IEnumerable<Register> registers)
    {
        this.Registers = registers
            .Select(register => new KeyValuePair<char, Register>(register.ID, register))
            .ToReadOnlyDictionary();
    }

    internal void LoadInstructions(Instruction[] instructions)
    {
        this.instructions = new Queue<Instruction>(instructions);
    }

    internal void PerformCycle()
    {
        ++this.CycleCounter;
        this.CycleCompleted?.Invoke(this, new CycleCompletedEventArgs());
    }

    internal void ExecuteInstructions()
    {
        while (this.instructions.Any())
        {
            this.ExecuteInstruction(this.instructions.Dequeue());
        }
    }

    void ExecuteInstruction(Instruction instruction)
    {
        instruction.Execute(this);
    }
}
