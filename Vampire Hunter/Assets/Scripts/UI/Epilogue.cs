using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epilogue : MonoBehaviour
{
    public Camera epilogueCamera;
    public Camera fightCamera;
    private SpriteRenderer whiteScreen;

    private bool hasStarted = false;
    private bool hasStarted2 = false;
    private bool fadeFromWhite;
    public float fadeSpeed = 0.5f;
    private bool moveCamera;
    public float camSpeed;
    public float deadZone;
    public float waitTime = 5f;
    public string pathToScene;

    // Start is called before the first frame update
    void Start()
    {
        whiteScreen = GameObject.Find("WhiteScreenEpilogue").gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (__staticInfoClass.epilogue && !hasStarted)
        {
            hasStarted = true;
            StartCoroutine(EndGame());
        }

        if (whiteScreen.color.a > 0 && fadeFromWhite)
        {
            whiteScreen.color = new Color(1.0f, 1.0f, 1.0f, (whiteScreen.color.a - Time.deltaTime * fadeSpeed));
        }

        if (moveCamera && epilogueCamera.gameObject.transform.position.y > deadZone)
        {
            epilogueCamera.gameObject.transform.position += new Vector3(0f, -camSpeed * Time.deltaTime, 0f);
        }
        else if (moveCamera && epilogueCamera.gameObject.transform.position.y <= deadZone && !hasStarted2)
        {
            StartCoroutine(backToMainMenu());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(8.047f);
        fightCamera.gameObject.SetActive(false);
        epilogueCamera.gameObject.SetActive(true);
        fadeFromWhite = true;
        yield return new WaitForSeconds(5.0f);
        moveCamera = true;
    }

    IEnumerator backToMainMenu()
    {
        yield return new WaitForSeconds(waitTime);

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(pathToScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
