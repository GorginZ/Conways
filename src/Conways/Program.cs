namespace Conways
{
  class Program
  {
    static void Main(string[] args)
    {
      var userInput = new ConsoleInput();
      var controller = new ConsoleController();
      var renderer = new ConsoleRenderer();
      var dimensions = userInput.GetDimensions();
      var indexes = userInput.GetValidIndexes(dimensions);
      var rules = new LifeRules();
      var world = new World(dimensions.Item1, dimensions.Item2, indexes, rules);
      Simulation.Run(controller, renderer, world);
    }
  }
}
