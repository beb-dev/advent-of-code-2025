using System.Collections.Generic;

namespace AdventOfCode2025.Days
{
	public class Day8 : Day
	{
		public struct Box
		{
			public long x, y, z;
			public int Circuit = -1;

			public Box(long x, long y, long z)
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}
		}

		public struct BoxPair
		{
			public int Box1;
			public int Box2;
			public long Distance;

			public BoxPair(int box1, int box2, long distance)
			{
				Box1 = box1;
				Box2 = box2;
				Distance = distance;
			}
		}

		public override string Part1(string[] input)
		{
			var boxes = ParseBoxes(input);
			var circuits = new List<List<int>>(1024);
			var boxPairsMinHeap = new PriorityQueue<BoxPair, double>(100_000);

			// Create circuits with one box each
			for (int i = 0; i < boxes.Count; i++)
			{
				Box box = boxes[i];
				box.Circuit = i;
				boxes[i] = box;
				circuits.Add(new List<int>(32));
				circuits[i].Add(i);
			}

			// Get all possible box pairs and their distance
			// Store them in a min heap based on shortest distance
			for (int i = 0; i < boxes.Count; i++)
			{
				for (int j = i+1; j < boxes.Count; j++)
				{
					long distance = Distance(boxes[i], boxes[j]);
					var pair = new BoxPair(i, j, distance);
					boxPairsMinHeap.Enqueue(pair, distance);
				}
			}

			// Check the first 1000 pairs 
			int pairs = 0;
			int maxPairs = 1000;

			// Test input checks only for the first 10 pairs
			// We know it is the test input when there are 20 boxes.
			if (boxes.Count == 20)
			{
				maxPairs = 10;
			}

			while (boxPairsMinHeap.Count > 0 && pairs < maxPairs)
			{
				pairs++;

				BoxPair pair = boxPairsMinHeap.Dequeue();
				Box box1 = boxes[pair.Box1];
				Box box2 = boxes[pair.Box2];

				if (box1.Circuit != box2.Circuit)
				{
					List<int> circuit1 = circuits[box1.Circuit];
					List<int> circuit2 = circuits[box2.Circuit];

					// Merge the second circuit into the first one
					int count = circuit2.Count;

					for (int i = 0; i < count; i++)
					{
						// Update the box's internal circuit index
						int boxIndex = circuit2[i];
						Box boxToMove = boxes[boxIndex];
						boxToMove.Circuit = box1.Circuit;
						boxes[boxIndex] = boxToMove;
					}

					// Move boxes in bulk, then clear circuit
					circuit1.AddRange(circuit2);
					circuit2.Clear();
				}
			}

			// Sort by descending number of boxes
			// to get the three circuits with the most boxes.
			circuits.Sort((a, b) => b.Count.CompareTo(a.Count));

			int total = circuits[0].Count * circuits[1].Count * circuits[2].Count;

			return total.ToString();
		}

		public override string Part2(string[] input)
		{
			var boxes = ParseBoxes(input);
			var circuits = new List<List<int>>(1024);
			var boxPairsMinHeap = new PriorityQueue<BoxPair, double>(100_000);

			// Create circuits with one box each
			for (int i = 0; i < boxes.Count; i++)
			{
				Box box = boxes[i];
				box.Circuit = i;
				boxes[i] = box;
				circuits.Add(new List<int>(32));
				circuits[i].Add(i);
			}

			// Get all possible box pairs and their distance
			// Store them in a min heap based on shortest distance
			for (int i = 0; i < boxes.Count; i++)
			{
				for (int j = i + 1; j < boxes.Count; j++)
				{
					long distance = Distance(boxes[i], boxes[j]);
					var pair = new BoxPair(i, j, distance);
					boxPairsMinHeap.Enqueue(pair, distance);
				}
			}

			// Connect boxes until they are all in one circuit
			while (boxPairsMinHeap.Count > 0)
			{
				BoxPair pair = boxPairsMinHeap.Dequeue();
				Box box1 = boxes[pair.Box1];
				Box box2 = boxes[pair.Box2];

				if (box1.Circuit != box2.Circuit)
				{
					List<int> circuit1 = circuits[box1.Circuit];
					List<int> circuit2 = circuits[box2.Circuit];

					// Merge the second circuit into the first one
					int count = circuit2.Count;

					for (int i = 0; i < count; i++)
					{
						// Update the box's internal circuit index
						int boxIndex = circuit2[i];
						Box boxToMove = boxes[boxIndex];
						boxToMove.Circuit = box1.Circuit;
						boxes[boxIndex] = boxToMove;
					}

					// Move boxes in bulk, then clear circuit
					circuit1.AddRange(circuit2);
					circuit2.Clear();

					// If circuit has all the boxes
					// then the operation is done
					if (circuit1.Count == boxes.Count)
					{
						long result = box1.x * box2.x;
						return result.ToString();
					}
				}
			}

			return "Result not found.";
		}

		public static long Distance(Box box1, Box box2)
		{
			long x = box1.x - box2.x;
			long y = box1.y - box2.y;
			long z = box1.z - box2.z;

			return x*x + y*y + z*z;
		}

		public static List<Box> ParseBoxes(string[] input)
		{
			var boxes = new List<Box>(1024);

			int length = input.Length;

			for (int i = 0; i < length; i++)
			{
				string[] splits = input[i].Split(',');

				long x = long.Parse(splits[0]);
				long y = long.Parse(splits[1]);
				long z = long.Parse(splits[2]);

				boxes.Add(new Box(x, y, z));
			}

			return boxes;
		}
	}
}
