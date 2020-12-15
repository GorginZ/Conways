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
      var world = new World(3, 4, new HashSet<(int, int)>());

      Assert.Equal(3, world.RowDimension);
      Assert.Equal(4, world.ColumnDimension);
    }

    [Fact]
    public void CanSetCellsAlive()
    {
      var world = new World(3, 4, new HashSet<(int, int)> { (0, 0) });
      Assert.True(world.IsLive((0, 0)));
    }

    [Fact]
    public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
    {
      var world = new World(3, 3, new HashSet<(int, int)> { (0, 0) });

      Assert.True(world.IsLive((0, 0)));

      world.Tick();

      Assert.False(world.IsLive((0, 0)));
    }

    [Fact]
    public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies()
    {
      var world = new World(3, 3, new HashSet<(int, int)> { (0, 0), (0, 1), (1, 0), (1, 1), (0, 2) });

      Assert.True(world.IsLive((0, 0)));

      world.Tick();

      Assert.False(world.IsLive((0, 0)));
    }

    [Fact]
    public void AnyLiveCellWithThreeLiveNeighboursLives()
    {
      var world = new World(3, 3, new HashSet<(int, int)> { (0, 0), (0, 1), (1, 0), (1, 1) });

      Assert.True(world.IsLive((0, 0)));

      world.Tick();

      Assert.True(world.IsLive((0, 0)));
    }

    [Fact]
    public void AnyLiveCellWithTwoLiveNeighboursLives()
    {
      var world = new World(3, 3, new HashSet<(int, int)> { new(0, 0),(0, 1),(1, 0) });

      Assert.True(world.IsLive((0, 0)));

      world.Tick();

      Assert.True(world.IsLive((0, 0)));
    }

    [Fact]
    public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesALiveCell()
    {
      var world = new World(3, 3, new HashSet<(int, int)> { (0, 0), (0, 1), (1, 0) });

      Assert.False(world.IsLive((1, 1)));

      world.Tick();

      Assert.True(world.IsLive((1, 1)));
    }
  }
}
