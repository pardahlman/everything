using System.Diagnostics;

namespace Everything.Model
{
  [DebuggerDisplay("Directory: {" + nameof(Name) + "}")]
  public sealed class DirectoryResultItem : ResultItem
  {
    public override ResultType Type => ResultType.Directory;
  }
}