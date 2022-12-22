namespace AdventOfCode2022.Days.Day7
{
    internal class File : FileSystemEntry
    {
        internal override int GetSize() => this.Size;
        internal int Size { get; init; }
    }
}
