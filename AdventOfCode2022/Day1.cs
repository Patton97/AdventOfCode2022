using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2022
{
    class Day1 : IDay
    {
        public void Solve()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Inputs\Day1Input.txt");
            string[] lines = File.ReadAllLines(path);
            int currentCalorieCount = 0;
            int highestCalorieCount = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    UpdateHighestIfHigher(ref currentCalorieCount, ref highestCalorieCount);
                    continue;
                }

                currentCalorieCount += int.Parse(line);
            }

            Console.WriteLine(highestCalorieCount);
            Console.Read();
        }

        void UpdateHighestIfHigher(ref int calorieCount, ref int highestCalorieCount)
        {
            if (highestCalorieCount < calorieCount)
            {
                highestCalorieCount = calorieCount;
            }
            calorieCount = 0;
        }
    }
}
