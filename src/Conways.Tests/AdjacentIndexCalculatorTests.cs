using Xunit;
using System.Collections.Generic;
namespace Conways.Tests
{
  public class AdjacentIndexCalculatorTests
  {
    [Fact]
    public void CanReturnIndexNeighbourhoodCorner()
    {
      var dimensions = (5, 5);
      var index = (0, 0);
      var neighbourhood = AdjacentIndexCalculator.GetAdjacentIndexes(index, dimensions);
      var expectedNeighbours = new HashSet<(int, int)> { (0, 1), (0, 4), (4, 0), (1, 0), (4, 1), (4, 4), (1, 1), (1, 4) };

      Assert.True(expectedNeighbours.SetEquals(neighbourhood));
    }

    [Fact]
    public void CanReturnIndexNeighbourhoodWrapped()
    {
      var index = (4, 1);
      var neighbourhood = AdjacentIndexCalculator.GetAdjacentIndexes(index, (5, 5));
      var expectedNeighbours = new HashSet<(int, int)> { (3, 1), (3, 2), (4, 2), (0, 2), (0, 1), (0, 0), (4, 0), (3, 0) };
      Assert.True(expectedNeighbours.SetEquals(neighbourhood));
    }
  }
}