using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Events;
using System;

public class SmallTile : MonoBehaviour
{
    [SerializeField] public Color baseColor, obstacleColor, artifactColor, emptyColor;
    private int x = 0;
    [SerializeField] private Image im;
    [SerializeField] public TextMeshProUGUI buttonCoordinate;

    public void SwitchColor()
    {
        if (x > 3) x = 0; else x++;
        Debug.Log(x);

        im.color = x switch
        {
            0 => baseColor,
            1 => obstacleColor,
            2 => emptyColor,
            3 => artifactColor,
            _ => baseColor,
        };
    }
}
