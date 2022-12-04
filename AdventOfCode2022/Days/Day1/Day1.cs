using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day1;

class Day1 : Day, IDay1
{
    /// <inheritdoc cref="IDay1.SolvePart1"/>
    public override void SolvePart1()
    {
        int highestCalorieCount = this.GetCaloriesPerElf()
            .OrderByDescending(num => num)
            .FirstOrDefault();
        Console.WriteLine($"Highest calorie count = {highestCalorieCount}");
    }

    /// <inheritdoc cref="IDay1.SolvePart2"/>
    public override void SolvePart2()
    {
        IOrderedEnumerable<int> highestCalorieCounts = this.GetCaloriesPerElf()
            .OrderByDescending(num => num);
        int numberOfCountsToPrint = 3;
        int i = 0;
        int sum = 0;
        foreach (int calorieCount in highestCalorieCounts.Take(numberOfCountsToPrint))
        {
            Console.WriteLine($"[{i}] {calorieCount}");
            sum += calorieCount;
            ++i;
        }
        Console.WriteLine($"Highest {numberOfCountsToPrint} calorie counts sum to {sum}");
    }

    IEnumerable<int> GetCaloriesPerElf()
    {
        return CountCaloriesPerElf(this.ReadLines());
    }

    static IEnumerable<int> CountCaloriesPerElf(IEnumerable<string> lines)
    {
        int currentCalorieCount = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                yield return currentCalorieCount;
                currentCalorieCount = 0;
                continue;
            }
            currentCalorieCount += int.Parse(line);
        }
    }
}
