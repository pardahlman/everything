using Everything.LowLevel.SyntacticSugar;

namespace Everything.Search
{
  public class SearchOptions
  {
    /// <summary>
    /// If enabled, the query will search the full path and file name of each file and folder.
    /// Enabling match path will add a significant performance hit (disabled by default.)
    /// </summary>
    public bool? MatchPath { get; set; }

    /// <summary>
    /// Specifies whether the search is case sensitive or insensitive.
    /// Match case is disabled by default.
    /// </summary>
    public bool? MatchCase { get; set; }

    /// <summary>
    /// Specifies whether the search matches whole words, or can match anywhere.
    /// Match whole word is disabled by default.
    /// </summary>
    public bool? MatchWholeWord { get; set; }

    /// <summary>
    /// Regex is disabled by default.
    /// </summary>
    public bool? RegexEnabled { get; set; }

    /// <summary>
    /// Specifies the maximum number of results to return.
    /// The default maximum number of results is all results.
    /// </summary>
    public uint? MaxResult { get; set; }

    /// <summary>
    /// Specifies the first result from the available results.
    /// The default offset is 0 (the first available result).
    /// </summary>
    public uint? Offset { get; set; }

    /// <summary>
    /// Specifies the sort for the result.
    /// </summary>
    public Sort? Sort { get; set; }

    /// <summary>
    /// Specifies what aspects of the request to retrieve
    /// </summary>
    public RequestFlags? RequestFlags { get; set; }

    public static SearchOptions Default => new SearchOptions
    {
      RequestFlags = LowLevel.SyntacticSugar.RequestFlags.FileName | LowLevel.SyntacticSugar.RequestFlags.Path,
      Sort = LowLevel.SyntacticSugar.Sort.NameAscending,
      MatchCase = false,
      MatchPath = false,
      MatchWholeWord = false,
      RegexEnabled = false,
      Offset = 0
    };
  }
}
