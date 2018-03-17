using System;
using System.Threading;
using System.Threading.Tasks;

namespace Everything
{
  public class IpcCallerLock
  {
    private static readonly SemaphoreSlim IpcSemaphore = new SemaphoreSlim(1,1);

    public static IDisposable Aquire(CancellationToken ct)
    {
      IpcSemaphore.Wait(ct);
      return new ReleaseOnDispose(IpcSemaphore);
    }

    public static async Task<IDisposable> AquireAsync(CancellationToken ct)
    {
      await IpcSemaphore.WaitAsync(ct);
      return new ReleaseOnDispose(IpcSemaphore);
    }

    private class ReleaseOnDispose : IDisposable
    {
      private readonly SemaphoreSlim _semaphoreSlim;

      public ReleaseOnDispose(SemaphoreSlim semaphoreSlim)
      {
        _semaphoreSlim = semaphoreSlim;
      }

      public void Dispose()
      {
        _semaphoreSlim.Release();
      }
    }
  }
}
