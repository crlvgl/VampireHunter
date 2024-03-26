using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueDialogue : MonoBehaviour
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
            PlayDialogue.ContinueDialogue();
        }
    }

    void OnMouseDown()
    {
        if (PauseMenu.disableAllPause)
        {
            return;
        }
        
        PlayDialogue.ContinueDialogue();
    }
}
