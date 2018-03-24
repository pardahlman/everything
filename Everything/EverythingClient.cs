using System;
using System.Threading;
using System.Threading.Tasks;
using Everything.LowLevel.SyntacticSugar;
using Everything.Model;
using Everything.Result;
using Everything.Search;
using Everything.Status;

namespace Everything
{
  public interface IEverythingClient
  {
    Task<SearchResult> SearchAsync(string query, SearchOptions options = default, CancellationToken ct = default);
    EverythingStatus GetStatus();
    void SetSearchState(SearchOptions options);
  }

  public class EverythingClient : IDisposable, IEverythingClient
  {
    private readonly SearchService _searchService;
    private readonly ISearchResultService _resultService;
    private readonly StatusService _statusService;

    public EverythingClient()
    {
      _searchService = new SearchService();
      _resultService = new SearchResultService();
      _statusService = new StatusService();
    }

    public async Task<SearchResult> SearchAsync(string query, SearchOptions options = default, CancellationToken ct = default)
    {
      ct.ThrowIfCancellationRequested();

      if (string.IsNullOrEmpty(query))
      {
        throw new ArgumentException("Must provide search query", nameof(query));
      }

      using (await IpcCallerLock.AquireAsync(ct))
      {
        _searchService.Search(query, options);
        ct.ThrowIfCancellationRequested();
        return _resultService.GetCurrentResult(options, ct);
      }
    }

    public void SetSearchState(SearchOptions options) => _searchService.SetSearchState(options);

    public EverythingStatus GetStatus() => _statusService.GetStatus();

    public void Dispose()
    {
      EverythingSdk.Reset();
    }
  }
}
