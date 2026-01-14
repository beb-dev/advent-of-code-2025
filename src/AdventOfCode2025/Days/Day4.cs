using System;
using AdventOfCode2025.Common;

namespace AdventOfCode2025.Days
{
	public class Day4 : Day
	{
		public override string Part1(string[] input)
		{
			int sums = 0;

			char[,] grid = ParseGrid(input);
			int rows = grid.GetLength(0);
			int columns = grid.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (CanAccessPaperRoll(grid, row, col))
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

			char[,] grid = ParseGrid(input);
			int rows = grid.GetLength(0);
			int columns = grid.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (CanAccessPaperRoll(grid, row, col))
					{
						// Remove roll, then check past rows and cols
						grid[row, col] = '.';
						row = Math.Max(row - 2, 0);
						col = Math.Max(col - 1, 0);
						sums++;
					}
				}
			}

			return sums.ToString();
		}

		public static bool CanAccessPaperRoll(char[,] grid, int row, int col)
		{
			if (!ContainsPaperRoll(grid, row, col))
			{
				return false;
			}

			int paperRolls = 0;
			int maxPaperRolls = 3;

			// Left, Right, Top, Down
			if (ContainsPaperRoll(grid, row - 1, col)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row + 1, col)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row, col - 1)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row, col + 1)) { paperRolls++; }

			// Top-Left, Down-Left, Top-Right, Down-Right
			if (ContainsPaperRoll(grid, row - 1, col - 1)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row - 1, col + 1)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row + 1, col - 1)) { paperRolls++; }
			if (ContainsPaperRoll(grid, row + 1, col + 1)) { paperRolls++; }

			return paperRolls <= maxPaperRolls;
		}

		public static bool ContainsPaperRoll(char[,] grid, int row, int col)
		{
			int rows = grid.GetLength(0);
			int columns = grid.GetLength(1);

			if (row < 0 || col < 0 || row >= rows || col >= columns)
			{
				return false;
			}

			return grid[row, col] == '@';
		}

		public static char[,] ParseGrid(string[] input)
		{
			int rows = input.Length;
			int columns = input[0].Length;

			char[,] grid = new char[rows, columns];

			for (int i = 0; i < input.Length; i++)
			{
				string line = input[i];

				for (int j = 0; j < line.Length; j++)
				{
					grid[i, j] = line[j];
				}
			}

			return grid;
		}
	}
}
