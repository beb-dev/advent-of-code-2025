using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public struct LongRange
	{
		public long Start;
		public long End;

		public LongRange(long start, long end)
		{
			Start = start;
			End = end;
		}
	}

	public class Inventory
	{
		public readonly List<long> Ids;
		public readonly List<LongRange> Ranges;

		public Inventory(int capacity)
		{
			Ids = new List<long>(capacity);
			Ranges = new List<LongRange>(capacity);
		}
	}

	public class Day5 : Day
	{
		public override string Part1(string[] input)
		{
			Inventory inventory = ParseInventory(input);

			int count = CountValidIdsPart1(inventory);

			return count.ToString();
		}

		public override string Part2(string[] input)
		{
			Inventory inventory = ParseInventory(input);

			long count = CountValidIdsPart2(inventory);	

			return count.ToString();
		}

		public static int CountValidIdsPart1(Inventory inventory)
		{
			int count = 0;
			int itemCount = inventory.Ids.Count;
			int rangeCount = inventory.Ranges.Count;

			for (int i = 0; i < itemCount; i++)
			{
				long id = inventory.Ids[i];

				for (int j = 0; j < rangeCount; j++)
				{
					LongRange range = inventory.Ranges[j];

					if (id >= range.Start && id <= range.End)
					{
						count++;
						break;
					}
				}
			}

			return count;
		}

		public static long CountValidIdsPart2(Inventory inventory)
		{
			long count = 0;
			var rangesProcessed = new List<LongRange>(512);

			for (int i = 0; i < inventory.Ranges.Count; i++)
			{
				var r1 = inventory.Ranges[i];
				bool addToCount = true;

				for (int j = 0; j < rangesProcessed.Count; j++)
				{
					LongRange r2 = rangesProcessed[j];
		
					if (r1.Start >= r2.Start && r1.End <= r2.End)
					{
						// Collision, the entire range fits in another range already processed.
						addToCount = false;
					}
					else if (r2.Start >= r1.Start && r2.End <= r1.End)
					{
						// Collision in the middle of the range.
						// Both ends need to be added to the list of valid ranges.
						inventory.Ranges.Add(new LongRange(r1.Start, r2.Start-1));
						inventory.Ranges.Add(new LongRange(r2.End+1, r1.End));
						addToCount = false;
					}
					else if (r1.Start >= r2.Start && r1.Start <= r2.End)
					{
						// Collision at the start of the range.
						// Test the part of the range that's outside the processed range
						// which is at the end.
						inventory.Ranges.Add(new LongRange(r2.End + 1, r1.End));
						addToCount = false;
					}
					else if (r1.End >= r2.Start && r1.End <= r2.End)
					{
						// Collision at the end of the range.
						// Test the part of the range that's outside the processed range
						// which is at the start.
						inventory.Ranges.Add(new LongRange(r1.Start, r2.Start - 1));
						addToCount = false;
					}

					// Get out early if this range should not be counted.
					if (!addToCount)
					{
						break;
					}
				}

				if (addToCount)
				{
					// +1 since range is inclusive
					count += r1.End - r1.Start + 1;

					// Don't need to keep ranges that do not contribute
					// to the count since other ranges that do already
					// cover their ranges.
					rangesProcessed.Add(r1);
				}
			}

			return count;
		}

		public static Inventory ParseInventory(string[] input)
		{
			var inventory = new Inventory(512);

			int length = input.Length;

			for (int i = 0; i < length; i++)
			{
				if (string.IsNullOrEmpty(input[i])) continue;

				int splitIndex = input[i].IndexOf('-');

				if (splitIndex != -1)
				{
					long start = long.Parse(input[i].AsSpan(0, splitIndex));
					long end = long.Parse(input[i].AsSpan(splitIndex+1, input[i].Length - splitIndex - 1));
					inventory.Ranges.Add(new LongRange(start, end));
				}
				else
				{
					inventory.Ids.Add(long.Parse(input[i]));
				}
			}

			return inventory;
		}
	}
}
