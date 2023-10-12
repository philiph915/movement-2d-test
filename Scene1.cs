using System.Collections.Generic;
using System.Linq;

namespace movement_2d_test;

// Scene1: Hard Coded Class that contains all the environment objects for this specific scene. 
// In the future it makes more sense to turn this into a generic scene class that loads all its object
// from some kind of plain text file or output from a tool like Tiled
public class Scene1
{

    // THIS IS A TERRIBLE WAY TO ASSIGN TILE INFORMATION AND IT WILL TAKE FOREVER TO DESIGN LEVELS LIKE THIS (Look up Tiled)

    // Create array of Point objects with coordinates for each tile (X,Y in tile units)
    private readonly Point[] _tilePos = {new(40,40),new(30,30),new(20,20), 
                                         new(40,20),new(40,30),new(20,40),};

    // Create array of Point objects corresponding to which sliced tile from the tilemap each tile object should be
    private readonly Point[] _tileImgIdx = {new(1,1),new(2,1),new(4,1), 
                                            new(3,4),new(0,0),new(1,2)};

    // Initialize the list of tiles (to be populated in the Initialize function)
    readonly List<Tile> _tileList = new();   

    // Information about this scene's tilemap
    private static readonly int _tileWidth = 16;
    private static readonly int _tileHeight = 16;
    private readonly TileMap GrassNDirt;

    // Constructor
    public Scene1()
    {
        // Create the "GrassNDirt" tilemap
        _tileList = GenerateTileList(_tilePos, _tileImgIdx); // First generate the list of tiles needed to create the tilemap
        GrassNDirt = new TileMap(Globals.Content.Load<Texture2D>("GrassNDirt"),5,8,_tileWidth,_tileHeight,_tileList);
    }

    // Function to generate the list of tiles
    private static List<Tile> GenerateTileList(Point[] tilePos, Point[] tileImgIdx) // int _tileWidth, int _tileHeight)
    {
        List<Tile> tileList = new(); 

        // Loop scross tile position array
        for (int ii = 0; ii < tilePos.Length; ii++)
        {
            tileList.Add(new Tile(tilePos[ii],tileImgIdx[ii]));
        }
        return tileList;
    }

    public void Draw()
    {
        GrassNDirt.Draw();
    }


}