using System;
using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public class Problem
	{
		public char Operator;
		public readonly List<long> Numbers;

		public Problem()
		{
			Operator = '+';
			Numbers = new List<long>(4);
		}
	}

	public class Day6 : Day
	{
		public override string Part1(string[] input)
		{
			List<Problem> operations = ParsePart1(input);

			long sums = SolveProblems(operations);

			return sums.ToString();
		}

		public override string Part2(string[] input)
		{
			List<Problem> operations = ParsePart2(input);

			long sums = SolveProblems(operations);

			return sums.ToString();
		}

		public static List<Problem> ParsePart1(string[] input)
		{
			// Build a list of problems to solve later
			var problems = new List<Problem>(1024);

			var options =
				StringSplitOptions.TrimEntries |
				StringSplitOptions.RemoveEmptyEntries;

			// Parse operators
			string[] operators = input[^1].Split(' ', options);

			// Create problems
			for (int i = 0; i < operators.Length; i++)
			{
				problems.Add(new Problem() { Operator = operators[i][0] });
			}

			// Find the numbers for each problem
			//
			// Get the first number of each problem
			// Get the second number of each problem
			//
			// ..and so on until the input is parsed completely
			int rows = input.Length - 1;

			for (int i = 0; i < rows; i++)
			{
				string[] values = input[i].Split(' ', options);

				for (int j = 0; j < values.Length; j++)
				{
					problems[j].Numbers.Add(long.Parse(values[j]));
				}
			}

			return problems;
		}

		public static List<Problem> ParsePart2(string[] input)
		{
			// Build a list of problems to solve later
			var problems = new List<Problem>(1024);

			Span<char> digits = stackalloc char[8];

			int rows = input.Length;
			int rowsWithNumbers = rows - 1;

			int col = 0;
			int columns = input[0].Length;

			while (col < columns)
			{
				var problem = new Problem
				{
					Operator = input[rows - 1][col]
				};

				problems.Add(problem);
				
				bool parsingProblem = true;

				while (parsingProblem)
				{
					int digitIndex = 0;
					int whitespace = 0;

					// The first few rows contain all digits.
					// A number's digits are found on the same column.
					for (int row = 0; row < rowsWithNumbers; row++)
					{
						char c = input[row][col];

						if (c == ' ')
						{
							// Found empty space
							whitespace++;
						}
						else
						{
							// Found digit
							digits[digitIndex] = c;
							digitIndex++;
						}
					}

					// Convert digits to number
					if (digitIndex > 0)
					{
						long number = long.Parse(digits[..digitIndex]);
						problem.Numbers.Add(number);
					}

					// Done parsing if current column is filled by whitespace
					// or it is the final column of the input.
					if (whitespace == rowsWithNumbers || col + 1 == columns)
					{
						parsingProblem = false;
					}

					col++;
				}
			}

			return problems;
		}

		public static long SolveProblems(List<Problem> problems)
		{
			// Find the answer to each problem
			// Add them all together
			long sums = 0;
			int length = problems.Count;

			for (int i = 0; i < length; i++)
			{
				Problem problem = problems[i];

				long answer = problem.Numbers[0];
				int numCount = problem.Numbers.Count;

				for (int j = 1; j < numCount; j++)
				{
					long num = problem.Numbers[j];

					switch (problem.Operator)
					{
						case '+':
							answer += num;
							break;
						case '*':
							answer *= num;
							break;
					}
				}

				sums += answer;
			}

			return sums;
		}
	}
}
