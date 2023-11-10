using Raylib_cs;

class Bird {
    int posY = Raylib.GetScreenHeight()/2;
    float GRAVITY = 30;
    int JUMPSPEED = 800;
    float velocity = 0;
    public void Tick() {
        velocity += GRAVITY;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) {
            velocity = -JUMPSPEED;
        }
        velocity = Math.Clamp(velocity, -JUMPSPEED, JUMPSPEED);
        posY += (int)(velocity * Raylib.GetFrameTime());
    }
    public void Draw() {
        Raylib.DrawRectangle(50, posY, 16, 16, Color.YELLOW);
    }
}