using System;
using Xunit;

namespace Conways.Tests
{
    public class GridTests
    {
        [Fact]
        public void GridIsOfSpecifiedDimensions()
        {
          var grid = new Grid<CellState>(3,4);
          Assert.Equal(3, grid.RowDimension);
          Assert.Equal(4, grid.ColumnDimension);
        }
    }
}
