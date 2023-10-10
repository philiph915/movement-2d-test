namespace movement_2d_test;

// static classes cannot be instantiated and must have static methods only
public static class InputManager 
{
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;

    public static void Update()
    {
        if (!CheckGampepadInputs()) // Check for gamepad inputs first
        {
            CheckKeyboardInputs(); // Check For Relevant Keyboard Inputs
        }
    }

    private static void CheckKeyboardInputs()
    {
        //The GetState() method of the keyboard class returns what keys are currently pressed
        var keyboardState = Keyboard.GetState(); 

        _direction = Vector2.Zero; // Initialize _direction vector as 0

        // update direction vector based on keyboard inputs
        if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;


        // normailze the direction vector if it is nonzero
        if (_direction != Vector2.Zero)
        {
            _direction.Normalize();
        }
    }

    private static bool CheckGampepadInputs()
    {

        var gamepadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);

        if ( gamepadState.ThumbSticks.Left != Vector2.Zero )
        {
            _direction = gamepadState.ThumbSticks.Left;
            _direction.Y*=-1;
            //_direction.Normalize(); // uncomment this to prevent the player from moving slowly by barely moving the joystick
            return true;
        }
        else
        {
            return false;
        }

    }
}