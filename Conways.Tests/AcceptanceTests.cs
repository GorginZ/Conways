using Xunit;
using System.Collections.Generic;
namespace Conways.Tests
{
  public class AcceptanceTests
  {
    [Fact]
    public void Wraps()
    {
      var world = new World(5, 5, new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2) });
      var expectedFirstIteration = "XXX  \n"
                                 + "     \n"
                                 + "     \n"
                                 + "     \n"
                                 + "     \n";

      Assert.Equal(expectedFirstIteration, ConsoleRenderer.GridAsString(world.GridClone()));

      world.Tick();

      var expectedSecondIteration = " X   \n"
                                 + " X   \n"
                                 + "     \n"
                                 + "     \n"
                                 + " X   \n";
      Assert.True(world.IsLive(new RowColumn(4, 1)));


      Assert.Equal(expectedSecondIteration, ConsoleRenderer.GridAsString(world.GridClone()));

      world.Tick();

      Assert.Equal(expectedFirstIteration, ConsoleRenderer.GridAsString(world.GridClone()));
    }

    [Fact]
    public void CanProduceBlinkerWhenNotOnEdgeOfGrid()
    {
      var world = new World(5, 5, new HashSet<RowColumn> { new RowColumn(1, 2), new RowColumn(2, 2), new RowColumn(3, 2) });
      var expectedFirstIteration = "     \n"
                                 + "  X  \n"
                                 + "  X  \n"
                                 + "  X  \n"
                                 + "     \n";

      Assert.Equal(expectedFirstIteration, ConsoleRenderer.GridAsString(world.GridClone()));

      world.Tick();

      var expectedSecondIteration = "     \n"
                                 + "     \n"
                                 + " XXX \n"
                                 + "     \n"
                                 + "     \n";

      Assert.Equal(expectedSecondIteration, ConsoleRenderer.GridAsString(world.GridClone()));

      world.Tick();

      Assert.Equal(expectedFirstIteration, ConsoleRenderer.GridAsString(world.GridClone()));
    }
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
      Assert.Equal(expectedFirstIteration, ConsoleRenderer.GridAsString(world.GridClone()));
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
      Assert.Equal(expectedSecondIteration, ConsoleRenderer.GridAsString(world.GridClone()));
      world.Tick();
      var expectedThirdIteration = "          \n"
                                  + "X X       \n"
                                  + " XX       \n"
                                  + " X        \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n";
      Assert.Equal(expectedThirdIteration, ConsoleRenderer.GridAsString(world.GridClone()));
      world.Tick();
      var expectedFourthIteration = "          \n"
                                  + "  X       \n"
                                  + "X X       \n"
                                  + " XX       \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n";
      Assert.Equal(expectedFourthIteration, ConsoleRenderer.GridAsString(world.GridClone()));

      world.Tick();
      var expectedFifthIteration = "          \n"
                                  + " X        \n"
                                  + "  XX      \n"
                                  + " XX       \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n"
                                  + "          \n";
      Assert.Equal(expectedFifthIteration, ConsoleRenderer.GridAsString(world.GridClone()));
    }
  }
}