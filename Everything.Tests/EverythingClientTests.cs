using System;
using System.Linq;
using System.Threading.Tasks;
using Everything.LowLevel.SyntacticSugar;
using Everything.Model;
using Everything.Search;
using Xunit;

namespace Everything.Tests
{
  public class EverythingClientTests
  {
    [Fact]
    public async Task Should_Work_For_Single_Query()
    {
      /* Setup */
      var query = $"spotify.exe";
      var query2 = $"{nameof(EverythingClientTests)}.cs";
      var client = new EverythingClient();

      /* Test */
      var result = await client.SearchAsync(query);
      var firstMatch = result.Items.FirstOrDefault();

      /* Assert */
      Assert.NotNull(firstMatch);
    }

    [Fact]
    public async Task Should_Be_Able_To_Sort()
    {
      /* Setup */
      var client = new EverythingClient();
      var query = "folder:Everything";

      /* Test */
      var result = await client.SearchAsync(query, new SearchOptions
      {
        Sort = Sort.DateModifiedAscending,
        RequestFlags = RequestFlags.DateModified
      });

      /* Assert */
      Assert.True(true);
    }

    [Fact]
    public void Should_Be_Able_To_Retrieve_Status()
    {
      /* Setup */
      var client = new EverythingClient();

      /* Test */
      var status = client.GetStatus();

      /* Assert */
      Assert.True(status.IsRunning);
    }

    [Fact]
    public async Task Should_Be_Able_To_Search_With_Query_Builder()
    {
      /* Setup */
      var client = new EverythingClient();

      /* Test */
      var result = await client.SearchAsync(q => q
        .Executables("everything")
        .OfLargeSize()
        .Modified("2018"));

      /* Assert */
      Assert.NotEmpty(result.Items);
    }

    [Fact]
    public async Task Should_Throw_If_Multiple_Query_Ongoing()
    {
      /* Setup */
      var client = new EverythingClient();
      var firstResult = await client.SearchAsync(nameof(EverythingClientTests));
      var firstItem = firstResult.Items.First();

      /* Test */
      var secondResult = await client.SearchAsync(nameof(EverythingClient));

      /* Assert */
      Assert.NotNull(firstResult);
      Assert.Throws<InvalidOperationException>(() => firstResult.Items.First());
    }
  }
}
