using System.Collections.Generic;

namespace Everything
{
  public class SearchResult
  {
    public uint TotalCount { get; set; }
    public uint FileCount { get; set; }
    public uint DirectoryCount { get; set; }
    public IEnumerable<SearchItem> Items { get; set; }
  }
}