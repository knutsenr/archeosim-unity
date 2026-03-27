using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Events;
using System;

public class SmallTile : MonoBehaviour
{
    [SerializeField] public Color baseColor, obstacleColor, artifactColor, nothingColor;
    private int x = 0;
    [SerializeField] private Image im;
    private string currentCoordinateName;
    public bool canDig = true;
    public bool digArtifact = false;
    public bool digNothing = true;

    public void SwitchColor()
    {
        if (x > 3) x = 0; else x++;

        // (x > 3) ? (x = 0) : x++;
        Debug.Log(x);

        switch (x)
        {
            case 0:
                im.color = baseColor;
                break;
            case 1:
                im.color = obstacleColor;
                break;
            case 2:
                im.color = nothingColor;
                break;
            case 3:
                im.color = artifactColor;
                break;
            default:
                im.color = baseColor;
                break;
        }
        // butt.colors = cb;
    }

    // public void Init(bool isOffset)
    // {
    //     im.color = isOffset ? offsetColor : baseColor;
    // }

    void Start()
    {
        // ColorBlock cb = button.colors;
        // cb.normalColor = newColor;
        // butt.colors = cb;
    }
}
