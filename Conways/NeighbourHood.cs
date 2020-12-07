using System.Collections.Generic;
namespace Conways
{
  public static class NeighbourHood
  {
    public static IEnumerable<RowColumn> GetNeighbourIndexes(RowColumn index, int rowDim, int colDim)
    {
      var row = index.Row;
      var column = index.Column;
      var left = column == 0 ? (colDim - 1) : (column - 1);
      var right = column == (colDim - 1) ? (0) : (column + 1);
      var up = row == 0 ? (rowDim - 1) : (row - 1);
      var down = row == (rowDim - 1) ? (0) : (row + 1);

      var neighbourHood = new HashSet<RowColumn>
      {
        new RowColumn(row, right), new RowColumn(row, left), new RowColumn(up, column), new RowColumn(down, column), new RowColumn(up, right), new RowColumn(up, left), new RowColumn(down, right), new RowColumn(down, left)
      };
      return neighbourHood;
    }
  }
}