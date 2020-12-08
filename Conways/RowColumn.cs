// namespace Conways
// {
//   public readonly struct (int,int)
//   {
//     public readonly int Row;
//     public readonly int Column;

//     public (int,int)(int row, int column)
//     {
//       Row = row;
//       Column = column;
//     }
//     public bool Equals((int,int) other) => (Row, Column).Equals(other);

//     public override bool Equals(object obj)
//     {
//       if (!(obj is (int,int) rowCol))
//         return false;
//       return this.Row == rowCol.Row && this.Column == rowCol.Column;
//     }
//     public static bool operator ==((int,int) a, (int,int) b) => a.Equals(b);
//     public static bool operator !=((int,int) a, (int,int) b) => !a.Equals(b);

//     public override int GetHashCode() => (Row, Column).GetHashCode();
//   }
// }