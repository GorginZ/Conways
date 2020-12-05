# Conways

<img src="docs/plan.png">Simplifying.

I liked the idea of a RowColumn for indexing, which can be easily passed around in some IEnumerable collection. 

Upon reflection, I don't need to pass around that many collections in conaways or need to refer to a specific index that often in a way that having an indexing system like my row col struct that necessary. I am going to try just using tuples. here's the old row column though. 

```c#
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
    public bool Equals(RowColumn other) => (Row, Column).Equals(other);

    public override bool Equals(object obj) => (Row, Column).Equals(obj);

    public static bool operator ==(RowColumn a, RowColumn b) => a.Equals(b);
    public static bool operator !=(RowColumn a, RowColumn b) => !a.Equals(b);

    public override int GetHashCode() => (Row, Column).GetHashCode();
  }
}

```

