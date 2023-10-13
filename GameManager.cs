namespace movement_2d_test;

public class GameManager
{

    public readonly Player _player;
    public readonly Scene1 _scene1;
    private Matrix _translation;

    public float delX;
    public float delY;

    // Constructor
    public GameManager()
    {
        // Instantiate Scene / Environment Objects
        _scene1 = new();

        // Instantiate a player object with specified sprite and position
        _player = new(Globals.Content.Load<Texture2D>("hedgehog_transparent_small"),new(600, 600));
        _player.SetBounds(new(1920,1080),new(48,48)); 

    }

    // Update all the objects in the game
    public void Update()
    {
        InputManager.Update();
        _player.Update();
        CalculateTranslation();
    }

    private void CalculateTranslation()
    {
        var dx = (Globals.WindowSize.X / 2) - _player.Position.X;
        dx = MathHelper.Clamp(dx, 1280-1920, 0);
        var dy = (Globals.WindowSize.Y / 2) - _player.Position.Y;
        dy = MathHelper.Clamp(dy, 720-1080+24, 0);
        _translation = Matrix.CreateTranslation(dx,dy,0f);

        // For debugging
        delX = (float)dx;
        delY = (float)dy;
    }

    //dx = MathHelper.Clamp(dx, -_map.MapSize.X + Globals.WindowSize.X + (_map.TileSize.X / 2), _map.TileSize.X / 2);
     //   var dy = (Globals.WindowSize.Y / 2) - _hero.Position.Y;
      //  dy = MathHelper.Clamp(dy, -_map.MapSize.Y + Globals.WindowSize.Y + (_map.TileSize.Y / 2), _map.TileSize.Y / 2);
        

    // Draw all the sprites in the game
    public void Draw()
    {
        Globals.SpriteBatch.Begin(transformMatrix: _translation);
        _scene1.Draw();
        _player.Draw();

        Globals.SpriteBatch.End();
    }
}