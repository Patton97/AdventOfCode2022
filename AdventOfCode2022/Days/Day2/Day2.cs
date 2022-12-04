using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Days.Day2;

class Day2 : Day, IDay2
{
    public override void Solve()
    {
        Console.WriteLine("Day 2 | Part 1");
        Console.WriteLine("----------");
        this.SolvePart1();
        Console.WriteLine("");
        Utils.WaitForKeyPress();
    }

    public void SolvePart1()
    {
        IEnumerable<StrategyGuideEntry> strategyGuideEntries = this.GetStrategyGuideEntries();
        int score = this.GetStrategyGuideEntries()
            .Select(this.GetScore)
            .Sum();
        Console.WriteLine($"Score: {score}");
    }

    IEnumerable<StrategyGuideEntry> GetStrategyGuideEntries()
    {
        string path = Path.Combine(this.FolderPath, "Day2Input.txt");
        string[] lines = File.ReadAllLines(path);

        var rock = new Move(Choice.Rock, 1);
        var paper = new Move(Choice.Paper, 2);
        var scissors = new Move(Choice.Scissors, 3);

        var charMoveMappings = new Dictionary<char, Move>
        {
            { 'A', rock },
            { 'B', paper },
            { 'C', scissors },
            { 'X', rock },
            { 'Y', paper },
            { 'Z', scissors },
        };

        return lines.Select(line => new StrategyGuideEntry
        {
            TheirMove = charMoveMappings[line[0]],
            YourMove = charMoveMappings[line[2]],
        });
    }

    int GetScore(StrategyGuideEntry entry)
    {
        var resultScores = new Dictionary<Result, int>
        {
            { Result.Lose, 0},
            { Result.Draw, 3},
            { Result.Win, 6},
        };
        Result result = this.GetResult(entry);
        return resultScores[result] + entry.YourMove.Points;
    }

    Result GetResult(StrategyGuideEntry entry)
    {
        if (entry.TheirMove.Choice == entry.YourMove.Choice)
        {
            return Result.Draw;
        }

        if (entry.TheirMove.Choice == Choice.Rock)
        {
            return entry.YourMove.Choice == Choice.Paper
                ? Result.Win
                : Result.Lose;
        }

        if (entry.TheirMove.Choice == Choice.Paper)
        {
            return entry.YourMove.Choice == Choice.Scissors
                ? Result.Win
                : Result.Lose;
        }

        if (entry.TheirMove.Choice == Choice.Scissors)
        {
            return entry.YourMove.Choice == Choice.Rock
                ? Result.Win
                : Result.Lose;
        }

        // technically unreachable, so we'll just say draw to please Mr. Compiler
        return Result.Draw;
    }
}

enum Choice { Rock, Paper, Scissors }

enum Result { Lose, Draw, Win }

readonly record struct Move(Choice Choice, int Points);

readonly record struct StrategyGuideEntry(Move TheirMove, Move YourMove);
