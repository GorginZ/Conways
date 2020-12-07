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
      var grid = new World(3, 4, new HashSet<RowColumn>());
      Assert.Equal(3, grid.RowDimension);
      Assert.Equal(4, grid.ColumnDimension);
    }
    [Fact]
    public void CanSetCellsAlive()
    {
      var grid = new World(3, 4, new HashSet<RowColumn> { new RowColumn(0, 0) }
      );
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
    }
    [Fact]
    public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0) });
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
      grid.Tick();
      Assert.False(grid.IsLive(new RowColumn(0, 0)));
    }

    [Fact]
    public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0), new RowColumn(1, 1), new RowColumn(0, 2) });
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
      grid.Tick();
      Assert.False(grid.IsLive(new RowColumn(0, 0)));
    }
    [Fact]
    public void AnyLiveCellWithThreeLiveNeighboursLives()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0), new RowColumn(1, 1) });
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
      grid.Tick();
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
    }
    [Fact]
    public void AnyLiveCellWithTwoLiveNeighboursLives()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0) });
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
      grid.Tick();
      Assert.True(grid.IsLive(new RowColumn(0, 0)));
    }

    [Fact]
    public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesALiveCell()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0) });
      Assert.False(grid.IsLive(new RowColumn(1, 1)));
      grid.Tick();
      Assert.True(grid.IsLive(new RowColumn(1, 1)));
    }
  }
}
