// using UnityEngine;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections;

// public class SmallGridManager : MonoBehaviour
// {
//     [SerializeField] private GridLayoutGroup gridLayout;
//     [SerializeField] private int wid, hei;
//     [SerializeField] private SmallTile smallTilePrefab;
//     private Dictionary<Vector2, SmallTile> smallTiles;

//     void Start()
//     {
//         // grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
//         // grid.constraintCount = wid;

//         GenerateSmallGrid();
//     }

//     void GenerateSmallGrid()
//     {
//         smallTiles = new Dictionary<Vector2, SmallTile>();

//         for (int y = 0; y < hei; y++)
//         {
//             for (int x = 0; x < wid; x++)
//             {
//                 // SmallTile smallSpawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
//                 SmallTile smallSpawnedTile = Instantiate(smallTilePrefab, gridLayout.transform);

//                 smallTiles[new Vector2(x, y)] = smallSpawnedTile;
//                 smallSpawnedTile.name = $"{x}, {y}";

//                 smallSpawnedTile.smallCoordinate.text = $"{x}, {y}";

//                 // Debug.Log($"{x}, {y}");

//                 // var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

//                 // smallSpawnedTile.Init(isOffset);

//                 // tiles[new Vector2(x, y)] = smallSpawnedTile;
//             }
//         }
//     }


//     // private static SmallGridManager _instance;
//     // public static SmallGridManager Instance // yes this one is cap
//     // {
//     //     get
//     //     {
//     //         if (_instance == null)
//     //         {
//     //             Debug.LogError("Smallgrid null");
//     //         }

//     //         return _instance;
//     //     }
//     // }

//     private void Awake()
//     {
//         // _instance = this;
//     }


// }
