namespace AdventOfCode2022.Days.Day1;

interface IDay1 : IDay
{
    /// <summary>
    /// The jungle must be too overgrown and difficult to navigate in vehicles
    /// or access from the air; the Elves' expedition traditionally goes on foot.
    /// As your boats approach land, the Elves begin taking inventory of their supplies.
    /// One important consideration is food - in particular, the number of Calories each
    /// Elf is carrying (your puzzle input).<br/>
    /// <br/>
    /// The Elves take turns writing down the number of Calories contained by the various
    /// meals, snacks, rations, etc.that they've brought with them, one item per line.<br/>
    /// <br/>
    /// Each Elf separates their own inventory from the previous Elf's inventory(if any) by a blank line.
    /// For example, suppose the Elves finish writing their items' Calories and end up with the following list:<br/>
    /// <br/>
    /// 1000<br/>
    /// 2000<br/>
    /// 3000<br/>
    /// <br/>
    /// 4000<br/>
    /// <br/>
    /// 5000<br/>
    /// 6000<br/>
    /// <br/>
    /// 7000<br/>
    /// 8000<br/>
    /// 9000<br/>
    /// <br/>
    /// 10000<br/>
    /// <br/>
    /// This list represents the Calories of the food carried by five Elves:<br/>
    /// <list type="bullet">
    ///     <item>
    ///         The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
    ///     </item>
    ///     <item>
    ///         The second Elf is carrying one food item with 4000 Calories.
    ///     </item>
    ///     <item>
    ///         The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
    ///     </item>
    ///     <item>
    ///         The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
    ///     </item>
    ///     <item>
    ///         The fifth Elf is carrying one food item with 10000 Calories.
    ///     </item>
    /// </list>
    /// In case the Elves get hungry and need extra snacks, they need to know which Elf to ask:<br/>
    /// they'd like to know how many Calories are being carried by the Elf carrying the most Calories.<br/>
    /// In the example above, this is 24000 (carried by the fourth Elf).<br/>
    /// <br/>
    /// Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
    /// </summary>
    void SolvePart1();

    /// <summary>
    /// By the time you calculate the answer to the Elves' question, they've already realized
    /// that the Elf carrying the most Calories of food might eventually run out of snacks.<br/>
    /// <br/>
    /// To avoid this unacceptable situation, the Elves would instead like to know the total Calories
    /// carried by the top three Elves carrying the most Calories. That way, even if one of those
    /// Elves runs out of snacks, they still have two backups.<br/>
    /// <br/>
    /// In the example above, the top three Elves are the fourth Elf (with 24000 Calories),
    /// then the third Elf(with 11000 Calories), then the fifth Elf(with 10000 Calories).
    /// The sum of the Calories carried by these three elves is 45000.<br/>
    /// <br/>
    /// Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
    /// </summary>
    void SolvePart2();
}
