using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Days.Day10.Instructions;

namespace AdventOfCode2022.Days.Day10;

internal class Day10 : Day
{
    public override void SolvePart1()
    {
        var signalStrengths = new List<int>();
        void Cpu_CycleCompleted(CPU sender, CPU.CycleCompletedEventArgs e)
        {
            if ((sender.CycleCounter + 20) % 40 != 0)
            {
                return;
            }

            Register xRegister = sender.Registers['X'];
            signalStrengths.Add((int)sender.CycleCounter * xRegister.Value);
        }
        var registers = new Register[]
        {
            new Register { ID = 'X', Value = 1, },
        };
        var cpu = new CPU(registers);
        cpu.CycleCompleted += Cpu_CycleCompleted;

        var parser = new RawInstructionParser();
        Instruction[] instructions = this.ReadLines()
            .Select(RawInstruction.Parse)
            .Select(parser.Parse)
            .ToArray();
        cpu.LoadInstructions(instructions);
        cpu.ExecuteInstructions();

        Console.WriteLine($"Sum of desired signal strengths: {signalStrengths.Sum()}");
    }

    public override void SolvePart2()
    {

    }
}
