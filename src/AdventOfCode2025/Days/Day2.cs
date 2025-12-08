using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public class Day2 : Day
	{
		public override string Part1(string[] input)
		{
			// Get the sums of invalid ids
			long sums = 0;
			List<long> productIds = ParseProductIds(input);
			int length = productIds.Count;

			for (int i = 0; i < length; i++)
			{
				long id = productIds[i];

				if (!ValidateIdPart1(id))
				{
					sums += id;
				}
			}

			return sums.ToString();
		}

		public override string Part2(string[] input)
		{
			// Get the sums of invalid ids
			long sums = 0;
			List<long> productIds = ParseProductIds(input);
			int length = productIds.Count;

			for (int i = 0; i < length; i++)
			{
				long id = productIds[i];

				if (!ValidateIdPart2(id))
				{
					sums += id;
				}
			}

			return sums.ToString();
		}

		public static bool ValidateIdPart1(long id)
		{
			Span<char> charBuffer = stackalloc char[19];

			id.TryFormat(charBuffer, out int length);

			// Id is valid when length is odd
			if (length == 0 || length % 2 != 0)
			{
				return true;
			}

			// Compare both halves to see if there is a match
			int halfLength = length /= 2;

			for (int i = 0; i < halfLength; i++)
			{
				if (charBuffer[i] != charBuffer[i + halfLength])
				{
					// Both halves are different, id is valid
					return true;
				}
			}

			// Both halves are the same, id is invalid
			return false;
		}

		public static bool ValidateIdPart2(long id)
		{
			Span<char> charBuffer = stackalloc char[19];

            id.TryFormat(charBuffer, out int length);

			if (length <= 1)
			{
				return true;
			}

			int size = 1;
			int maxSize = (length / 2);

			// Look for a pattern that repeats
			// Starts with s size of 1, then grow size  
			// until pattern is too big to repeat.
			while (size <= maxSize)
			{
				// Ignore sizes that can't repeat for a given length
				if (length % size != 0)
				{
					size++;
					continue;
				}

				// Search pattern
				ReadOnlySpan<char> source = charBuffer.Slice(0, length);
				ReadOnlySpan<char> pattern = charBuffer.Slice(0, size);
				int index;

				while ((index = source.IndexOf(pattern)) != -1)
				{
					// Stop if pattern is not continuous
					if (index != 0) break;

					// Id is invalid when all matches are found
					if (source.Length == pattern.Length)
					{
						return false;
					}

					source = source.Slice(index + size);
				}

				size++;
			}

			return true;
		}

		public static List<long> ParseProductIds(string[] input)
		{
			var productIds = new List<long>(2048);

			for (int i = 0; i < input.Length; i++)
			{
				string[] ranges = input[i].Split(',');

				for (int j = 0; j < ranges.Length; j++)
				{
					// For test input since it is on several lines ending with ","
					if (ranges[j].Length == 0)
					{
						continue;
					}

					string[] range = ranges[j].Split('-');

					long start = long.Parse(range[0].AsSpan());
					long end = long.Parse(range[1].AsSpan());

					long current = start;

					while (current <= end)
					{
						productIds.Add(current);
						current++;
					}
				}
			}

			return productIds;
		}
	}
}
