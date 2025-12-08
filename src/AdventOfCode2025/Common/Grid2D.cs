using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Common
{
	public class Grid2D<T>
	{
		private readonly T[,] m_grid;
		private readonly int m_rows;
		private readonly int m_columns;

		public Grid2D(T[,] grid)
		{
			m_grid = grid;
			m_rows = grid.GetLength(0);
			m_columns = grid.GetLength(1);
		}

		public int Rows
		{
			get { return m_rows; }
		}

		public int Columns
		{
			get { return m_rows; }
		}

		public T Get(int row, int column)
		{
			if (!CheckBounds(row, column))
			{
				throw new IndexOutOfRangeException($"Index is out of range. Row: {row} / Column: {column}");
			}

			return m_grid[row, column];
		}

		public bool TryGet(int row, int column, out T? output)
		{
			if (CheckBounds(row, column))
			{
				output = m_grid[row, column];
				return true;
			}
			else
			{
				output = default;
				return false;
			}
		}

		public void Set(T value, int row, int column)
		{
			if (!CheckBounds(row, column))
			{
				throw new IndexOutOfRangeException($"Index is out of range. Row: {row} / Column: {column}");
			}

			m_grid[row, column] = value;
		}

		public bool TrySet(T value, int row, int column)
		{
			if (!CheckBounds(row, column))
			{
				return false;
			}

			m_grid[row, column] = value;
			return true;
		}

		public bool CheckBounds(int row, int column)
		{
			return
				row >= 0 &&
				row < m_rows &&
				column >= 0 &&
				column < m_columns;
		}

		public bool Contains(T? value, int row, int column)
		{
			if (!CheckBounds(row, column))
			{
				return false;
			}

			return value is not null && value.Equals(m_grid[row, column]);
		}
	}
}
