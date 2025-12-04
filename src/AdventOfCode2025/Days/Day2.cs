using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public class Day2 : Day
	{
		public override string Part1(string[] input)
		{
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
			string s = id.ToString();
			int length = s.Length;

			if (length == 0 || length % 2 != 0)
			{
				return true;
			}

			int halfLength = length /= 2;

			for (int i = 0; i < halfLength; i++)
			{
				if (s[i] != s[i + halfLength])
				{
					return true;
				}
			}

			return false;
		}

		public static bool ValidateIdPart2(long id)
		{
			string s = id.ToString();

			if (s.Length <= 1)
			{
				return true;
			}

			int size = 1;

			while (size < s.Length)
			{
				// Size must fit in length
				if (s.Length % size != 0)
				{
					size++;
					continue;
				}

				int index = 0;
				int match = 0;
				int matchRequired = s.Length / size;
				
				var source = s.AsSpan();
				var search = s.AsSpan(0, size);

				while ((index = source.IndexOf(search)) != -1)
				{
					int nextIndex = index + size;
					source = source.Slice(nextIndex);
					match++;
				}

				if (match == matchRequired)
				{
					return false;
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
					// TODO: Recopy test input and check if this works.
					if (ranges[j].Length == 0)
					{
						continue;
					}

					string[] range = ranges[j].Split('-');

					// TODO: Use TryParse?
					// TODO: check if range has length of 2
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
