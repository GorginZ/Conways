using System.Collections.Generic;
namespace Conways
{
  public class LifeRules : IRules
  {
    public ISet<(int, int)> CellNeighbours((int row, int column) index, (int rowDimension, int columnDimension) dimensions)
    {
      var left = index.column == 0 ? (dimensions.columnDimension - 1) : (index.column - 1);
      var right = index.column == (dimensions.columnDimension - 1) ? (0) : (index.column + 1);
      var up = index.row == 0 ? (dimensions.rowDimension - 1) : (index.row - 1);
      var down = index.row == (dimensions.rowDimension - 1) ? (0) : (index.row + 1);

      var rightNeighbour = (index.row, right);
      var leftNeighbour = (index.row, left);
      var upNeighbour = (up, index.column);
      var downNeighbour = (down, index.column);
      var rightUpDiagonal = (up, right);
      var leftUpDiagonal = (up, left);
      var lowerRightDiagonal = (down, right);
      var lowerLeftDiagonal = (down, left);

      return new HashSet<(int, int)> { upNeighbour, rightUpDiagonal, rightNeighbour, lowerRightDiagonal, downNeighbour, lowerLeftDiagonal, leftNeighbour, leftUpDiagonal };
    }

    public bool CellShouldBeMadeLiveNextItteration(bool isLive, int numberOfLiveNeighbours)
    {
      return numberOfLiveNeighbours == 3 || (isLive && numberOfLiveNeighbours == 2);
    }
  }
}