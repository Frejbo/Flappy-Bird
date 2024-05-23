using Raylib_cs;
using System.Linq.Expressions;
using System.Numerics;

class Bird : GameObject {
    private float GRAVITY = 30;
    private int JUMPSPEED = 700;
    private float velocity = 0;
    private bool isAlive = true;
    public bool IsAlive { get {return isAlive;} private set {} }
    private Score score = new Score();
    private AnimationPlayer animPlayer = new AnimationPlayer(Raylib.LoadTexture("Assets/Player/bird1.png"), new Vector2(16, 16), 100);

    public void Kill() { // Kills the bird
        isAlive = false;
    }
    public void Revive() { // Revives the bird
        isAlive = true;
    }

    public Bird() { // starts animation, and sets position to start position.
        animPlayer.Play();
        Position = new Vector2(50, Raylib.GetScreenHeight()/2);
    }
    public Rectangle GetRect() { // returns a rectangle of where the bird currently is.
        return new Rectangle(Position.X, Position.Y, 16, 16);
    }
    public void Tick() { // Should be called every frame to process
        if (!IsOnScreen()) { // If outside the screen, kill.
            Kill();
        }
        velocity += GRAVITY; // Add gravity
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && IsAlive) { // Check if space is pressed and jump. play a flap animation.
            velocity = -JUMPSPEED;
            animPlayer.Loop = false;
            animPlayer.Play();
        }
        velocity = Math.Clamp(velocity, -JUMPSPEED, JUMPSPEED); // Sets max speed
        Rotation = velocity / 50; // Sets rotation, just visual.
        Position = new Vector2(Position.X, Position.Y + (int)(velocity * Raylib.GetFrameTime())); // Adds the calculated velocity to the position, multiplied by deltaTime.
    }
    bool IsOnScreen() { // Boolean, returns true if the bird is on screen, otherwise false.
        if (Position.Y+16 < 0 || Position.Y > Raylib.GetScreenHeight()) {
            return false;
        }
        return true;
    }
    public void Draw() { // Draws the bird at the current position with the current rotation. Should be called after Raylib.BeginDrawing().
        score.DrawScore();
        animPlayer.Draw(new Vector2(Position.X, Position.Y), new Vector2(3, 3), Rotation);
    }
}