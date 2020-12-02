using System;
using System.IO;
using System.Linq;

namespace adventofcode
{
    class Program
    {
        private const string PUZZLE = "puzzle";
        private const string INPUTTXT = "_input.txt";

        static void Main(string[] args)
        {
            var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            var files = Directory.GetFiles(directory, $"*{INPUTTXT}");

            Console.Write($"Enter a number between 1 and {files.Length} to solve the puzzle for that day:\r\n");
            if (int.TryParse(Console.ReadLine(), out var puzzleIndex) && puzzleIndex > 0 && puzzleIndex <= files.Length)
            {
                var inputFile = $"{PUZZLE}{puzzleIndex}{INPUTTXT}";
                var lines = File.ReadAllLines($"{directory}\\{inputFile}");

                switch (puzzleIndex)
                {
                    case 1:
                        Console.WriteLine("Puzzle 1 was not implemented");
                        break;
                    case 2:
                        FindValidPasswordsPartOne(lines);
                        FindValidPasswordsPartTwo(lines);
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("An invalid puzzle number was selected.");
                        break;
                }
            }

            Console.WriteLine("\nFINISHED");
            Console.ReadLine();
        }

        // AdventOfCode Day 2 - Part One
        private static void FindValidPasswordsPartOne(string[] fileLines)
        {
            Console.WriteLine("========== AdventOfCode Day 2 - Part One ==========");

            var validPasswordCount = 0;
            foreach (var line in fileLines)
            {
                var policy = line.Split(':').First().Trim();
                var password = line.Split(':').Last().Trim();

                var policyParts = policy.Split(' ');

                int.TryParse(policyParts.First().Trim().Split('-').First(), out var policyCharMin);
                int.TryParse(policyParts.First().Trim().Split('-').Last(), out var policyCharMax);

                var policyChar = policyParts.Last().Trim().ToCharArray();
                if (policyChar.Length != 1)
                {
                    // somethings wrong.
                }

                var charCount = password.Count(c => c.Equals(policyChar.First()));
                if (charCount >= policyCharMin && charCount <= policyCharMax)
                {
                    validPasswordCount++;
                    //Console.WriteLine($"Line '{line}': This password validates with it's policy.");
                }
            }

            Console.WriteLine($"The puzzle input contains {validPasswordCount} passwords that are valid according to their policy.\r\n");
        }

        // AdventOfCode Day 2 - Part Two
        private static void FindValidPasswordsPartTwo(string[] fileLines)
        {
            Console.WriteLine("========== AdventOfCode Day 2 - Part Two ==========");

            var validPasswordCount = 0;
            foreach (var line in fileLines)
            {
                var policy = line.Split(':').First().Trim();
                var password = line.Split(':').Last().Trim();

                var policyParts = policy.Split(' ');

                if(!int.TryParse(policyParts.First().Trim().Split('-').First(), out var policyCharMin))
                {
                    // something's wrong
                }
                policyCharMin -= 1;

                if(!int.TryParse(policyParts.First().Trim().Split('-').Last(), out var policyCharMax))
                {
                    // something's wrong
                }
                policyCharMax -= 1;

                var policyChars = policyParts.Last().Trim().ToCharArray();
                if (policyChars.Length != 1)
                {
                    // somethings wrong.
                }
                var policyChar = policyChars.First();

                if((password[policyCharMin] == policyChar && password[policyCharMax] != policyChar) 
                    || (password[policyCharMin] != policyChar && password[policyCharMax] == policyChar))
                {
                    
                    validPasswordCount++;
                }
            }

            Console.WriteLine($"The puzzle input contains {validPasswordCount} passwords that are valid according to their policy.\r\n");
        }
    }
}
