using System.Collections.Generic; // Need this to use the List object

namespace movement_2d_test;

public class TileMap
{
    private int _numRows;
    private int _numCols;
    private int _tileWidth;
    private int _tileHeight;
    private Texture2D _texture;
    private Rectangle[,] _sourceRectangles;
    private List<Tile> _tileList; // List of Tile objects representing positions and image indices of each tile to be drawn from this tilemap

    // constructor
    public TileMap(Texture2D texture, int numRows, int numCols, int tileWidth, int tileHeight, List<Tile> tileList)
    {
        _texture    = texture;
        _numRows    = numRows;
        _numCols    = numCols;
        _tileHeight = tileHeight;
        _tileWidth  = tileWidth;
        _tileList   = tileList;

         _sourceRectangles = SliceTiles();
    }

    // Creates _sourceRectangles, an array of rectangles representing coordinates for bounding rectangles for each individual tile in the tilemap, indexed by (row,col)
    private Rectangle[,] SliceTiles()
    {
        Rectangle[,] sourceRectangles = new Rectangle[_numRows, _numCols];
        for (int ii = 0; ii < _numRows; ii++)
        {
            for (int jj = 0; jj < _numCols; jj++)
            {
                sourceRectangles[ii,jj] = new(jj*_tileWidth,ii*_tileHeight,_tileWidth,_tileHeight);
            }

        }
        return sourceRectangles;
    }


    // Draw Each Tile in tileList
    public void Draw()
    {

        // For each Tile in TileList, SpriteBatch.Draw this class's _texture, at the correct position based on Tile._pos, using the correct rectangle in _sourceRectangles based on Tile._tileMapRowCol

        // Will some day have to figure out how to add colliders to tiles, however this is probably out of the scope of this prototype 
        
        Rectangle drawBoundRect;
        Vector2 thisTilePos;
        foreach (Tile thisTile in _tileList)
        {
            // Extract Current Tile position and Drawing Rectangle
            drawBoundRect = _sourceRectangles[thisTile._tileMapRowCol.X,thisTile._tileMapRowCol.Y];
            thisTilePos = new(thisTile._pos.X*_tileWidth,thisTile._pos.Y*_tileHeight);

            // ADDED IN A SCALE FACTOR TO MAKE THE TILES MORE VISIBLE. YES THIS SCREWS UP THE TILE POSITIONS / COORDINATES 
            Globals.SpriteBatch.Draw(_texture, thisTilePos, drawBoundRect, Color.White, 0f, new(0,0), 3*1f, SpriteEffects.None, 0f); // Assumes tile origin is top-left corner
        }
        

        //SpriteBatch.Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        //Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }

}