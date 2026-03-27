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

    // [SerializeField] private TMP_Text coordinatePairText;
    private int randomX;
    private int randomY;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = wid;

        GenerateGrid();
        // PickCoordinate();

    }

    void GenerateGrid()
    {
        for (int y = 0; y < hei; y++)
        {
            for (int x = 0; x < wid; x++)
            {
                SmallTile spawnedTile = Instantiate(tilePrefab, grid.transform);
                spawnedTile.name = $"{x}, {y}";

                TMP_Text text = spawnedTile.GetComponentInChildren<TMP_Text>();
                text.text = spawnedTile.name;

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                // spawnedTile.Init(isOffset);

                // tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
