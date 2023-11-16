using Raylib_cs;
using System.Numerics;

class Obstacle {
    Texture2D texture = Raylib.LoadTexture("Assets/Pipe.png");
    Random random = new Random();
    Vector2 position = new Vector2(Raylib.GetScreenWidth(), 0);
    int SPEED = 3;
    public Obstacle() {
        texture.Width *= 4;
        texture.Height *= 4;
        position.Y = -random.Next((texture.Height - Raylib.GetScreenHeight()));
    }
    public void Tick() {
        position.X -= SPEED;
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