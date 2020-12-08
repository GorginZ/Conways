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
      var neighbourHood = NeighbourHood.GetNeighbourIndexes(index, dimensions);
      var expectedNeighbours = new HashSet<(int, int)> { (0, 1), (0, 4), (4, 0), (1, 0), (4, 1), (4, 4), (1, 1), (1, 4) };

      Assert.True(expectedNeighbours.SetEquals(neighbourHood));
    }
    [Fact]
    public void CanReturnIndexNeighbourhoodWrap()
    {
      var index = (4,1);
      var neighbourHood = NeighbourHood.GetNeighbourIndexes(index, (5, 5));
      var expectedNeighbours = new HashSet<(int,int)> { (3, 1),(3, 2), (4, 2),(0,2),(0, 1), (0, 0),(4, 0), (3, 0) };
      Assert.True(expectedNeighbours.SetEquals(neighbourHood));
    }
    // [Fact]
    // public void CanReturnIndexNeighbourhood()
    // {
    //   var index = new RowColumn(0,0);
    //   var neighbourHood = NeighbourHood.GetNeighbourIndexes(index, 5, 5);
    //   var expectedNeighbours = new HashSet<RowColumn> { new RowColumn(0, 1), new RowColumn(0, 4), new RowColumn(4, 0), new RowColumn(1, 0), new RowColumn(4, 1), new RowColumn(4, 4), new RowColumn(1, 1), new RowColumn(1, 4) };
    //   Assert.True(expectedNeighbours.SetEquals(neighbourHood));
    // }
    // [Fact]
    // public void CanReturnIndexNeighbourhoodWrap()
    // {
    //   var index = new RowColumn(4,1);
    //   var neighbourHood = NeighbourHood.GetNeighbourIndexes(index, 5, 5);
    //   var expectedNeighbours = new HashSet<RowColumn> { new RowColumn(3, 1), new RowColumn(3, 2), new RowColumn(4, 2), new RowColumn(0,2), new RowColumn(0, 1), new RowColumn(0, 0), new RowColumn(4, 0), new RowColumn(3, 0) };
    //   Assert.True(expectedNeighbours.SetEquals(neighbourHood));
    // }

  }
}