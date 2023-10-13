using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace movement_2d_test;

// This class is what is actually used to run the game;
// The Update() and Draw() methods will be called continuously
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteBatch _debugSpriteBatch;
    private GameManager _gameManager; 
    private SpriteFont _debugFont;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
       
        // Add Initialization Logic to set window size, graphics settings, pass content to Globals class, and
        // instantiate game manager
        Globals.WindowSize = new(1280,720);
        _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
        _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
        _graphics.ApplyChanges();

        Globals.Content = Content;
        _gameManager = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        _debugSpriteBatch = new SpriteBatch(GraphicsDevice);
        _debugFont = Content.Load<SpriteFont>("DebugFont");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.Clear(Color.CornflowerBlue); // background color
        GraphicsDevice.Clear(Color.Green);

        // TODO: Add your drawing code here
        _gameManager.Draw(); // Draw sprites with the game manager
        DebugRender(_debugSpriteBatch); // Draw Debug Graphics / Text

        base.Draw(gameTime);
    }

    protected void DebugRender(SpriteBatch sb)
    {
        // Populate Debug Text
        System.String debugString = null; // Initialize an empty string
        debugString += InputManager.Direction.ToString() + "\n"; // Add Direction Input
        debugString += _gameManager._player.Position.ToString() + "\n"; // Add Player Position
        debugString += "delX: " + _gameManager.delX.ToString() + "delY: " + _gameManager.delY.ToString() + "\n"; // Add Camera Deltas

        // Render Debug Text
        sb.Begin();
        sb.DrawString(_debugFont,debugString,new(0,0),Color.Blue);
        sb.End();

    }
}
