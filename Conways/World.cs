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

    public World(int rowDimension, int colDimension, ISet<(int, int)> startingState)
    {
      _grid = new CellState[rowDimension, colDimension];
      SetMany(startingState, CellState.Alive);
    }

    public void Tick()
    {
      var toAlive = GetCellsToMakeLiveNextIteration();
      _grid = new CellState[RowDimension, ColumnDimension];
      SetMany(toAlive, CellState.Alive);
    }

    public CellState[,] CloneGrid() => _grid.Clone() as CellState[,];

    private void SetMany(ISet<(int, int)> indexes, CellState value)
    {
      foreach (var (row, column) in indexes)
        _grid[row, column] = value;
    }

    public bool IsLive((int Row, int Column) index) => _grid[index.Row, index.Column].Equals(CellState.Alive);

    private ISet<(int, int)> GetCellsToMakeLiveNextIteration()
    {
      var cellsToMakeLive = new HashSet<(int, int)>();
      for (int row = 0; row < RowDimension; row++)
      {
        for (int col = 0; col < ColumnDimension; col++)
        {
          var liveCount = GetNumberOfLiveNeighboursForThisCell(row, col);
          if (liveCount == 3 || (IsLive((row, col)) && liveCount == 2))
          {
            cellsToMakeLive.Add((row, col));
          }
        }
      }
      return cellsToMakeLive;
    }

    private int GetNumberOfLiveNeighboursForThisCell(int row, int col) => AdjacentIndexCalculator.GetAdjacentIndexes((row, col), (RowDimension, ColumnDimension)).Count(IsLive);
  }
}