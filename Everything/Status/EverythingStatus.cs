using System;
using Everything.LowLevel.SyntacticSugar;

namespace Everything.Status
{
  public class EverythingStatus
  {
    public Version Version { get; set; }
    public Error LastError { get; set; }
    public bool IsRunning { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsDatabaseLoaded { get; set; }
    public TargetMachine TargetMachine { get; set; }
  }
}
