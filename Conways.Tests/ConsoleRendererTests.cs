using System;
using Xunit;

namespace Conways.Tests
{
  public class ConsoleRendererTests
  {
    [Fact]
    public void CanVisualizeGrid()
    {
      var grid = new CellState[,] { { CellState.Dead, CellState.Alive }, { CellState.Dead, CellState.Alive } };
      var expectedGrid = " X\n"
                  + " X\n";
      Assert.Equal(expectedGrid, ConsoleRenderer.VisualizeGridInConsole(grid));

    }
  }
}