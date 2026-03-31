using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color artifactColor, emptyColor;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] public GameObject hilight;
    [SerializeField] private GameObject spriteLayer;
    [SerializeField] private GameObject obstacleLayer;
    [SerializeField] private GameObject excavatedLayer;
    [SerializeField] private Collider2D coll;
    public TextMeshProUGUI coordinateBox;

    public int artifactChance;
    public int obstacleChance;
    public bool isExcavated = false;

    public void Init(bool isOffset, int rand)
    {
        // rend.color = isOffset ? artifactColor : emptyColor;

        // spriteLayer.GetComponent<SpriteRenderer>().flipX = isOffset ? true : false;

        if (rand < obstacleChance) { IsObstacle(); } else if (rand < artifactChance + obstacleChance) { IsArtifact(); } else { IsEmpty(); }
    }

    public void IsObstacle()
    {
        obstacleLayer.SetActive(true);
        coll.isTrigger = false;
        gameObject.tag = "Unit_Obstacle";
    }

    public void IsArtifact()
    {
        gameObject.tag = "Unit_Artifact";
        excavatedLayer.GetComponent<SpriteRenderer>().color = artifactColor;
    }

    public void IsEmpty()
    {
        gameObject.tag = "Unit_Empty";
        excavatedLayer.GetComponent<SpriteRenderer>().color = emptyColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hilight.SetActive(true);
        other.gameObject.GetComponent<PlayerController>().currentTile = this.gameObject;
        // if (other.gameObject.GetComponent<PlayerController>().isDigging) Dig();
        // else Debug.Log("Already excavated!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hilight.SetActive(false);
        if (isExcavated) excavatedLayer.SetActive(true);
    }

    public void Dig()
    {
        isExcavated = true;
        if (gameObject.tag == "Unit_Artifact") Debug.Log("Artifact found!");
        else Debug.Log("Jack Shit");
    }
}
