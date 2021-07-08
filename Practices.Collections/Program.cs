using BenchmarkDotNet.Running;

namespace Practices.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = BenchmarkRunner.Run<AddBenchmark>();
            //var result = BenchmarkRunner.Run<ReplaceBenchmark>();
            //var result = BenchmarkRunner.Run<Remove>();
            var result = BenchmarkRunner.Run<ArrayToImmutable>();
        }
    }
}
