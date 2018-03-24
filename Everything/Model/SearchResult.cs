using System.Collections.Generic;

namespace Everything.Model
{
  public sealed class SearchResult
  {
    public uint MatchingItemsCount { get; set; }
    public uint MatchingFileCount { get; set; }
    public uint MatchingDirectoryCount { get; set; }
    public IEnumerable<ResultItem> Items { get; set; }
  }
}
