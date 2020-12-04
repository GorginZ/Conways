using System;
using System.Collections.Generic;
using Xunit;

namespace Conways.Tests
{
  public class GridTests
  {
    [Fact]
    public void GridIsOfSpecifiedDimensions()
    {
      var grid = new Grid<CellState>(3, 4);
      Assert.Equal(3, grid.RowDimension);
      Assert.Equal(4, grid.ColumnDimension);
    }
    [Fact]
    public void CanSetCellsAlive()
    {
      var grid = new Grid<CellState>(3, 4);
      Assert.False(grid.IsLive(new RowColumn(0, 0)));
      grid.SetMany(new HashSet<RowColumn> { new RowColumn(0, 0) }, CellState.Alive);
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
    }
  }
}
