using System.Threading;
using Everything.Model;
using Everything.Search;

namespace Everything.Result
{
  internal interface ISearchResultService
  {
    SearchResult GetCurrentResult(SearchOptions options, CancellationToken ct = default);
  }
}