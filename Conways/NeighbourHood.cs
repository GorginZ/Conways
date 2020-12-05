using System.Collections.Generic;
namespace Conways
{
  public static class NeighbourHood
  {
    public static IEnumerable<(int, int)> GetNeighbourhoodIndexes((int row, int column) index, (int rowDim, int colDim) dimensions)
    {
      var left = index.column == 0 ? (dimensions.colDim - 1) : (index.column - 1);
      var right = index.column == (dimensions.colDim - 1) ? (0) : (index.column + 1);
      var up = index.row == 0 ? (dimensions.rowDim - 1) : (index.row - 1);
      var down = index.row == (dimensions.rowDim - 1) ? (0) : (index.row + 1);

      var neighbourHood = new List<(int, int)>
      {
        (index.row, right), (index.row, left), (up, index.column),(down, index.column), (up, right), (up, left), (down, right), (down, left)
        };
      return neighbourHood;
    }
  }
}