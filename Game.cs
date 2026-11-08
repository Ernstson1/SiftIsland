using System.Numerics;
using SiftIsland.Entites;

namespace SiftIsland;

public class Game
{
    readonly Player player = new Player(new Vector2(400, 300));
    readonly Inputhandler inputHandler = new();

    public void Update(float dt)
    {
        InputState input = inputHandler.Read();
        player.Update(dt, input);
    }

    public void Draw()
    {
        player.Draw();
    }
}
