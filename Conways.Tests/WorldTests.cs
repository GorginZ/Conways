using System;
using System.Collections.Generic;
using Xunit;

namespace Conways.Tests
{
  public class WorldTests
  {
    [Fact]
    public void GridIsOfSpecifiedDimensions()
    {
      var grid = new World<CellState>(3, 4);
      Assert.Equal(3, grid.RowDimension);
      Assert.Equal(4, grid.ColumnDimension);
    }
    [Fact]
    public void CanSetCellsAlive()
    {
      var grid = new World<CellState>(3, 4);
      Assert.False(grid.IsLive((0, 0)));
      grid.SetMany(new HashSet<(int, int)> { (0, 0) }, CellState.Alive);
      Assert.True(grid.IsLive((0, 0)));
    }
  }
}