﻿using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace AdventOfCode2022.Days.Day5;

internal interface IDay5 : IDay
{
    /// <summary>
    /// The expedition can depart as soon as the final supplies have been unloaded from the ships.
    /// Supplies are stored in stacks of marked crates, but because the needed supplies are buried
    /// under many other crates, the crates need to be rearranged.<br/>
    /// <br/>
    /// The ship has a giant cargo crane capable of moving crates between stacks. To ensure none of
    /// the crates get crushed or fall over, the crane operator will rearrange them in a series of
    /// carefully-planned steps. After the crates are rearranged, the desired crates will be at the
    /// top of each stack.<br/>
    /// <br/>
    /// The Elves don't want to interrupt the crane operator during this delicate procedure, but
    /// they forgot to ask her which crate will end up where, and they want to be ready to unload
    /// them as soon as possible so they can embark.<br/>
    /// <br/>
    /// They do, however, have a drawing of the starting stacks of crates and the rearrangement
    /// procedure (your puzzle input). For example:<br/>
    /// <code>
    ///     [D]
    /// [N] [C]
    /// [Z] [M] [P]
    ///  1   2   3
    /// 
    /// move 1 from 2 to 1
    /// move 3 from 1 to 3
    /// move 2 from 2 to 1
    /// move 1 from 1 to 2
    /// </code>
    /// In this example, there are three stacks of crates. Stack 1 contains two crates: crate Z is
    /// on the bottom, and crate N is on top. Stack 2 contains three crates; from bottom to top,
    /// they are crates M, C, and D. Finally, stack 3 contains a single crate, P.<br/>
    /// <br/>
    /// Then, the rearrangement procedure is given. In each step of the procedure, a quantity of
    /// crates is moved from one stack to a different stack. In the first step of the above rearrangement
    /// procedure, one crate is moved from stack 2 to stack 1, resulting in this configuration:<br/>
    /// <br/>
    /// <code>
    /// [D]
    /// [N] [C]
    /// [Z] [M] [P]
    ///  1   2   3
    /// </code>
    /// In the second step, three crates are moved from stack 1 to stack 3. Crates are moved one at a
    /// time, so the first crate to be moved (D) ends up below the second and third crates:<br/>
    /// <br/>
    /// <code>
    ///         [Z]
    ///         [N]
    ///     [C] [D]
    ///     [M] [P]
    ///  1   2   3
    /// </code>
    /// Then, both crates are moved from stack 2 to stack 1. Again, because crates are moved one at a time,
    /// crate C ends up below crate M:<br/>
    /// <br/>
    /// <code>
    ///         [Z]
    ///         [N]
    /// [M]     [D]
    /// [C]     [P]
    ///  1   2   3
    /// </code>
    /// Finally, one crate is moved from stack 1 to stack 2:<br/>
    /// <br/>
    /// <code>
    ///         [Z]
    ///         [N]
    ///         [D]
    /// [C] [M] [P]
    ///  1   2   3
    /// </code>
    /// The Elves just need to know which crate will end up on top of each stack; in this example,
    /// the top crates are C in stack 1, M in stack 2, and Z in stack 3, so you should combine
    /// these together and give the Elves the message CMZ.<br/>
    /// <br/>
    /// After the rearrangement procedure completes, what crate ends up on top of each stack?
    /// </summary>
    void SolvePart1();

    /// <summary>
    /// As you watch the crane operator expertly rearrange the crates, you notice the process
    /// isn't following your prediction.<br/>
    /// <br/>
    /// Some mud was covering the writing on the side of the crane, and you quickly wipe it away.
    /// The crane isn't a CrateMover 9000 - it's a CrateMover 9001.<br/>
    /// <br/>
    /// The CrateMover 9001 is notable for many new and exciting features: air conditioning,
    /// leather seats, an extra cup holder, and the ability to pick up and move multiple crates at once.<br/>
    /// <br/>
    /// Again considering the example above, the crates begin in the same configuration:
    /// <code>
    ///     [D]
    /// [N] [C]
    /// [Z] [M] [P]
    ///  1   2   3
    /// </code>
    /// Moving a single crate from stack 2 to stack 1 behaves the same as before:
    /// <code>
    /// [D]
    /// [N] [C]
    /// [Z] [M] [P]
    ///  1   2   3
    /// </code>
    /// However, the action of moving three crates from stack 1 to stack 3 means that those three moved crates stay in the same order, resulting in this new configuration:
    /// <code>
    ///         [D]
    ///         [N]
    ///     [C] [Z]
    ///     [M] [P]
    ///  1   2   3
    /// </code>
    /// Next, as both crates are moved from stack 2 to stack 1, they retain their order as well:
    /// <code>
    ///         [D]
    ///         [N]
    /// [C]     [Z]
    /// [M]     [P]
    ///  1   2   3
    /// </code>
    /// Finally, a single crate is still moved from stack 1 to stack 2, but now it's crate C that gets moved:
    /// <code>
    ///         [D]
    ///         [N]
    ///         [Z]
    /// [M] [C] [P]
    ///  1   2   3
    /// </code>
    /// In this example, the CrateMover 9001 has put the crates in a totally different order: MCD.<br/>
    /// <br/>
    /// Before the rearrangement process finishes, update your simulation so that the Elves know
    /// where they should stand to be ready to unload the final supplies. After the rearrangement
    /// procedure completes, what crate ends up on top of each stack?
    /// </summary>
    void SolvePart2();
}
