using System;
using Everything.LowLevel.SyntacticSugar;

namespace Everything.Search
{
  internal class SearchService
  {
    public void Search(string query, SearchOptions options = default)
    {
      if (string.IsNullOrEmpty(query))
      {
        throw new ArgumentNullException(nameof(query));
      }

      EverythingSdk.Search = query;
      SetSearchState(options);
      EverythingSdk.Query(wait: true);
    }

    public void SetSearchState(SearchOptions options)
    {
      if (options?.RequestFlags != null) EverythingSdk.RequestFlags = options.RequestFlags.Value;
      if (options?.Sort != null) EverythingSdk.Sort = options.Sort.Value;
      if (options?.MatchPath != null) EverythingSdk.MatchPath = options.MatchPath.Value;
      if (options?.MatchCase != null) EverythingSdk.MatchCase = options.MatchCase.Value;
      if (options?.MatchWholeWord != null) EverythingSdk.MatchWholeWord = options.MatchWholeWord.Value;
      if (options?.RegexEnabled != null) EverythingSdk.Regex = options.RegexEnabled.Value;
      if (options?.MaxResult != null) EverythingSdk.Max = options.MaxResult.Value;
      if (options?.Offset != null) EverythingSdk.Offset = options.Offset.Value;
    }
  }
}
