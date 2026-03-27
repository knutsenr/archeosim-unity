using UnityEngine;

[System.Serializable]

public class Page
{
    public string title;
    [TextArea(1, 3)]
    public string pageText;
}
