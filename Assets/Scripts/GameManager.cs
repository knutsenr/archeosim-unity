using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("Pages Tabs")]
    [SerializeField] private GameObject allTabs; // all pages to fade out 
    [SerializeField] private GameObject defaultTab; // specific field
    [SerializeField] private GameObject buttons; // specific field
    // private bool faded = false;

    [Header("Animation Elements")]
    public GameObject journal;
    [SerializeField] private float fps = 0.02f;
    public float duration = 3f;
    [SerializeField] private Sprite[] pages;

    [Header("Journal Tabs")]
    [SerializeField] public List<GameObject> tabs;
    private List<GameObject> inactiveTabs;
    [SerializeField] public Sprite[] digImages;
    private bool journalVisible = true;


    [Header("Player")]
    [SerializeField] private PlayerController player;
    private GameObject currentTile;

    public void PressTurnPage(GameObject target)
    {
        inactiveTabs = tabs;

        // fade out page
        foreach (var x in tabs) { StartCoroutine(FadeOut(x)); }

        // turn page animation
        StartCoroutine(TurnPage());

        // // bring new page up
        StartCoroutine(FadeIn(target));
    }

    public IEnumerator TurnPage()
    {
        Debug.Log("Turning page");
        for (int x = 0; x < 7; x++)
        {
            journal.GetComponent<Image>().sprite = pages[x];
            yield return new WaitForSeconds(fps);
        }
    }

    public IEnumerator FadeOut(GameObject target)
    {
        float counter = 0f;

        // Debug.Log("fade out");
        CanvasGroup targ = target.GetComponent<CanvasGroup>();

        while (counter < duration)
        {
            counter += Time.deltaTime;
            targ.alpha = Mathf.Lerp(targ.alpha, 0, counter / duration);

            yield return null;
        }
    }

    public IEnumerator FadeIn(GameObject target)
    {
        CanvasGroup targ = target.GetComponent<CanvasGroup>();

        float counter = 0f;

        while (counter < 3) { counter += Time.deltaTime; }

        counter = 0f;
        Debug.Log(target + " fade in");

        while (counter < duration)
        {
            counter += Time.deltaTime;
            targ.alpha = Mathf.Lerp(0, 1, counter / duration);

            yield return null;
        }
    }

    public void MakeVisible(GameObject obj, GameObject visibleTab)
    {
        obj.SetActive(!obj.activeInHierarchy);

        if (obj.name == "Journal")
        {
            journalVisible = !journalVisible;
            // Debug.Log("Journal Visibility " + journalVisible);

            foreach (GameObject a in WhichChild(visibleTab))
            {
                a.GetComponent<CanvasGroup>().alpha = 0;
                // Debug.Log(a + "is alpha 0");
            }
            visibleTab.GetComponent<CanvasGroup>().alpha = 1;
        }

        // Debug.Log("Button clicked " + obj.name);
    }

    private List<GameObject> WhichChild(GameObject target)
    {
        inactiveTabs = new List<GameObject>();
        foreach (GameObject z in tabs)
        {
            inactiveTabs.Add(z);
        }
        inactiveTabs.Remove(target);

        return inactiveTabs;
    }

    public void ShowCoordinates()
    {
        cam.cullingMask ^= 1 << LayerMask.NameToLayer("Coordinates");
    }

    public void Dig(Button butt)
    {
        currentTile = player.currentTile;
        int temp = currentTile.GetComponent<Tile>().DigStage();
        Image img = tabs[3].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();

        img.sprite = digImages[temp];

        // Debug.Log(tabs[3].GetComponent<Image>().sprite);


        if (temp > 3) butt.interactable = false;
    }

    void Start()
    {
        MakeVisible(journal, defaultTab);
    }

    void Update()
    {
        // if (y == false) StopAllCoroutines();
    }
}
