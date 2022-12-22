using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day7
{
    internal class Directory : FileSystemEntry
    {
        private Dictionary<string, FileSystemEntry> entries = new();
        internal FileSystemEntry[] Entries => this.entries.Values.ToArray();
        internal Directory[] Directories => this.entries.Values.OfType<Directory>().ToArray();
        internal File[] Files => this.entries.Values.OfType<File>().ToArray();
        internal override int GetSize()
        {
            int directoriesSize = this.Directories.Sum(directory => directory.GetSize());
            int filesSize = this.Files.Sum(file => file.GetSize());
            return directoriesSize + filesSize;
        }
        internal Directory GetOrAddDirectory(string directoryName)
        {
            Directory directory = this.Directories
                .FirstOrDefault(directory => string.Equals(directory.Name, directoryName));
            if (directory != null)
            {
                return directory;
            }

            directory = new Directory
            {
                Name = directoryName,
                Parent = this,
            };
            this.entries.Add(directory.Name, directory);
            return directory;
        }
        internal File GetOrAddFile(string fileName, int fileSize)
        {
            if (this.Files.FirstOrDefault(file => string.Equals(file.Name, fileName)) is File file)
            {
                return file;
            }

            file = new File
            {
                Name = fileName,
                Parent = this,
                Size = fileSize,
            };
            this.entries.Add(file.Name, file);
            return file;
        }
    }
}
