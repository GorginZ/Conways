using System;
using System.Collections.Generic;

namespace Conways
{
  class Program
  {
    static void Main(string[] args)
    {
      var userInput = new ConsoleInput();
      var dimensions = userInput.GetDimensions();
      var indexes = userInput.GetStartingState(dimensions);
      var world = new World(dimensions.Item1, dimensions.Item2, indexes);
      var renderer = new ConsoleRenderer();
      Simulation.Run(renderer, world);
    }
  }
}
