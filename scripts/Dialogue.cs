using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//SentenceCount
public class Dialogue
{

    [TextArea(3,10)]

    public string[] sentences;
    public string name;
}
