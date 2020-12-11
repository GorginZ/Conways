using System.Collections.Generic;
using Xunit;
namespace Conways.Tests
{
  public class InputParserTests
  {
    [Fact]
    public void CanParseValidInput()
    {
      var input = "0,0 3,3 5,5";
      var dimensions = (6, 6);
      var indexes = InputParser.ParseInputToValidIndexes(input, dimensions);
      Assert.True(indexes.SetEquals(new HashSet<(int, int)>{(0, 0), (3, 3), (5, 5)}));
    }

    [Fact]
    public void CanHandleTyposAndIgnoresThem()
    {
      var input = "0dfjak,lsjf 0,0 ldkfjiii4388 44,43 3,3 5,5";
      var dimensions = (6, 6);
      var indexes = InputParser.ParseInputToValidIndexes(input, dimensions);
      Assert.True(indexes.SetEquals(new HashSet<(int, int)>{(0, 0), (3, 3), (5, 5)}));
    }

    [Fact]
    public void WontParseDuplicateInputIndexes()
    {
      var input = "0,0 0,0 0,0 3,3 3,3 3,3 2,2 2,2 2,2 2,2 2,2";
      var dimensions = (6, 6);
      var indexes = InputParser.ParseInputToValidIndexes(input, dimensions);
      Assert.Equal(3, indexes.Count);
    }

    [Fact]
    public void WillOnlyParseInRangeIndexes()
    {
      var input = "0,0 4,5 2,2 3,3 6,6";
      var dimensions = (6, 6);
      var indexes = InputParser.ParseInputToValidIndexes(input, dimensions);
      Assert.True(indexes.SetEquals(new HashSet<(int, int)>{(0, 0), (4, 5), (2, 2), (3,3)}));
    }
  }
}