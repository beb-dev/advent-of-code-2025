using AdventOfCode2025.Common;

namespace AdventOfCode2025.Tests
{
	public class Grid2DTests
	{
		[Fact]
		public void GetValue()
		{
			int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
			
			var grid = new Grid2D<int>(numbers);

			// First Row
			Assert.Equal(1, grid.Get(0, 0));
			Assert.Equal(2, grid.Get(0, 1));
			Assert.Equal(3, grid.Get(0, 2));

			// Second Row
			Assert.Equal(4, grid.Get(1, 0));
			Assert.Equal(5, grid.Get(1, 1));
			Assert.Equal(6, grid.Get(1, 2));

			// Third Row
			Assert.Equal(7, grid.Get(2, 0));
			Assert.Equal(8, grid.Get(2, 1));
			Assert.Equal(9, grid.Get(2, 2));
		}

		[Fact]
		public void GetValueOutOfBound()
		{
			int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

			var grid = new Grid2D<int>(numbers);

			Assert.Throws<IndexOutOfRangeException>(() => grid.Get(-1, 0));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Get(0, -1));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Get(3, 0));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Get(0, 3));
		}

		[Fact]
		public void TryGetValue()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4} };

			var grid = new Grid2D<int>(numbers);

			// First Row
			Assert.True(grid.TryGet(0, 0, out int num1));
			Assert.Equal(1, num1);

			Assert.True(grid.TryGet(0, 1, out int num2));
			Assert.Equal(2, num2);

			// Second Row
			Assert.True(grid.TryGet(1, 0, out int num3));
			Assert.Equal(3, num3);

			Assert.True(grid.TryGet(1, 1, out int num4));
			Assert.Equal(4, num4);
		}

		[Fact]
		public void TryGetValueOutOfBound()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			Assert.False(grid.TryGet(-1, 0, out int num1));
			Assert.Equal(0, num1);

			Assert.False(grid.TryGet(2, 0, out int num2));
			Assert.Equal(0, num2);

			Assert.False(grid.TryGet(0, -1, out int num3));
			Assert.Equal(0, num3);

			Assert.False(grid.TryGet(0, 2, out int num4));
			Assert.Equal(0, num4);
		}

		[Fact]
		public void SetValue()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			grid.Set(100, 0, 0);

			Assert.Equal(100, grid.Get(0, 0));
		}

		[Fact]
		public void SetValueOutOfBound()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			Assert.Throws<IndexOutOfRangeException>(() => grid.Set(100, -1, 0));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Set(100, 0, -1));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Set(100, 3, 0));
			Assert.Throws<IndexOutOfRangeException>(() => grid.Set(100, 0, 3));
		}

		[Fact]
		public void TrySetValue()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			Assert.True(grid.TrySet(100, 0, 0));
			Assert.Equal(100, grid.Get(0, 0));
		}

		[Fact]
		public void TrySetValueOutOfBound()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			Assert.False(grid.TrySet(100, -1, 0));
			Assert.False(grid.TrySet(100, 2, 0));
			Assert.False(grid.TrySet(100, 0, -1));
			Assert.False(grid.TrySet(100, 0, 2));
		}

		[Fact]
		public void CheckBounds()
		{
			int[,] numbers = { { 1, 2 }, { 3, 4 } };

			var grid = new Grid2D<int>(numbers);

			Assert.True(grid.CheckBounds(0, 0));
			Assert.True(grid.CheckBounds(0, 1));
			Assert.True(grid.CheckBounds(1, 0));
			Assert.True(grid.CheckBounds(1, 1));

			Assert.False(grid.CheckBounds(-1, 0));
			Assert.False(grid.CheckBounds(2, 0));
			Assert.False(grid.CheckBounds(0, -1));
			Assert.False(grid.CheckBounds(0, 2));
		}
	}
}
