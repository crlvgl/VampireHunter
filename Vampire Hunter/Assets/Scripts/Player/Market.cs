using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Market : MonoBehaviour
{
    [Header("Objects needed")]
    public GameObject nihil;
    public GameObject crystals;
    public Camera marketCam;
    public Camera fightCam;
    public GameObject playerPeaceful;
    public GameObject playerCombat;
    private SpriteRenderer blackScreen;
    private SpriteRenderer blackScreen2;
    public UnityEngine.Rendering.Universal.Light2D lighting;

    [Header("Variables")]
    public float waitTime = 5.0f;
    public float fadeSpeed = 0.5f;
    public float shakeDuration;
    public float shakeAmount;
    public float decay;
    private Vector3 originalCamPos1;
    private Vector3 originalCamPos2;
    private bool activeCoordinator = false;
    private bool fadeToBlack = false;
    private bool fadeFromBlack = false;
    private bool turnLightOn = false;
    public float fadeSpeedLight = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GameObject.Find("BlackScreen").gameObject.GetComponent<SpriteRenderer>();
        blackScreen2 = GameObject.Find("BlackScreen2").gameObject.GetComponent<SpriteRenderer>();
        originalCamPos1 = marketCam.transform.position;
        originalCamPos2 = fightCam.transform.position;
        __staticInfoClass.projectileScale = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeCoordinator)
        {
            activeCoordinator = true;
            StartCoroutine(ShakeCamera());
        }

        if (blackScreen.color.a < 1 && fadeToBlack)
        {
            blackScreen.color = new Color(0.0f, 0.0f, 0.0f, (blackScreen.color.a + Time.deltaTime * fadeSpeed));
        }
        if (blackScreen2.color.a > 0 && fadeFromBlack)
        {
            blackScreen2.color = new Color(0.0f, 0.0f, 0.0f, (blackScreen2.color.a - Time.deltaTime * fadeSpeed));
        }

        if (lighting.intensity < 1 && turnLightOn)
        {
            lighting.intensity += Time.deltaTime * fadeSpeedLight;
        }

        if (shakeDuration > 0)
        {
            marketCam.transform.localPosition = originalCamPos1 + Random.insideUnitSphere * shakeAmount;
            fightCam.transform.localPosition = originalCamPos2 + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decay;
        }
        else
        {
            marketCam.transform.localPosition = originalCamPos1;
            fightCam.transform.localPosition = originalCamPos2;
        }
    }

    void Shake(float duration)
    {
        shakeDuration += duration;
    }

    IEnumerator ShakeCamera()
    {
        yield return new WaitForSeconds(waitTime);
        PauseMenu.disableAllPause = true;
        PlayDialogue.disableAllDialogue = true;
        Shake(16.0f);
        yield return new WaitForSeconds(5.0f);
        fadeToBlack = true;
        yield return new WaitForSeconds(3.0f);
        lighting.intensity = 0;
        nihil.SetActive(true);
        crystals.SetActive(true);
        playerCombat.SetActive(true);
        fightCam.gameObject.SetActive(true);
        marketCam.gameObject.SetActive(false);
        playerPeaceful.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        fadeFromBlack = true;
        yield return new WaitForSeconds(1.0f);
        turnLightOn = true;
        yield return new WaitForSeconds(0.3f);
        PauseMenu.disableAllPause = false;
        PlayDialogue.disableAllDialogue = false;
    }
}
