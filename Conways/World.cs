using System;
using System.Collections.Generic;
using System.Linq;

namespace Conways
{
  public class World
  {
    private CellState[,] _grid;
    public int RowDimension => _grid.GetLength(0);
    public int ColumnDimension => _grid.GetLength(1);
    public World(int rowDimension, int colDimension)
    {
      _grid = new CellState[rowDimension, colDimension];
    }
    public CellState[,] GridClone() => _grid.Clone() as CellState[,];
    public void SetMany(IEnumerable<(int, int)> indexes, CellState value)
    {
      foreach ((int, int) index in indexes)
        _grid[index.Item1, index.Item2] = value;
    }
    public bool IsLive((int, int) index) => _grid[index.Item1, index.Item2].Equals(CellState.Alive);
    public void Tick()
    {
      var toAlive = CellsToAlive();
      SetMany(toAlive, CellState.Alive);

    }
    public IEnumerable<(int, int)> CellsToAlive()
    {
      var toAlive = new HashSet<(int, int)>();

      for (int i = 0; i < this.RowDimension; i++)
      {
        for (int j = 0; i < this.ColumnDimension; j++)
        {
          int liveCount = NeighbourHood.GetNeighbourhoodIndexes((i, j), (this.RowDimension, this.ColumnDimension)).Where(IsLive).Count();

          if (IsLive((i, j)) && liveCount == 2 || liveCount == 3)
          {
            toAlive.Append((i, j));
          }
          if (liveCount == 3)
          {
            toAlive.Add((i, j));
          }
        }
      }
      return toAlive;
    }
  }
}