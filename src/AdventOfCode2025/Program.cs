using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2025.Days;

namespace AdventOfCode2025
{
	public static class Program
	{
		private static readonly List<Day> m_days = new List<Day>()
		{
			new Day1(),
			new Day2(),
			new Day3(),
			new Day4()
		};

		public static void Main()
		{
			int dayNumber = 4;

			string[] input = DataParser.GetLinesByDay(dayNumber, false);
			string[] inputTest = DataParser.GetLinesByDay(dayNumber, true);

			var output = new StringBuilder(128);

			Day day = GetDay(dayNumber);

			string part1 = day.Part1(input);
			string part2 = day.Part2(input);
			output.AppendLine($"Part 1: {part1}");
			output.AppendLine($"Part 2: {part2}");
			output.AppendLine("");

			string part1Test = day.Part1(inputTest);
			string part2Test = day.Part2(inputTest);

			output.AppendLine($"Part 1: {part1Test} (Test Input)");
			output.AppendLine($"Part 2: {part2Test} (Test Input)");

			Console.WriteLine(output);
		}

		private static Day GetDay(int day)
		{
			int index = day - 1;

			if (index < 0 || index >= m_days.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 12.");
			}

			return m_days[index];
		}
	}
}