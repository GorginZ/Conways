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
    public World(int rowDimension, int colDimension, IEnumerable<(int,int)> startingState)
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
    private void SetMany(IEnumerable<(int,int)> indexes, CellState value)
    {
      foreach ((int Row,int Column) index in indexes)
        _grid[index.Column, index.Column] = value;
    }
    public bool IsLive((int Row, int Column) index) => _grid[index.Row, index.Column].Equals(CellState.Alive);
    private IEnumerable<(int,int)> CellsToAlive()
    {
      var toAlive = new HashSet<(int,int)>();
      for (int i = 0; i < RowDimension; i++)
      {
        for (int j = 0; j < ColumnDimension; j++)
        {
          int liveCount = NeighbourHood.GetNeighbourIndexes((i,j), (this.RowDimension, this.ColumnDimension)).Where(IsLive).Count();
          if (liveCount == 3 || IsLive((i,j)) && liveCount == 2)
          {
            toAlive.Add((i,j));
          }
        }
      }
      return toAlive;
    }
  }
}