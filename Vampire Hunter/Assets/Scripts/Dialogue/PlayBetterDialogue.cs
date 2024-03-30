using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayBetterDialogue : MonoBehaviour
{
    private static string[] dialogue;
    private static TMP_Text dialogueText;
    private static Queue<string> dialogueQueue;
    public static GameObject TextBox;
    private static TMP_Text dialogueName;
    private static SpriteRenderer portrait;
    public string[] triggerList;
    private static Queue<string> triggerQueue;
    public Color vampireColorTemp = new Color(255, 128, 128, 255);
    public Color humanColorTemp = new Color(98, 160, 240, 255);
    public Color fangsColorTemp = new Color(196, 128, 255, 255);
    public static bool enableDialogueSingle = false;
    private static bool firstTimeEntered = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<string>();
        triggerQueue = new Queue<string>();
        
        TextBox = GameObject.Find("Main Camera").gameObject.transform.Find("BetterTextBox").gameObject;
        dialogueText = TextBox.transform.Find("Canvas").gameObject.transform.Find("TextBoxText").GetComponent<TMP_Text>();
        dialogueName = TextBox.transform.Find("NameLeft").gameObject.transform.Find("Canvas").gameObject.transform.Find("NameText").GetComponent<TMP_Text>();
        portrait = TextBox.transform.Find("PortraitLeft").gameObject.GetComponent<SpriteRenderer>();

        foreach (string temp in triggerList)
        {
            triggerQueue.Enqueue(temp);
        }

        InitiateDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableDialogueSingle)
        {
            enableDialogueSingle = false;
            StartTalking();
        }
    }

    static void InitiateDialogue()
    {
        __staticInfoClass.singleTrigger = triggerQueue.Dequeue();
    }

    static void StartTalking()
    {
        if (!TextBox.activeSelf)
        {
            PlayDialogue.disableAllDialogue = true;
            TextBox.SetActive(true);
        }

        dialogueQueue.Clear();

        dialogue = __staticInfoClass.singleDialogue;

        foreach (string talk in dialogue)
        {
            dialogueQueue.Enqueue(talk);
        }

        dialogueName.text = __staticInfoClass.singleName;

        if (__staticInfoClass.singleName == "Fangs")
        {
            dialogueName.color = new Color(196, 128, 255, 255);
        }
        else if (__staticInfoClass.singleName == "Corvus" || __staticInfoClass.singleName == "Nihil")
        {
            dialogueName.color = new Color(98, 160, 240, 255);
        }
        else if (__staticInfoClass.singleName == "Miresu")
        {
            dialogueName.color = new Color(255, 128, 128, 255);
        }

        portrait.sprite = __staticInfoClass.singleSprite;

        ContinueDialogue();

        InitiateDialogue();
    }

    public static void ContinueDialogue()
    {
        if (triggerQueue.Count == 0 && dialogueQueue.Count == 0)
        {
            ContinuelastTime();
            return;
        }
        if (dialogueQueue.Count == 0)
        {
            StartTalking();
            return;
        }

        dialogueText.text = dialogueQueue.Dequeue();
    }

    static void ContinuelastTime()
    {
        if (firstTimeEntered)
        {
            firstTimeEntered = false;
            StartTalkingLastTime();
            return;
        }
        if (dialogueQueue.Count == 0)
        {
            TextBox.SetActive(false);
            dialogueText.text = "";
            PlayDialogue.disableAllDialogue = false;
            firstTimeEntered = true;
            return;
        }

        dialogueText.text = dialogueQueue.Dequeue();
    }

    static void StartTalkingLastTime()
    {
        if (!TextBox.activeSelf)
        {
            PlayDialogue.disableAllDialogue = true;
            TextBox.SetActive(true);
        }

        dialogueQueue.Clear();

        dialogue = __staticInfoClass.singleDialogue;

        foreach (string talk in dialogue)
        {
            dialogueQueue.Enqueue(talk);
        }

        dialogueName.text = __staticInfoClass.singleName;

        if (__staticInfoClass.singleName == "Fangs")
        {
            dialogueName.color = new Color(196, 128, 255, 255);
        }
        else if (__staticInfoClass.singleName == "Corvus" || __staticInfoClass.singleName == "Nihil")
        {
            dialogueName.color = new Color(98, 160, 240, 255);
        }
        else if (__staticInfoClass.singleName == "Miresu")
        {
            dialogueName.color = new Color(255, 128, 128, 255);
        }

        portrait.sprite = __staticInfoClass.singleSprite;

        ContinueDialogue();
    }
}
