using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public string pathToScene;
    public float timeToLoad = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause == true || PlayDialogue.disableAllDialogue == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1"))
        {
            if (pathToScene != null && pathToScene != "" && UnityEngine.SceneManagement.SceneManager.loadedSceneCount == 1)
            {
                PlayerPrefs.SetString("openScene", pathToScene);
                StartCoroutine(LoadSceneAsync());
            }
        }
    }

    IEnumerator LoadSceneAsync()
    {
        __staticInfoClass.sceneToLoad = pathToScene;
        __staticInfoClass.timeToLoad = timeToLoad;

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Assets/Scenes/UI/LoadingScreen.unity");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
