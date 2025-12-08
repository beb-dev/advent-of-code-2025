using System;

namespace AdventOfCode2025.Days
{
	public class Day3 : Day
	{
		public override string Part1(string[] input)
		{
			int sums = 0;
			int length = input.Length;

			for (int i = 0; i < length; i++)
			{
				sums += GetVoltagePart1(input[i]);
			}

			return sums.ToString();
		}

		public override string Part2(string[] input)
		{
			long sums = 0;
			int length = input.Length;

			for (int i = 0; i < length; i++)
			{
				sums += GetVoltagePart2(input[i]);
			}

			return sums.ToString();
		}

		public static int GetVoltagePart1(string line)
		{
			// Build the biggest 2-digits number possible from string
			int high = line[0] - '0';
			int low = 0;

			int length = line.Length;

			for (int i = 1; i < length; i++)
			{
				int volt = line[i] - '0';

				if (volt > low)
				{
					low = volt;
				}

				if (low > high && i + 1 < length)
				{
					high = low;
					low = line[i + 1] - '0';
				}
			}

			return (high*10) + low;
		}

		public static long GetVoltagePart2(string line)
		{
			// Build the biggest 12-digits number possible from string
			int digits = 12;
			Span<char> span = stackalloc char[digits];
			span.Fill('0');

			int start = 0;

			for (int i = 0; i < digits; i++)
			{
				// Search the next biggest digit.
				// Must be between a certain range or else
				// the final number won't have enough digits.
				int end = line.Length - digits + i;

				for (int j = start; j <= end; j++)
				{
					if (span[i] < line[j])
					{
						// Next digit has to be after this one
						start = j + 1; 
						span[i] = line[j];
					}
				}
			}

			return long.Parse(span);
		}
	}
}
