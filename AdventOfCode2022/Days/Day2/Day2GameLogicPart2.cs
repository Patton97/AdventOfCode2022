﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day2;

class Day2GameLogicPart2 : Day2GameLogic
{
    private readonly record struct StrategyGuideEntry(Choice TheirChoice, Result TargetResult);

    internal override int GetTotalScore(IEnumerable<string> lines)
    {
        return this.GetStrategyGuideEntries(lines)
            .Select(this.GetScore)
            .Sum();
    }

    IEnumerable<StrategyGuideEntry> GetStrategyGuideEntries(IEnumerable<string> lines)
    {
        var charChoiceMappings = new Dictionary<char, Choice>
        {
            { 'A', Choice.Rock },
            { 'B', Choice.Paper },
            { 'C', Choice.Scissors },
        };

        var charResultMappings = new Dictionary<char, Result>
        {
            { 'X', Result.Lose },
            { 'Y', Result.Draw },
            { 'Z', Result.Win },
        };

        return lines.Select(line => new StrategyGuideEntry
        {
            TheirChoice = charChoiceMappings[line[0]],
            TargetResult = charResultMappings[line[2]],
        });
    }

    Choice GetYourChoice(Choice theirChoice, Result targetResult)
    {
        if (targetResult == Result.Draw)
        {
            return theirChoice;
        }

        if (theirChoice == Choice.Rock)
        {
            return targetResult == Result.Win
                ? Choice.Paper
                : Choice.Scissors;
        }

        if (theirChoice == Choice.Paper)
        {
            return targetResult == Result.Win
                ? Choice.Scissors
                : Choice.Rock;
        }

        if (theirChoice == Choice.Scissors)
        {
            return targetResult == Result.Win
                ? Choice.Rock
                : Choice.Paper;
        }

        throw new Exception();
    }

    int GetScore(StrategyGuideEntry entry)
    {
        Choice yourChoice = this.GetYourChoice(entry.TheirChoice, entry.TargetResult);
        return this.GetScore(yourChoice, entry.TargetResult);
    }
}
