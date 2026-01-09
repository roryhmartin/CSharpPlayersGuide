namespace Operator_Overloading___operand_city;

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate c, BlockOffset o) =>
        new BlockCoordinate(c.Row + o.RowOffset, c.Column + o.ColumnOffset);

    public static BlockCoordinate operator +(BlockOffset o, BlockCoordinate c) =>
        new BlockCoordinate(o.RowOffset + c.Row, o.ColumnOffset + c.Column);

    public static BlockCoordinate operator +(BlockCoordinate start, Direction direction)
    {
        return start + (direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.East => new BlockOffset(0, +1),
            Direction.South => new BlockOffset(+1, 0),
            Direction.West => new BlockOffset(0, -1)
        });
    }

    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            if (index == 1) return Column;
            throw new IndexOutOfRangeException("choose 0 or 1");
        }
    }

}