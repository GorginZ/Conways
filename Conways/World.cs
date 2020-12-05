using System;
using System.Collections.Generic;
using System.Linq;

namespace Conways
{
  public class World<CellState>
  {
    private CellState[,] _grid;
    public int RowDimension => _grid.GetLength(0);
    public int ColumnDimension => _grid.GetLength(1);
    public World(int rowDimension, int colDimension)
    {
      _grid = new CellState[rowDimension, colDimension];
    }
    public CellState[,] GridClone() => _grid.Clone() as CellState[,];
    public void SetMany(IEnumerable<(int,int)> indexes, CellState value)
    {
      foreach ((int,int) index in indexes)
        _grid[index.Item1, index.Item2] = value;
    }
    public bool IsLive((int,int) index) => _grid[index.Item1, index.Item2].Equals(Conways.CellState.Alive);
    public void Tick()
    {

    }
  }
}