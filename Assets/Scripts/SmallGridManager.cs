using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SmallGridManager : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private int wid, hei;
    [SerializeField] private SmallTile tilePrefab;
    private Dictionary<Vector2, SmallTile> tiles;

    private static SmallGridManager _instance;
    public static SmallGridManager Instance // yes this one is cap
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Smallgrid null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        // grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        // grid.constraintCount = wid;

        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, SmallTile>();

        for (int y = 0; y < hei; y++)
        {
            for (int x = 0; x < wid; x++)
            {
                // SmallTile spawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                SmallTile spawnedTile = Instantiate(tilePrefab, grid.transform);

                tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.name = $"{x}, {y}";

                spawnedTile.coordinateBox.text = $"{x}, {y}";

                // Debug.Log($"{x}, {y}");

                // var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                // spawnedTile.Init(isOffset);

                // tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }



}
