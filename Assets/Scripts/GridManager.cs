using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int wid, hei;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    private int rand;

    private Dictionary<Vector2, Tile> tiles;

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < wid; x++)
        {
            for (int y = 0; y < hei; y++)
            {
                rand = Random.Range(0, 100);
                var spawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                spawnedTile.Init(isOffset, rand);

                tiles[new Vector2(x, y)] = spawnedTile;

                spawnedTile.coordinateBox.text = $"{x}, {y}";
            }
        }

        cam.transform.position = new Vector3((float)wid / 2 - 0.5f, (float)hei / 2 - 0.5f, -10);
    }

    void Start()
    {
        GenerateGrid();
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }

}
