using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

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
    public int digStage = 0;
    public string artifact;
    public int artLayer;

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
        int artRand = Random.Range(5, 0); // return 1, 2, 3, 4, or 5. i think.
        artLayer = Random.Range(3, 0); // return 1, 2, or 3

        // Which artifact   
        artifact = artRand switch
        {
            5 => "Artifact",
            3 => "Feature",
            4 => "Feature",
            _ => "Chert",
        };

        gameObject.tag = "Unit_Artifact";
        // excavatedLayer.GetComponent<SpriteRenderer>().color = artifactColor;
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

        if (this.gameObject.tag == "Unit_Artifact") { Debug.Log("Dig Here"); }
        // if (other.gameObject.GetComponent<PlayerController>().isDigging) Dig();
        // else Debug.Log("Already excavated!");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hilight.SetActive(false);
        if (isExcavated) excavatedLayer.SetActive(true);
    }

    public int DigStage()
    {
        if (digStage < 3)
        {
            Debug.Log(digStage);
            digStage++;
            if (digStage > 2) isExcavated = true;
        }
        return digStage;
    }
}
