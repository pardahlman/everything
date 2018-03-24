using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Everything.LowLevel.SyntacticSugar;
using Everything.Model;
using Everything.Search;

namespace Everything.Result
{
  internal class SearchResultService : ISearchResultService
  {
    public SearchResult GetCurrentResult(SearchOptions options, CancellationToken ct = default)
    {
      var availableResult = (int)EverythingSdk.GetResultCount();

      var result = new SearchResult
      {
        MatchingItemsCount = EverythingSdk.GetTotalResultCount(),
        MatchingDirectoryCount = EverythingSdk.GetTotalFolderResultCount(),
        MatchingFileCount = EverythingSdk.GetTotalFileResultCount(),
      };

      var items = new ResultItem[availableResult];
      Parallel.For(fromInclusive: 0, toExclusive: availableResult, body: i =>
      {
        var index = (uint)i;
        var resultType = GetResultType(index);
        switch (resultType)
        {
          case ResultType.Unknown:
            break;
          case ResultType.File:
            items[i] = CreateFileResult(index);
            break;
          case ResultType.Directory:
            items[i] = CreateDirectoryResult(index);
            break;
          case ResultType.Volume:
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }, parallelOptions: new ParallelOptions { CancellationToken = ct }
    );

      result.Items = items.ToList().AsReadOnly();
      return result;
    }

    private static ResultType GetResultType(uint index)
    {
      if (EverythingSdk.IsFile(index))
        return ResultType.File;
      if (EverythingSdk.IsFolder(index))
        return ResultType.Directory;
      if (EverythingSdk.IsVolume(index))
        return ResultType.Volume;
      return ResultType.Unknown;
    }

    private static FileResultItem CreateFileResult(uint resultIndex)
    {
      var pathBuilder = new StringBuilder(260);
      EverythingSdk.GetFullPath(resultIndex, pathBuilder);
      var fullPath = pathBuilder.ToString();

      return new FileResultItem
      {
        // TODO: Uncomment when SDK does not kill the entire process :(
        Name = Path.GetFileName(fullPath), //EverythingSdk.GetFileName(resultIndex)
        Extension = Path.GetExtension(fullPath), //EverythingSdk.GetExtension(resultIndex)
        FullPath = fullPath,
        Created = EverythingSdk.TryGetDateCreated(resultIndex, out var created) ? created : default,
        Modified = EverythingSdk.TryGetDateModified(resultIndex, out var modified) ? modified : default,
        Accessed = EverythingSdk.TryGetDateAccessed(resultIndex, out var accessed) ? accessed : default,
        Attributes = EverythingSdk.GetAttributes(resultIndex),
        RunCount = EverythingSdk.GetRunCount(resultIndex),
        Size = EverythingSdk.TryGetSize(resultIndex, out var size) ? size : default
      };
    }

    private static DirectoryResultItem CreateDirectoryResult(uint resultIndex)
    {
      var pathBuilder = new StringBuilder(260);
      EverythingSdk.GetFullPath(resultIndex, pathBuilder);
      var fullPath = pathBuilder.ToString();

      return new DirectoryResultItem
      {
        Name = Path.GetDirectoryName(fullPath),
        FullPath = fullPath,
        Created = EverythingSdk.TryGetDateCreated(resultIndex, out var created) ? created : default,
        Modified = EverythingSdk.TryGetDateModified(resultIndex, out var modified) ? modified : default,
        Accessed = EverythingSdk.TryGetDateAccessed(resultIndex, out var accessed) ? accessed : default
      };
    }
  }
}

