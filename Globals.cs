using Microsoft.Xna.Framework.Content;

namespace movement_2d_test;

public static class Globals
{
    public static float Time { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point WindowSize { get; set; }

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds; // this is the delta time between frames
    }
}