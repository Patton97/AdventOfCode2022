using System.Linq;

namespace AdventOfCode2022.Days.Day7
{
    internal class FileSystemBrowser
    {
        internal Directory Root { get; }
        internal Directory CurrentDirectory { get; set; }
        internal FileSystemBrowser(Directory root)
        {
            this.Root = root;
            this.CurrentDirectory = this.Root;
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
}
