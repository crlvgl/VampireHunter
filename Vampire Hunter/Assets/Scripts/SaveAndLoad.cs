using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveLoadExitButton.saveGame == true)
        {
            SaveGame();
            SaveLoadExitButton.saveGame = false;
        }
        else if (SaveLoadExitButton.loadGame == true)
        {
            LoadGame();
            SaveLoadExitButton.loadGame = false;
        }
    }

    private void LoadGame()
    {
        // you still gotta implenent this
        // need to look what you need
    }

    private void SaveGame()
    {
        PlayerPrefs.SetString("openScene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        // you still gotta implenent this
        // need to look what you need
        // will be the same as above
    }
}
