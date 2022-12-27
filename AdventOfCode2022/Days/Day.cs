﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2022.Days;

public abstract class Day : IDay
{
    public void Solve()
    {
        int i = 1;
        uint dayNumber = this.DayNumber;
        foreach (Action partSolver in this.PartSolvers)
        {
            Console.WriteLine($"Day {this.DayNumber} | Part {i}");
            Console.WriteLine("----------");
            partSolver.Invoke();
            Console.WriteLine("");
            ++i;
        }
        Utils.WaitForKeyPress();
    }

    public abstract void SolvePart1();
    public abstract void SolvePart2();

    protected virtual Action[] PartSolvers => new Action[]
    {
        this.SolvePart1,
        this.SolvePart2,
    };

    protected virtual uint DayNumber => uint.Parse(new ReadOnlySpan<char>(this.GetType().Name.LastOrDefault()));

    protected string[] ReadLines(bool useExample = false)
    {
        string root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string path = Path.Combine(root, @$"Days\Day{this.DayNumber}\Day{this.DayNumber}{(useExample ? "Example" : "")}Input.txt");
        return File.ReadAllLines(path);
    }
}
