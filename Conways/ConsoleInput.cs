using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Conways
{
  public class ConsoleInput : IRead, IControl
  {
    private ConsoleKey InputKey;
    public ControlCommand Command { get; set; }

    public string ReadInput(string prompt)
    {
      Console.WriteLine(prompt);
      return Console.ReadLine();
    }

    public void SetInputKey() => InputKey = Console.ReadKey(true).Key;

    public void SetCurrentCommand()
    {
      SetInputKey();
      if (InputKey == ConsoleKey.Escape)
      {
        Command = ControlCommand.End;
      }
      if (InputKey == ConsoleKey.Spacebar)
      {
        Command = Command == ControlCommand.Running ? ControlCommand.Paused : ControlCommand.Running;
      }
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

    public ISet<(int, int)> GetValidIndexes((int rowCount, int colCount) dimensions)
    {
      var indexList = new HashSet<(int, int)>();
      while (indexList.Count < 3)
      {
        var input = ReadInput("enter indexes to set alive eg 0,0 0,1 0,2");
        indexList = new HashSet<(int, int)>(InputParser.ParseInputToValidIndexes(input, dimensions));
      }
      return indexList;
    }
  }
}