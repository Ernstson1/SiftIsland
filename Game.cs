using System.Numerics;
using SiftIsland.Entites;

namespace SiftIsland;

public class Game
{
    private List<Entity> entities = new List<Entity> { new Player(new Vector2(400, 300)) };

    public void Update(float dt)
    {
        foreach (var e in entities)
            e.Update(dt);
    }

    public void Draw()
    {
        foreach (var e in entities)
            e.Draw();
    }
}
