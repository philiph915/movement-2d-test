namespace movement_2d_test;

public class GameManager
{

    public readonly Player _player;

    // Constructor
    public GameManager()
    {
        // Instantiate a player object with specified sprite and position
        _player = new(Globals.Content.Load<Texture2D>("hedgehog_transparent_small"),new(600, 600));
        _player.SetBounds(new(800,800),new(16,16)); 
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
        _player.Draw();

        Globals.SpriteBatch.End();
    }
}