using System;

namespace AdventOfCode2025.Days
{
	public class Day1 : Day
	{
		public override string Part1(string[] input)
		{
			int count = 0;
			int dial = 50;

			for (int i = 0; i < input.Length; i++)
			{
				dial += GetRotation(input[i]);

				if (dial % 100 == 0)
				{
					count++;
				}
			}

			return count.ToString();
		}

		public override string Part2(string[] input)
		{
			int count = 0;
			int dial = 50;

			for (int i = 0; i < input.Length; i++)
			{
				int rotation = GetRotation(input[i]);
				int tick = Math.Sign(rotation);
				int length = Math.Abs(rotation);

				for (int j = 0; j < length; j++)
				{
					dial += tick;

					if (dial % 100 == 0)
					{
						count++;
					}
				}
			}

			return count.ToString();
		}

		public static int GetRotation(string input)
		{
			ReadOnlySpan<char> span = input.AsSpan(1, input.Length - 1);

			if (input[0] == 'L')
			{
				return -int.Parse(span);
			}
			else if (input[0] == 'R')
			{
				return int.Parse(span);
			}
			else
			{
				throw new ArgumentException("Input does not contain a rotation.", nameof(input));
			}
		}
	}
}
