using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadingScreen : MonoBehaviour
{
    [Tooltip("Path to scene to load, if empty uses __staticInfoClass.sceneToLoad")]
    public string pathToScene;
    public float waitTime = 3.0f;
    private bool isLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        if (__staticInfoClass.sceneToLoad != "none")
        {
            pathToScene = __staticInfoClass.sceneToLoad;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pathToScene != null && pathToScene != "" && isLoading == false)
        {
            isLoading = true;
            StartCoroutine(LoadScene());
            __staticInfoClass.sceneToLoad = "none";
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitTime);

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(pathToScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
