using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day7
{
    internal class Day7 : Day, IDay7
    {
        public override void SolvePart1()
        {
            var rootDir = new Directory
            {
                Name = ".",
                Parent = null
            };
            var browser = new FileSystemBrowser(rootDir);
            foreach (string line in this.ReadLines(useExample: false).Skip(1))
            {
                if (line.StartsWith("$"))
                {
                    browser.ExecuteCommand(string.Concat(line.Skip(2)));
                    continue;
                }
                else if (line.StartsWith($"dir"))
                {
                    this.AddDirectory(browser.CurrentDirectory, line);
                }
                else
                {
                    this.AddFile(browser.CurrentDirectory, line);
                }
            }

            Dictionary<string, int> directorySizes = new();
            this.StoreDirectorySizes(ref directorySizes, browser.Root);
            int totalSize = directorySizes.Values.Sum();
            Console.WriteLine($"Total Size (of relevant directories): {totalSize}");
        }

        private void StoreDirectorySizes(ref Dictionary<string, int> directorySizes, Directory directory)
        {
            int size = directory.GetSize();
            if (size <= 100000)
            {
                directorySizes.Add(directory.FullPath, size);
            }
            foreach (Directory childDirectory in directory.Directories)
            {
                this.StoreDirectorySizes(ref directorySizes, childDirectory);
            }
        }

        public override void SolvePart2()
        {
            
        }

        private void AddDirectory(Directory parent, string directoryListing)
        {
            parent.GetOrAddDirectory(directoryName: string.Concat(directoryListing.Skip(4)));
        }

        private void AddFile(Directory parent, string fileListing)
        {
            string[] fileListingSegments = fileListing.Split(" ").ToArray();
            parent.GetOrAddFile(
                fileName: string.Concat(fileListingSegments[1]),
                fileSize: int.Parse(fileListingSegments[0])
            );
        }
    }
}
