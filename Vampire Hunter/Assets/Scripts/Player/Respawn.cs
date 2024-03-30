using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static bool respawn = false;
    public GameObject respawnScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Marketplace")
        {
            respawnScreen = GameObject.Find("FightCamera").gameObject.transform.Find("RespawnScreen").gameObject;
        }
        else
        {
            respawnScreen = GameObject.Find("Main Camera").gameObject.transform.Find("RespawnScreen").gameObject;
            respawnScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            respawnScreen.SetActive(true);
        }
    }
}
