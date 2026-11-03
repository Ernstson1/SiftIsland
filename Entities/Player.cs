using System.Numerics;
using Raylib_cs;

namespace SiftIsland.Entites;

public class Player : Entity
{
    private const float Speed = 300;

    public Player(Vector2 position)
        : base(position) { }

    public override void Update(float dt)
    {
        var move = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.W))
            move.Y -= 1;

        if (Raylib.IsKeyDown(KeyboardKey.A))
            move.X -= 1;

        if (Raylib.IsKeyDown(KeyboardKey.D))
            move.X += 1;

        if (Raylib.IsKeyDown(KeyboardKey.S))
            move.Y += 1;

        if (move != Vector2.Zero)
            Position += Vector2.Normalize(move) * Speed * dt;
    }

    public override void Draw()
    {
        Raylib.DrawCircleV(Position, 20, Color.White);
    }
}
