using Raylib_cs;
using System.Numerics;

class Bird {
    int posY = Raylib.GetScreenHeight()/2;
    float GRAVITY = 30;
    int JUMPSPEED = 600;
    float velocity = 0;
    float rotation = 0;
    Texture2D texture = Raylib.LoadTexture("Assets/Player/Bird.png");
    // public Bird() {
    //     texture.Height *= 3;
    //     texture.Width *= 3;
    // }
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
        Raylib.DrawTextureEx(texture, new Vector2(50, posY), rotation, 3, Color.YELLOW);
    }
}