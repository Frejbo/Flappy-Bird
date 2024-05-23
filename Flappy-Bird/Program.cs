using System.Numerics;
using Raylib_cs;

// Set up Raylib window
Raylib.InitWindow(1280, 720, "Flappy Bird");
Raylib.SetTargetFPS(60);

Bird bird = new Bird();
bool gameIsRunning = false;
int PipesVisible = 4;
List<Obstacle> obstacles = new();

while (!Raylib.WindowShouldClose()) { // Run gameloop until window is closed
    if (!gameIsRunning) { // If game isn't running, wait for it to start and animate bird.
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
            gameIsRunning = true;
            bird.Tick();
        }
        Draw();
        continue;
    }
    bird.Tick(); // Always update the bird when game is running

    foreach (Obstacle o in obstacles) { // Check if any obstacle is colliding with the bird and if there is, kill the bird.
        o.Tick();
        if (o.isColliding(bird.GetRect())) {
            bird.Kill();
            Console.WriteLine("Killing bird");
        }
    }
    if (obstacles.Count < PipesVisible) { // If there is too few obstacles visible, see if there is space to spawn a new and if there is, spawn new obstacle.
        if (obstacles.Count() == 0 || obstacles[obstacles.Count-1].SpaceForNew(PipesVisible)) {
            obstacles.Add(new Obstacle(bird));
        }
    }
    if (obstacles[0].ShouldRemove()) { // Check if any obstacles should be removed
        obstacles.RemoveAt(0);
    }

    Draw(); // Draw every frame
}

void Draw() { // Draws everything using Raylib
    Raylib.ClearBackground(Color.BLUE); // Set bg
    Raylib.BeginDrawing(); // Start drawing
    foreach (Obstacle o in obstacles) { // Draw obstacles
        o.Draw();
    }
    bird.Draw(); // Draw bird
    if (!bird.IsAlive) { // if bird died, draw dead text.
        Raylib.DrawText("The bird got dedded", Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2, 48, Color.BLACK);
    }
    if (!gameIsRunning) { // Show how to play and start the game if it isn't running.
        Raylib.DrawText("Press SPACE to flap", Raylib.GetScreenWidth()/2, Raylib.GetScreenHeight()/2, 48, Color.BLACK);
    }
    
    Raylib.EndDrawing(); // Stop drawing
}