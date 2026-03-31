using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class DialogueChoice
{
    public string optionText; // what the player sees
    public string targetNodeID; // the id of the note that this leads to
}


[System.Serializable]

public class DialogueNode
{
    public string speakerName;
    [TextArea(1, 3)]
    public string dialogueText;
    public string nodeID; // next line if linear
    public List<DialogueChoice> options;
}

