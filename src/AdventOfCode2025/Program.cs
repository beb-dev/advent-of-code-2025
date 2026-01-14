using System;
using System.Collections.Generic;
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
			new Day4(),
			new Day5(),
			new Day6(),
			new Day7(),
			new Day8(),
		};

		public static void Main()
		{
			int dayNum = 8;
			Day day = GetDay(dayNum);

			string[] input = DataParser.GetLinesByDay(dayNum, false);
			string[] testInput = DataParser.GetLinesByDay(dayNum, true);

			Console.WriteLine($"Day {dayNum} Part 1 (Test Input): {day.Part1(testInput)}");
			Console.WriteLine($"Day {dayNum} Part 2 (Test Input): {day.Part2(testInput)}");
			Console.WriteLine();
			Console.WriteLine($"Day {dayNum} Part 1: {day.Part1(input)}");
			Console.WriteLine($"Day {dayNum} Part 2: {day.Part2(input)}");
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