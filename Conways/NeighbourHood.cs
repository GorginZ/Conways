using System.Collections.Generic;
namespace Conways
{
  public static class NeighbourHood
  {
  public static IEnumerable<(int, int)> GetNeighbourIndexes((int row, int column) index, (int rowDim, int colDim) dimensions)
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

    // public static IEnumerable<RowColumn> GetNeighbourIndexes(RowColumn index, int rowDim, int colDim)
    // {
    //   var row = index.Row;
    //   var column = index.Column;

    //   var left = column == 0 ? (colDim - 1) : (column - 1);
    //   var right = column == (colDim - 1) ? (0) : (column + 1);
    //   var up = row == 0 ? (rowDim - 1) : (row - 1);
    //   var down = row == (rowDim - 1) ? (0) : (row + 1);

    //   var neighbourHood = new HashSet<RowColumn>
    //   {
    //     new RowColumn(row, right), new RowColumn(row, left), new RowColumn(up, column), new RowColumn(down, column), new RowColumn(up, right), new RowColumn(up, left), new RowColumn(down, right), new RowColumn(down, left)
    //   };
    //   return neighbourHood;
    // }
  }
}