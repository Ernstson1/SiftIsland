using System.Numerics;
using Raylib_cs;

namespace SiftIsland.Entites;

public class Player
{
    private const float Speed = 50;
    const float HalfW = 5f,
        HalfH = 3f;
    public Vector2 Position { get; set; }

    public Player(Vector2 position)
    {
        Position = position;
    }

    private bool Blocked(TileMap map)
    {
        float l = Position.X - HalfW;
        float r = Position.X + HalfW - 0.01f;
        float t = Position.Y - HalfH;
        float b = Position.Y + HalfH - 0.01f;

        return !map.IsWalkableAtPixel(l, t)
            || !map.IsWalkableAtPixel(r, t)
            || !map.IsWalkableAtPixel(l, b)
            || !map.IsWalkableAtPixel(r, b);
    }

    public void Update(float dt, InputState input, TileMap map)
    {
        Vector2 move = input.Move * Speed * dt;

        Position += new Vector2(move.X, 0);
        if (Blocked(map))
            Position -= new Vector2(move.X, 0);

        Position += new Vector2(0, move.Y);
        if (Blocked(map))
            Position -= new Vector2(0, move.Y);
    }

    public void Draw()
    {
        static Vector2 Snap(Vector2 v) => new(MathF.Round(v.X), MathF.Round(v.Y));
        var p = Snap(Position);
        Raylib.DrawRectangle((int)p.X - 8, (int)p.Y - 29, 16, 32, Color.White);

        // hitbox, only while debugging
        if (Game.Debug)
            Raylib.DrawRectangleLines(
                (int)(Position.X - HalfW),
                (int)(Position.Y - HalfH),
                10,
                6,
                Color.Red
            );
    }
}
