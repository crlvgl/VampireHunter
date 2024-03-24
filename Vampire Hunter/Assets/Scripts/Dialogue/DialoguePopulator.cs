using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopulator : MonoBehaviour
{
    [Header("Dialogue")]
    [Tooltip("The dialogue to be displayed, each string is one slide")]
    [TextArea(3, 10)]
    public string[] dialogue;
    [Tooltip("The dialogue trigger that will trigger this dialogue; MUST BE UNIQUE")]
    public string dialogueTrigger;
    private bool copied = false;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogue.Length == 0)
        {
            Debug.LogError("No dialogue to display");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!copied)
        {
            if (__staticInfoClass.dialogueTrigger == dialogueTrigger)
            {
                copied = true;
                __staticInfoClass.dialogue = dialogue;
            }
        }
    }
}
