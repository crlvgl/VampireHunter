using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public string pathToScene;

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
            StartCoroutine(LoadGame());
            SaveLoadExitButton.loadGame = false;
        }
    }

    private IEnumerator LoadGame()
    {
        Debug.Log("Loading Game");
        __staticInfoClass.timeToLoad = 3f;
        __staticInfoClass.sceneToLoad = PlayerPrefs.GetString("openScene");

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(pathToScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        // you still gotta implenent this
        // need to look what you need
    }

    private void SaveGame()
    {
        Debug.Log("Saving Game");
        
        PlayerPrefs.SetString("openScene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().path);
        // you still gotta implenent this
        // need to look what you need
        // will be the same as above
    }
}
