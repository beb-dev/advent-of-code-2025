using System;
using AdventOfCode2025.Common;

namespace AdventOfCode2025.Days
{
	public class Day4 : Day
	{
		public override string Part1(string[] input)
		{
			int sums = 0;

			Grid2D<char> grid = ParseGrid(input);
			int rows = grid.Rows;
			int columns = grid.Columns;

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (grid.Contains('@', row, col) && CanAccessPaperRoll(grid, row, col))
					{
						sums++;
					}
				}
			}

			return sums.ToString();
		}

		public override string Part2(string[] input)
		{
			int sums = 0;

			Grid2D<char> grid = ParseGrid(input);
			int rows = grid.Rows;
			int columns = grid.Columns;

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (grid.Contains('@', row, col) && CanAccessPaperRoll(grid, row, col))
					{
						grid.Set('.', row, col);
						sums++;
						row = Math.Max(row-2, 0);
						col = Math.Max(col-1, 0);
					}
				}
			}

			
			return sums.ToString();
		}

		public static bool CanAccessPaperRoll(Grid2D<char> grid, int row, int column)
		{
			int count = 0;

			// Left, Right, Top, Down
			if (grid.Contains('@', row-1, column)) { count++; }
			if (grid.Contains('@', row+1, column)) { count++; }
			if (grid.Contains('@', row, column-1)) { count++; }
			if (grid.Contains('@', row, column+1)) { count++; }

			// Top-Left, Down-Left, Top-Right, Down-Right
			if (grid.Contains('@', row-1, column-1)) { count++; }
			if (grid.Contains('@', row-1, column+1)) { count++; }
			if (grid.Contains('@', row+1, column-1)) { count++; }
			if (grid.Contains('@', row+1, column+1)) { count++; }

			return count < 4;
		}

		public static Grid2D<char> ParseGrid(string[] input)
		{
			int rows = input.Length;
			int columns = input[0].Length;

			char[,] chars = new char[rows, columns];

			for (int i = 0; i < input.Length; i++)
			{
				string line = input[i];

				for (int j = 0; j < line.Length; j++)
				{
					chars[i, j] = line[j];
				}
			}

			return new Grid2D<char>(chars);
		}
	}
}
