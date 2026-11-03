using System.Numerics;

namespace SiftIsland.Entites;

public abstract class Entity
{
    public Vector2 Position { get; set; }

    protected Entity(Vector2 position)
    {
        Position = position;
    }

    public abstract void Update(float dt);
    public abstract void Draw();
}
