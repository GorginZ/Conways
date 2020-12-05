using System;
using System.Text;

namespace Conways
{
  public class ConsoleRenderer : IRender
  {
    public void Render(CellState[,] grid)
    {
      Console.Clear();
      Console.WriteLine(VisualizeGridInConsole(grid));
    }
    public static string VisualizeGridInConsole(CellState[,] grid)
    {
      var seeSB = new StringBuilder();

      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          if (grid[i, j] == CellState.Alive)
          {
            seeSB.Append("X");
          }
          else
          {
            seeSB.Append(" ");
          }
        }
        seeSB.Append("\n");
      }
      return seeSB.ToString();
    }
  }
}