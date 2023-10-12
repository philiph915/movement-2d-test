namespace movement_2d_test;

public class Sprite
{
    private readonly Texture2D _texture;
    public Vector2 Position {get; protected set;} // Coordinates in world frame representing location of sprite origin
    public Vector2 Origin {get; protected set;} // Coordinates in sprite frame representing center of image

    // constructor
    public Sprite(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        Position = position;
        Origin = new(_texture.Width / 2, texture.Height/2); // place the origin at the center of the image by default 
    }

    public void Draw()
    {
        //SpriteBatch.Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }

    public void Draw(Rectangle _sourceRectangle)
    {
        //SpriteBatch.Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        Globals.SpriteBatch.Draw(_texture, Position, _sourceRectangle, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }

}