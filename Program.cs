using System.Numerics;
using Raylib_cs;
using SiftIsland;

const int GameW = 480,
    GameH = 270,
    Scale = 4;

Raylib.InitWindow(GameW * Scale, GameH * Scale, "Sift Island");
Raylib.SetTargetFPS(60);

Game game = new Game();

RenderTexture2D target = Raylib.LoadRenderTexture(GameW, GameH);
Raylib.SetTextureFilter(target.Texture, TextureFilter.Point);

while (!Raylib.WindowShouldClose())
{
    float dt = Raylib.GetFrameTime();

    game.Update(dt);

    Raylib.BeginTextureMode(target);
    Raylib.ClearBackground(Color.Black);
    game.Draw();
    Raylib.EndTextureMode();

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.DrawTexturePro(
        target.Texture,
        new Rectangle(0, 0, GameW, -GameH),
        new Rectangle(0, 0, GameW * Scale, GameH * Scale),
        Vector2.Zero,
        0f,
        Color.White
    );

    Raylib.DrawFPS(10, 10);

    Raylib.EndDrawing();
}

Raylib.UnloadRenderTexture(target);
Raylib.CloseWindow();
