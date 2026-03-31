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

    public int artifactChance;
    public int obstacleChance;
    public bool excavated = false;

    public void Init(bool isOffset, int rand)
    {
        rend.color = isOffset ? offsetColor : baseColor;

        // spriteLayer.GetComponent<SpriteRenderer>().flipX = isOffset ? true : false;

        if (rand < obstacleChance) { IsObstacle(); } else if (rand < artifactChance + obstacleChance) { IsArtifact(); } else { IsEmpty(); }
    }

    public void IsObstacle()
    {
        obstacle.SetActive(true);
        coll.isTrigger = false;
        gameObject.tag = "Unit_Obstacle";
    }

    public void IsArtifact() { gameObject.tag = "Unit_Artifact"; }

    public void IsEmpty() { gameObject.tag = "Unit_Empty"; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hilight.SetActive(true);
        if (!excavated) Dig(); else Debug.Log("Already excavated!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hilight.SetActive(false);
    }

    public void Dig()
    {
        excavated = true;

        if (gameObject.tag == "Unit_Artifact") Debug.Log("Artifact found!");
        else Debug.Log("Jack Shit");
    }
}
