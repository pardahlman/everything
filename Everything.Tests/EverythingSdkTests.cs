using System;
using Everything.LowLevel.SyntacticSugar;
using Xunit;

namespace Everything.Tests
{
  public class EverythingSdkTests
  {
    [Fact]
    public void Should_Be_Able_To_Set_Search()
    {
      /* Setup */
      var query = Guid.NewGuid().ToString();

      /* Test */
      EverythingSdk.Search = query;
      var retrieved = EverythingSdk.Search;

      /* Assert */
      Assert.Equal(query, retrieved);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_Be_Able_To_Match_Path(bool matchPath)
    {
      /* Setup */
      EverythingSdk.MatchPath = matchPath;

      /* Test */
      var retrieved = EverythingSdk.MatchPath;

      /* Assert */
      Assert.Equal(matchPath, retrieved);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_Be_Able_To_Match_Whole_Word(bool matchWholeWord)
    {
      /* Setup */
      EverythingSdk.MatchWholeWord = matchWholeWord;

      /* Test */
      var retrieved = EverythingSdk.MatchWholeWord;

      /* Assert */
      Assert.Equal(matchWholeWord, retrieved);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_Be_Able_To_Match_Case(bool matchCase)
    {
      /* Setup */
      EverythingSdk.MatchCase = matchCase;

      /* Test */
      var retrieved = EverythingSdk.MatchCase;

      /* Assert */
      Assert.Equal(matchCase, retrieved);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_Be_Able_To_Enable_Regex(bool regex)
    {
      /* Setup */
      EverythingSdk.Regex = regex;

      /* Test */
      var retrieved = EverythingSdk.Regex;

      /* Assert */
      Assert.Equal(regex, retrieved);
    }

    [Fact]
    public void Should_Be_Able_To_Set_Max()
    {
      /* Setup */
      EverythingSdk.Max = 123u;
      const uint newValue = 321u;

      /* Test */
      EverythingSdk.Max = newValue;
      var retrieved = EverythingSdk.Max;

      /* Assert */
      Assert.Equal(newValue, retrieved);
    }

    [Fact]
    public void Should_Be_Able_To_Set_Offset()
    {
      /* Setup */
      EverythingSdk.Offset = 123u;
      const uint newValue = 321u;

      /* Test */
      EverythingSdk.Offset = newValue;
      var retrieved = EverythingSdk.Offset;

      /* Assert */
      Assert.Equal(newValue, retrieved);
    }

    [Fact]
    public void Should_Be_Able_To_Get_Version()
    {
      /* Setup */
      /* Test */
      var version = EverythingSdk.Version;

      /* Assert */
      Assert.True(version.Major > 0);
    }
  }
}
