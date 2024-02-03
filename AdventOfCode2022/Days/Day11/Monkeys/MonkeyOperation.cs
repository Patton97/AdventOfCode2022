using System;
using System.IO;

namespace AdventOfCode2022.Days.Day11.Monkeys;

internal record MonkeyOperation(uint? ModifierAmount, char OperatorChar)
{
    internal virtual void Perform(Item item, Action<string> printDebugInfo = null)
    {
        ulong worryLevelModifierAmount = this.ModifierAmount ?? item.WorryLevel;

        string operationDescription;
        ulong newWorryLevel;
        switch (this.OperatorChar)
        {
            case '+':
                operationDescription = "increases by";
                newWorryLevel = item.WorryLevel + worryLevelModifierAmount;
                break;
            case '*':
                operationDescription = "is multiplied by";
                newWorryLevel = item.WorryLevel * worryLevelModifierAmount;
                break;
            default:
                throw new InvalidDataException($"Could not determine operator from char '{this.OperatorChar}'");
        }

        if (newWorryLevel < item.WorryLevel)
        {
            throw new Exception(
                $"New worry level is lower than old worry level. " +
                $"The puzzle input doesn't provide negative modifier amounts, " +
                $"so there may be a overflow occurring."
            );
        }

        if (printDebugInfo != null)
        {
            string worryLevelModifierAmountAsDebugString = this.ModifierAmount == null
                ? "itself"
                : worryLevelModifierAmount.ToString();
            printDebugInfo.Invoke($"    Worry level {operationDescription} {worryLevelModifierAmountAsDebugString} to {newWorryLevel}.");
        }

        item.WorryLevel = newWorryLevel;
    }
}

internal record MonkeyOperationPart2(uint? ModifierAmount, char OperatorChar, uint LowestCommonMultiple)
    : MonkeyOperation(ModifierAmount, OperatorChar)
{
    internal override void Perform(Item item, Action<string> printDebugInfo = null)
    {
        ulong worryLevelModifierAmount = this.ModifierAmount ?? item.WorryLevel;

        string operationDescription;
        ulong newWorryLevel;
        switch (this.OperatorChar)
        {
            case '+':
                operationDescription = "increases by";
                newWorryLevel = item.WorryLevel + worryLevelModifierAmount;
                break;
            case '*':
                operationDescription = "is multiplied by";
                newWorryLevel = item.WorryLevel * worryLevelModifierAmount;
                break;
            default:
                throw new InvalidDataException($"Could not determine operator from char '{this.OperatorChar}'");
        }

        if (newWorryLevel < item.WorryLevel)
        {
            throw new Exception(
                $"New worry level is lower than old worry level. " +
                $"The puzzle input doesn't provide negative modifier amounts, " +
                $"so there may be a overflow occurring."
            );
        }

        if (printDebugInfo != null)
        {
            string worryLevelModifierAmountAsDebugString = this.ModifierAmount == null
                ? "itself"
                : worryLevelModifierAmount.ToString();
            printDebugInfo.Invoke($"    Worry level {operationDescription} {worryLevelModifierAmountAsDebugString} to {newWorryLevel}.");
        }

        item.WorryLevel = newWorryLevel;
    }
}
