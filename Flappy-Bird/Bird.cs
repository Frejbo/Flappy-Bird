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
    
    AnimationPlayer animPlayer = new AnimationPlayer(Raylib.LoadTexture("Assets/Player/bird1.png"), new Vector2(16, 16), 100, false);
    public Rectangle GetRect() {
        return new Rectangle(posX, posY, 16, 16);
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
        if (posY+16 < 0 || posY > Raylib.GetScreenHeight()) {
            return false;
        }
        return true;
    }
    public void Draw() {
        score.DrawScore();
        animPlayer.Draw(new Vector2(posX, posY), new Vector2(3, 3), rotation);
    }
}