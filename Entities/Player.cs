using System.Numerics;
using Raylib_cs;

namespace SiftIsland.Entites;

public class Player
{
    private const float Speed = 50;
    public Vector2 Position { get; set; }

    public Player(Vector2 position)
    {
        Position = position;
    }

    public void Update(float dt, InputState input, TileMap map)
    {
        Position += input.Move * Speed * dt;
    }

    public void Draw()
    {
        Raylib.DrawCircleV(Position, 3, Color.White);
    }
}
