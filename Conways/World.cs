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
    public CellState[,] GridClone()
    {
      return _grid.Clone() as CellState[,];
    }
    public void SetMany(IEnumerable<RowColumn> indexes, CellState value)
    {
      foreach (RowColumn index in indexes)
        _grid[index.Row, index.Column] = value;
    }
    public bool IsLive(RowColumn index) => _grid[index.Row, index.Column].Equals(Conways.CellState.Alive);

  }
}