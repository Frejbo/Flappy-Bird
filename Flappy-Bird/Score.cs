using System.Runtime;
using System.Numerics;
using Raylib_cs;
class Score {
    static public int score = 0;
    public void DrawScore() {
        Raylib.DrawText(score.ToString(), 16, 16, 48, Color.BLACK);
    }
}