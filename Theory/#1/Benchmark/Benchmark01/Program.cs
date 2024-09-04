using System.Collections;
using System.Linq;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;


namespace benchmark
{
	public static class Program
	{
		static void Main()
		{
			var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
		}
	}

	public class Math
	{
		List<int> digits;

		public Math()
		{
			digits = new List<int>();
			for (int i = 0; i < 1000; i++)
			{
				digits.Add(new Random().Next(0, 100));
			}
		}

		[Benchmark]
		public int simpleSum()
		{
			digits = new List<int>();
			for (int i = 0; i < 1000; i++)
			{
				digits.Add(new Random().Next(0, 100));
			}

			return digits.Sum();
		}

		[Benchmark]
		public int parallelSum()
		{
			digits = new List<int>();
			for (int i = 0; i < 1000; i++)
			{
				digits.Add(new Random().Next(0, 100));
			}
			return digits.AsParallel().Sum();
		}
	}
}






