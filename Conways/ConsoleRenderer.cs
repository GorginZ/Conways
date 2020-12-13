using System;
using System.Text;

namespace Conways
{
  public class ConsoleRenderer : IRender
  {
    public void Render(CellState[,] grid, ControlCommand currentComand)
    {
      const string header = "CONWAYS GAME OF LIFE";
      var status = currentComand.ToString();
      const string footer = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
      Console.Clear();
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (header.Length / 2)) + "}", header));
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (status.Length / 2)) + "}", status));
      Console.WriteLine(GridAsString(grid));
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (footer.Length / 2)) + "}", footer));
    }

    public static string GridAsString(CellState[,] grid)
    {
      var seeSB = new StringBuilder();

      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          if (grid[i, j] == CellState.Alive)
          {
            seeSB.Append('X');
          }
          else
          {
            seeSB.Append(' ');
          }
        }
        seeSB.Append('\n');
      }
      return seeSB.ToString();
    }
  }
}