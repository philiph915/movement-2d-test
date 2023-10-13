using System;
using System.Collections.Generic;

namespace movement_2d_test;

// Scene1: Hard Coded Class that contains all the environment objects for this specific scene. 
// In the future it makes more sense to turn this into a generic scene class that loads all its object
// from some kind of plain text file or output from a tool like Tiled
public class Scene1
{

    // THIS IS A TERRIBLE WAY TO ASSIGN TILE INFORMATION AND IT WILL TAKE FOREVER TO DESIGN LEVELS LIKE THIS (Look up Tiled)

    /* // Without using drawScale 
    // Create array of Point objects with coordinates for each tile (X,Y in tile units)
    private readonly Point[] _tilePos = {new(40,40),new(30,30),new(20,20), 
                                         new(40,20),new(40,30),new(20,40),}; */

    // Create array of Point objects with coordinates for each tile (X,Y in tile units)
    private readonly Point[] _tilePos = {new(13,13),new(10,10),new(6,6), new(13,20),new(10,22),new(26,6), 
                                         new(13,6),new(13,10),new(6,13), new(20,13),new(10,22),new(26,18)};

    // Create array of Point objects corresponding to which sliced tile from the tilemap each tile object should be
    private readonly Point[] _tileImgIdx = {new(1,1),new(2,1),new(4,1), new(0,1),new(2,0),new(4,1), 
                                            new(3,4),new(0,0),new(2,4), new(3,1),new(3,4),new(0,3)};

    // Initialize the list of tiles (to be populated in the Initialize function)
    readonly List<Tile> _tileList = new();   

    // Information about this scene's tilemap
    public int _tileWidth = 16;
    public int _tileHeight = 16;
    private readonly TileMap GrassNDirt;
    private readonly float _gridScale = 1.0f;//3.0f;
    public Point mapSize; 

    private static readonly bool createRandomMap = true;

    // Constructor
    public Scene1()
    {
        // Hard-Coded Map Size in tiles
        mapSize = new(1920/(_tileWidth*(int)_gridScale),1080/(_tileHeight*(int)_gridScale));

        // Option to populate the entire map with random tiles
        if (createRandomMap)
        {
            Point[] tilePosRandom = new Point[mapSize.X*mapSize.Y]; 
            Point[] tileImgRandom = new Point[mapSize.X*mapSize.Y]; 

            Random random = new(); // Initialize a random number generator

            int pseudoCount = 0;

            // Loop across entire map
            for (int xInd = 0; xInd < mapSize.X; xInd++)
            {
                for (int yInd = 0; yInd < mapSize.Y; yInd++)
                {
                    tilePosRandom[pseudoCount] = new(xInd,yInd);
                    tileImgRandom[pseudoCount] = new(random.Next(0,3),random.Next(3,4)); //this is row, col (annoying)
                    pseudoCount++;
                }
            }
            // Generate the tile list using the randomly generated tiles
            _tileList = GenerateTileList(tilePosRandom, tileImgRandom); // First generate the list of tiles needed to create the tilemap
        }
        else
        {
            // Generate the tile list using the user-specified tiles
            _tileList = GenerateTileList(_tilePos, _tileImgIdx); // First generate the list of tiles needed to create the tilemap
        }

        // Create the "GrassNDirt" tilemap
        GrassNDirt = new TileMap(Globals.Content.Load<Texture2D>("GrassNDirt"),5,8,_tileWidth,_tileHeight,_gridScale,_tileList);

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