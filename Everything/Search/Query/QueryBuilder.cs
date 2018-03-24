using System;
using System.Text;

namespace Everything.Search.Query
{
  public class QueryBuilder : IQueryBuilder, ISizeConstraintBuilder, ITimeConstraintBuilder
  {

    private readonly StringBuilder _builder;
    public string Query => _builder.ToString();

    public QueryBuilder()
    {
      _builder = new StringBuilder();
    }

    public ISizeConstraintBuilder AllFiles(string query = default) => TypeQuery(Macros.Files, query);
    public ISizeConstraintBuilder AllFolders(string query = default) => TypeQuery(Macros.Folder, query);
    public ISizeConstraintBuilder Everything(string query = default) => TypeQuery(string.Empty, query);
    public ISizeConstraintBuilder Executables(string query = default) => TypeQuery(Macros.Exe, query);
    public ISizeConstraintBuilder CompressedFiles(string query = default) => TypeQuery(Macros.Zip, query);
    public ISizeConstraintBuilder Pictures(string query = default) => TypeQuery(Macros.Pic, query);
    public ISizeConstraintBuilder Documents(string query = default) => TypeQuery(Macros.Doc, query);
    public ISizeConstraintBuilder Audio(string query = default) => TypeQuery(Macros.Audio, query);

    private ISizeConstraintBuilder TypeQuery(string type, string query)
    {
      query = query ?? string.Empty;
      _builder.Append($"{type}{query} ");
      return this;
    }

    public ITimeConstraintBuilder OfAnySize() => this;
    public ITimeConstraintBuilder OfTinySize() => SizeQuery(SizeConstants.Tiny);
    public ITimeConstraintBuilder OfSmallSize() => SizeQuery(SizeConstants.Small);
    public ITimeConstraintBuilder OfMediumSize() => SizeQuery(SizeConstants.Medium);
    public ITimeConstraintBuilder OfLargeSize() => SizeQuery(SizeConstants.Large);
    public ITimeConstraintBuilder OfHugeSize() => SizeQuery(SizeConstants.Huge);
    public ITimeConstraintBuilder OfGiganticSize() => SizeQuery(SizeConstants.Gigantic);
    public ITimeConstraintBuilder Sized(uint size, SizeUnit unit) => SizeQuery($"{size}{unit.ToString()}");
    public ITimeConstraintBuilder LargerThan(uint size, SizeUnit unit) => SizeQuery($">{size}{unit.ToString()}");
    public ITimeConstraintBuilder SmallerThan(uint size, SizeUnit unit) => SizeQuery($"<{size}{unit.ToString()}");

    private ITimeConstraintBuilder SizeQuery(string size)
    {
      _builder.Append($"size:{size} ");
      return this;
    }

    public ITimeConstraintBuilder WithTimeConstraint(string dateConstraint)
    {
      _builder.Append(dateConstraint);
      return this;
    }

    public void WithoutTimeConstraints() { }

    public void Created(string createdAt) => WithTimeConstraint($"{DateConstants.DateCreated}{createdAt}");
    public void CreatedAt(DateTime created) => WithTimeConstraint($"{DateConstants.DateCreated}{created:yyyy-MM-dd}");
    public void CreatedToday() => WithTimeConstraint($"{DateConstants.DateCreated}{DateConstants.Today}");
    public void CreatedYesterday() => WithTimeConstraint($"{DateConstants.DateCreated}{DateConstants.Yesterday}");
    public void Accessed(string accessedAt) => WithTimeConstraint($"{DateConstants.DateAccessed}{accessedAt}");
    public void AccessedAt(DateTime created) => WithTimeConstraint($"{DateConstants.DateAccessed}{created:yyyy-MM-dd}");
    public void AccessedToday() => WithTimeConstraint($"{DateConstants.DateAccessed}{DateConstants.Today}");
    public void AccessedYesterday() => WithTimeConstraint($"{DateConstants.DateAccessed}{DateConstants.Yesterday}");
    public void Modified(string modifiedAt) => WithTimeConstraint($"{DateConstants.DateModified}{modifiedAt}");
    public void ModifiedAt(DateTime created) => WithTimeConstraint($"{DateConstants.DateModified}{created:yyyy-MM-dd}");
    public void ModifiedToday() => WithTimeConstraint($"{DateConstants.DateModified}{DateConstants.Today}");
    public void ModifiedYesterday() => WithTimeConstraint($"{DateConstants.DateModified}{DateConstants.Yesterday}");
  }

  public interface IQueryBuilder
  {
    ISizeConstraintBuilder AllFiles(string query = default);
    ISizeConstraintBuilder AllFolders(string query = default);
    ISizeConstraintBuilder Everything(string query = default);
    ISizeConstraintBuilder Executables(string query = default);
    ISizeConstraintBuilder CompressedFiles(string query = default);
    ISizeConstraintBuilder Pictures(string query = default);
    ISizeConstraintBuilder Documents(string query = default);
    ISizeConstraintBuilder Audio(string query = default);
  }

  public interface ISizeConstraintBuilder
  {
    ITimeConstraintBuilder OfAnySize();

    /// <summary>
    /// 0-10 KB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfTinySize();

    /// <summary>
    /// 10-100 KB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfSmallSize();

    /// <summary>
    /// 100KB - 1MB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfMediumSize();

    /// <summary>
    /// 1-16 MB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfLargeSize();

    /// <summary>
    /// 16-128 MB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfHugeSize();

    /// <summary>
    /// Larger than 128 MB
    /// </summary>
    /// <returns>The time contraint builder.</returns>
    ITimeConstraintBuilder OfGiganticSize();

    ITimeConstraintBuilder Sized(uint size, SizeUnit unit);
    ITimeConstraintBuilder LargerThan(uint size, SizeUnit unit);
    ITimeConstraintBuilder SmallerThan(uint size, SizeUnit unit);
  }

  public enum SizeUnit
  {
    Kb,
    Mb,
    Gb
  }

  public interface ITimeConstraintBuilder
  {
    ITimeConstraintBuilder WithTimeConstraint(string dateConstraint);
    void WithoutTimeConstraints();

    void Created(string createdAt);
    void CreatedAt(DateTime created);
    void CreatedToday();
    void CreatedYesterday();
    void Accessed(string accessedAt);
    void AccessedAt(DateTime created);
    void AccessedToday();
    void AccessedYesterday();
    void Modified(string modifiedAt);
    void ModifiedAt(DateTime created);
    void ModifiedToday();
    void ModifiedYesterday();
  }

  public enum DateSpan
  {
    Last,
    Past,
    Prev,
    Current,
    This,
    Coming,
    Next
  }

  public enum DateUnit
  {
    Year,
    Month,
    Week,

  }
}
