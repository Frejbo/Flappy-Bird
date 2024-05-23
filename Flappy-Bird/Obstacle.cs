using Raylib_cs;
using System.Dynamic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

class Obstacle : GameObject {
    private Texture2D texture = Raylib.LoadTexture("Assets/Pipe.png");
    private Rectangle collision = new Rectangle(0, 0, 32, 94);
    public int Speed {
        get {
            return speed;
        }
        set {
            speed = Math.Max(value, 0);
        }
    }
    private int speed = 4;
    private Score score = new Score();
    private bool givenScore = false;
    private Bird bird;
    public Obstacle(Bird b) {
        // för över parametrar till de faktiska variablerna
        bird = b;
        texture.Width *= 4;
        texture.Height *= 4;
        collision.Width *= 4;
        collision.Height *= 4;
        Position = new Vector2(Raylib.GetScreenWidth(), -Randomizer.Next((texture.Height - Raylib.GetScreenHeight())));
    }
    public void Tick() { // Should be called every frame in order to move the obstacles forward.
        if (!bird.IsAlive) { // Don't move if the bird is dead.
            return;
        }
        Position = new Vector2(Position.X - speed, Position.Y); // Update position
        if (Position.X + texture.Width < bird.Position.X) { // If object passes behind the bird, add a score to Score class.
            if (!givenScore) {
                givenScore = true;
                Score.Amount++;
            }
        }
    }
    public bool isColliding(Rectangle rect) { // Checks if this obstacle is overlapping the given rectangle. If it does, returns true.
        collision.X = Position.X;
        collision.Y = Position.Y;
        if (Raylib.CheckCollisionRecs(collision, rect)) {
            return true;
        }
        collision.Y = Position.Y + texture.Height - collision.Height;
        if (Raylib.CheckCollisionRecs(collision, rect)) {
            return true;
        }
        return false;
    }
    public void Draw() { // Draws this obstacle at the current position. Should be called after Raylib.BeginDrawing().
        Raylib.DrawTexture(texture, (int)Position.X, (int)Position.Y, Color.WHITE);
    }
    public bool ShouldRemove() { // Returns true if this obstacle has moved out of screen and should be removed.
        return Position.X < -texture.Width;
    }
    public bool SpaceForNew(int RequestedPipes) { // Returns true if there is space available to spawn a new obstacle, depending of the spacingand how many pipes the user want.
        int spacing = Raylib.GetScreenWidth() / RequestedPipes;
        return Raylib.GetScreenWidth()-texture.Width-Position.X > spacing;
    }
}