using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Xml.Serialization;

public class DialogueManager : MonoBehaviour
{
    InputAction _InteractAction;
    public static DialogueManager instance;

    [Header("Linked Components")]
    public TextMeshProUGUI speakerText; // formerly nameBox
    public TextMeshProUGUI dialogueText; // formerly textBox
    public GameObject dialogueGameObject;

    [Header("Text Config")]
    public float typingSpeed = 0.05f;
    public Transform optionsContainer;
    public GameObject optionButtonPrefab;

    [Header("Dialogue Status")]
    public bool isTyping = false;
    public bool dialogueFinished = true;

    // [Header("Dialogue")]

    #region PRIVATE VARIABLES
    private int currentIndex = 0;
    private Coroutine typingCoroutine;
    private bool justStarted = false;
    private Dictionary<string, DialogueNode> dialogueNodes;
    private DialogueNode currentNode;
    #endregion

    private void Awake()
    {
        _InteractAction = InputSystem.actions.FindAction("Dig");

        if (instance == null) instance = this;
        else Destroy(dialogueGameObject);
    }

    public void StartDialogue(List<DialogueNode> nodes, string startingNodeId)
    {
        dialogueNodes.Clear();
        dialogueGameObject.SetActive(true);
        dialogueFinished = false;
        foreach (var node in nodes) dialogueNodes[node.nodeID] = node;
        DisplayNode(startingNodeId);
        // dialogueLines = newNode;
        // currentIndex = 0;
        // justStarted = true;
        // typingCoroutine = StartCoroutine(TypeLine(dialogueNodes[currentIndex]));
    }

    private void DisplayNode(string nodeID)
    {
        currentNode = dialogueNodes[nodeID];
        speakerText.text = currentNode.speakerName;
        dialogueText.text = currentNode.dialogueText;

        // Clear previous choices
        foreach (Transform child in optionsContainer)
        {
            Destroy(child.gameObject);
            foreach (var option in currentNode.options)
            {
                GameObject buttonObj = Instantiate(optionButtonPrefab, optionsContainer);
                var tmpText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
                tmpText.text = option.optionText;

                buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    DisplayNode(option.targetNodeID);
                });
            }
        }
    }

    IEnumerator TypeLine(DialogueNode node)
    {
        isTyping = true;

        dialogueText.text = "";
        speakerText.text = node.speakerName;

        foreach (char c in node.dialogueText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void ShowFullLine(DialogueNode node)
    {
        dialogueText.text = node.dialogueText;
    }

    // Update is called once per frame
    void Update()
    {
        // if (_InteractAction.WasPressedThisFrame())
        // {
        //     // Debug.Log("interact");
        //     if (justStarted) { justStarted = false; return; }
        //     if (isTyping)
        //     {
        //         StopCoroutine(typingCoroutine);
        //         ShowFullLine(dialogueLines[currentIndex]);
        //         isTyping = false;
        //     }
        //     else
        //     {
        //         currentIndex++;

        //         if (currentIndex < dialogueLines.Length)
        //         {
        //             typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentIndex]));
        //         }
        //         else
        //         {
        //             textBox.text = "";
        //             nameBox.text = "";
        //             dialogueFinished = true;
        //             dialogueGameObject.SetActive(false);
        //         }
        //     }
        // }
    }

}
