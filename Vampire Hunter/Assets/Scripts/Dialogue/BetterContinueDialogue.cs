using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterContinueDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1"))
        {
            PlayBetterDialogue.ContinueDialogue();
        }
    }

    void OnMouseDown()
    {
        if (PauseMenu.disableAllPause)
        {
            return;
        }

        PlayBetterDialogue.ContinueDialogue();
    }
}
