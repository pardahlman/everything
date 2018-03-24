using System;

namespace Everything.Model
{
  public abstract class ResultItem
  {
    public abstract ResultType Type { get; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public DateTime Accessed { get; set; }
    public string Name { get; set; }
    public string FullPath { get; set; }
  }
}