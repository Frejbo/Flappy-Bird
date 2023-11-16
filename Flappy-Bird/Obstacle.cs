using Raylib_cs;

class Obstacle {
    Texture2D texture = Raylib.LoadTexture("Assets/Pipe.png");
    int posX = Raylib.GetScreenWidth();
    public void Tick() {
        posX-= 2;
    }
    public void Draw() {
        Raylib.DrawTexture(texture, posX, 0, Color.WHITE);
    }
    public bool ShouldRemove() {
        return posX < -texture.Width;
    }
    public bool SpaceForNew(int RequestedPipes) {
        int spacing = Raylib.GetScreenWidth() / RequestedPipes;
        return Raylib.GetScreenWidth()-posX > spacing;
    }
}