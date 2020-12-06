using System;
using System.Collections.Generic;

namespace Conways
{
  class Program
  {
    static void Main(string[] args)
    {
      var indexes = new HashSet<RowColumn>{new RowColumn(0,0), new RowColumn(0,1), new RowColumn(0,2)};
      var world = new World(10, 10, indexes);
      var renderer = new ConsoleRenderer();
      Simulation.Run(renderer, world);
    }
  }
}
