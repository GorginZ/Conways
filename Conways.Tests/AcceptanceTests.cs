using Xunit;
using System.Collections.Generic;
namespace Conways.Tests
{
  public class AcceptanceTests
  {
    [Fact]
    public void ReproducesGlider()
    {
      var world = new World(10, 10, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(1, 1), new RowColumn(1, 2), new RowColumn(2, 0), new RowColumn(2, 1) });
      var expectedFirstIteration = "X         \n"
              + " XX       \n"
              + "XX        \n"
              + "          \n"
              + "          \n"
              + "          \n"
              + "          \n"
              + "          \n"
              + "          \n"
              + "          \n";
      Assert.Equal(expectedFirstIteration, ConsoleRenderer.VisualizeGridInConsole(world.GridClone()));
      world.Tick();
      var expectedSecondIteration = " X        \n"
                                  + "  X       \n"
                                  + "XXX       \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n";
              Assert.Equal(expectedSecondIteration, ConsoleRenderer.VisualizeGridInConsole(world.GridClone()));

    }
  }
}