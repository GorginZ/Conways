using System;

namespace Conways
{
  public class ConsoleInput : IRead
  {
    public string ReadInput(string prompt)
    {
      Console.WriteLine(prompt);
      return Console.ReadLine();
    }
    // public (int, int) GetDimensions()
    // {
    //     var rowInput = ReadInput("How many rows?");
    //     var colInput = ReadInput("How many columns?");
    //     var parsedRow = int.TryParse(rowInput, out int rowValue);
    //     var parsedCol = int.TryParse(colInput, out int colValue);
    //     if (parsedRow && parsedCol && IsValid(rowValue) && IsValid(colValue))
    //     {
    //       return (rowValue, colValue);
    //     }
    // }
    public static bool IsValid(int value) => value <= 50;
  }
}