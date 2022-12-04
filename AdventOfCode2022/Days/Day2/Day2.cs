using System;
using System.IO;

namespace AdventOfCode2022.Days.Day2;

class Day2 : Day, IDay2
{
    public override void Solve()
    {
        Console.WriteLine("Day 2 | Part 1");
        Console.WriteLine("----------");
        this.SolvePart1();
        Console.WriteLine("");

        Console.WriteLine("Day 2 | Part 2");
        Console.WriteLine("----------");
        this.SolvePart2();
        Console.WriteLine("");

        Utils.WaitForKeyPress();
    }

    public void SolvePart1() => this.SolvePart(new Day2GameLogicPart1());
    public void SolvePart2() => this.SolvePart(new Day2GameLogicPart2());

    void SolvePart(Day2GameLogic logic)
    {
        string path = Path.Combine(this.FolderPath, "Day2Input.txt");
        string[] lines = File.ReadAllLines(path);
        int score = logic.GetTotalScore(lines);
        
        Console.WriteLine($"Score: {score}");
    }
}

enum Choice { Rock, Paper, Scissors }

enum Result { Lose, Draw, Win }
