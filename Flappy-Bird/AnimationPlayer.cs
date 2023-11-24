using System.Numerics;
using Raylib_cs;
using System.Threading;

class AnimationPlayer {
    Texture2D texture;
    public bool loop = true;
    public int frameLengthMS;
    public int frame = 0;
    Vector2 atlasCoords;
    public AnimationPlayer(Texture2D t, Vector2 AtlasCoordinates, int frameLength = 100, bool looping = true) {
        texture = t;
        frameLengthMS = frameLength;
        atlasCoords = AtlasCoordinates;
        loop = looping;
        Play();
    }

    public void Draw(Vector2 position, Vector2 scale, float rotation = 0) {
        Raylib.DrawTexturePro(
            texture,
            new Rectangle(atlasCoords.X * frame, 0, atlasCoords.X, atlasCoords.Y),
            new Rectangle(position.X, position.Y, atlasCoords.X * scale.X, atlasCoords.Y * scale.Y),
            new Vector2(0, 0),
            rotation,
            Color.WHITE
        );
    }

    Thread workerThread = new Thread(Animate);
    public void Play() {
        workerThread.Start(this); // försöker fixa flera parametrar in i den
    }

    static public void Animate(object o) {
        AnimationPlayer animationplayer = (AnimationPlayer) o;
        
        // counting the frames in texture spreadsheet
        int totalFrames = 0;
        while (animationplayer.atlasCoords.X * totalFrames < animationplayer.texture.Width) {
            totalFrames++;
        }


        while (true) {
            if (animationplayer.frame == totalFrames) {
                animationplayer.frame = 0;
            }
            else {
                animationplayer.frame++;
            }

            if (!animationplayer.loop) {
                animationplayer.workerThread.Interrupt();

            }
            Thread.Sleep(animationplayer.frameLengthMS);
        }
    }
}