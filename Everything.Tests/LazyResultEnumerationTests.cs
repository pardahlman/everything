using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Everything.Tests
{
  public class LazyResultEnumerationTests
  {
    [Fact]
    public async Task Should_Work_For_Single_Query()
    {
      /* Setup */
      var query = $"{nameof(LazyResultEnumerationTests)}.cs";
      var client = new EverythingClient();

      /* Test */
      var result = await client.SearchAsync(query);
      var firstMatch = result.Items.FirstOrDefault();

      /* Assert */
      Assert.NotNull(firstMatch);
    }
  }
}
