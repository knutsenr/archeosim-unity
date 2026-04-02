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
    private bool journalVisible = true;


    [Header("Referenced Scripts")]
    [SerializeField] private PlayerController player;
    [SerializeField] private ExcavateManager excavate;

    public void PressTurnPage(GameObject target)
    {
        // fade out page
        foreach (var x in tabs) { StartCoroutine(FadeOut(x)); }

        // turn page animation
        StartCoroutine(TurnPage());

        // // bring new page up
        StartCoroutine(FadeIn(target));

        foreach (var x in WhichChild(target)) x.SetActive(false);
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
        target.SetActive(true);
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
        if (obj.name == "Journal")
        {
            journalVisible = !journalVisible;
            Debug.Log("Journal Visibility " + journalVisible);

            foreach (GameObject a in WhichChild(visibleTab))
            {
                a.GetComponent<CanvasGroup>().alpha = 0;
                a.SetActive(false);
            }
            // visibleTab.SetActive(!obj.activeInHierarchy);
            visibleTab.SetActive(!obj.activeInHierarchy);
            visibleTab.GetComponent<CanvasGroup>().alpha = 1;
        }

        obj.SetActive(!obj.activeInHierarchy);
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

    void Start()
    {
        MakeVisible(journal, defaultTab);
    }

    void Update()
    {
        // if (y == false) StopAllCoroutines();
    }
}
