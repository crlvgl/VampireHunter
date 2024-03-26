using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopulator : MonoBehaviour
{
    [Header("Dialogue")]
    [Tooltip("The dialogue to be displayed, each string is one slide")]
    [TextArea(3, 10)]
    public string[] dialogue;
    [Tooltip("The name of the Character speaking")]
    public string dialogueName;
    public Sprite Sprite;
    [Tooltip("The side of the screen the dialogue will be displayed on, 'left' or 'right'")]
    public string side;
    [Tooltip("The dialogue trigger that will trigger this dialogue; MUST BE UNIQUE")]
    public string dialogueTrigger;
    [Tooltip("Check if this is the last dialogue in the conversation, will trigger the end of the conversation")]
    public bool lastDialogue = false;
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
                if (side == "left")
                {
                    __staticInfoClass.leftDialogue = dialogue;
                    __staticInfoClass.leftDialogueName = dialogueName;
                    __staticInfoClass.leftSprite = Sprite;
                }
                else if (side == "right")
                {
                    __staticInfoClass.rightDialogue = dialogue;
                    __staticInfoClass.rightDialogueName = dialogueName;
                    __staticInfoClass.rightSprite = Sprite;
                }
                __staticInfoClass.lastDialogue = lastDialogue;
            }
        }
    }
}
