using System.Diagnostics;

namespace AdventOfCode2022.Days.Day7
{
    [DebuggerDisplay("{FullPath}")]
    internal abstract class FileSystemEntry
    {
        internal required string Name { get; init; }
        internal required Directory Parent { get; init; }
        internal abstract int GetSize();
        internal string FullPath
        {
            get
            {
                if (this.Parent == null)
                {
                    return this.Name;
                }
                return this.Parent.FullPath + "/" + this.Name;
            }
        }
    }
}
