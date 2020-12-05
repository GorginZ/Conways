namespace Conways
{
  public readonly struct RowColumn
  {
    public readonly int Row;
    public readonly int Column;

    public RowColumn(int row, int column)
    {
      Row = row;
      Column = column;
    }
    // public bool Equals(RowColumn other) => (Row, Column).Equals(other);

    // public override bool Equals(object obj) => (Row, Column).Equals(obj);

    // public static bool operator ==(RowColumn a, RowColumn b) => a.Equals(b);
    // public static bool operator !=(RowColumn a, RowColumn b) => !a.Equals(b);

    // public override int GetHashCode() => (Row, Column).GetHashCode();
  }
}