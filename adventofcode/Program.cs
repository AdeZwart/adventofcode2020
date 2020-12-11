using System;
using System.IO;

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
                        Console.WriteLine("Puzzle 1 was not implemented\r\n");
                        break;

                    case 2:
                        Day2.FindValidPasswordsPartOne(lines);
                        Day2.FindValidPasswordsPartTwo(lines);
                        break;

                    case 3:
                        Day3.PartOne(lines);
                        Day3.PartTwo(lines);
                        break;

                    case 4:
                        Day4.PartOne(lines);
                        Day4.PartTwo(lines);
                        break;

                    case 5:
                        Day5.PartOne(lines);
                        Day5.PartTwo(lines);
                        break;

                    case 6:
                        Day6.PartOne(lines);
                        Day6.PartTwo(lines);
                        break;

                    case 7:
                        Day7.PartOne(lines);
                        Day7.PartTwo(lines);
                        break;

                    case 8:
                        Day8.PartOne(lines);
                        Day8.PartTwo(lines);
                        break;

                    case 9:
                        Day9.PartOne(lines);
                        Day9.PartTwo(lines);
                        break;

                    case 10:
                        Day10.PartOne(lines);
                        Day10.PartTwo(lines);
                        break;

                    default:
                        Console.WriteLine("An invalid puzzle number was selected.\r\n");
                        break;
                }           
            }

            Console.WriteLine("\nFINISHED");
            Console.ReadLine();
        }


    }
}
