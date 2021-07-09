using BenchmarkDotNet.Running;

namespace Practices.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Add>();
            BenchmarkRunner.Run<Replace>();
            BenchmarkRunner.Run<Remove>();
            BenchmarkRunner.Run<ArrayToImmutable>();
        }
    }
}
