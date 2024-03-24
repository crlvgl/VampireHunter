using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayDialogue : MonoBehaviour
{
    private static Queue<string> dialogueQueue;
    private static TMP_Text dialogueText;
    public static GameObject TextBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueText = TextBox.transform.Find("DialogueText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause)
        {
            return;
        }
    }

    public static void ContinueDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        dialogueText.text = dialogueQueue.Dequeue();
    }

    static void EndDialogue()
    {
        TextBox.SetActive(false);
        dialogueText.text = "";
        Debug.Log("End of dialogue");
    }
}
