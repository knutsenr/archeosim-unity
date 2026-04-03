using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ExcavateManager : MonoBehaviour
{
    private Tile currentTile;
    private int currentLayer;

    [Header("Local Component References")]
    [SerializeField] private Image digImage;
    [SerializeField] private Image siftImage;
    [SerializeField] private float fps = 0.4f;

    [Header("ImageArrays")]
    public Sprite[] digImages;
    [SerializeField] private Sprite[] siftLayer1;
    [SerializeField] private Sprite[] siftLayer2;
    [SerializeField] private Sprite[] siftLayer3;
    [SerializeField] private Sprite[] artifactImages;

    [Header("Artifacts")]
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private GridLayoutGroup allArtifactGrid;
    [SerializeField] private Artifact artifactPrefab;
    public List<Artifact> allArtifacts;

    [Header("Scripts Referenced")]
    [SerializeField] private PlayerController player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SmallTile tile;

    private bool layerSifted = false;
    private int tempLayer = 0;

    public void OpenExcavate()
    {
        int tmp = currentTile.digStage;

        digImage.sprite = digImages[tmp];
        gameManager.MakeVisible(gameManager.journal, gameManager.tabs[3]);
    }

    public void DigNext(Button butt)
    {
        tempLayer = currentTile.DigStage();

        if (tempLayer > 3) butt.interactable = false;
        else
        {
            digImage.sprite = digImages[tempLayer];
            siftImage.sprite = tempLayer switch
            {
                1 => siftLayer1[0],
                2 => siftLayer2[0],
                3 => siftLayer3[0],
                _ => siftLayer1[0],
            };
        }

        Debug.Log(digImages[tempLayer]);
    }

    public void Sift(Button butt)
    {
        StartCoroutine(AnimateSift(tempLayer));

        if (currentTile.tag == "Unit_Artifact" && tempLayer == currentTile.artLayer)
        {
            Debug.Log("Artifact in " + tempLayer);
            DisplayArtifact();
        }
    }

    public IEnumerator AnimateSift(int layer)
    {
        Debug.Log("Sifting switch  " + layer);
        for (int x = 0; x < 5; x++)
        {
            siftImage.sprite = layer switch
            {
                1 => siftLayer1[x],
                2 => siftLayer2[x],
                3 => siftLayer3[x],
                _ => siftLayer1[0],
            };
            yield return new WaitForSeconds(fps);
        }

        layerSifted = true;
    }

    public void DisplayArtifact()
    {
        Debug.Log(currentTile.artifact + " found in layer " + tempLayer);
        Artifact art = Instantiate(artifactPrefab, gridLayout.transform);

        art.unitText.text = "Unit: " + $"({currentTile.coordinateBox.text})";
        art.layerText.text = "Layer: " + $"{tempLayer}";
        art.artifactText.text = currentTile.artifact;

        if (currentTile.artifact == "Artifact") { art.image.sprite = artifactImages[0]; }
        else { art.image.sprite = artifactImages[1]; }

        allArtifacts.Add(art);
    }

    public void ShowArtifacts()
    {
        // foreach (var z in allArtifacts)
        // {
        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Artifact art = Instantiate(allArtifacts[x], allArtifactGrid.transform);
                // SmallTile art = Instantiate(tile, allArtifactGrid.transform);
            }
        }
        // }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTile = player.currentTile.GetComponent<Tile>();
    }
}
