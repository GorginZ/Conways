using Xunit;
using System.Collections.Generic;
namespace Conways.Tests
{
  public class NeighbourHoodTests
  {
    [Fact]
    public void CanReturnIndexNeighbourhood()
    {
      var neighbourHood = NeighbourHood.GetNeighbourIndexes(0, 0, 5, 5);
      var expectedNeighbours = new HashSet<RowColumn> { new RowColumn(0, 1), new RowColumn(0, 4), new RowColumn(4, 0), new RowColumn(1, 0), new RowColumn(4, 1), new RowColumn(4, 4), new RowColumn(1, 1), new RowColumn(1, 4) };
      Assert.True(expectedNeighbours.SetEquals(neighbourHood));
    }
  }
}