using Raylib_cs;

Raylib.InitWindow(1280, 720, "Flappy Bird");
Raylib.SetTargetFPS(60);

Bird bird = new Bird();
bool gameIsRunning = false;

while (!Raylib.WindowShouldClose()) {
    if (!gameIsRunning) {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            gameIsRunning = true;
        }
        Draw();
        continue;
    }
    bird.Tick();
    Draw();
}

void Draw() {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.BeginDrawing();
    bird.Draw();
    Raylib.EndDrawing();
}