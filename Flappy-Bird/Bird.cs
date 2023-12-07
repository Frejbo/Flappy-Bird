using Raylib_cs;
using System.Linq.Expressions;
using System.Numerics;

class Bird : GameObject {
    float GRAVITY = 30;
    int JUMPSPEED = 700;
    float velocity = 0;
    public bool isAlive = true;
    Score score = new Score();
    
    AnimationPlayer animPlayer = new AnimationPlayer(Raylib.LoadTexture("Assets/Player/bird1.png"), new Vector2(16, 16), 100);
    public Bird() {
        animPlayer.Play();
        position = new Vector2(50, Raylib.GetScreenHeight()/2);
    }
    public Rectangle GetRect() {
        return new Rectangle(position.X, position.Y, 16, 16);
    }
    public void Tick() {
        if (!IsOnScreen()) {
            isAlive = false;
        }
        velocity += GRAVITY;
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && isAlive) {
            velocity = -JUMPSPEED;
            animPlayer.loop = false;
            animPlayer.Play();
        }
        velocity = Math.Clamp(velocity, -JUMPSPEED, JUMPSPEED);
        rotation = velocity / 50;
        position.Y += (int)(velocity * Raylib.GetFrameTime());
    }
    bool IsOnScreen() {
        if (position.Y+16 < 0 || position.Y > Raylib.GetScreenHeight()) {
            return false;
        }
        return true;
    }
    public void Draw() {
        score.DrawScore();
        animPlayer.Draw(new Vector2(position.X, position.Y), new Vector2(3, 3), rotation);
    }
}