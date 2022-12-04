using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Days.Day1;

class Day1 : Day, IDay1
{
    public override void Solve()
    {
        Console.WriteLine("Day 1 | Part 1");
        Console.WriteLine("----------");
        this.SolvePart1();
        Console.WriteLine("");

        Console.WriteLine("Day 1 | Part 2");
        Console.WriteLine("----------");
        this.SolvePart2();
        Console.WriteLine("");

        Utils.WaitForKeyPress();
    }

    /// <inheritdoc/>
    public void SolvePart1()
    {
        int highestCalorieCount = GetCaloriesPerElf().OrderByDescending(num => num).FirstOrDefault();
        Console.WriteLine($"Highest calorie count = {highestCalorieCount}");
    }

    /// <inheritdoc/>
    public void SolvePart2()
    {
        var highestCalorieCounts = GetCaloriesPerElf().OrderByDescending(num => num);
        int numberOfCountsToPrint = 3;
        int i = 0;
        int sum = 0;
        foreach (var calorieCount in highestCalorieCounts.Take(numberOfCountsToPrint))
        {
            Console.WriteLine($"[{i}] {calorieCount}");
            sum += calorieCount;
            ++i;
        }
        Console.WriteLine($"Highest {numberOfCountsToPrint} calorie counts sum to {sum}");
    }

    IEnumerable<int> GetCaloriesPerElf()
    {
        string path = Path.Combine(this.FolderPath, "Day1Input.txt");
        string[] lines = File.ReadAllLines(path);

        return CountCaloriesPerElf(lines);
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
