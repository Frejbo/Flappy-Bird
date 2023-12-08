using Raylib_cs;
using System.Numerics;

class DebugScene {
    AnimationPlayer animPlayer = new(Raylib.LoadTexture("Assets/Background-sheet.png"), new Vector2(256, 256), 500, true, 500);
    public DebugScene() {
        animPlayer.Play();
    }
    public void Run() {
        Raylib.ClearBackground(Color.BLUE);
        Raylib.BeginDrawing();
        animPlayer.Draw(new Vector2(0, 0), new Vector2(2, 2));
        Raylib.EndDrawing();
    }
}