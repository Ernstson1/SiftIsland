using System.Numerics;
using System.Text.Json;
using Raylib_cs;

namespace SiftIsland;

public class TileMap
{
    public const int TileSize = 16;
    public int Width { get; }
    public int Height { get; }
    readonly TileType[,] tiles;

    public int PixelWidht => Width * TileSize;
    public int PixelHeight => Height * TileSize;

    static readonly Color GrassColor = new(123, 192, 67, 255); // #7BC043
    static readonly Color WaterColor = new(66, 135, 245, 255); // #7BC043

    public TileMap(int widht, int height, TileType[,] tiles)
    {
        Width = widht;
        Height = height;
        this.tiles = tiles;
    }

    public static TileMap LoadFromJson(string path)
    {
        var json = File.ReadAllBytes(path);
        var data = JsonSerializer.Deserialize<MapData>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        )!;

        var tiles = new TileType[data.Width, data.Height];
        for (int y = 0; y < data.Height; y++)
        {
            for (int x = 0; x < data.Width; x++)
            {
                tiles[x, y] = (TileType)data.Tiles[y][x];
            }
        }

        return new TileMap(data.Width, data.Height, tiles);
    }

    public Vector2 Center => new(PixelWidht / 2f, PixelHeight / 2f);

    public bool IsWalkable(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
            return false;
        return tiles[x, y] == TileType.Grass;
    }

    public bool IsWalkableAtPixel(float px, float py) =>
        IsWalkable((int)MathF.Floor(px / TileSize), (int)MathF.Floor(py / TileSize));

    public void Draw()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                DrawTile(tiles[x, y], x, y);
            }
        }
    }

    private void DrawTile(TileType type, int x, int y)
    {
        Color color = type switch
        {
            TileType.Grass => GrassColor,
            TileType.Water => WaterColor,
            _ => Color.Magenta,
        };

        Raylib.DrawRectangle(x * TileSize, y * TileSize, TileSize, TileSize, color);
    }
}
