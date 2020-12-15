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
        for (int column = 0; column < ColumnDimension; column++)
        {
          var indexOfCell = (row, column);
          if (CellShouldBeMadeLive(indexOfCell))
          {
            cellsToMakeLive.Add((row, column));
          }
        }
      }
      return cellsToMakeLive;
    }
    private bool CellShouldBeMadeLive((int row, int column) indexOfCell)
    {
      var numberOfLiveNeighbours = GetNumberOfLiveNeighboursForThisCell(indexOfCell);
      return numberOfLiveNeighbours == 3 || (IsLive(indexOfCell) && numberOfLiveNeighbours == 2);
    }
    private int GetNumberOfLiveNeighboursForThisCell((int row, int column) indexOfCell) => GetAdjacentIndexes(indexOfCell).Count(IsLive);

    private ISet<(int, int)> GetAdjacentIndexes((int row, int column) index)
    {
      var left = index.column == 0 ? (ColumnDimension - 1) : (index.column - 1);
      var right = index.column == (ColumnDimension - 1) ? (0) : (index.column + 1);
      var up = index.row == 0 ? (RowDimension - 1) : (index.row - 1);
      var down = index.row == (RowDimension - 1) ? (0) : (index.row + 1);

      var rightNeighbour = (index.row, right);
      var leftNeighbour = (index.row, left);
      var upNeighbour = (up, index.column);
      var downNeighbour = (down, index.column);
      var rightUpDiagonal = (up, right);
      var leftUpDiagonal = (up, left);
      var lowerRightDiagonal = (down, right);
      var lowerLeftDiagonal = (down, left);

      return new HashSet<(int, int)>{upNeighbour, rightUpDiagonal, rightNeighbour, lowerRightDiagonal, downNeighbour, lowerLeftDiagonal, leftNeighbour, leftUpDiagonal};
    }
  }
}