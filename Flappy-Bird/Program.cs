using Raylib_cs;

Raylib.InitWindow(1280, 720, "Flappy Bird");
Raylib.SetTargetFPS(60);

Bird bird = new Bird();
bool gameIsRunning = false;
int PipesVisible = 5;
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
    }
    if (obstacles.Count < PipesVisible) {
        if (obstacles.Count() == 0 || obstacles[obstacles.Count-1].SpaceForNew(PipesVisible)) {
            obstacles.Add(new Obstacle());
            Console.WriteLine("Spawning pipe");
        }
    }
    if (obstacles[0].ShouldRemove()) {
        obstacles.RemoveAt(0); //maybe assing again?
    }
    Console.WriteLine(obstacles);

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