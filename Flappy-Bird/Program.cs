using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1280, 720, "Flappy Bird");
Raylib.SetTargetFPS(60);

Bird bird = new Bird();
bool gameIsRunning = false;
int PipesVisible = 4;
List<Obstacle> obstacles = new();

AnimationPlayer anim = new AnimationPlayer(Raylib.LoadTexture("Assets/Player/bird1.png"), new Vector2(16, 16), 100);

while (!Raylib.WindowShouldClose()) {
    if (!gameIsRunning) {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            gameIsRunning = true;
            bird.Tick();
        }
        Draw();
        continue;
    }
    bird.Tick();

    foreach (Obstacle o in obstacles) {
        o.Tick();
        if (o.isColliding(bird.GetRect())) {
            bird.isAlive = false;
        }
    }
    if (obstacles.Count < PipesVisible) {
        if (obstacles.Count() == 0 || obstacles[obstacles.Count-1].SpaceForNew(PipesVisible)) {
            obstacles.Add(new Obstacle(bird));
        }
    }
    if (obstacles[0].ShouldRemove()) {
        obstacles.RemoveAt(0);
    }

    Draw();
}

void Draw() {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.BeginDrawing();
    foreach (Obstacle o in obstacles) {
        o.Draw();
    }
    bird.Draw();
    if (!bird.isAlive) {
        Raylib.DrawText("The bird got dedded", Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2, 48, Color.BLACK);
    }
    if (!gameIsRunning) {
        Raylib.DrawText("Press SPACE to flap", Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2, 48, Color.BLACK);
    }
    Raylib.EndDrawing();
}