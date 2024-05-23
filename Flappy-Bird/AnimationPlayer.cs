using System.Numerics;
using Raylib_cs;
using System.Threading;

class AnimationPlayer {
    private Texture2D texture;
    private bool loop = true;
    public bool Loop {private get {return loop;} set => loop = value; }
    public int FrameLengthMS { get {return frameLengthMS;} set {frameLengthMS = value;}}
    private int frameLengthMS = 100;
    public int Frame { get => frame; set => frame = value; }
    private int frame = 0;
    private Vector2 atlasCoords;
    private bool playing = false;
    private int crossFadeMS = 0;
    private Thread workerThread = new Thread(Animate);
    private List<int> frameVisibility = new();
    private int totalFrames = 0;

    public AnimationPlayer(Texture2D t, Vector2 AtlasCoordinates, int frameLength = 100, bool looping = true, int crossFadeMilliSeconds = 0) { // Takes in the required and optional paramaters and sets them.
        texture = t;
        FrameLengthMS = frameLength;
        atlasCoords = AtlasCoordinates;
        Loop = looping;
        crossFadeMS = crossFadeMilliSeconds;
        workerThread.Start(this);
    }

    public void Draw(Vector2 position, Vector2 scale, float rotation = 0) { // Using Raylib, this method will draw the current frame at the given position, scale and rotation. This should be called after Raylib.BeginDrawing().
        Raylib.DrawTexturePro(
            texture,
            new Rectangle(atlasCoords.X * Frame, 0, atlasCoords.X, atlasCoords.Y),
            new Rectangle(position.X, position.Y, atlasCoords.X * scale.X, atlasCoords.Y * scale.Y),
            new Vector2(0, 0),
            rotation,
            Color.WHITE
        );
    }

    public void Play() { // Starts playing the animation. Calling play while playing wont restart the animation, there is currently no way to cancel the animation. You may use Stop() for that.
        
        // counting the frames in texture spritesheet
        totalFrames = 0;
        while (atlasCoords.X * totalFrames < texture.Width) {
            frameVisibility.Add(0);
            totalFrames++;
        }

        playing = true;
    }
    public void Stop() { // Will finish animation the current loop, and then stop animating.
        playing = false;
    }

    static public void Animate(object o) { // Being called by a Thread automatically.
        AnimationPlayer animationplayer = (AnimationPlayer) o;

        // float frameLoop = 0;
        while (!Raylib.WindowShouldClose()) {
            // Work in progress, crossfading ability.
            // int crossFadeMS = 200;
            // frameLoop = ((float)(Raylib.GetTime()/100)*crossFadeMS % animationplayer.totalFrames);// / crossFadeMS;
            // Console.WriteLine(frameLoop);

            if (animationplayer.playing) { // Plays the animation.
                if (animationplayer.Frame == animationplayer.totalFrames) {
                    animationplayer.Frame = 0;
                    if (!animationplayer.Loop) {
                        animationplayer.playing = false;
                    }
                }
                else {
                    animationplayer.Frame++;
                }
                Thread.Sleep(animationplayer.FrameLengthMS);
            }
        }
    }

    static public void CrossFade(object o) { // Work in progress
        
    }
}