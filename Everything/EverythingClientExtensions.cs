using System;
using System.Threading;
using System.Threading.Tasks;
using Everything.Model;
using Everything.Search;
using Everything.Search.Query;

namespace Everything
{
  public static class EverythingClientExtensions
  {
    public static Task<SearchResult> SearchAsync(
      this IEverythingClient client,
      Action<IQueryBuilder> query,
      SearchOptions options = default,
      CancellationToken ct = default)
    {
      var queryBuilder = new QueryBuilder();
      query?.Invoke(queryBuilder);
      return client.SearchAsync(queryBuilder.Query, options, ct);
    }
  }
}
