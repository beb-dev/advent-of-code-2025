using AdventOfCode2025.Days;
using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Tests
{
	public class Day3Tests
	{
		[Fact]
		public void TestVoltagePart1()
		{
			Assert.Equal(98, Day3.GetVoltagePart1("987654321111111"));
			Assert.Equal(89, Day3.GetVoltagePart1("811111111111119"));
			Assert.Equal(78, Day3.GetVoltagePart1("234234234234278"));
			Assert.Equal(92, Day3.GetVoltagePart1("818181911112111"));


			Assert.Equal(87, Day3.GetVoltagePart1("1350452581657"));
			Assert.Equal(99, Day3.GetVoltagePart1("9877896419029"));
		}

		[Fact]
		public void TestVoltagePart2()
		{
			Assert.Equal(987654321111, Day3.GetVoltagePart2("987654321111111"));
			Assert.Equal(811111111119, Day3.GetVoltagePart2("811111111111119"));
			Assert.Equal(434234234278, Day3.GetVoltagePart2("234234234234278"));
			Assert.Equal(888911112111, Day3.GetVoltagePart2("818181911112111"));
		}
	}
}
