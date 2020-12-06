using System;
using System.Collections.Generic;

namespace Conways
{
  class Program
  {
    static void Main(string[] args)
    {
      var indexes = new HashSet<RowColumn>{new RowColumn(3,3), new RowColumn(3,4), new RowColumn(3,5)};
      var world = new World(10, 10, indexes);
      var renderer = new ConsoleRenderer();
      Simulation.Run(renderer, world);
    }
  }
}
