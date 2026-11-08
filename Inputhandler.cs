using System.Numerics;
using Raylib_cs;

namespace SiftIsland;

public struct InputState
{
    public Vector2 Move;
    public bool InteractHeld;
    public bool OpenQuestBook;
    public bool OpenInventory;
    public bool Escape;
}

public class Inputhandler
{
    public InputState Read()
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
            move = Vector2.Normalize(move);

        return new InputState
        {
            Move = move,
            InteractHeld = Raylib.IsKeyDown(KeyboardKey.F),
            OpenInventory = Raylib.IsKeyDown(KeyboardKey.E),
            OpenQuestBook = Raylib.IsKeyDown(KeyboardKey.G),
            Escape = Raylib.IsKeyDown(KeyboardKey.Escape),
        };
    }
}
