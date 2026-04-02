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

    [Header("ImageArrays")]
    public Sprite[] digImages;
    [SerializeField] private Sprite[] siftLayer1;
    [SerializeField] private Sprite[] siftLayer2;
    [SerializeField] private Sprite[] siftLayer3;

    [Header("Scripts Referenced")]
    [SerializeField] private PlayerController player;
    [SerializeField] private GameManager gameManager;

    public void OpenExcavate()
    {
        int tmp = currentTile.digStage;

        digImage.sprite = digImages[tmp];
        gameManager.MakeVisible(gameManager.journal, gameManager.tabs[3]);
    }

    public void DigNext(Button butt)
    {
        int temp = currentTile.DigStage();

        if (temp > 3) butt.interactable = false;
        else digImage.sprite = digImages[temp];

        Debug.Log(digImages[temp]);
    }

    public void Sift(Button butt)
    {
        currentLayer = currentTile.DigStage();
        Debug.Log("Sift" + currentLayer);
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
