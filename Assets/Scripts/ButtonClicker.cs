// using UnityEngine;
// using System.Collections;
// using UnityEngine.U2D.Animation;
// using System.Linq;
// using UnityEngine.UI;

// public class ButtonClicker : MonoBehaviour
// {
//     // [Header("Journal Elements")]
//     [SerializeField] private GameManager manager;

//     [Header("Pages Elements")]
//     [SerializeField] private GameObject allPages; // all pages to fade out 
//     [SerializeField] private GameObject targetField; // specific field
//     private float duration = 2f;
//     private bool faded = false;

//     [Header("Animation Elements")]
//     [SerializeField] private GameObject journal;
//     [SerializeField] private float fps = 0.02f;
//     // [SerializeField] private Sprite[] pagesArray;


//     // [SerializeField] private Button currentButton;


//     void Awake()
//     {
//         // im = GetComponent<Image>();
//         // rend.sprite = pagesLibrary.GetSprite("pages", "pageAnim_0");
//     }

//     // public void MakeVisible(GameObject obj)
//     // {
//     //     if (obj.activeInHierarchy == false) { obj.SetActive(true); }
//     //     else { obj.SetActive(false); }
//     //     Debug.Log("Button clicked " + obj.activeInHierarchy);
//     //     // Renderer red = targetObject.GetComponent<Renderer>();
//     //     // rend.material.color = Rnadom.ColorHSV();
//     // }

//     // public void PressTurnPage()
//     // {
//     //     StartCoroutine(manager.TurnPage());

//     //     // fade out page
//     //     var canvasGroup = allPages.GetComponent<CanvasGroup>();
//     //     StartCoroutine(FadeOut(canvasGroup, canvasGroup.alpha, 0));
//     //     faded = !faded;

//     //     Debug.Log("turn");

//     //     // bring new page up
//     //     StartCoroutine(FadeIn(canvasGroup, canvasGroup.alpha, 1));
//     //     // faded = !faded;
//     // }

//     // public IEnumerator FadeOut(CanvasGroup canvasGroup, float start, float end)
//     // {
//     //     float counter = 0f;

//     //     while (counter < duration)
//     //     {
//     //         counter += Time.deltaTime;
//     //         canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);

//     //         yield return null;
//     //     }
//     // }

//     // public IEnumerator FadeIn(CanvasGroup canvasGroup, float start, float end)
//     // {
//     //     targetField.SetActive(true);

//     //     float counter = 0f;

//     //     while (counter < 3) { counter += Time.deltaTime; }

//     //     counter = 0;

//     //     while (counter < duration)
//     //     {
//     //         counter += Time.deltaTime;
//     //         canvasGroup.alpha = Mathf.Lerp(0, 1, counter / duration);

//     //         yield return null;
//     //     }
//     // }


//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         // DisableChildren(allPages);
//         // im.sprite = pages[0];
//     }
// }
