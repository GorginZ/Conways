using Xunit;
using System.Collections.Generic;
namespace Conways.Tests
{
  public class NeighbourHoodTests
  {

    [Fact]
    public void CanReturnIndexNeighbourhood()
    {
      var dimensions = (5, 5);
      var index = (0, 0);
      var neighbourHood = NeighbourHood.GetNeighbourhoodIndexes(index, dimensions);
      Assert.Equal(new List<(int,int)> { (0, 1), (0, 4), (4, 0), (1, 0), (4, 1), (4, 4), (1, 1), (1, 4)}, neighbourHood);
    }
  }
}