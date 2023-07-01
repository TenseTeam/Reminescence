using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public Monologue[] DialogueParts;
}

[System.Serializable]
public class Monologue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
