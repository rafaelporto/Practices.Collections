using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace Practices.Collections
{
	[RankColumn]
	[MemoryDiagnoser]
	[ThreadingDiagnoser]
	[SimpleJob(targetCount: 1)]
	public class ArrayToImmutable
	{
		private Item[] _array;
		private int count = 100_000;
		private ImmutableArray<Item>.Builder _immutableArrayBuilder;

		public ArrayToImmutable()
		{
			_array = ItemFactory.CreateArrayItems(count);
			_immutableArrayBuilder = ImmutableArray.CreateBuilder<Item>(count);
		}

		[Benchmark]
		public ImmutableArray<Item> ConvertArrayToImmutable()
		{
			_immutableArrayBuilder.AddRange(_array);
			return _immutableArrayBuilder.ToImmutable();
		}

		[Benchmark]
		public ImmutableArray<Item> ConvertArrayToImmutableExtensions()
		{
			_immutableArrayBuilder.AddRange(_array);
			return _immutableArrayBuilder.ToImmutableArray();
		}

		[Benchmark]
		public ImmutableArray<Item> ConvertArrayToImmutableCreate()
		{
			return ImmutableArray.Create(_array);
		}
	}
}
