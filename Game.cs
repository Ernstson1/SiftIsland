using System.Numerics;
using Raylib_cs;
using SiftIsland.Entites;

namespace SiftIsland;

public class Game
{
    readonly Player player;
    readonly Inputhandler inputHandler = new();
    readonly TileMap map;

    // Temporary:
    Camera2D camera = new()
    {
        Offset = new Vector2(480 / 2f, 270 / 2f), // the screen center
        Zoom = 2f,
    };

    public Game()
    {
        map = TileMap.LoadFromJson("Data/island.json");
        player = new Player(map.Center);
    }

    public void Update(float dt)
    {
        InputState input = inputHandler.Read();
        player.Update(dt, input, map);
    }

    public void Draw()
    {
        camera.Target = player.Position;

        Raylib.BeginMode2D(camera);
        map.Draw();
        player.Draw();
        Raylib.EndMode2D();
    }
}
