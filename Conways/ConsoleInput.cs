using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Conways
{
  public class ConsoleInput : IRead
  {
    public string ReadInput(string prompt)
    {
      Console.WriteLine(prompt);
      return Console.ReadLine();
    }
    public (int, int) GetDimensions()
    {
      while (true)
      {
        var rowInput = ReadInput("How many rows?");
        var colInput = ReadInput("How many columns?");
        var parsedRow = int.TryParse(rowInput, out int rowValue);
        var parsedCol = int.TryParse(colInput, out int colValue);
        if (parsedRow && parsedCol && IsValid(rowValue) && IsValid(colValue))
        {
          return (rowValue, colValue);
        }
      }
    }

    public IEnumerable<(int,int)> GetStartingState((int rowCount, int colCount) dimensions)
    {
      var indexList = new HashSet<(int,int)>();

      while (true)
      {
        var input = ReadInput("enter indexes to set alive eg 0,0 0,1 0,2");
        var indexes = input.Split(" ");
        foreach (string index in indexes)
        {
          var values = index.Split(",");
          var rowTryParse = int.TryParse(index[0].ToString(), out int row);
          var colTryParse = int.TryParse(index[2].ToString(), out int column);
          if (rowTryParse && colTryParse && row <= dimensions.rowCount - 1 && column <= dimensions.colCount - 1)
          {
            indexList.Add((row, column));
          }
        }
        return indexList;
      }
    }
    public static bool IsValid(int value) => value <= 50 && value >= 3;
  }
}