using System;

namespace Conways
{
  public class Grid<T>
  {
    private readonly T[,] _grid;
    public int RowDimension => _grid.GetLength(0);
    public int ColumnDimension => _grid.GetLength(1);
    public Grid(int rowDimension, int colDimension)
    {
      _grid = new T[rowDimension, colDimension];
    }
  }
}