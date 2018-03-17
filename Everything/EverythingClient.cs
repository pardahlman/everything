using System.Threading;
using System.Threading.Tasks;

namespace Everything
{
  public class EverythingClient
  {
    private readonly IResultEnumerator _resultEnumerator;
    private readonly IReplyIdGenerator _replyIdGenerator;

    public EverythingClient()
    {
      _resultEnumerator = new LazyResultEnumerator();
      _replyIdGenerator = new ReplyIdGenerator();
    }

    public async Task<SearchResult> SearchAsync(string term, SearchOptions options = default, CancellationToken ct = default)
    {
      if (string.IsNullOrEmpty(term))
      {
        return default;
      }

      var replyId = _replyIdGenerator.Next();
      using (await IpcCallerLock.AquireAsync(ct))
      {
        IpcWrapper.Search = term;

        if (options?.MatchPath != null) IpcWrapper.MatchPath = options.MatchPath.Value;
        if (options?.MatchCase != null) IpcWrapper.MatchCase = options.MatchCase.Value;
        if (options?.MatchWholeWord != null) IpcWrapper.MatchWholeWord = options.MatchWholeWord.Value;
        if (options?.RegexEnabled != null) IpcWrapper.Regex = options.RegexEnabled.Value;
        if (options?.MaxResult != null) IpcWrapper.Max = options.MaxResult.Value;
        if (options?.Offset != null) IpcWrapper.Offset = options.Offset.Value;

        IpcWrapper.ReplyId = replyId;
        IpcWrapper.Query(wait: true);

        var numberOfResult = IpcWrapper.GetResultCount();

        return new SearchResult
        {
          TotalCount = IpcWrapper.GetTotalResultCount(),
          DirectoryCount = IpcWrapper.GetFolderResultCount(),
          FileCount = IpcWrapper.GetFileResultCount(),
          Items = _resultEnumerator.GetResultItems(replyId, 0, numberOfResult, ct)
        };
      }
    }
  }
}
