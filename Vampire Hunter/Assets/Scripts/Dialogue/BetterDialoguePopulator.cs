using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterDialoguePopulator : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogue;
    public string dialogueName;
    public Sprite sprite;
    public string dialogueTrigger;

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
        if (__staticInfoClass.singleTrigger == dialogueTrigger)
        {
            __staticInfoClass.singleDialogue = dialogue;
            __staticInfoClass.singleName = dialogueName;
            __staticInfoClass.singleSprite = sprite;
        }
    }
}
