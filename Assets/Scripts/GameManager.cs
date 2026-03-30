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
    [SerializeField] private GameObject journal;
    [SerializeField] private float fps = 0.02f;
    public float duration = 3f;
    [SerializeField] private Sprite[] pages;

    [Header("Journal Tabs")]
    [SerializeField] private List<GameObject> tabs;
    private List<GameObject> inactiveTabs;


    public void PressTurnPage(GameObject target)
    {
        inactiveTabs = tabs;
        // fade out page
        // StartCoroutine(FadeOut(WhichChild(0)));
        // StartCoroutine(FadeOut(WhichChild(1)));
        // foreach (var x in tabs) { Debug.Log(x); }
        foreach (var x in tabs) { StartCoroutine(FadeOut(x)); }

        StartCoroutine(TurnPage());
        // faded = !faded;

        // // bring new page up
        StartCoroutine(FadeIn(target));
        // faded = !faded;
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

        Debug.Log("fade out");
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

    public void MakeVisible(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);

        // if (obj.activeInHierarchy) obj.SetActive(false);  obj.SetActive(true);

        if (obj.name == "Journal")
        {
            Debug.Log("Journal Visibility");
            // defaultTab.SetActive(obj.activeInHierarchy);
            // buttons.SetActive(obj.activeInHierarchy);
        }
        // else if (obj.transform.childCount > 0) { AbleChildren(obj); }

        Debug.Log("Button clicked " + obj.name);
    }

    private List<GameObject> WhichChild(GameObject target)
    {
        inactiveTabs.Remove(target);

        return inactiveTabs;
    }

    public void AbleChildren(GameObject parent)
    {
        // Debug.Log("disable children");
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i).gameObject;

            child.SetActive(!child.activeSelf);
        }
    }

    public void ShowCoordinates()
    {
        cam.cullingMask ^= 1 << LayerMask.NameToLayer("Coordinates");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeVisible(journal);
    }

    void Update()
    {
        // if (y == false) StopAllCoroutines();
    }
}
