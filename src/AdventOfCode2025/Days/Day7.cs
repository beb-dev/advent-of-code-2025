using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public class Day7 : Day
	{ 
		public override string Part1(string[] input)
		{
			int splits = 0;
			int maxRows = input.Length;
			int maxCols = input[0].Length;

			var tiles = new Queue<(int, int)>(1024);
			var tileVisited = new HashSet<(int, int)>(1024);

			// Send beam downward at starting location
			int startRow = 0;
			int startCol = input[startRow].IndexOf('S');
			tiles.Enqueue((startRow, startCol));

			while (tiles.Count > 0)
			{
				(int row, int col) = tiles.Dequeue();

				// Skip tiles already visited
				if (tileVisited.Contains((row, col)))
				{
					continue;
				}

				// Stop if out of bound
				if (row < 0 || row >= maxRows || col < 0 || col >= maxCols)
				{
					continue;
				}

				// Mark tile as visited
				tileVisited.Add((row, col));

				char tile = input[row][col];

				if (tile == '^')
				{
					// Found splitter, split the beam in two
					splits++;
					tiles.Enqueue((row-1, col - 1));
					tiles.Enqueue((row-1, col + 1));
				}
				else
				{
					// Keep moving beam downward
					tiles.Enqueue((row + 1, col));
				}
			}

			return splits.ToString();
		}

		public override string Part2(string[] input)
		{
			// Send beam downward at starting location
			// Count all possible paths (timelines)
			int startRow = 0;
			int startCol = input[startRow].IndexOf('S');
			var cachedTimelines = new Dictionary<(int, int), long>(1024);

			long timelines = FindTimelines(input, startRow, startCol, cachedTimelines);

			return timelines.ToString();
		}

		public static long FindTimelines(string[] input, int row, int col, Dictionary<(int, int), long> cachedTimelines)
		{
			// Found timeline when out of bound
			if (row < 0 || row >= input.Length || col < 0 || col >= input[0].Length)
			{
				return 1;
			}

			// Use cached value when possible
			if (cachedTimelines.TryGetValue((row, col), out long value))
			{
				return value;
			}

			// Calculate the number of timelines
			long timelines = 0;
			char tile = input[row][col];

			if (tile == '^')
			{
				// Time to explore more timelines
				timelines += FindTimelines(input, row, col-1, cachedTimelines);
				timelines += FindTimelines(input, row, col+1, cachedTimelines);
			}
			else
			{
				// Keep moving down until we find a splitter or go out of bound
				timelines += FindTimelines(input, row + 1, col, cachedTimelines);
			}

			// Cache result to avoid computing this again
			cachedTimelines[(row, col)] = timelines;

			return timelines;
		}
	}
}

