using System.Collections.Generic;
namespace Conways
{
  public static class AdjacentIndexCalculator
  {
    public static ISet<(int, int)> GetAdjacentIndexes((int row, int column) index, (int rowDimension, int columnDimension) dimensions)
    {
      var left = index.column == 0 ? (dimensions.columnDimension - 1) : (index.column - 1);
      var right = index.column == (dimensions.columnDimension - 1) ? (0) : (index.column + 1);
      var up = index.row == 0 ? (dimensions.rowDimension - 1) : (index.row - 1);
      var down = index.row == (dimensions.rowDimension - 1) ? (0) : (index.row + 1);

      var adjacentIndexes = new HashSet<(int, int)>{(index.row, right), (index.row, left),
      (up, index.column), (down, index.column), (up, right), (up, left), (down, right), (down, left)};
      return adjacentIndexes;
    }
  }
}