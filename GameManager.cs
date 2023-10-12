namespace movement_2d_test;

public class GameManager
{

    public readonly Player _player;
    public readonly Scene1 _scene1;

    // Constructor
    public GameManager()
    {
        // Instantiate a player object with specified sprite and position
        _player = new(Globals.Content.Load<Texture2D>("hedgehog_transparent_small"),new(600, 600));
        _player.SetBounds(new(800,800),new(16,16)); 

        // Instantiate Scene / Environment Objects
        _scene1 = new();
    }

    // Update all the objects in the game
    public void Update()
    {
        InputManager.Update();
        _player.Update();
    }

    // Draw all the sprites in the game
    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _scene1.Draw();
        _player.Draw();

        Globals.SpriteBatch.End();
    }
}