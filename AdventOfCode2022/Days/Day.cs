using System.IO;
using System.Reflection;

namespace AdventOfCode2022.Days;

abstract class Day : IDay
{
    public abstract void Solve();
    protected string FolderPath
    {
        get
        {
            string root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(root, @"Days\" + GetType().Name);
        }
    }
}
