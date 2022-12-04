namespace AdventOfCode2022.Days.Day3;

internal interface IDay3 : IDay
{
    /// <summary>
    /// One Elf has the important job of loading all of the rucksacks with supplies
    /// for the jungle journey. Unfortunately, that Elf didn't quite follow the packing
    /// instructions, and so a few items now need to be rearranged.<br/>
    /// <br/>
    /// Each rucksack has two large compartments.All items of a given type are meant to go
    /// into exactly one of the two compartments. The Elf that did the packing failed to follow
    /// this rule for exactly one item type per rucksack.<br/>
    /// <br/>
    /// The Elves have made a list of all of the items currently in each rucksack
    /// (your puzzle input), but they need your help finding the errors. Every item type is
    /// identified by a single lowercase or uppercase letter (that is, a and A refer to different
    /// types of items).<br/>
    /// <br/>
    /// The list of items for each rucksack is given as characters all on a single line.
    /// A given rucksack always has the same number of items in each of its two compartments,
    /// so the first half of the characters represent items in the first compartment, while the
    /// second half of the characters represent items in the second compartment.<br/>
    /// <br/>
    /// For example, suppose you have the following list of contents from six rucksacks:<br/>
    /// <br/>
    /// <code>
    /// vJrwpWtwJgWrhcsFMMfFFhFp
    /// jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
    /// PmmdzqPrVvPwwTWBwg
    /// wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
    /// ttgJtRGJQctTZtZT
    /// CrZsJsPPZsGzwwsLwLmpwMDw
    /// </code>
    /// <list type="bullet">
    ///     <item>
    ///         The first rucksack contains the items vJrwpWtwJgWrhcsFMMfFFhFp, which means its
    ///         first compartment contains the items vJrwpWtwJgWr, while the second compartment
    ///         contains the items hcsFMMfFFhFp.The only item type that appears in both compartments
    ///         is lowercase p.
    ///     </item>
    ///     <item>
    ///         The second rucksack's compartments contain jqHRNqRjqzjGDLGL and rsFMfFZSrLrFZsSL.
    ///         The only item type that appears in both compartments is uppercase L.
    ///     </item>
    ///     <item>
    ///         The third rucksack's compartments contain PmmdzqPrV and vPwwTWBwg;
    ///         the only common item type is uppercase P.
    ///     </item>
    ///     <item>
    ///         The fourth rucksack's compartments only share item type v.
    ///     </item>
    ///     <item>
    ///         The fifth rucksack's compartments only share item type t.
    ///     </item>
    ///     <item>
    ///         The sixth rucksack's compartments only share item type s.
    ///     </item>
    /// </list>
    /// To help prioritize item rearrangement, every item type can be converted to a priority:<br/>
    /// <br/>
    /// <list type="bullet">
    ///     <item>
    ///         Lowercase item types a through z have priorities 1 through 26.
    ///     </item>
    ///     <item>
    ///         Uppercase item types A through Z have priorities 27 through 52.
    ///     </item>
    /// </list>
    /// In the above example, the priority of the item type that appears in both compartments
    /// of each rucksack is 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s); the sum of these
    /// is 157.<br/>
    /// <br/>
    /// Find the item type that appears in both compartments of each rucksack. What is the sum
    /// of the priorities of those item types?
    /// </summary>
    void SolvePart1();
}
