namespace Everything
{
  public interface IReplyIdGenerator
  {
    uint Next();
  }

  public class ReplyIdGenerator : IReplyIdGenerator
  {
    private uint _current;
    private readonly object _lock;

    public ReplyIdGenerator()
    {
      _current = 0;
      _lock = new object();
    }

    public uint Next()
    {
      lock (_lock)
      {
        _current++;
        return _current;
      }
    }
  }
}
