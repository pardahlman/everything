using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Everything
{
  public interface IResultEnumerator
  {
    IEnumerable<SearchItem> GetResultItems(uint replyId, uint fromInclusive, uint toExclusive, CancellationToken ct);
  }

  internal class LazyResultEnumerator : IResultEnumerator
  {
    private readonly ItemGenerator _itemGenerator;

    public LazyResultEnumerator()
    {
      _itemGenerator = new ItemGenerator();
    }

    public IEnumerable<SearchItem> GetResultItems(uint replyId, uint fromInclusive, uint toExclusive, CancellationToken ct)
    { 
      for (var i = fromInclusive; i < toExclusive; i++)
      {
        if (ct.IsCancellationRequested)
        {
          yield break;
        }

        yield return _itemGenerator.Generate(replyId, i, ct);
      }
    }
  }

  internal class ParallelResultEnumerator : IResultEnumerator
  {
    private readonly ItemGenerator _itemGenerator;

    public ParallelResultEnumerator()
    {
      _itemGenerator = new ItemGenerator();
    }

    public IEnumerable<SearchItem> GetResultItems(uint replyId, uint fromInclusive, uint toExclusive, CancellationToken ct)
    {
      var numberOfItems = toExclusive - fromInclusive;
      var searchItems = new SearchItem[numberOfItems];
      Parallel.For(fromInclusive, toExclusive, body: (longIndex, state) =>
      {
        var index = (uint) longIndex + fromInclusive;
        searchItems[index] = _itemGenerator.Generate(index);
      }, parallelOptions: new ParallelOptions {CancellationToken = ct});

      return searchItems;
    }
  }
}
