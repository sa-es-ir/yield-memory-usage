# Benchmark for yield memory usage 
Using ``yield`` you can work one item 

![yield-benchmark](yield-benchmark.png)

# Checking using and not using ``yield``
```csharp

[MemoryDiagnoser(false)]
public class YieldBenchmark
{
    [Params(10_000, 100_000,1_000_000)]
    public int ItemsCount { get; set; }

    [Benchmark]
    public void ReturnItems()
    {
        foreach (var _ in ReturnWholeItems())
        {
        }
    }

    [Benchmark]
    public void ReturnItems_Yield()
    {
        foreach (var _ in YieldReturnItems())
        {
        }
    }

    private IEnumerable<int> ReturnWholeItems()
    {
        var list = new List<int>(ItemsCount);
        for (int i = 0; i < ItemsCount; i++)
            list.Add(i);

        return list;
    }

    private IEnumerable<int> YieldReturnItems()
    {
        for (int i = 0; i < ItemsCount; i++)
            yield return i;
    }
}
```
