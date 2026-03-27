using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    InputAction _InteractAction;
    public static DialogueManager instance;

    [Header("Linked Components")]
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox;
    public GameObject dialogueGameObject;

    [Header("Text Config")]
    public float typingSpeed = 0.05f;

    [Header("Dialogue Status")]
    public bool isTyping = false;
    public bool dialogueFinished = true;

    [Header("Dialogue")]
    public DialogueLine[] dialogueLines;

    #region PRIVATE VARIABLES
    private int currentIndex = 0;
    private Coroutine typingCoroutine;
    private bool justStarted = false;
    #endregion

    private void Awake()
    {
        _InteractAction = InputSystem.actions.FindAction("Dig");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(dialogueGameObject);
        }
    }

    public void StartDialogue(DialogueLine[] newLines)
    {
        dialogueGameObject.SetActive(true);
        dialogueFinished = false;
        dialogueLines = newLines;
        currentIndex = 0;
        justStarted = true;
        typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentIndex]));
    }

    IEnumerator TypeLine(DialogueLine line)
    {
        isTyping = true;

        textBox.text = "";
        nameBox.text = line.speakerName;

        foreach (char c in line.dialogueText)
        {
            textBox.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void ShowFullLine(DialogueLine line)
    {
        textBox.text = line.dialogueText;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_InteractAction.WasPressedThisFrame())
        {
            // Debug.Log("interact");
            if (justStarted) { justStarted = false; return; }
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                ShowFullLine(dialogueLines[currentIndex]);
                isTyping = false;
            }
            else
            {
                currentIndex++;

                if (currentIndex < dialogueLines.Length)
                {
                    typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentIndex]));
                }
                else
                {
                    textBox.text = "";
                    nameBox.text = "";
                    dialogueFinished = true;
                    dialogueGameObject.SetActive(false);
                }
            }
        }
    }

}
