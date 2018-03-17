using System.IO;
using System.Text;
using System.Threading;

namespace Everything
{
  public class ItemGenerator
  {
    public SearchItem Generate(uint replyId, uint index, CancellationToken ct)
    {
      using (IpcCallerLock.Aquire(ct))
      {
        IpcWrapper.ReplyId = replyId;
        return Generate(index);
      }
    }

    public SearchItem Generate(uint index)
    {
      var pathBuilder = new StringBuilder(260);
      IpcWrapper.GetResultFullPath(index, pathBuilder, 260);
      var fullPath = pathBuilder.ToString();

      var item = new SearchItem
      {
        FileName = File.Exists(fullPath) ? Path.GetFileName(fullPath) : string.Empty,
        Path = File.Exists(fullPath) ? Path.GetDirectoryName(fullPath) : fullPath,
        Type = GetResultType(index)
      };

      return item;
    }

    private static ResultType GetResultType(uint index)
    {
      if (IpcWrapper.IsFileResult(index))
      {
        return ResultType.File;
      }
      if (IpcWrapper.IsFolderResult(index))
      {
        return ResultType.Directory;
      }
      if (IpcWrapper.IsVolumeResult(index))
      {
        return ResultType.Volume;
      }
      return ResultType.Unknown;
    }
  }

  public enum ResultType
  {
    Unknown,
    File,
    Directory,
    Volume
  }
}
