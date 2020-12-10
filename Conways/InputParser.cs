using System.Collections.Generic;

namespace Conways
{
  public static class InputParser
  {
    public static ISet<(int, int)> ParseInputToValidIndexes(string input, (int rowCount, int colCount) dimensions)
    {
      var indexList = new HashSet<(int, int)>();
      var indexes = input.Split(" ");

      foreach (string index in indexes)
      {
        if (index.Length >= 3)
        {
          var rowTryParse = int.TryParse(index[0].ToString(), out int row);
          var colTryParse = int.TryParse(index[2].ToString(), out int column);
          if (rowTryParse && colTryParse && row <= dimensions.rowCount - 1 && column <= dimensions.colCount - 1)
          {
            indexList.Add((row, column));
          }
        }
      }
      return indexList;
    }

  }
}