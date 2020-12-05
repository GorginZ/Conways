using System.Collections.Generic;
using Xunit;
namespace Conways.Tests
{
  public class IntegrationTests
  {
    [Fact]
    public void CanVisualizeCurrentCopyOfGrid()
    {
      var grid = new World<CellState>(4, 5);
      var expectedGrid = "     \n"
                       + "     \n"
                       + "     \n"
                       + "     \n";
      Assert.Equal(expectedGrid, ConsoleRenderer.VisualizeGridInConsole(grid.GridClone()));
    }
    [Fact]
    public void CanSetAnInitialState()
    {
      var grid = new World<CellState>(3, 4);
      grid.SetMany(new HashSet<(int, int)> { (0, 0), (0, 1), (0, 2) }, CellState.Alive);
      var expectedGrid = "XXX \n"
                       + "    \n"
                       + "    \n";
      Assert.Equal(expectedGrid, ConsoleRenderer.VisualizeGridInConsole(grid.GridClone()));
    }
    [Fact]
    public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
    {
      var grid = new World<CellState>(3, 3);
      grid.SetMany(new HashSet<(int, int)> { (0, 0), (0, 1), (2, 2) }, CellState.Alive);
      var expectedInitialGrid = "XX \n"
                       + "   \n"
                       + "  X\n";
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.VisualizeGridInConsole(grid.GridClone()));

      grid.Tick();

      var expectedPostTickGrid = "   \n"
                       + "   \n"
                       + "   \n";
      Assert.Equal(expectedPostTickGrid, ConsoleRenderer.VisualizeGridInConsole(grid.GridClone()));


    }

  }
}