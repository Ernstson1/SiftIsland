namespace SiftIsland;

public class MapData
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int[][] Tiles { get; set; } = Array.Empty<int[]>();
}
