using System.Numerics;
using Raylib_cs;

class AnimationPlayer {
    Texture2D texture;
    public bool loop = true;
    public int frameLengthMS;
    Vector2 AtlasCoords;
    public AnimationPlayer(Texture2D t, Vector2 AtlasCoordinates, int frameLength = 100) {
        texture = t;
        frameLengthMS = frameLength;
        AtlasCoords = AtlasCoordinates;
    }
    // I'll try to make this threaded
}