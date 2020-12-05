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
    public World(int rowDimension, int colDimension, IEnumerable<RowColumn> startingState)
    {
      _grid = new CellState[rowDimension, colDimension];
      SetMany(startingState, CellState.Alive);
    }
    public void Tick()
    {
      var toAlive = CellsToAlive();
      _grid = new CellState[RowDimension, ColumnDimension];
      SetMany(toAlive, CellState.Alive);
    }
    public CellState[,] GridClone() => _grid.Clone() as CellState[,];
    private void SetMany(IEnumerable<RowColumn> indexes, CellState value)
    {
      foreach (RowColumn index in indexes)
        _grid[index.Row, index.Column] = value;
    }
    public bool IsLive(RowColumn index) => _grid[index.Row, index.Column].Equals(CellState.Alive);
    private IEnumerable<RowColumn> CellsToAlive()
    {
      var toAlive = new HashSet<RowColumn>();

      for (int i = 0; i < (RowDimension -1); i++)
      {
        for (int j = 0; j < (ColumnDimension -1); j++)
        {
          int liveCount = NeighbourHood.GetNeighbourIndexes(i, j, this.RowDimension, this.ColumnDimension).Where(IsLive).Count();

          var thisCell = new RowColumn(i, j);

          if (IsLive(thisCell) && liveCount == 2 || liveCount == 3)
          {
            toAlive.Add(thisCell);
          }
          if (liveCount == 3)
          {
            toAlive.Add(thisCell);
          }
        }
      }
      return toAlive;
    }
  }
}