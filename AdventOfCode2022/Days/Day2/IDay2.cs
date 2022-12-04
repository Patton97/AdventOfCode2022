﻿namespace AdventOfCode2022.Days.Day2;

interface IDay2 : IDay
{
    /// <summary>
    /// The Elves begin to set up camp on the beach. To decide whose tent gets to be
    /// closest to the snack storage, a giant Rock Paper Scissors tournament is already in progress.<br/>
    /// <br/>
    /// Rock Paper Scissors is a game between two players.Each game contains many rounds; in each round,
    /// the players each simultaneously choose one of Rock, Paper, or Scissors using a hand shape.
    /// Then, a winner for that round is selected: Rock defeats Scissors, Scissors defeats Paper, and Paper
    /// defeats Rock. If both players choose the same shape, the round instead ends in a draw.<br/>
    /// <br/>
    /// Appreciative of your help yesterday, one Elf gives you an encrypted strategy guide (your puzzle input)
    /// that they say will be sure to help you win. "The first column is what your opponent is going to play:
    /// A for Rock, B for Paper, and C for Scissors. The second column--" Suddenly, the Elf is called away
    /// to help with someone's tent.<br/>
    /// <br/>
    /// The second column, you reason, must be what you should play in response: X for Rock, Y for Paper,
    /// and Z for Scissors.Winning every time would be suspicious, so the responses must have
    /// been carefully chosen.<br/>
    /// <br/>
    /// The winner of the whole tournament is the player with the highest score. Your total score is the
    /// sum of your scores for each round. The score for a single round is the score for the shape you
    /// selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the
    /// round(0 if you lost, 3 if the round was a draw, and 6 if you won).<br/>
    /// <br/>
    /// Since you can't be sure if the Elf is trying to help you or trick you, you should calculate
    /// the score you would get if you were to follow the strategy guide.<br/>
    /// <br/>
    /// For example, suppose you were given the following strategy guide:<br/>
    /// <br/>
    /// <code>
    /// A Y<br/>
    /// B X<br/>
    /// C Z<br/>
    /// <br/>
    /// </code>
    /// This strategy guide predicts and recommends the following:<br/>
    /// <list type="bullet">
    ///     <item>
    ///         In the first round, your opponent will choose Rock(A), and you should choose Paper(Y).<br/>
    ///         This ends in a win for you with a score of 8 (2 because you chose Paper + 6 because you won).
    ///     </item>
    ///     <item>
    ///         In the second round, your opponent will choose Paper(B), and you should choose Rock(X).<br/>
    ///         This ends in a loss for you with a score of 1 (1 + 0).
    ///     </item>
    ///     <item>
    ///         The third round is a draw with both players choosing Scissors, giving you a score of 3 + 3 = 6.
    ///     </item>
    /// </list>
    /// In this example, if you were to follow the strategy guide, you would get a total score of 15 (8 + 1 + 6).
    /// What would your total score be if everything goes exactly according to your strategy guide?
    /// </summary>
    void SolvePart1();
}