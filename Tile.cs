namespace movement_2d_test;

public class Tile
{
    public Point _pos;
    public Point _tileMapRowCol;

    public Tile(Point pos, Point tileMapRowCol)
    {
        _pos = pos;
        _tileMapRowCol = tileMapRowCol;
    }
}