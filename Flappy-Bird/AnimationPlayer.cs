using System.Numerics;
using Raylib_cs;
using System.Threading;

class AnimationPlayer {
    Texture2D texture;
    public bool loop = true;
    public int frameLengthMS;
    int frame = 0;
    Vector2 AtlasCoords;
    public AnimationPlayer(Texture2D t, Vector2 AtlasCoordinates, int frameLength = 100) {
        texture = t;
        frameLengthMS = frameLength;
        AtlasCoords = AtlasCoordinates;
        Play();
    }

    public void Play() {
        Thread workerThread = new Thread(Animate);
        workerThread.Start("hej"); // försöker fixa flera parametrar in i den

    }

    static public void Animate(object o) {
        Console.WriteLine(o);
    }
    // I'll try to make this threaded
}