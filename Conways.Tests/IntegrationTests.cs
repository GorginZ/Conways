using System.Collections.Generic;
using Xunit;
namespace Conways.Tests
{
  public class IntegrationTests
  {
    [Fact]
    public void CanVisualizeCurrentCopyOfGrid()
    {
      var grid = new World(4, 5, new HashSet<RowColumn>());
      var expectedGrid = "     \n"
                       + "     \n"
                       + "     \n"
                       + "     \n";
      Assert.Equal(expectedGrid, ConsoleRenderer.GridAsString(grid.GridClone()));
    }
    [Fact]
    public void CanSetAnInitialState()
    {
      var grid = new World(3, 4, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2) });
      var expectedGrid = "XXX \n"
                       + "    \n"
                       + "    \n";
      Assert.Equal(expectedGrid, ConsoleRenderer.GridAsString(grid.GridClone()));
    }
    [Fact]
    public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(2, 2) });
      var expectedInitialGrid = "   \n"
                       + "   \n"
                       + "  X\n";
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.GridAsString(grid.GridClone()));

      grid.Tick();

      var expectedPostTickGrid = "   \n"
                       + "   \n"
                       + "   \n";
      Assert.Equal(expectedPostTickGrid, ConsoleRenderer.GridAsString(grid.GridClone()));

    }

    [Fact]
    public void VisualAnyLiveCellWithMoreThanThreeLiveNeighboursDies()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0), new RowColumn(1, 1), new RowColumn(0, 2) });
      var expectedInitialGrid = "XXX\n"
                             + "XX \n"
                             + "   \n";
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.GridAsString(grid.GridClone()));
      grid.Tick();
      var expectedSecondIteration = "   \n"
                                  + "   \n"
                                   + "   \n";

      Assert.Equal(expectedSecondIteration, ConsoleRenderer.GridAsString(grid.GridClone()));

    }
    [Fact]
    public void VisualAnyLiveCellWithThreeLiveNeighboursLives()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0), new RowColumn(1, 1) });
      var expectedInitialGrid = "XX \n"
                              + "XX \n"
                              + "   \n";
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.GridAsString(grid.GridClone()));
      grid.Tick();
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.GridAsString(grid.GridClone()));

    }
    [Fact]
    public void VisualAnyLiveCellWithTwoLiveNeighboursLivesAndADeadCellWithExactlyThreeLiveNeighboursBecomesLiveWithWrapping()
    {
      var grid = new World(3, 3, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(1, 0) });
      var expectedInitialGrid = "XX \n"
                              + "X  \n"
                              + "   \n";
      Assert.Equal(expectedInitialGrid, ConsoleRenderer.GridAsString(grid.GridClone()));
      grid.Tick();
      var expectedSecondIteration = "XXX\n"
                              + "XXX\n"
                              + "XXX\n";
      Assert.Equal(expectedSecondIteration, ConsoleRenderer.GridAsString(grid.GridClone()));
    }

  }
}