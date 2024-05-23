using System.Runtime;
using System.Numerics;
using Raylib_cs;
class Score {
    static public int Amount {
        get {
            return amount;
        }
        set {
            amount = Math.Max(value, 0);
        }
    }
    static private int amount = 0;
    public void DrawScore() { // Draws the score using Raylib. Should be called after Raylib.BeginDrawing().
        Raylib.DrawText(amount.ToString(), 16, 16, 48, Color.BLACK);
    }
}