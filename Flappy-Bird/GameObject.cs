using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;

class GameObject {
    // Properties for basic game objects.
    private Vector2 position = new Vector2();
    public Vector2 Position {get {return position;} set {position = value;}}
    private Random randomizer = new Random();
    public Random Randomizer {private set {} get {return randomizer;}}
    private float rotation = 0;
    public float Rotation {set {rotation = value;} get {return rotation;}}

}