using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class NPCDialogue : MonoBehaviour
{
    public List<DialogueNode> dialogueNodes;
    private bool playerInRange = false;
    public bool dialogueStarted = false;
    InputAction dialogueAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dialogueAction = InputSystem.actions.FindAction("Dialogue");
    }

    void Start()
    {
        //         List<DialogueNode> nodes = new List<DialogueNode>
        //         {
        //             new() // formerly nodes.Add(new DialogueNode
        //             {
        //                 nodeID = "start",
        //                 speakerName = "Me",
        //                 dialogueText = "Testing",
        //                 options = new List<DialogueChoice>
        // {
        //     new() { optionText = "option 1", targetNodeID = "response1"}, // formerly new DialogueChoice . . . 
        //     new() { optionText = "opt 2", targetNodeID = "response2"}
        // }
        //             },
        //             new()
        //             {
        //                 nodeID = "response1",
        //                 speakerName = "Professor",
        //                 dialogueText = "bye 1",
        //                 options = new List<DialogueChoice>()
        //             },
        //             new() {
        //                 nodeID = "response2",
        //                 speakerName = "Professor",
        //                 dialogueText = "bye bye 2",
        //                 options = new List<DialogueChoice>()
        //             }
        //         };

        // Object.FindFirstObjectByType<DialogueManager>().StartDialogue(nodes, "start");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && dialogueStarted == false && dialogueAction.WasPressedThisFrame())
        {
            Debug.Log("here");
            DialogueManager.instance.StartDialogue(dialogueNodes, "p1");

            dialogueStarted = true;
        }
        if (dialogueStarted && DialogueManager.instance.dialogueFinished == true)
        {
            dialogueStarted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
