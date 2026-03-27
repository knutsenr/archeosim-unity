using UnityEngine;
using System.Collections;
using UnityEngine.U2D.Animation;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public static JournalManager leftInst;

    [Header("Animation Elements")]
    public static JournalManager leftPage; // panel on left
    // public static Panel rightInst; // panel on right
    public TextMeshProUGUI titleText; // text for title
    public TextMeshProUGUI mainText; // text for contents

    [Header("Page Contents")]
    public Page[] contents;

    void Awake()
    {
        if (leftInst == null)
        {
            leftInst = this;
        }
        else
        {
            Destroy(leftPage);
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
}
