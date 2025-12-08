using AdventOfCode2025.Days;

namespace AdventOfCode2025.Tests
{
	public class Day2Tests
	{
		[Fact]
		public void ValidateIdsPart1()
		{
			Assert.True(Day2.ValidateIdPart1(0));
			Assert.True(Day2.ValidateIdPart1(1));
			Assert.True(Day2.ValidateIdPart1(12));
			Assert.True(Day2.ValidateIdPart1(123));
			Assert.True(Day2.ValidateIdPart1(1234));
			Assert.True(Day2.ValidateIdPart1(12345));

			Assert.True(Day2.ValidateIdPart1(101));
			Assert.True(Day2.ValidateIdPart1(1213));
			Assert.True(Day2.ValidateIdPart1(123122));
			Assert.True(Day2.ValidateIdPart1(123321));

			Assert.False(Day2.ValidateIdPart1(11));
			Assert.False(Day2.ValidateIdPart1(22));
			Assert.False(Day2.ValidateIdPart1(1010));
			Assert.False(Day2.ValidateIdPart1(1188511885));
			Assert.False(Day2.ValidateIdPart1(222222));
			Assert.False(Day2.ValidateIdPart1(446446));
			Assert.False(Day2.ValidateIdPart1(38593859));
		}

		[Fact]
		public void ValidateIdsPart2()
		{
			Assert.True(Day2.ValidateIdPart2(0));
			Assert.True(Day2.ValidateIdPart2(1));
			Assert.True(Day2.ValidateIdPart2(12));
			Assert.True(Day2.ValidateIdPart2(123));
			Assert.True(Day2.ValidateIdPart2(1234));
			Assert.True(Day2.ValidateIdPart2(12345));

			Assert.True(Day2.ValidateIdPart2(101));
			Assert.True(Day2.ValidateIdPart2(1213));
			Assert.True(Day2.ValidateIdPart2(123122));
			Assert.True(Day2.ValidateIdPart2(123321));

			Assert.False(Day2.ValidateIdPart2(11));
			Assert.False(Day2.ValidateIdPart2(22));
			Assert.False(Day2.ValidateIdPart2(99));
			Assert.False(Day2.ValidateIdPart2(111));
			Assert.False(Day2.ValidateIdPart2(999));
			Assert.False(Day2.ValidateIdPart2(1010));
			Assert.False(Day2.ValidateIdPart2(1188511885));
			Assert.False(Day2.ValidateIdPart2(222222));
			Assert.False(Day2.ValidateIdPart2(446446));
			Assert.False(Day2.ValidateIdPart2(38593859));
			Assert.False(Day2.ValidateIdPart2(565656));
			Assert.False(Day2.ValidateIdPart2(824824824));
			Assert.False(Day2.ValidateIdPart2(2121212121));
		}
	}
}
