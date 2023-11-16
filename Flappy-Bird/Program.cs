using Raylib_cs;

Raylib.InitWindow(1280, 720, "Flappy Bird");
Raylib.SetTargetFPS(60);

Bird bird = new Bird();
bool gameIsRunning = false;
int PipesVisible = 4;
List<Obstacle> obstacles = new();

while (!Raylib.WindowShouldClose()) {
    if (!gameIsRunning) {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            gameIsRunning = true;
        }
        Draw();
        continue;
    }
    bird.Tick();

    foreach (Obstacle o in obstacles) {
        o.Tick();
        Console.WriteLine(o.isColliding(bird.GetRect()));        
    }
    if (obstacles.Count < PipesVisible) {
        if (obstacles.Count() == 0 || obstacles[obstacles.Count-1].SpaceForNew(PipesVisible)) {
            obstacles.Add(new Obstacle());
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
    bird.Draw();
    Raylib.EndDrawing();
    foreach (Obstacle o in obstacles) {
        o.Draw();
    }
}