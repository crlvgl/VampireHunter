using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayDialogue : MonoBehaviour
{
    private static string[] leftDialogue;
    private static string[] rightDialogue;
    private static TMP_Text dialogueText;
    private static Queue<string> dialogueQueue;
    public static GameObject TextBox;
    private static TMP_Text leftName;
    private static TMP_Text rightName;
    private static SpriteRenderer leftPortrait;
    private static SpriteRenderer rightPortrait;
    public static bool disableAllDialogue = false;
    private static string side = "left";
    [Tooltip("List with all dialogue triggers that will trigger DialoguePopulator; must be same length as triggerListLengths; !! MUST BE UNIQUE !!")]
    public string[] triggerListNames;
    private Queue<string> triggerListNamesQueue;
    [Tooltip("List with all dialogue trigger lengths that will trigger DialoguePopulator; must be same length as triggerListNames")]
    public int[] triggerListLengths;
    private Queue<int> triggerListLengthsQueue;
    public static List<(string triggerName, int triggerLength)> triggerList;
    private static Queue<string> dialogueTriggerQueue;
    private static int triggerStage = 0;
    private static string currentTrigger;
    private static int tempTriggerStage = 1;
    public Color vampireColorTemp = new Color(255, 128, 128, 255);
    private static Color vampireColor;
    public Color humanColorTemp = new Color(98, 160, 240, 255);
    private static Color humanColor;
    public Color fangsColorTemp = new Color(196, 128, 255, 255);
    private static Color fangsColor;

    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<string>();
        triggerListNamesQueue = new Queue<string>();
        triggerListLengthsQueue = new Queue<int>();
        dialogueTriggerQueue = new Queue<string>();

        vampireColor = vampireColorTemp;
        humanColor = humanColorTemp;
        fangsColor = fangsColorTemp;

        TextBox = this.transform.Find("Main Camera").gameObject.transform.Find("TextBox").gameObject;
        dialogueText = TextBox.transform.Find("Canvas").gameObject.transform.Find("TextBoxText").GetComponent<TMP_Text>();
        leftName = TextBox.transform.Find("NameLeft").gameObject.transform.Find("Canvas").gameObject.transform.Find("NameText").GetComponent<TMP_Text>();
        rightName = TextBox.transform.Find("NameRight").gameObject.transform.Find("Canvas").gameObject.transform.Find("NameText").GetComponent<TMP_Text>();
        leftPortrait = TextBox.transform.Find("PortraitLeft").gameObject.GetComponent<SpriteRenderer>();
        rightPortrait = TextBox.transform.Find("PortraitRight").gameObject.GetComponent<SpriteRenderer>();

        foreach (string temp in triggerListNames)
        {
            triggerListNamesQueue.Enqueue(temp);
        }
        foreach (int temp in triggerListLengths)
        {
            triggerListLengthsQueue.Enqueue(temp);
        }
        for (int i = 0; i < triggerListNames.Length; i++)
        {
            triggerList.Add((triggerListNamesQueue.Dequeue(), triggerListLengthsQueue.Dequeue()));
        }
        foreach ((string triggerName, int triggerLength) in triggerList)
        {
            dialogueTriggerQueue.Enqueue(triggerName);
        }

        SetTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause)
        {
            return;
        }
    }

    static void SetTrigger()
    {
        if (dialogueTriggerQueue.Count == 0)
        {
            return;
        }

        if (triggerStage == 0)
        {
            currentTrigger = dialogueTriggerQueue.Dequeue();
        
            foreach ((string triggerName, int triggerLength) in triggerList)
            {
                if (triggerName == currentTrigger)
                {
                    triggerStage = triggerLength;
                    break;
                }
            }

            BuildTrigger();
        }

        BuildTrigger();
    }

    static void BuildTrigger()
    {
        if (tempTriggerStage <= triggerStage)
        {
            __staticInfoClass.dialogueTrigger = currentTrigger + tempTriggerStage.ToString();
            tempTriggerStage++;
        }
        else
        {
            tempTriggerStage = 1;
            triggerStage = 0;
        }
    }

    // Triggered by other Dialogues, starts entire Dialogue sequence
    static void InitiateDialogue()
    {
        disableAllDialogue = true;
        TextBox.SetActive(true);

        leftPortrait.sprite = __staticInfoClass.leftSprite;
        rightPortrait.sprite = __staticInfoClass.rightSprite;
        
        leftName.text = __staticInfoClass.leftDialogueName;
        if (__staticInfoClass.leftDialogueName == "Fangs")
        {
            leftName.color = fangsColor;
        }
        else if (__staticInfoClass.leftDialogueName == "Corvus" || __staticInfoClass.leftDialogueName == "Nihil")
        {
            leftName.color = humanColor;
        }
        else if (__staticInfoClass.leftDialogueName == "Miresu")
        {
            leftName.color = vampireColor;
        }

        rightName.text = __staticInfoClass.rightDialogueName;
        if (__staticInfoClass.rightDialogueName == "Fangs")
        {
            rightName.color = fangsColor;
        }
        else if (__staticInfoClass.rightDialogueName == "Corvus" || __staticInfoClass.rightDialogueName == "Nihil")
        {
            rightName.color = humanColor;
        }
        else if (__staticInfoClass.rightDialogueName == "Miresu")
        {
            rightName.color = vampireColor;
        }

        StartTalking();
    }

    static void StartTalking()
    {
        dialogueQueue.Clear();

        if (side == "left")
        {
            foreach (string talk in leftDialogue)
            {
                dialogueQueue.Enqueue(talk);
            }

            leftName.text = __staticInfoClass.leftDialogueName;
            if (__staticInfoClass.leftDialogueName == "Fangs")
            {
                leftName.color = new Color(196, 128, 255, 255);
            }
            else if (__staticInfoClass.leftDialogueName == "Corvus" || __staticInfoClass.leftDialogueName == "Nihil")
            {
                leftName.color = new Color(98, 160, 240, 255);
            }
            else if (__staticInfoClass.leftDialogueName == "Miresu")
            {
                leftName.color = new Color(255, 128, 128, 255);
            }

            leftPortrait.sprite = __staticInfoClass.leftSprite;
            rightPortrait.color = new Color(128, 128, 128, 255);
            rightName.color = new Color(rightName.color.r, rightName.color.g, rightName.color.b, 0.2f);

            side = "right";
        }
        else if (side == "right")
        {
            foreach (string talk in rightDialogue)
            {
                dialogueQueue.Enqueue(talk);
            }

            rightName.text = __staticInfoClass.rightDialogueName;
            if (__staticInfoClass.rightDialogueName == "Fangs")
            {
                rightName.color = new Color(196, 128, 255, 255);
            }
            else if (__staticInfoClass.rightDialogueName == "Corvus" || __staticInfoClass.rightDialogueName == "Nihil")
            {
                rightName.color = new Color(98, 160, 240, 255);
            }
            else if (__staticInfoClass.rightDialogueName == "Miresu")
            {
                rightName.color = new Color(255, 128, 128, 255);
            }
            
            rightPortrait.sprite = __staticInfoClass.rightSprite;
            leftPortrait.color = new Color(128, 128, 128, 255);
            leftName.color = new Color(leftName.color.r, leftName.color.g, leftName.color.b, 0.2f);

            side = "left";
        }
        
        ContinueDialogue();
    }

    public static void ContinueDialogue()
    {
        if (dialogueQueue.Count == 0 && __staticInfoClass.lastDialogue)
        {
            EndDialogue();
            return;
        }
        else if (dialogueQueue.Count == 0)
        {
            ChangeSide();
            return;
        }
        dialogueText.text = dialogueQueue.Dequeue();
    }

    static void EndDialogue()
    {
        TextBox.SetActive(false);
        dialogueText.text = "";
        side = "left";
        SetTrigger();
        disableAllDialogue = false;
        Debug.Log("End of dialogue");
    }

    static void ChangeSide()
    {
        StartTalking();
        SetTrigger();
    }
}
