using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode2025
{
	public static class DataParser
	{
		public static string[] GetLinesByDay(int day, bool useTestInput = false)
		{
			if (day <= 0 || day > 12)
			{
				throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 12.");
			}

			string path = GetFilePathByDay(day, useTestInput);

			if (!File.Exists(path))
			{
				return [];
			}

			return File.ReadAllLines(path);
		}

		private static string GetFilePathByDay(int day, bool useTestInput = false)
		{
			if (useTestInput)
			{
				return GetFilePath($"Data/input_day{day}_test.txt");
			}
			else
			{
				return GetFilePath($"Data/input_day{day}.txt");
			}
		}

		private static string GetFilePath(string fileName)
		{
			string location = Assembly.GetExecutingAssembly().Location;
			string? directory = Path.GetDirectoryName(location);

			if (string.IsNullOrEmpty(directory))
			{
				return string.Empty;
			}

			return Path.Combine(directory, fileName);
		}
	}
}
