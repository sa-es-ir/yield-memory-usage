using BenchmarkDotNet.Running;
using YieldMemoryUsage;

Console.WriteLine(BenchmarkRunner.Run<YieldBenchmark>());