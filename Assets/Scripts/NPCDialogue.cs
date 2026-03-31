using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : MonoBehaviour
{
    public DialogueNode[] dialogueNodes;
    private bool playerInRange = false;
    public bool dialogueStarted = false;
    InputAction digAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        digAction = InputSystem.actions.FindAction("Dig");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && dialogueStarted == false && digAction.WasPressedThisFrame())
        {
            Debug.Log("here");
            // DialogueManager.instance.StartDialogue(dialogueNodes);
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
