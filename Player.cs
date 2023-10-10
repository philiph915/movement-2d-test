namespace movement_2d_test;

public class Player : Sprite
{

    // Class Parameters
    private const float SPEED = 500; // movement speed in pixels per second
    private Vector2 _minPos, _maxPos; // can declare two Vector2's at once using this syntax


    // Constructor (inherit from base class)
    public Player(Texture2D texture, Vector2 position) : base(texture, position)
    {

    }

    public void SetBounds(Point mapSize, Point tileSize)
    {
        // C# compiler knows that new() is creating a Vector2 due to _minPos being a Vector2,
        // therefore we don't have to specify the type here (nice)
        _minPos = new((-tileSize.X / 2 ) + Origin.X, (-tileSize.Y / 2) + Origin.Y); // This point represents the minimum X and Y position the player is allowed to reach 
        _maxPos = new Vector2(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y); // here I specified the type just because
    }

    public void Update()
    {
        // Update the player's position based on input and delta time
        Position += InputManager.Direction * Globals.Time * SPEED;

        // Limit the player's position to the specified map bounds
        Position = Vector2.Clamp(Position, _minPos, _maxPos);
    }
}