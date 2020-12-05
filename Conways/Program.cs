using System;
using System.Collections.Generic;

namespace Conways
{
  class Program
  {
    static void Main(string[] args)
    {
      var indexes = new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(1, 2), new RowColumn(2, 0), new RowColumn(2, 1), new RowColumn(2, 2), new RowColumn(3, 4), new RowColumn(4, 5), new RowColumn(5, 3), new RowColumn(5, 4), new RowColumn(5, 5) };
      var world = new World(10, 10, indexes);
      var renderer = new ConsoleRenderer();
      Simulation.Run(renderer, world);
    }
  }
}
