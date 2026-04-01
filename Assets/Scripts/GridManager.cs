using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    [Header("Big Grid Variables")]
    [SerializeField] private int wid, hei;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    private Dictionary<Vector2, Tile> tiles;
    private int rand;

    [Header("Small Grid Variables")]
    [SerializeField] private SmallTile smallTilePrefab;
    [SerializeField] private GridLayoutGroup gridLayout;
    private Dictionary<Vector2, SmallTile> smallTiles;


    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        smallTiles = new Dictionary<Vector2, SmallTile>();

        for (int y = 0; y < hei; y++)
        {
            for (int x = 0; x < wid; x++)
            {
                FinishPrimaryGrid(x, y);

                FinishSmallGrid(x, y);
            }
        }

        cam.transform.position = new Vector3((float)wid / 2 - 0.5f, (float)hei / 2 - 0.5f, -10);
    }

    private void FinishPrimaryGrid(int x, int y)
    {
        // Instantiate Big Grid 
        Tile tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
        tile.name = $"Tile {x} {y}";
        tile.coordinateBox.text = $"{x}, {y}";
        tiles[new Vector2(x, y)] = tile;

        rand = Random.Range(0, 100);
        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

        tile.Init(isOffset, rand);
    }

    private void FinishSmallGrid(int x, int y)
    {
        // Instantiate Small Journal Grid
        SmallTile tile = Instantiate(smallTilePrefab, gridLayout.transform);
        // // smallTiles[new Vector2(x, y)] = smallSpawnedTile;
        tile.name = $"{x}, {y}";
        tile.buttonCoordinate.text = tile.name;
    }

    void Start()
    {
        GenerateGrid();
    }

    // public Tile GetTileAtPosition(Vector2 pos)
    // {
    //     if (tiles.TryGetValue(pos, out var tile))
    //     {
    //         return tile;
    //     }
    //     return null;
    // }

}
