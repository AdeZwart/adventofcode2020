using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace adventofcode
{
    public static class Day13
    {
        private static Stopwatch stopWatch = new Stopwatch();

        public static void PartOne(string[] fileLines)
        {
            stopWatch.Restart();
            Console.WriteLine("========== AdventOfCode Day 13 - Part One ==========");
            
            int.TryParse(fileLines.First(), out var firstPossibleDepartTimestamp);

            var (busId, actualDepartTime) = FindFirstDepartingBus(firstPossibleDepartTimestamp, fileLines.Last());

            var waitTime = actualDepartTime - firstPossibleDepartTimestamp;

            Console.Write($"Result {busId * waitTime}");
            stopWatch.Stop();
            Console.WriteLine($"Answer found in {stopWatch.ElapsedMilliseconds} ms.\r\n");
        }
        public static void PartTwo(string[] fileLines)
        {
            stopWatch.Restart();
            Console.WriteLine("========== AdventOfCode Day 13 - Part Two ==========");



            Console.Write($"");
            stopWatch.Stop();
            Console.WriteLine($"Answer found in {stopWatch.ElapsedMilliseconds} ms.\r\n");
        }

        private static KeyValuePair<int, int> FindFirstDepartingBus(int FirstPossibleDepartTimestamp, string shuttleBusSchedule)
        {
            var shuttles = new List<KeyValuePair<int, int>>();
            var shuttleBusses = shuttleBusSchedule.Split(',').Where(b => b != "x").ToArray();
            foreach (var bus in shuttleBusses)
            {
                if (int.TryParse(bus, out var busId))
                {
                    var iterations = Math.Ceiling((decimal)FirstPossibleDepartTimestamp / busId);

                    shuttles.Add(new KeyValuePair<int, int>(busId, Convert.ToInt32(iterations * busId)));
                }
            }

            var a = shuttles.OrderBy(kv => kv.Value);
            var b = a.First(s => s.Value >= FirstPossibleDepartTimestamp);

            return shuttles.OrderBy(kv => kv.Value).First(s => s.Value >= FirstPossibleDepartTimestamp);
        }
    }
}
