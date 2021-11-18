using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script guardas las líneas de dialogo que dice el Npc

// Es utilizado en el script DialogueTrigger.cs donde se escribe desde el inspector lo que va a decir el npc

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}
