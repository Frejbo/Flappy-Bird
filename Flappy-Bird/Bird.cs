using Raylib_cs;
using System.Linq.Expressions;
using System.Numerics;

class Bird {
    int posY = Raylib.GetScreenHeight()/2;
    static public int posX = 50;
    float GRAVITY = 30;
    int JUMPSPEED = 700;
    float velocity = 0;
    float rotation = 0;
    public bool isAlive = true;
    Score score = new Score();
    Texture2D texture = Raylib.LoadTexture("Assets/Player/Bird.png");
    public Rectangle GetRect() {
        return new Rectangle(posX, posY, texture.Width, texture.Height);
    }
    public void Tick() {
        if (!IsOnScreen()) {
            isAlive = false;
        }
        velocity += GRAVITY;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && isAlive) {
            velocity = -JUMPSPEED;
        }
        velocity = Math.Clamp(velocity, -JUMPSPEED, JUMPSPEED);
        rotation = velocity / 50;
        posY += (int)(velocity * Raylib.GetFrameTime());
    }
    bool IsOnScreen() {
        if (posY+texture.Height < 0 || posY > Raylib.GetScreenHeight()) {
            return false;
        }
        return true;
    }
    public void Draw() {
        if(IsOnScreen()) {
            Raylib.DrawTextureEx(texture, new Vector2(posX, posY), rotation, 3, Color.YELLOW);
        }
        score.DrawScore();
    }
}