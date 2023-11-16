using Raylib_cs;
using System.Numerics;

class Bird {
    int posY = Raylib.GetScreenHeight()/2;
    int posX = 50;
    float GRAVITY = 30;
    int JUMPSPEED = 600;
    float velocity = 0;
    float rotation = 0;
    Texture2D texture = Raylib.LoadTexture("Assets/Player/Bird.png");
    public Rectangle GetRect() {
        return new Rectangle(posX, posY, texture.Width, texture.Height);
    }
    public void Tick() {
        velocity += GRAVITY;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) {
            velocity = -JUMPSPEED;
        }
        velocity = Math.Clamp(velocity, -JUMPSPEED, JUMPSPEED);
        rotation = velocity / 50;
        posY += (int)(velocity * Raylib.GetFrameTime());
    }
    public void Draw() {
        Raylib.DrawTextureEx(texture, new Vector2(posX, posY), rotation, 3, Color.YELLOW);
    }
}