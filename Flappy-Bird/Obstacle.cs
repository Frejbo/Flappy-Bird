using Raylib_cs;
using System.Numerics;

class Obstacle {
    Texture2D texture = Raylib.LoadTexture("Assets/Pipe.png");
    Random random = new Random();
    Vector2 position = new Vector2(Raylib.GetScreenWidth(), 0);
    Rectangle collision = new Rectangle(0, 0, 32, 94);
    public int speed = 3;
    public Obstacle() {
        texture.Width *= 4;
        texture.Height *= 4;
        collision.Width *= 4;
        collision.Height *= 4;
        position.Y = -random.Next((texture.Height - Raylib.GetScreenHeight()));
    }
    public void Tick() {
        position.X -= speed;
    }
    public bool isColliding(Rectangle rect) {
        collision.X = position.X;
        collision.Y = position.Y;
        if (Raylib.CheckCollisionRecs(collision, rect)) {
            return true;
        }
        collision.Y = position.Y + texture.Height - collision.Height;
        if (Raylib.CheckCollisionRecs(collision, rect)) {
            return true;
        }
        return false;
    }
    public void Draw() {
        Raylib.DrawTexture(texture, (int)position.X, (int)position.Y, Color.WHITE);
    }
    public bool ShouldRemove() {
        return position.X < -texture.Width;
    }
    public bool SpaceForNew(int RequestedPipes) {
        int spacing = Raylib.GetScreenWidth() / RequestedPipes;
        return Raylib.GetScreenWidth()-texture.Width-position.X > spacing;
    }
}