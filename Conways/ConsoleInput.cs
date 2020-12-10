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
      var rowValue = 0;
      var colValue = 0;
      while (!IsValidDimension(rowValue) && !IsValidDimension(colValue))
      {
        var rowInput = ReadInput("How many rows?");
        var colInput = ReadInput("How many columns?");
        var parsedRow = int.TryParse(rowInput, out int rowOut);
        var parsedCol = int.TryParse(colInput, out int colOut);
        if (parsedRow && parsedCol && IsValidDimension(rowOut) && IsValidDimension(colOut))
        {
          rowValue = rowOut;
          colValue = colOut;
        }
      }
      return (rowValue, colValue);
    }

    public static bool IsValidDimension(int value) => value <= 30 && value >= 3;

    public ISet<(int, int)> GetStartingState((int rowCount, int colCount) dimensions)
    {
      var indexList = new HashSet<(int, int)>();
      while (indexList.Count < 3)
      {
        var input = ReadInput("enter indexes to set alive eg 0,0 0,1 0,2");
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
      }
      return indexList;
    }
  }
}