using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nihil : MonoBehaviour
{
    private SpriteRenderer whiteScreen;
    public GameObject deathScreen;

    public static int health = 1000;
    public float fadeSpeed = 1.0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        whiteScreen = GameObject.Find("WhiteScreen").gameObject.GetComponent<SpriteRenderer>();
        deathScreen = GameObject.Find("DeathScreen").gameObject;
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            PauseMenu.disableAllPause = true;
            PlayDialogue.disableAllDialogue = true;
            FadeToWhite();
        }
    }

    void FadeToWhite()
    {
        if (whiteScreen.color.a < 1.0f)
        {
            whiteScreen.color = new Color(1.0f, 1.0f, 1.0f, (whiteScreen.color.a + Time.deltaTime * fadeSpeed));
        }
        else if (whiteScreen.color.a >= 1.0f)
        {
            Debug.Log("works");
            deathScreen.SetActive(true);
            Destroy(player);
            Destroy(this.gameObject);
        }
    }
}
