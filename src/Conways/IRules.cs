using System.Collections.Generic;

namespace Conways
{
  public interface IRules
  {
    bool CellShouldBeMadeLiveNextItteration(bool islive, int numberOfLiveNeighbours);
    ISet<(int, int)> CellNeighbours((int row, int column) index, (int rowDimension, int columnDimension) dimensions);
  }
}