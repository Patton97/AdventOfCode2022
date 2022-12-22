using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Days.Day7
{
    internal class Day7 : Day, IDay7
    {
        public override void SolvePart1()
        {
            Dictionary<string, int> directorySizes = this.InitialiseFileSystem().GetDirectorySizes();
            int totalSize = directorySizes.Values.Where(size => size <= 100000).Sum();
            Console.WriteLine($"Total Size (of relevant directories): {totalSize}");
        }

        public override void SolvePart2()
        {
            const int TOTAL_DISK_SPACE = 70000000;
            const int REQUIRED_UNUSED_SPACE = 30000000;

            FileSystemBrowser browser = this.InitialiseFileSystem();
            int currentUnusedSpace = TOTAL_DISK_SPACE - browser.Root.GetSize();
            int amountToDelete = REQUIRED_UNUSED_SPACE - currentUnusedSpace;

            (string nameOfDirectoryToDelete, int sizeOfDirectoryToDelete) = browser.GetDirectorySizes()
                .Where(kvp => kvp.Value >= amountToDelete)
                .OrderBy(kvp => kvp.Value)
                .FirstOrDefault();
            Console.WriteLine($"Directory to be deleted: {nameOfDirectoryToDelete} (size={sizeOfDirectoryToDelete})");
        }

        private FileSystemBrowser InitialiseFileSystem()
        {
            var rootDir = new Directory
            {
                Name = ".",
                Parent = null
            };
            var browser = new FileSystemBrowser(rootDir);
            foreach (string line in this.ReadLines().Skip(1))
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
            return browser;
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
