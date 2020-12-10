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
      Assert.True(indexes.SetEquals(new HashSet<(int, int)>((0, 0), (3, 3), (5, 5))));
    }
    [Fact]
    public void CanHandleTyposAndIgnoresThem()
    {

    }
    [Fact]
    public void WontParseDuplicatInputIndexes()
    {

    }
  }
}