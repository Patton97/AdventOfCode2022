using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdventOfCode2022;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal class MonkeyManager
{
    internal ReadOnlyDictionary<int, Monkey> Monkeys { get; }
    internal MonkeyManager(IEnumerable<Monkey> monkeys)
    {
        this.Monkeys = monkeys
            .ToDictionary(monkey => monkey.ID, monkey => monkey)
            .ToReadOnlyDictionary();
    }

    internal void ProcessRounds(int numRounds)
    {
        for (int i = 0; i < numRounds; ++i)
        {
            this.ProcessRound();
        }
    }

    internal ulong GetMonkeyBusiness()
    {
        return this.Monkeys
            .Select(monkey => (ulong)monkey.Value.ItemsInspected)
            .OrderByDescending(x => x)
            .Take(2)
            .Product();
    }

    private void ProcessRound()
    {
        foreach (Monkey monkey in this.Monkeys.Values)
        {
            monkey.TakeTurn(this.Monkeys);
        }
    }
}
