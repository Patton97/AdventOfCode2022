using System.Collections.Generic;
using System.Collections.ObjectModel;

using AdventOfCode2022.Days.Day10.Instructions.Factories;

namespace AdventOfCode2022.Days.Day10.Instructions;

internal class RawInstructionParser
{
    ReadOnlyDictionary<string, InstructionFactory> instructionFactories = new(
        new Dictionary<string, InstructionFactory>
        {
            { "addx", new AddInstructionFactory { TargetRegisterID = 'X' } },
            { "noop", new NoopInstructionFactory() },
        }
    );

    internal Instruction Parse(RawInstruction rawInstruction)
    {
        InstructionFactory factory = this.instructionFactories[rawInstruction.InstructionName];
        return factory.CreateInstruction(rawInstruction);
    }
}
