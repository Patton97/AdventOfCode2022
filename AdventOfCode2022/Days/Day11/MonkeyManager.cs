using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdventOfCode2022.Days.Day11;

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

    internal int GetMonkeyBusiness()
    {
        return this.Monkeys
            .Select(monkey => monkey.Value.ItemsInspected)
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
