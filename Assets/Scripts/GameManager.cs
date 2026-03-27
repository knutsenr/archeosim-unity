using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Button journalButton;
    [SerializeField] private Camera cam;

    [Header("Pages Elements")]
    [SerializeField] private GameObject pannels;
    public float duration = 0.2f;
    private bool faded = false;

    [Header("Animation Elements")]
    [SerializeField] private GameObject journal;
    [SerializeField] private float fps = 0.02f;
    [SerializeField] private Sprite[] pages;


    void Awake()
    {

    }

    public IEnumerator TurnPage()
    {
        Debug.Log("Here");
        for (int x = 0; x < 7; x++)
        {
            journal.GetComponent<Image>().sprite = pages[x];
            yield return new WaitForSeconds(fps);
        }
    }

    public void MakeVisible()
    {
        if (journal.activeInHierarchy == false) { journal.SetActive(true); }
        else { journal.SetActive(false); }
        Debug.Log("Button clicked " + journal.activeInHierarchy);
        // Renderer red = targetObject.GetComponent<Renderer>();
        // rend.material.color = Rnadom.ColorHSV();
        // leftPage.SetActive(true);
        // rightPage.SetActive(true);
        pannels.transform.GetChild(0).gameObject.SetActive(true);
        pannels.transform.GetChild(1).gameObject.SetActive(true);
        pannels.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void showCoordinates()
    {
        cam.cullingMask ^= 1 << LayerMask.NameToLayer("Coordinates");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // journal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
