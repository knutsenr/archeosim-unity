using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] public GameObject hilight;
    [SerializeField] private GameObject spriteLayer;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Collider2D coll;
    public TextMeshProUGUI coordinateBox;

    public bool canDig = true;
    public bool digArtifact = false;
    public bool digNothing = true;


    public void Init(bool isOffset, int rand)
    {
        rend.color = isOffset ? offsetColor : baseColor;

        spriteLayer.GetComponent<SpriteRenderer>().flipX = isOffset ? true : false;

        if (rand < 5) { IsObstacle(); } else if (rand > 5 && rand < 60) { digArtifact = true; } else { canDig = true; digNothing = true; }
    }

    public void IsObstacle()
    {
        obstacle.SetActive(true);
        coll.isTrigger = false;

        canDig = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hilight.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hilight.SetActive(false);
    }

}
