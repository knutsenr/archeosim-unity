using UnityEngine;
using System.Collections;
using UnityEngine.U2D.Animation;
using System.Linq;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    // [Header("Journal Elements")]
    [SerializeField] private GameManager manager;
    // [SerializeField] private GameObject openButton;
    // // public SpriteLibraryAsset pagesLibrary;

    // [Header("Animation Elements")]
    // [SerializeField] private Image im;
    // [SerializeField] private int fps;
    // [SerializeField] private Sprite[] pages;
    // private Coroutine co;


    // [Header("Pages Elements")]
    // // [SerializeField] private Panel leftPage;
    // // [SerializeField] private Panel rightPage;
    // public float duration = 0.4f;
    // private bool faded = false;

    // Update is called once per frame

    [Header("Pages Elements")]
    [SerializeField] private GameObject allPages; // all pages to fade out 
    [SerializeField] private GameObject targetField; // specific field
    private float duration = 2f;
    private bool faded = false;

    [Header("Animation Elements")]
    [SerializeField] private GameObject journal;
    [SerializeField] private float fps = 0.02f;
    // [SerializeField] private Sprite[] pagesArray;


    // [SerializeField] private Button currentButton;


    void Awake()
    {
        // im = GetComponent<Image>();
        // rend.sprite = pagesLibrary.GetSprite("pages", "pageAnim_0");
    }

    // public void MakeVisible(GameObject obj)
    // {
    //     if (obj.activeInHierarchy == false) { obj.SetActive(true); }
    //     else { obj.SetActive(false); }
    //     Debug.Log("Button clicked " + obj.activeInHierarchy);
    //     // Renderer red = targetObject.GetComponent<Renderer>();
    //     // rend.material.color = Rnadom.ColorHSV();
    // }

    public void PressTurnPage()
    {
        // fade out page
        var canvasGroup = allPages.GetComponent<CanvasGroup>();
        StartCoroutine(FadeOut(canvasGroup, canvasGroup.alpha, 0));
        faded = !faded;

        StartCoroutine(manager.TurnPage());
        Debug.Log("turn");
        // journal.GetComponent<Image>().sprite = pagesArray[0];

        DisableChildren(allPages.transform.GetChild(0).gameObject);
        DisableChildren(allPages.transform.GetChild(1).gameObject);

        // bring new page up
        StartCoroutine(FadeIn(canvasGroup, canvasGroup.alpha, 1));
        // faded = !faded;
    }



    public IEnumerator FadeOut(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }

    public IEnumerator FadeIn(CanvasGroup canvasGroup, float start, float end)
    {
        targetField.SetActive(true);

        float counter = 0f;

        while (counter < 3) { counter += Time.deltaTime; }

        counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, counter / duration);

            yield return null;
        }
    }

    // private IEnumerator TurnPage()
    // {
    //     Debug.Log("Here");
    //     for (int x = 0; x < 7; x++)
    //     {
    //         journal.GetComponent<Image>().sprite = pagesArray[x];
    //         yield return new WaitForSeconds(fps);
    //     }
    // }

    public void DisableChildren(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i).gameObject;

            if (child != null) { child.SetActive(false); }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        journal.SetActive(false);
        // im.sprite = pages[0];
    }
}
