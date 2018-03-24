using System.Diagnostics;
using System.IO;

namespace Everything.Model
{
  [DebuggerDisplay("File: {" + nameof(Name) + "}")]
  public sealed class FileResultItem : ResultItem
  {
    public string Extension { get; set; }
    public FileAttributes Attributes { get; set; }
    public uint RunCount { get; set; }
    public override ResultType Type => ResultType.File;
    public long Size { get; set; }
  }
}
