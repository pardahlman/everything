using System;
using System.Runtime.InteropServices;
using Everything.LowLevel;
using Xunit;

namespace Everything.Tests
{
  public class LowLevelSdkTests
  {
    [Fact]
    public void Should_Be_Able_To_Get_And_Set_Query()
    {
      /* Setup */
      var query = Guid.NewGuid().ToString();

      /* Test */
      LowLevelSdk.Everything_SetSearch(query);
      var retrieved = LowLevelSdk.Everything_GetSearch();

      /* Assert */
      Assert.Equal(query, retrieved);
    }

    [Fact]
    public void Should_Be_Able_To_Get_Machine()
    {
      /* Setup */
      var expected = new[]
      {
        TargetMachine.EVERYTHING_TARGET_MACHINE_ARM,
        TargetMachine.EVERYTHING_TARGET_MACHINE_X64,
        TargetMachine.EVERYTHING_TARGET_MACHINE_X86
      };

      /* Test */
      var machine = LowLevelSdk.Everything_GetTargetMachine();
      
      /* Assert */
      Assert.Contains(machine, expected);
    }
  }
}
