using System.Numerics;
using Raylib_cs;
using SiftIsland;

Raylib.InitWindow(1920, 1080, "Sift Island");
Raylib.SetTargetFPS(60);

Game game = new Game();

// RenderTexture2D target = Raylib.LoadRenderTexture(480, 270);
while (!Raylib.WindowShouldClose())
{
    float dt = Raylib.GetFrameTime();

    game.Update(dt);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.DrawFPS(10, 10);

    game.Draw();
    Raylib.EndDrawing();
}

Raylib.CloseWindow();
