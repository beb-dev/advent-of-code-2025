using AdventOfCode2025.Days;

namespace AdventOfCode2025.Tests
{
	public class Day5Tests
	{
		[Fact]
		public void IgnoreIdsAlreadyCounted()
		{
			var inventory = new Inventory(32);

			// [100-109]
			inventory.Ranges.Add(new LongRange(100, 109));
			Assert.Equal(10, Day5.CountValidIdsPart2(inventory));

			// [101-108] already counted by previous range
			inventory.Ranges.Add(new LongRange(101, 108));
			Assert.Equal(10, Day5.CountValidIdsPart2(inventory));

			// [99-110]
			// Contains the previous range
			// Only need to count 99 and 110
			// Ignore [100-109]
			inventory.Ranges.Add(new LongRange(99, 110));
			Assert.Equal(12, Day5.CountValidIdsPart2(inventory));
		}

		[Fact]
		public void CountIdsOutsideOverlap()
		{
			var inventory = new Inventory(32);

			// [100-109] are counted
			inventory.Ranges.Add(new LongRange(100, 109));
			Assert.Equal(10, Day5.CountValidIdsPart2(inventory));

			// [99-101] only 99 needs to be counted
			inventory.Ranges.Add(new LongRange(99, 101));
			Assert.Equal(11, Day5.CountValidIdsPart2(inventory));

			// [109-110] only 110 needs to be counted
			inventory.Ranges.Add(new LongRange(109, 110));
			Assert.Equal(12, Day5.CountValidIdsPart2(inventory));
		}

		[Fact]
		public void CountIdStuckBetweenTwoRanges()
		{
			var inventory = new Inventory(32);

			// The id 105 is missing on purpose for this test.
			// [100-104] 105 [106-109]
			inventory.Ranges.Add(new LongRange(100, 104));
			inventory.Ranges.Add(new LongRange(106, 109));
			Assert.Equal(9, Day5.CountValidIdsPart2(inventory));

			// [100-109]
			// Only need to count 105
			inventory.Ranges.Add(new LongRange(100, 109));
			Assert.Equal(10, Day5.CountValidIdsPart2(inventory));
		}

		[Fact]
		public void Ranges_from_test_input_works_for_part2()
		{
			var inventory = new Inventory(32);

			// Note: test input is missing multiple edge cases.
			inventory.Ranges.Add(new LongRange(3, 5));
			inventory.Ranges.Add(new LongRange(10, 14));
			inventory.Ranges.Add(new LongRange(16, 20));
			inventory.Ranges.Add(new LongRange(12, 18));

			Assert.Equal(14, Day5.CountValidIdsPart2(inventory));
		}
	}
}
