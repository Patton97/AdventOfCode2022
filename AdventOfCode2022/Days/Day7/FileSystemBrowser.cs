using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day7;

internal class FileSystemBrowser
{
    internal Directory Root { get; }
    internal Directory CurrentDirectory { get; set; }
    internal FileSystemBrowser(Directory root)
    {
        this.Root = root;
        this.CurrentDirectory = this.Root;
    }

    internal Dictionary<string, int> GetDirectorySizes()
    {
        Dictionary<string, int> directorySizes = new();
        void GetDirectorySizes(Directory directory)
        {
            directorySizes.Add(directory.FullPath, directory.GetSize());
            foreach (Directory childDirectory in directory.Directories)
            {
                GetDirectorySizes(childDirectory);
            }
        }
        GetDirectorySizes(this.Root);
        return directorySizes;
    }

    internal void ExecuteCommand(string command)
    {
        if (command.StartsWith("cd"))
        {
            this.ChangeDirectory(string.Concat(command.Skip(3)));
        }
    }

    private void ChangeDirectory(string targetDirectoryName)
    {
        if (targetDirectoryName == "..")
        {
            this.CurrentDirectory = this.CurrentDirectory.Parent ?? this.CurrentDirectory;
            return;
        }
        this.CurrentDirectory = this.CurrentDirectory.GetOrAddDirectory(targetDirectoryName);
    }
}
