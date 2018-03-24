using Everything.LowLevel.SyntacticSugar;

namespace Everything.Status
{
  internal class StatusService
  {
    public EverythingStatus GetStatus()
    {
      return new EverythingStatus
      {
        Version = EverythingSdk.Version,
        LastError = EverythingSdk.LastError,
        IsRunning = EverythingSdk.Version.Major != 0,
        TargetMachine = EverythingSdk.TargetMachine,
        IsAdmin = EverythingSdk.IsAdmin
      };
    }
  }
}
